using APBD_ZAD5.DTOs.Request;
using APBD_ZAD5.Models;

namespace APBD_ZAD5.Repositories;

public interface IAnimalRepository
{
    IEnumerable<Animal> getAnimals(string orderCol);
    
    
    public int DeleteAnimal(int id);
    public int UpdateAnimal(UpdateAnimalDTO animal, int id );
    public int CreateAnimal(CreateAnimalDTO animal);
}