using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Разработка_API__Система_Аэропорта.Models;

namespace Разработка_API__Система_Аэропорта.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class БортпроводникController : ControllerBase
    {
        public MyDbContext Context { get; }
        public БортпроводникController(MyDbContext context)
        {
            Context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Бортпроводник> users = Context.Бортпроводникs.ToList();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Бортпроводник? e1 = Context.Бортпроводникs.Where(x => x.КодБортпроводника == id).FirstOrDefault();
            if (e1 == null)
            {
                return BadRequest("Not Found\nTry again later");
            }
            return Ok();
        }
        [HttpPost]
        public IActionResult Add(Бортпроводник e1)
        {
            Context.Бортпроводникs.Add(e1);
            Context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(Бортпроводник e1)
        {
            Context.Бортпроводникs.Remove(e1);
            Context.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Бортпроводник? e1 = Context.Бортпроводникs.Where(x => x.КодБортпроводника == id).FirstOrDefault();
            if (e1 == null)
            {
                return BadRequest();
            }
            Context.Бортпроводникs.Remove(e1);
            Context.SaveChanges();
            return Ok();
        }
    }
}
