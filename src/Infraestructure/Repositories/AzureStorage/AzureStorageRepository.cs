using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Domain.Dto;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;


namespace Infraestructure.Repositories.AzureStorage;
public class AzureStorageRepository : IAzureStorageRepository
{
    private readonly string _storageConnectionString;
    private readonly string _storageContainerName;
    private readonly ILogger<AzureStorageRepository> _logger;

    public AzureStorageRepository(IConfiguration configuration, ILogger<AzureStorageRepository> logger)
    {
        _storageConnectionString = configuration.GetSection("BlobConnectionString").Value ?? throw new ArgumentNullException(nameof(configuration));
        _storageContainerName = configuration.GetSection("BlobContainerName").Value ?? throw new ArgumentNullException(nameof(configuration));
        _logger = logger;
    }

    public Task<BlobResponseDto> DeleteAsync(string blobFilename)
    {
        throw new NotImplementedException();
    }

    public async Task<BlobDto> DownloadAsync(string blobFilename)
    {
        // Get a reference to a container named in appsettings.json
        BlobContainerClient client = new BlobContainerClient(_storageConnectionString, _storageContainerName);

        try
        {
            // Get a reference to the blob uploaded earlier from the API in the container from configuration settings
            BlobClient file = client.GetBlobClient(blobFilename);

            // Check if the file exists in the container
            if (await file.ExistsAsync())
            {
                var data = await file.OpenReadAsync();
                Stream blobContent = data;

                // Download the file details async
                var content = await file.DownloadContentAsync();

                // Add data to variables in order to return a BlobDto
                string name = blobFilename;
                string contentType = content.Value.Details.ContentType;
                string uri = file.Uri.AbsoluteUri;

                // Create new BlobDto with blob data from variables
                return new BlobDto { Content = blobContent, FileName = name, ContentType = contentType, Uri = uri };
            }
        }
        catch (RequestFailedException ex)
            when (ex.ErrorCode == BlobErrorCode.BlobNotFound)
        {
            // Log error to console
            _logger.LogError($"File {blobFilename} was not found.");
        }

        // File does not exist, return null and handle that in requesting method
        return null;
    }

    public Task<List<BlobDto>> ListAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<BlobResponseDto> UploadAsync(IFormFile blob)
    {
        // Create new upload response object that we can return to the requesting method
        BlobResponseDto response = new();

        // Get a reference to a container named in appsettings.json and then create it
        BlobContainerClient container = new BlobContainerClient(_storageConnectionString, _storageContainerName);
        //await container.CreateAsync();
        try
        {
            // Get a reference to the blob just uploaded from the API in a container from configuration settings
            BlobClient client = container.GetBlobClient(blob.FileName);

            // Open a stream for the file we want to upload
            await using (Stream? data = blob.OpenReadStream())
            {
                // Upload the file async
                await client.UploadAsync(data);
            }

            // Everything is OK and file got uploaded
            response.Status = $"File {blob.FileName} Uploaded Successfully";
            response.Error = false;
            response.Blob.Uri = client.Uri.AbsoluteUri;
            response.Blob.FileName = blob.FileName;

        }
        // If the file already exists, we catch the exception and do not upload it
        catch (RequestFailedException ex)
           when (ex.ErrorCode == BlobErrorCode.BlobAlreadyExists)
        {
            _logger.LogError($"File with name {blob.FileName} already exists in container. Set another name to store the file in the container: '{_storageContainerName}.'");
            response.Status = $"File with name {blob.FileName} already exists. Please use another name to store your file.";
            response.Error = true;
            response.Blob.FileName = blob.FileName;
            return response;
        }
        // If we get an unexpected error, we catch it here and return the error message
        catch (RequestFailedException ex)
        {
            // Log error to console and create a new response we can return to the requesting method
            _logger.LogError($"Unhandled Exception. ID: {ex.StackTrace} - Message: {ex.Message}");
            response.Status = $"Unexpected error: {ex.StackTrace}. Check log with StackTrace ID.";
            response.Error = true;
            return response;
        }

        // Return the BlobUploadResponse object
        return response;
    }
}