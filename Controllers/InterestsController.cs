using System.Net;
using APIAssignment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIAssignment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InterestsController : ControllerBase
    {
        [HttpPost("{name:alpha}, {interest:alpha}")]
        public ActionResult<Interests> CreateInterest(string name, string interest)
        {
            int lastId = IInterestRepository.Interest.LastOrDefault()?.Id ?? 0;

            int newId = lastId + 1;

            Interests entry = new Interests
            {
                Id = newId,
                Name = name,
                Interest = interest
            };
            IInterestRepository.Interest.Add(entry);

            return Ok(entry);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Interests>> GetInterests()
        {
            return Ok(IInterestRepository.Interest);
        }

        [HttpGet("{id:int}")]
        public ActionResult<Interests> GetInterestById(int id)
        {
            if (id <= 0)
                return BadRequest();

            var entry = IInterestRepository.Interest.Where(i => i.Id == id).FirstOrDefault();

            if (entry == null)
                return NotFound($"ID {id} is not present");

            return Ok(entry);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<bool> DeleteInterests(int id)
        {
            if (id <= 0)
                return BadRequest();

            var entry = IInterestRepository.Interest.Where(i => i.Id == id).FirstOrDefault();

            if (entry == null)
                return NotFound($"ID {id} is not present");

            IInterestRepository.Interest.Remove(entry);

            return Ok(true);
        }

    }
}
