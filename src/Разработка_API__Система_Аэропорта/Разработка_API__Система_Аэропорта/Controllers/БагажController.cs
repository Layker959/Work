using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Разработка_API__Система_Аэропорта.Models;

namespace Разработка_API__Система_Аэропорта.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class БагажController : ControllerBase
    {
        public MyDbContext Context { get; }
        public БагажController(MyDbContext context)
        {
            Context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Багаж> users = Context.Багажs.ToList();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Багаж? e1 = Context.Багажs.Where(x => x. КодТалонаБагажа == id).FirstOrDefault();
            if (e1 == null)
            {
                return BadRequest("Not Found\nTry again later");
            }
            return Ok();
        }
        [HttpPost]
        public IActionResult Add(Багаж e1)
        {
            Context.Багажs.Add(e1);
            Context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(Багаж e1)
        {
            Context.Багажs.Remove(e1);
            Context.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Багаж? e1 = Context.Багажs.Where(x => x.КодТалонаБагажа == id).FirstOrDefault();
            if (e1 == null)
            {
                return BadRequest();
            }
            Context.Багажs.Remove(e1);
            Context.SaveChanges();
            return Ok();
        }
    }
}
