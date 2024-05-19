using System.Data.SqlClient;
using APBD_ZAD5.DTOs;
using APBD_ZAD5.Models;
using APBD_ZAD5.Repositories;
using APBD_ZAD5.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace APBD_ZAD5.Controllers;


[Route("api/animals")]
[ApiController]
public class AnimalsController : ControllerBase
{
    private IAnimalServices _animalServices;

    public AnimalsController(IAnimalServices animalServices)
    {
        _animalServices = animalServices;
    }
    
    [HttpGet("order")]
    public ActionResult<IEnumerator<AnimalDTO>> GetAnimals(string order)
    {
        IEnumerable<Animal> animals =  _animalServices.GetAnimals(order);

        return Ok();

    }

    [HttpPost]
    public ActionResult CreateAnimal(Animal animal)
    {
        var affectedCount = _animalServices.CreateAnimal(animal);
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPut("{id:int}")]
    public ActionResult UpadeteAnimal(int id, Animal animal)
    {
        var affectedCount = _animalServices.UpdateAnimal(animal);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public ActionResult DeleteAniaml(int id)
    {
        var affectedCount = _animalServices.DeleteAnimal(id);
        return NoContent();
    }

}