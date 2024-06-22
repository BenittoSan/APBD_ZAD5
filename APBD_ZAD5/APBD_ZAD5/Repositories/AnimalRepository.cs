using System.Data.SqlClient;
using APBD_ZAD5.DTOs.Request;
using APBD_ZAD5.Models;

namespace APBD_ZAD5.Repositories;

public class AnimalRepository : IAnimalRepository
{

    private IConfiguration _configuration;

    public AnimalRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public IEnumerable<Animal> getAnimals(string orderCol)
    {
        var validColumns = new HashSet<String> { "Name", "Description", "Category", "Area" };

        if (!validColumns.Contains(orderCol))
        {
            orderCol = "Name";
        }
        
        using var con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
         con.Open();

        using var cmd = new SqlCommand();
        cmd.Connection = con;
        
        cmd.CommandText = $"SELECT Id,Name,Description,Category,Area FROM ANIMALS ORDER BY {orderCol}";
        
        var dr =  cmd.ExecuteReader();
        var animals = new List<Animal>();

        while (  dr.Read() )
        {
            var animal = new Animal
            {
                IdAnimal = (int)dr["Id"],
                Name = dr["Name"].ToString(),
                Description = dr["Description"].ToString(),
                Category = dr["Category"].ToString(),
                Area = dr["Area"].ToString()

            };
            animals.Add(animal);
        }

        return animals;
        
    }

   

    public int CreateAnimal(CreateAnimalDTO animal)
    {
        using var con = new SqlConnection("data source=SpaceShip;initial catalog=APBD;trusted_connection=true");
        con.Open();

        using var cmd = new SqlCommand();
        cmd.Connection = con;

        
        cmd.CommandText =
            "Insert into Animals (Name, Description, Category, Area) values (@Name,@Description,@Category,@Area)";
        cmd.Parameters.AddWithValue("@Name", animal.Name);
        cmd.Parameters.AddWithValue("@Description", animal.Description);
        cmd.Parameters.AddWithValue("@Category", animal.Category);
        cmd.Parameters.AddWithValue("@Area", animal.Area);

        var affectedCount = cmd.ExecuteNonQuery();
        return affectedCount;
    }

    public int DeleteAnimal(int id)
    {
        using var con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        
        con.Open();

        using var cmd = new SqlCommand();
        cmd.Connection = con;

        cmd.CommandText =
            "DELETE FROM Animals WHERE Id = @Id";
        cmd.Parameters.AddWithValue("@Id", id);
        

        var affectedCount = cmd.ExecuteNonQuery();
        return affectedCount;
    }

    public int UpdateAnimal(UpdateAnimalDTO animal, int id)
    {
        using var con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        con.Open();

        using var cmd = new SqlCommand();
        cmd.Connection = con;

        cmd.CommandText =
            "UPDATE ANIMALS SET Name=@Name,Description=@Desctription,Category=@Category,Area=@Area WHERE Id= @IdAnimal";
        cmd.Parameters.AddWithValue("@IdAnimal",id);
        cmd.Parameters.AddWithValue("@Name", animal.Name);
        cmd.Parameters.AddWithValue("@Desctription", animal.Description);
        cmd.Parameters.AddWithValue("@Category", animal.Category);
        cmd.Parameters.AddWithValue("@Area", animal.Area);

        var affectedCount = cmd.ExecuteNonQuery();
        return affectedCount;
    }
}