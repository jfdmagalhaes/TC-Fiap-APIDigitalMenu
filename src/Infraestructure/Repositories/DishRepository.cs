using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.EntityFramework.Context;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Infraestructure.Repositories;

public class DishRepository : IDishRepository
{
    private readonly IDishDbContext _context;
    private readonly IConfiguration _configuration;
    public IUnitOfWork UnitOfWork => _context;

    public DishRepository(IDishDbContext context, IConfiguration configuration)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }

    public string GetConnection()
    {
        return _configuration.GetSection("ConnectionStrings").GetSection("AppConnection").Value!;
    }

    public int AddDish(DishEntity dishRegister)
    {
        //var connection = GetConnection();
        //using (var cn = new SqlConnection(connection))
        //{

        //}

        _context.Dishes.Add(dishRegister);

        var teste = dishRegister;
        throw new NotImplementedException();
    }

    private bool disposedValue = false;


    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            disposedValue = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);

        GC.SuppressFinalize(this);

    }
}