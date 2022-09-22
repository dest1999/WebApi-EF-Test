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
            //TODO использовать badrequest при ошибке?
            //возвращаем ок т.к. запрос обработан
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
        public IActionResult Put(int id, [FromBody] EmployeeDTO employee)
        {
            bool isSuccess = employeeRepository.Update(id, employee);
            string outMessage = !isSuccess ? "Employee already exist, cant modify" : isSuccess.ToString();
            return Ok(outMessage);
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool isDeleteOk = employeeRepository.Delete(id);
            return Ok(isDeleteOk);
        }

    }
}
