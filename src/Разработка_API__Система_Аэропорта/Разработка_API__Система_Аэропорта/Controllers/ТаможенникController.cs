using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Разработка_API__Система_Аэропорта.Models;

namespace Разработка_API__Система_Аэропорта.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ТаможенникController : ControllerBase
    {
        public MyDbContext Context { get; }
        public ТаможенникController(MyDbContext context)
        {
            Context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Таможенник> users = Context.Таможенникs.ToList();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Таможенник? e1 = Context.Таможенникs.Where(x => x.КодТаможенника == id).FirstOrDefault();
            if (e1 == null)
            {
                return BadRequest("Not Found\nTry again later");
            }
            return Ok();
        }
        [HttpPost]
        public IActionResult Add(Таможенник e1)
        {
            Context.Таможенникs.Add(e1);
            Context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(Таможенник e1)
        {
            Context.Таможенникs.Remove(e1);
            Context.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Таможенник? e1 = Context.Таможенникs.Where(x => x.КодТаможенника == id).FirstOrDefault();
            if (e1 == null)
            {
                return BadRequest();
            }
            Context.Таможенникs.Remove(e1);
            Context.SaveChanges();
            return Ok();
        }
    }
}
