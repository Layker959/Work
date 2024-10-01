using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Разработка_API__Система_Аэропорта.Models;

namespace Разработка_API__Система_Аэропорта.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class БилетController : ControllerBase
    {
        public MyDbContext Context { get; }
        public БилетController(MyDbContext context)
        {
            Context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Билет> users = Context.Билетs.ToList();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Билет? e1 = Context.Билетs.Where(x => x.КодБилета == id).FirstOrDefault();
            if (e1 == null)
            {
                return BadRequest("Not Found\nTry again later");
            }
            return Ok();
        }
        [HttpPost]
        public IActionResult Add(Билет e1)
        {
            Context.Билетs.Add(e1);
            Context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(Билет e1)
        {
            Context.Билетs.Remove(e1);
            Context.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Билет? e1 = Context.Билетs.Where(x => x.КодБилета == id).FirstOrDefault();
            if (e1 == null)
            {
                return BadRequest();
            }
            Context.Билетs.Remove(e1);
            Context.SaveChanges();
            return Ok();
        }
    }
}
