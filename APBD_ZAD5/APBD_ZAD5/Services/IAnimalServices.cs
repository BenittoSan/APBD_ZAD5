using APBD_ZAD5.DTOs.Request;
using APBD_ZAD5.DTOs.Response;
using APBD_ZAD5.Models;

namespace APBD_ZAD5.Services;

public interface IAnimalServices
{
    IEnumerable<GetAnimalsDTO> GetAnimals(string orderBy);
    public int DeleteAnimal(int id);
    public int UpdateAnimal(UpdateAnimalDTO animal, int id );
    public int CreateAnimal(CreateAnimalDTO animal);
}