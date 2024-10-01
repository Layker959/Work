using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Разработка_API__Система_Аэропорта.Models;

namespace Разработка_API__Система_Аэропорта.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ТалонБагажаController : ControllerBase
    {
        public MyDbContext Context { get; }
        public ТалонБагажаController(MyDbContext context)
        {
            Context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<ТалонБагажа> users = Context.ТалонБагажаs.ToList();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            ТалонБагажа? e1 = Context.ТалонБагажаs.Where(x => x.КодТалонаБагажа == id).FirstOrDefault();
            if (e1 == null)
            {
                return BadRequest("Not Found\nTry again later");
            }
            return Ok();
        }
        [HttpPost]
        public IActionResult Add(ТалонБагажа e1)
        {
            Context.ТалонБагажаs.Add(e1);
            Context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(ТалонБагажа e1)
        {
            Context.ТалонБагажаs.Remove(e1);
            Context.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            ТалонБагажа? e1 = Context.ТалонБагажаs.Where(x => x.КодТалонаБагажа == id).FirstOrDefault();
            if (e1 == null)
            {
                return BadRequest();
            }
            Context.ТалонБагажаs.Remove(e1);
            Context.SaveChanges();
            return Ok();
        }
    }
}
