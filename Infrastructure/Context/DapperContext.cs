using System.Data;
using Npgsql;
using Microsoft.Extensions.Configuration;
public class DapperContext
{
    IConfiguration configuration;
    public DapperContext( IConfiguration configuration)
    {
        this.configuration=configuration;
    }
    public IDbConnection CreateConnection(){
        return new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection"));
    }
}