using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Разработка_API__Система_Аэропорта.Models;

namespace Разработка_API__Система_Аэропорта.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ЭкипажController : ControllerBase
    {
        public MyDbContext Context { get; }
        public ЭкипажController(MyDbContext context)
        {
            Context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Экипаж> users = Context.Экипажs.ToList();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Экипаж? e1 = Context.Экипажs.Where(x => x.КодЭкипажа == id).FirstOrDefault();
            if (e1 == null)
            {
                return BadRequest("Not Found\nTry again later");
            }
            return Ok();
        }
        [HttpPost]
        public IActionResult Add(Экипаж e1)
        {
            Context.Экипажs.Add(e1);
            Context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(Экипаж e1)
        {
            Context.Экипажs.Remove(e1);
            Context.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Экипаж? e1 = Context.Экипажs.Where(x => x.КодЭкипажа == id).FirstOrDefault();
            if (e1 == null)
            {
                return BadRequest();
            }
            Context.Экипажs.Remove(e1);
            Context.SaveChanges();
            return Ok();
        }
    }
}
