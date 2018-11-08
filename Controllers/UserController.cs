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
        private readonly IEmployeeRepository _employeeRepository;
        public UserController(IEmployeeRepository _employeeRepository)
        {
            this._employeeRepository = _employeeRepository;
        }
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var employees = await _employeeRepository.FindAll();
            return new OkObjectResult(employees);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var employee = await _employeeRepository.FindEmpById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return new OkObjectResult(employee);
        }

        [HttpGet]
        [Route("GetByName/{name}")] //[Route("get1/{param1}")] //   /api/example/get1/1?param2=4
        public async Task<IActionResult> GetByName(string name)
        {
            var employees = await _employeeRepository.Find("name like N'%'+@NAME+'%'", new {NAME=name});
            if (employees == null)
            {
                return NotFound();
            }
            return new OkObjectResult(employees);
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
