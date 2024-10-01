using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Разработка_API__Система_Аэропорта.Models;

namespace Разработка_API__Система_Аэропорта.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ПаспортController : ControllerBase
    {
        public MyDbContext Context { get; }
        public ПаспортController(MyDbContext context)
        {
            Context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Паспорт> users = Context.Паспортs.ToList();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Паспорт? e1 = Context.Паспортs.Where(x => x.СерияНомер == id).FirstOrDefault();
            if (e1 == null)
            {
                return BadRequest("Not Found\nTry again later");
            }
            return Ok();
        }
        [HttpPost]
        public IActionResult Add(Паспорт e1)
        {
            Context.Паспортs.Add(e1);
            Context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(Паспорт e1)
        {
            Context.Паспортs.Remove(e1);
            Context.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Паспорт? e1 = Context.Паспортs.Where(x => x.СерияНомер == id).FirstOrDefault();
            if (e1 == null)
            {
                return BadRequest();
            }
            Context.Паспортs.Remove(e1);
            Context.SaveChanges();
            return Ok();
        }
    }
}
