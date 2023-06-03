using Microsoft.Extensions.DependencyInjection;
using Web.ServiceClients;

namespace Web;

public class Startup
{
    private IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {

        var serviceClient = "https://localhost:7061";

        services.AddHttpClient<DishesServiceClient>(client =>
        {
            client.BaseAddress = new Uri(serviceClient);
            client.DefaultRequestHeaders.Accept.Clear();

            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        });

        services.AddScoped<IDishesServiceClient, DishesServiceClient>();
        services.AddRazorPages();

        //services.AddMvc().AddRazorPagesOptions(opt => opt.Conventions.AddPageRoute("/Pages2/Home", ""));
    }

    public void Configure(WebApplication app, IWebHostEnvironment env)
    {
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();
        app.MapRazorPages();
        
        app.Run();
    }
}
