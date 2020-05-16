using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson.IO;
using RandomAteDataManager.Models;
using RandomAteDataManager.Services;

namespace RandomAteDataManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishesController : ControllerBase
    {
        private readonly DishManagementService _dishManagementService;

        public DishesController(DishManagementService dishManagementService)
        {
            _dishManagementService = dishManagementService;
        }

        // GET: api/Dishes
        // Returns all dishes.
        [HttpGet]
        public ActionResult<List<DishModel>> Get() => _dishManagementService.Get();

        // GET: api/Dishes/{id}
        // Returns exact one dish by id
        [HttpGet("{id:length(24)}", Name = "GetDish")]
        public ActionResult<DishModel> Get(string id)
        {
            var dish = _dishManagementService.Get(id);
            if (dish == null)
            {
                return NotFound();
            }
            return dish;
        }

        // POST: api/Dishes
        // Add one dish
        [HttpPost]
        public ActionResult<DishModel> Create(DishModel dish)
        {
            _dishManagementService.Create(dish);
            // return CreatedAtRoute("GetDish", new {id = dish.Id.ToString(), dish});
            return NoContent();
        }

        
        // PUT: api/Dishes/{id}
        // Updates (replaces) dish on id.
        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, DishModel dishIn)
        {
            var dish = _dishManagementService.Get(id);
            if (dish == null)
            {
                return NotFound();
            }
            _dishManagementService.Update(id, dishIn);

            return NoContent();
        }

        // DELETE: api/Dishes/{id}
        // Deletes dish on id.
        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var dish = _dishManagementService.Get(id);
            if (dish == null)
            {
                return NotFound();
            }
            _dishManagementService.Remove(id);

            return NoContent();
        }

    }
}
