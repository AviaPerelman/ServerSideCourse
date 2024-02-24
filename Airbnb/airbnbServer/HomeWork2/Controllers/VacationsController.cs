using HomeWork2.BL;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HomeWork2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacationsController : ControllerBase
    {
        // GET: api/<VacationsController>
        //[HttpGet]
        //public IEnumerable<Vacation> Get()
        //{
        //    Vacation vacation = new Vacation();
        //    return vacation.Read();
        //}

        // GET: api/<VacationsController>
        [HttpGet]
        public IEnumerable<Vacation> Get()
        {
            Vacation vacation = new Vacation();
            return vacation.Read();
        }

        [HttpGet("getByDates")]
        public IEnumerable<Vacation> GetByDates(DateTime startDates, DateTime endDate)
        {
            Vacation vacation = new Vacation();
            return vacation.ReadByDates(startDates, endDate);
        }

        // GET api/<VacationsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<VacationsController>
        [HttpPost]
        public int Post([FromBody] Vacation vacation)
        {
            return vacation.InsertVacation();
        }

        // PUT api/<VacationsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<VacationsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

