using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Car_Rental_Web_API.Models;

[ApiController]
[Route("api/[controller]")]
public class CarsController : ControllerBase
{
    private static List<Car> cars = new List<Car>
    {
        new Car{ Id = 1, Model = "MFD",  Year = 1908 },
        new Car { Id = 2, Model = "DTF",  Year = 2093 }
    };

    [HttpGet]
    public ActionResult<IEnumerable<Car>> GetAll()
    {
        return Ok(cars);
    }

    [HttpGet("{id}")]
    public ActionResult<Car> GetById(int id)
    {
        var car = cars.FirstOrDefault(s => s.Id == id);
        if (car == null) return NotFound();
        return Ok(car);
    }

    [HttpPost]
    public ActionResult<Car> Create(Car newCar)
    {
        newCar.Id = cars.Max(s => s.Id) + 1;
        cars.Add(newCar);
        return CreatedAtAction(nameof(GetById), new { id = newCar.Id }, newCar);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Car updatedCar)
    {
        var car = cars.FirstOrDefault(s => s.Id == id);
        if (car == null) return NotFound();

        car.Model = updatedCar.Model;
        car.Year = updatedCar.Year;
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var car = cars.FirstOrDefault(s => s.Id == id);
        if ( car == null) return NotFound();

         cars.Remove(car);
        return NoContent();
    }
}

