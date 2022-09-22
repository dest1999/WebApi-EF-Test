using Microsoft.AspNetCore.Mvc;
using WebApi_EF_Test.DAL;
using WebApi_EF_Test.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi_EF_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IRepository<Employee> employeeRepository;

        public EmployeesController(IRepository<Employee> EmployeeRepository)
        {
            employeeRepository = EmployeeRepository;
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public IActionResult Post([FromBody] EmployeeDTO employee)
        {
            int emplTmp = employeeRepository.Create(employee);
            string outMessage = emplTmp < 0? "Employee already exist, cant create" : emplTmp.ToString();
            return Ok(outMessage);
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var tmp = employeeRepository.Get(id);
            return Ok(tmp);
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool isDeleteOk = employeeRepository.Delete(id);
            return Ok(isDeleteOk);
        }



        // GET: api/<EmployeesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
