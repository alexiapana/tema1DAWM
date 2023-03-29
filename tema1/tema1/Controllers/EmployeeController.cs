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

        [HttpGet("/get-all")]
        public ActionResult GetAllEmployees()
        {
            return Ok(employees);
        }
        [HttpGet ("get/{id}")]
        public ActionResult GetEmployee(int id)
        {
            var employee = employees.Find(x =>x.Id == id);
            if(employee == null)
            {
                return NotFound("Employee not found");
            }
            return Ok(employee);
        }

        [HttpPost("add")]
        public ActionResult AddEmployee(Employee employee)
        {
            employees.Add(employee);
            return Ok(employee);
        }

        [HttpPut ("edit-employee")]
        public ActionResult UpdateEmployeeData(Employee employee)
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

        [HttpDelete ("delete-employee")]
        public ActionResult DeleteEmployee(int id)
        {
            var employee = employees.Find(x => x.Id == id);
            if (employee == null)
            {
                return NotFound("invalid Id!");
            }
            employees.Remove(employee);
            return Ok(employee);
        }
    }
}
