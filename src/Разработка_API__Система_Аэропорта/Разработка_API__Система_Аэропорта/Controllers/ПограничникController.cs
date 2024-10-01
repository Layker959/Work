using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Разработка_API__Система_Аэропорта.Models;

namespace Разработка_API__Система_Аэропорта.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ПограничникController : ControllerBase
    {
        public MyDbContext Context { get; }
        public ПограничникController(MyDbContext context)
        {
            Context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Пограничник> users = Context.Пограничникs.ToList();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Пограничник? e1 = Context.Пограничникs.Where(x => x.КодПограничника == id).FirstOrDefault();
            if (e1 == null)
            {
                return BadRequest("Not Found\nTry again later");
            }
            return Ok();
        }
        [HttpPost]
        public IActionResult Add(Пограничник e1)
        {
            Context.Пограничникs.Add(e1);
            Context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(Пограничник e1)
        {
            Context.Пограничникs.Remove(e1);
            Context.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Пограничник? e1 = Context.Пограничникs.Where(x => x.КодПограничника == id).FirstOrDefault();
            if (e1 == null)
            {
                return BadRequest();
            }
            Context.Пограничникs.Remove(e1);
            Context.SaveChanges();
            return Ok();
        }
    }
}
