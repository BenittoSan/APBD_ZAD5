using APBD_ZAD5.Models;
using APBD_ZAD5.Repositories;

namespace APBD_ZAD5.Services;

public class AnimalServices : IAnimalServices
{
    private IAnimalRepository _animalRepository;

    public AnimalServices(IAnimalRepository animalRepository)
    {
        _animalRepository = animalRepository;
    }
    
    public IEnumerable<Animal> GetAnimals(string orderBy)
    {
       var animals =  _animalRepository.getAnimals(orderBy);
       return animals;
    }

    public int DeleteAnimal(int id)
    {
        var affectedCount = _animalRepository.DeleteAnimal(id);
        return affectedCount;
    }

    public int UpdateAnimal(Animal animal)
    {
        var affectedCount = _animalRepository.UpdateAnimal(animal);
        return affectedCount;
    }

    public int CreateAnimal(Animal animal)
    {
        var affectedCount = _animalRepository.CreateAnimal(animal);
        return affectedCount;
    }
}