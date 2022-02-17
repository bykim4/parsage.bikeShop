using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parsage.BikeShop.Context;
using Parsage.BikeShop.Models;

namespace Parsage.BikeShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BikesController : ControllerBase
    {
        private BikeContext _bikeContext;

        public BikesController(BikeContext bikeContext)
        {
            _bikeContext = bikeContext;
        }

        [HttpGet]
        public async Task<IEnumerable<Bike>> Get()
        {
            return await _bikeContext.Bikes
                            .Include(b => b.Manufacturer)
                            .OrderBy(o => o.Manufacturer.Name)
                            .ToListAsync();
        }

        [Route("manufacturers")]
        [HttpGet]
        public async Task<IEnumerable<Manufacturer>> GetManufacturers()
        {
            return await _bikeContext.Manufacturers.ToListAsync();
        }

        // GET api/bikes/5
        [HttpGet("{id}")]
        public Bike Get(int id)
        {
            return _bikeContext.Bikes.FirstOrDefault(s => s.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Bike bike)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            _bikeContext.Attach(bike.Manufacturer);
            await _bikeContext.Bikes.AddAsync(bike);
            var status = await _bikeContext.SaveChangesAsync();

            return Created(Request.Path, status);
        }


        // PUT api/bikes/5
        [HttpPut("{id}")]
        public async Task<ActionResult<int>> Put(int id, [FromBody] Bike bike)
        {
            var bikeFromDb = _bikeContext.Bikes.FirstOrDefault(s => s.Id == id);
            if (bikeFromDb == null)
                return BadRequest();


             _bikeContext.Entry<Bike>(bikeFromDb).CurrentValues.SetValues(bike);
            await _bikeContext.SaveChangesAsync();

            return StatusCode(200);
        }

        // DELETE api/bikes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            var bikeFromDb = _bikeContext.Bikes.FirstOrDefault(s => s.Id == id);
            if (bikeFromDb == null)
                return NotFound();
            

            _bikeContext.Bikes.Remove(bikeFromDb);
            await _bikeContext.SaveChangesAsync();

            return Ok();
        }
    }
}
