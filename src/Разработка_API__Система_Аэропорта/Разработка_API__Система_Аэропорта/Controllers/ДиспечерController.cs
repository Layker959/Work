using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Разработка_API__Система_Аэропорта.Models;

namespace Разработка_API__Система_Аэропорта.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ДиспечерController : ControllerBase
    {
        public MyDbContext Context { get; }
        public ДиспечерController(MyDbContext context)
        {
            Context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Диспечер> users = Context.Диспечерs.ToList();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Диспечер? e1 = Context.Диспечерs.Where(x => x.КодДиспечера == id).FirstOrDefault();
            if (e1 == null)
            {
                return BadRequest("Not Found\nTry again later");
            }
            return Ok();
        }
        [HttpPost]
        public IActionResult Add(Диспечер e1)
        {
            Context.Диспечерs.Add(e1);
            Context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(Диспечер e1)
        {
            Context.Диспечерs.Remove(e1);
            Context.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Диспечер? e1 = Context.Диспечерs.Where(x => x.КодДиспечера == id).FirstOrDefault();
            if (e1 == null)
            {
                return BadRequest();
            }
            Context.Диспечерs.Remove(e1);
            Context.SaveChanges();
            return Ok();
        }
    }
}
