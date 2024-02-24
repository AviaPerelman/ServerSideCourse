using HomeWork2.BL;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HomeWork2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlatsController : ControllerBase
    {
        // GET: api/<FlatsController>
        [HttpGet]
        public IEnumerable<Flat> Get()
        {
            Flat flat = new Flat();
            return flat.ReadFlats();
        }

        [HttpGet("GetByPriceAndCity")]
        public IEnumerable<Flat> GetByPriceAndCity(string city, double maxPrice)
        {
            Flat flat = new Flat();
            return flat.ReadByPriceAndCity(city, maxPrice);
        }

        // GET api/<FlatsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FlatsController>
        [HttpPost]
        public int Post([FromBody] Flat flat)
        {

            int numEffected = flat.InsertFlat();
            return numEffected;
        }

        //[HttpGet("GetFlats")]
        //public IEnumerable<Flat> GetFlats()
        //{
        //    Flat flat = new Flat();
        //    return flat.ReadFlats();
        //}



        // PUT api/<FlatsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FlatsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
