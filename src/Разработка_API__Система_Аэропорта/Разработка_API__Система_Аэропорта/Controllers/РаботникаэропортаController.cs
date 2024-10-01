using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Разработка_API__Система_Аэропорта.Models;

namespace Разработка_API__Система_Аэропорта.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class РаботникАэропортаController : ControllerBase
    {
        public MyDbContext Context { get; }
        public РаботникАэропортаController(MyDbContext context)
        {
            Context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<РаботникАэропорта> users = Context.РаботникАэропортаs.ToList();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            РаботникАэропорта? e1 = Context.РаботникАэропортаs.Where(x => x.КодРаботника == id).FirstOrDefault();
            if (e1 == null)
            {
                return BadRequest("Not Found\nTry again later");
            }
            return Ok();
        }
        [HttpPost]
        public IActionResult Add(РаботникАэропорта e1)
        {
            Context.РаботникАэропортаs.Add(e1);
            Context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(РаботникАэропорта e1)
        {
            Context.РаботникАэропортаs.Remove(e1);
            Context.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            РаботникАэропорта? e1 = Context.РаботникАэропортаs.Where(x => x.КодРаботника == id).FirstOrDefault();
            if (e1 == null)
            {
                return BadRequest();
            }
            Context.РаботникАэропортаs.Remove(e1);
            Context.SaveChanges();
            return Ok();
        }
    }
}
