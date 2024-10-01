using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Разработка_API__Система_Аэропорта.Models;

namespace Разработка_API__Система_Аэропорта.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ПилотController : ControllerBase
    {
        public MyDbContext Context { get; }
        public ПилотController(MyDbContext context)
        {
            Context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Пилот> users = Context.Пилотs.ToList();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Пилот? e1 = Context.Пилотs.Where(x => x.КодПилота == id).FirstOrDefault();
            if (e1 == null)
            {
                return BadRequest("Not Found\nTry again later");
            }
            return Ok();
        }
        [HttpPost]
        public IActionResult Add(Пилот e1)
        {
            Context.Пилотs.Add(e1);
            Context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(Пилот e1)
        {
            Context.Пилотs.Remove(e1);
            Context.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Пилот? e1 = Context.Пилотs.Where(x => x.КодПилота == id).FirstOrDefault();
            if (e1 == null)
            {
                return BadRequest();
            }
            Context.Пилотs.Remove(e1);
            Context.SaveChanges();
            return Ok();
        }
    }
}
