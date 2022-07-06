using Npgsql;

namespace PersonApp.Repositories;

public class PersonRepository: IPersonRepository
{
    private readonly IConfiguration _configuration;

    public PersonRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    private string GetConnectionString()
    {
        return _configuration.GetSection("ConnectionStrings")
            .GetValue<string>("DefaultConnection");
    }

    public long GetAllCount()
    {
        const string query = "select count(p.*) from PERSONS p";
        using var connection = new NpgsqlConnection(GetConnectionString());
        var command = new NpgsqlCommand(query, connection);
        connection.Open();
        var reader = command.ExecuteReader();
        reader.Read();
        var res = reader.GetInt64(0);
        reader.Close();
        return res;
    }
}
