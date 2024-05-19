using APBD_ZAD5.Models;

namespace APBD_ZAD5.Repositories;

public interface IAnimalRepository
{
    IEnumerable<Animal> getAnimals(string orderCol);
    
    
    public int DeleteAnimal(int id);
    public int UpdateAnimal(Animal animal );
    public int CreateAnimal(Animal animal);
}