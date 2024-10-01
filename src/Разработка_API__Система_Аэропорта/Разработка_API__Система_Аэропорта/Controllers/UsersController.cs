using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Разработка_API__Система_Аэропорта.Models;

namespace Разработка_API__Система_Аэропорта.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public MyDbContext Context { get; }
        public UsersController(MyDbContext context)
        {
            Context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Рассписание> users = Context.Рассписаниеs.ToList();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Рассписание? e1 = Context.Рассписаниеs.Where(x => x.КодСамолёта == id).FirstOrDefault();
            if (e1 == null)
            {
                return BadRequest("Not Found\nTry again later");
            }
            return Ok();
        }
        [HttpPost]
        public IActionResult Add(Рассписание e1)
        {
            Context.Рассписаниеs.Add(e1);
            Context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(Рассписание e1)
        {
            Context.Рассписаниеs.Remove(e1);
            Context.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Рассписание? e1 = Context.Рассписаниеs.Where(x => x.КодСамолёта == id).FirstOrDefault();
            if (e1 == null)
            {
                return BadRequest();
            }
            Context.Рассписаниеs.Remove(e1);
            Context.SaveChanges();
            return Ok();
        }
    }
}
