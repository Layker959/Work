using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Разработка_API__Система_Аэропорта.Models;

namespace Разработка_API__Система_Аэропорта.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class СамолётController : ControllerBase
    {
        public MyDbContext Context { get; }
        public СамолётController(MyDbContext context)
        {
            Context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Самолёт> users = Context.Самолётs.ToList();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Самолёт? e1 = Context.Самолётs.Where(x => x.КодСамолёта == id).FirstOrDefault();
            if (e1 == null)
            {
                return BadRequest("Not Found\nTry again later");
            }
            return Ok();
        }
        [HttpPost]
        public IActionResult Add(Самолёт e1)
        {
            Context.Самолётs.Add(e1);
            Context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(Самолёт e1)
        {
            Context.Самолётs.Remove(e1);
            Context.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Самолёт? e1 = Context.Самолётs.Where(x => x.КодСамолёта == id).FirstOrDefault();
            if (e1 == null)
            {
                return BadRequest();
            }
            Context.Самолётs.Remove(e1);
            Context.SaveChanges();
            return Ok();
        }
    }
}
