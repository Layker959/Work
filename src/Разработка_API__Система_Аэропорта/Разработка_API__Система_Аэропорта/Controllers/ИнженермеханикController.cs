using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Разработка_API__Система_Аэропорта.Models;

namespace Разработка_API__Система_Аэропорта.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ИнженерМеханикController : ControllerBase
    {
        public MyDbContext Context { get; }
        public ИнженерМеханикController(MyDbContext context)
        {
            Context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<ИнженерМеханик> users = Context.ИнженерМеханикs.ToList();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            ИнженерМеханик? e1 = Context.ИнженерМеханикs.Where(x => x.КодИнженерМеханика == id).FirstOrDefault();
            if (e1 == null)
            {
                return BadRequest("Not Found\nTry again later");
            }
            return Ok();
        }
        [HttpPost]
        public IActionResult Add(ИнженерМеханик e1)
        {
            Context.ИнженерМеханикs.Add(e1);
            Context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(ИнженерМеханик e1)
        {
            Context.ИнженерМеханикs.Remove(e1);
            Context.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            ИнженерМеханик? e1 = Context.ИнженерМеханикs.Where(x => x.КодИнженерМеханика == id).FirstOrDefault();
            if (e1 == null)
            {
                return BadRequest();
            }
            Context.ИнженерМеханикs.Remove(e1);
            Context.SaveChanges();
            return Ok();
        }
    }
}
