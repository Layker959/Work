using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Разработка_API__Система_Аэропорта.Models;

namespace Разработка_API__Система_Аэропорта.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ГрузчикController : ControllerBase
    {
        public MyDbContext Context { get; }
        public ГрузчикController(MyDbContext context)
        {
            Context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Грузчик> users = Context.Грузчикs.ToList();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Грузчик? e1 = Context.Грузчикs.Where(x => x.КодГрузчика == id).FirstOrDefault();
            if (e1 == null)
            {
                return BadRequest("Not Found\nTry again later");
            }
            return Ok();
        }
        [HttpPost]
        public IActionResult Add(Грузчик e1)
        {
            Context.Грузчикs.Add(e1);
            Context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(Грузчик e1)
        {
            Context.Грузчикs.Remove(e1);
            Context.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Грузчик? e1 = Context.Грузчикs.Where(x => x.КодГрузчика == id).FirstOrDefault();
            if (e1 == null)
            {
                return BadRequest();
            }
            Context.Грузчикs.Remove(e1);
            Context.SaveChanges();
            return Ok();
        }
    }
}
