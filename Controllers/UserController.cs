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
            var employee = await _employeeRepository.FindById(id, customIdColumn: "EMP_ID");
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
            var employees = await _employeeRepository.Find("NAME LIKE N'%'+@NAME+'%'", new { NAME = name });
            if (employees == null)
            {
                return NotFound();
            }
            return new OkObjectResult(employees);
        }
        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Employee employee)
        {
            var result = await _employeeRepository.Add(employee);
            return new OkObjectResult(result);
        }

        // PUT api/values/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Employee employee)
        {
            var result = await _employeeRepository.Update(employee, "EMP_ID");
            return new OkObjectResult(result);
        }

        // PATCH api/values/5
        [HttpPatch]
        public async Task<IActionResult> Patch([FromBody] Employee employee)
        {
            var result = await _employeeRepository.Update(employee, "EMP_ID");
            return new OkObjectResult(result);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _employeeRepository.Remove(id, "EMP_ID");
            return new OkObjectResult(result);
        }
    }
}
