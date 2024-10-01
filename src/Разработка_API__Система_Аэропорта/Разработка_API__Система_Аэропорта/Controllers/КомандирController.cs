using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Разработка_API__Система_Аэропорта.Models;

namespace Разработка_API__Система_Аэропорта.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class КомандирController : ControllerBase
    {
        public MyDbContext Context { get; }
        public КомандирController(MyDbContext context)
        {
            Context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Командир> users = Context.Командирs.ToList();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Командир? e1 = Context.Командирs.Where(x => x.КодКомандира == id).FirstOrDefault();
            if (e1 == null)
            {
                return BadRequest("Not Found\nTry again later");
            }
            return Ok();
        }
        [HttpPost]
        public IActionResult Add(Командир e1)
        {
            Context.Командирs.Add(e1);
            Context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(Командир e1)
        {
            Context.Командирs.Remove(e1);
            Context.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Командир? e1 = Context.Командирs.Where(x => x.КодКомандира == id).FirstOrDefault();
            if (e1 == null)
            {
                return BadRequest();
            }
            Context.Командирs.Remove(e1);
            Context.SaveChanges();
            return Ok();
        }
    }
}
