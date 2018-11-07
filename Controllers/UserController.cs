using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mydapper.Repository;
using mydapper.Models;

namespace mydapper.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IEmployeeRepository em;
        public UserController(IEmployeeRepository emp)
        {
            em = emp;
        }
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await em.FindAll();
            return new OkObjectResult(result);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var result = await em.FindEmpById(id);
            if (result == null)
            {
                return NotFound();
            }
            return new OkObjectResult(result);
        }

        [HttpGet]
        [Route("GetByName/{name}")] //[Route("get1/{param1}")] //   /api/example/get1/1?param2=4
        public async Task<IActionResult> GetByName(string name)
        {
            var result = await em.Find("name like '%'+@NAME+'%'", new {NAME=name});
            if (result == null)
            {
                return NotFound();
            }
            return new OkObjectResult(result);
        }
        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
