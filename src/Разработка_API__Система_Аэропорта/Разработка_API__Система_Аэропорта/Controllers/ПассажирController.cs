using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Разработка_API__Система_Аэропорта.Models;

namespace Разработка_API__Система_Аэропорта.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ПассажирController : ControllerBase
    {
        public MyDbContext Context { get; }
        public ПассажирController(MyDbContext context)
        {
            Context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Пассажир> users = Context.Пассажирs.ToList();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Пассажир? e1 = Context.Пассажирs.Where(x => x.КодПассажира == id).FirstOrDefault();
            if (e1 == null)
            {
                return BadRequest("Not Found\nTry again later");
            }
            return Ok();
        }
        [HttpPost]
        public IActionResult Add(Пассажир e1)
        {
            Context.Пассажирs.Add(e1);
            Context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(Пассажир e1)
        {
            Context.Пассажирs.Remove(e1);
            Context.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Пассажир? e1 = Context.Пассажирs.Where(x => x.КодПассажира == id).FirstOrDefault();
            if (e1 == null)
            {
                return BadRequest();
            }
            Context.Пассажирs.Remove(e1);
            Context.SaveChanges();
            return Ok();
        }
    }
}
