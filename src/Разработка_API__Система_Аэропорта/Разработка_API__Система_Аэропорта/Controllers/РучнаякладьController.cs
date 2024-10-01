using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Разработка_API__Система_Аэропорта.Models;

namespace Разработка_API__Система_Аэропорта.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class РучнаяКладьController : ControllerBase
    {
        public MyDbContext Context { get; }
        public РучнаяКладьController(MyDbContext context)
        {
            Context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<РучнаяКладь> users = Context.РучнаяКладьs.ToList();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            РучнаяКладь? e1 = Context.РучнаяКладьs.Where(x => x.КодТалонаБагажа == id).FirstOrDefault();
            if (e1 == null)
            {
                return BadRequest("Not Found\nTry again later");
            }
            return Ok();
        }
        [HttpPost]
        public IActionResult Add(РучнаяКладь e1)
        {
            Context.РучнаяКладьs.Add(e1);
            Context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(РучнаяКладь e1)
        {
            Context.РучнаяКладьs.Remove(e1);
            Context.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            РучнаяКладь? e1 = Context.РучнаяКладьs.Where(x => x.КодТалонаБагажа == id).FirstOrDefault();
            if (e1 == null)
            {
                return BadRequest();
            }
            Context.РучнаяКладьs.Remove(e1);
            Context.SaveChanges();
            return Ok();
        }
    }
}
