using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Разработка_API__Система_Аэропорта.Models;

namespace Разработка_API__Система_Аэропорта.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ОхранаController : ControllerBase
    {
        public MyDbContext Context { get; }
        public ОхранаController(MyDbContext context)
        {
            Context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Охрана> users = Context.Охранаs.ToList();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Охрана? e1 = Context.Охранаs.Where(x => x.КодОхранника == id).FirstOrDefault();
            if (e1 == null)
            {
                return BadRequest("Not Found\nTry again later");
            }
            return Ok();
        }
        [HttpPost]
        public IActionResult Add(Охрана e1)
        {
            Context.Охранаs.Add(e1);
            Context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(Охрана e1)
        {
            Context.Охранаs.Remove(e1);
            Context.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Охрана? e1 = Context.Охранаs.Where(x => x.КодОхранника == id).FirstOrDefault();
            if (e1 == null)
            {
                return BadRequest();
            }
            Context.Охранаs.Remove(e1);
            Context.SaveChanges();
            return Ok();
        }
    }
}
