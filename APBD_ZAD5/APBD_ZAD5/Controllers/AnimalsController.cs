using System.Data.SqlClient;
using APBD_ZAD5.DTOs;
using APBD_ZAD5.DTOs.Request;
using APBD_ZAD5.DTOs.Response;
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
    public ActionResult<IEnumerator<GetAnimalsDTO>> GetAnimals(string order)
    {
       var  animals =  _animalServices.GetAnimals(order);
       

        return Ok(animals);

    }

    [HttpPost]
    public ActionResult CreateAnimal(CreateAnimalDTO animal)
    {
        var affectedCount = _animalServices.CreateAnimal(animal);

        return Ok("affected rows : " + affectedCount);
    }

    [HttpPut("{id:int}")]
    public ActionResult UpadeteAnimal(int id, [FromBody]UpdateAnimalDTO animal)
    {
        var affectedCount = _animalServices.UpdateAnimal(animal,id);
        return Ok( new {affectedCount} );
    }

    [HttpDelete("{id:int}")]
    public ActionResult DeleteAniaml(int id)
    {
        var affectedCount = _animalServices.DeleteAnimal(id);
        return Ok(new {affectedCount});
    }

}