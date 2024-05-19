using System.Data.SqlClient;
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
        bool isColumnName;
        if ((orderCol.Equals("name") || orderCol.Equals("description") || orderCol.Equals("category") ||
             orderCol.Equals("area ")) == true) isColumnName = true;
        else
        {
            isColumnName = false;
            orderCol = "name";
        }

        using var con = new SqlConnection(_configuration["ConnectionString:DefaultConnection"]);
         con.Open();

        using var cmd = new SqlCommand();
        cmd.Connection = con;


        cmd.CommandText = "SELECT Id,Name,Description,Category,Area FROM ANIMAL ORDER BY @orderCol";
        cmd.Parameters.AddWithValue("@orderCol", orderCol);
        

        var dr =  cmd.ExecuteReader();
        var animals = new List<Animal>();

        while (  dr.Read() )
        {
            var animal = new Animal
            {
                IdAnimal = (int)dr["IdAnimal"],
                Name = dr["Name"].ToString(),
                Description = dr["Description"].ToString(),
                Category = dr["Category"].ToString(),
                Area = dr["Area"].ToString()

            };
            animals.Add(animal);

        }

        return animals;
        
    }

   

    public int CreateAnimal(Animal animal)
    {
        using var con = new SqlConnection(_configuration["ConnectionString:DefaultConnection"]);
        con.Open();

        using var cmd = new SqlCommand();
        cmd.Connection = con;

        cmd.CommandText =
            "Insert into Animals (Name, Description, Category, Area) values ('@Name','@Description','@Category','@Area')";
        cmd.Parameters.AddWithValue("@Name", animal.Name);
        cmd.Parameters.AddWithValue("@Description", animal.Description);
        cmd.Parameters.AddWithValue("@Category", animal.Category);
        cmd.Parameters.AddWithValue("@Area", animal.Area);

        var affectedCount = cmd.ExecuteNonQuery();
        return affectedCount;
    }

    public int DeleteAnimal(int id)
    {
        using var con = new SqlConnection(_configuration["ConnectionString:DefaultConnection"]);
        con.Open();

        using var cmd = new SqlCommand();
        cmd.Connection = con;

        cmd.CommandText =
            "DELETE FROM Aniaml WHERE Id = @IdAniaml";
        cmd.Parameters.AddWithValue("@IdAnimal", id);

        var affectedCount = cmd.ExecuteNonQuery();
        return affectedCount;
    }

    public int UpdateAnimal(Animal animal)
    {
        using var con = new SqlConnection(_configuration["ConnectionString:DefaultConnection"]);
        con.Open();

        using var cmd = new SqlCommand();
        cmd.Connection = con;

        cmd.CommandText =
            "UPDATE ANIMAL SET Name=@Name,Description=@Desctription,Category=@Category,Area=@Area WHERE Id=@IdAnimal";
        cmd.Parameters.AddWithValue("@IdAniaml", animal.IdAnimal);
        cmd.Parameters.AddWithValue("@Name", animal.Name);
        cmd.Parameters.AddWithValue("@Description", animal.Description);
        cmd.Parameters.AddWithValue("@Category", animal.Category);
        cmd.Parameters.AddWithValue("@Area", animal.Area);

        var affectedCount = cmd.ExecuteNonQuery();
        return affectedCount;
    }
}