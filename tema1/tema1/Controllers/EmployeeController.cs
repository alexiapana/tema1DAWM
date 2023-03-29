using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tema1.Model;

namespace tema1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public static List<Employee> employees = new()
        {
            new Employee{ Id=1, FirstName="Maria", LastName="Popescu", Department="Marketing"}
            , new Employee{ Id=2, FirstName="Andrei", LastName="Ionescu", Department="Resurse umane"}
        };

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            return Ok(employees);
        }
        [HttpGet ("{id}")]
        public IActionResult GetEmployee(int id)
        {
            var employee = employees.Find(x =>x.Id == id);
            if(employee == null)
            {
                return NotFound("Employee not found");
            }
            return Ok(employee);
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            employees.Add(employee);
            return Ok(employee);
        }

        [HttpPut]
        public IActionResult UpdateEmployeeData(Employee employee)
        {
            var employeeInList = employees.Find(x => x.Id == employee.Id);
            if(employee == null) {
                return NotFound("Invalid Id!");
            }
            employeeInList.FirstName = employee.FirstName;
            employeeInList.LastName = employee.LastName;
            employeeInList.Department = employee.Department;
            return Ok(employeeInList);
        }

        [HttpDelete]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = employees.Find(x => x.Id == x.Id);
            if (employee == null)
            {
                return NotFound("invalid Id!");
            }
            employees.Remove(employee);
            return Ok(employee);
        }
    }
}
