using APBD_ZAD5.Models;

namespace APBD_ZAD5.Services;

public interface IAnimalServices
{
    IEnumerable<Animal> GetAnimals(string orderBy);
    public int DeleteAnimal(int id);
    public int UpdateAnimal(Animal animal );
    public int CreateAnimal(Animal animal);
}