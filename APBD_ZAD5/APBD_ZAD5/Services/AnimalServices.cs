using APBD_ZAD5.DTOs;
using APBD_ZAD5.DTOs.Request;
using APBD_ZAD5.DTOs.Response;
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
    
    public IEnumerable<GetAnimalsDTO> GetAnimals(string orderBy)
    {
       var animals =  _animalRepository.getAnimals(orderBy);

       var animalsDTO = new List<GetAnimalsDTO>();

       foreach (var animal in animals)
       {
          var newAnimal = new GetAnimalsDTO
           {
               Id = animal.IdAnimal,
               Name = animal.Name,
               Description = animal.Description,
               Area = animal.Description,
               Category = animal.Category
           };
          
          animalsDTO.Add(newAnimal);
       }
       
       return animalsDTO;
    }

    public int DeleteAnimal(int id)
    {
        var affectedCount = _animalRepository.DeleteAnimal(id);
        return affectedCount;
    }

    public int UpdateAnimal(UpdateAnimalDTO animal, int id)
    {
        var affectedCount = _animalRepository.UpdateAnimal(animal,id);
        return affectedCount;
    }

    public int CreateAnimal(CreateAnimalDTO animal)
    {
        var affectedCount = _animalRepository.CreateAnimal(animal);
        return affectedCount;
    }
}