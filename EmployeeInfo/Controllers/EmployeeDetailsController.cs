using EmployeeInfo.AWS_SecretManager;
using EmployeeInfo.Models;
using EmployeeInfo.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeInfo.Controllers
{
    [ApiController]
    [Route("EmployeeDetails")]
    public class EmployeeDetailsController : ControllerBase
    {

        private readonly IEmployeeRepo _employeeRepo;
        private readonly Serilog.ILogger _logger;

        public EmployeeDetailsController(IEmployeeRepo employeeRepo, Serilog.ILogger logger)
        {
            _employeeRepo = employeeRepo;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetEmployeeDetails()
        {
            AWSSecretManager yyy = new AWSSecretManager();
           var tttt= yyy.GetSecret();
            List<EmployeeDetails> employeeList = new List<EmployeeDetails>();
            employeeList = _employeeRepo.GetEmployeeDetails();
            if (employeeList.Count > 0)
            {
                return Ok(employeeList);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("GetEmployee")]
        public IActionResult GetEmployeeDetailsById(int Id)
        {
            EmployeeDetails? employeeDetails = new EmployeeDetails();
            employeeDetails = _employeeRepo.GetEmployeeDetails(Id);
            if (employeeDetails.EmployeeId != 0)
            {
                return Ok(employeeDetails);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult AddEmployeeDetails([FromBody] EmployeeDetails employeeDetails)
        {
            if (employeeDetails.EmployeeId != 0)
            {
                _employeeRepo.AddEmployeeDetails(employeeDetails);
                _logger.Information("Employee Details Added Sucessfully");
                return Ok(employeeDetails);
            }
            else
            {
                _logger.Information("Error While adding EmployeeDetails");
                return BadRequest();
            }
        }


        [HttpPut]
        public IActionResult Update(int Id, EmployeeDetails employeeDetails)
        {
            if (Id == employeeDetails.EmployeeId)
            {
                _employeeRepo.UpdateEmployeeDetails(employeeDetails);
                _logger.Information("Employee Details Updated Sucessfully");
                return Ok(employeeDetails);
            }
            else
            {
                _logger.Information("Error While updating EmployeeDetails");
                return BadRequest();
            }
        }


        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            EmployeeDetails? employeeDetails = new EmployeeDetails();
            employeeDetails = _employeeRepo.GetEmployeeDetails(Id);
            if (employeeDetails.EmployeeId != 0)
            {
                _employeeRepo.DeleteEmployeeDetails(employeeDetails.EmployeeId);
                _logger.Information("Employee Details Deleted Sucessfully");
                return Ok(employeeDetails);
            }
            
            else
            {
                _logger.Information("Error While deleting EmployeeDetails");
                return NotFound();
            }
        }
    }
}
