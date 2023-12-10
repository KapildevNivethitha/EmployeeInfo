using EmployeeInfo.AWS_SecretManager;
using EmployeeInfo.Models;
using EmployeeInfo.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

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
            List<EmployeeDetailsInfo> employeeList = new List<EmployeeDetailsInfo>();
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
            EmployeeDetailsInfo? employeeDetails = new EmployeeDetailsInfo();
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
        public IActionResult AddEmployeeDetails([FromBody] EmployeeDetailsInfo employeeDetails)
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
        public IActionResult Update(int Id, EmployeeDetailsInfo employeeDetails)
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
            EmployeeDetailsInfo? employeeDetails = new EmployeeDetailsInfo();
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
