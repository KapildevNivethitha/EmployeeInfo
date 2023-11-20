using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EmployeeInfo.Models
{
    public class EmployeeDetails
    {
        [Key]
        public int EmployeeId { get; set; }

        [DisplayName("Employee Name")]
        [Required(ErrorMessage = "Employee Name can't be empty")]
        public string EmployeeName { get; set; } = String.Empty;

  
        [DisplayName("Employee Designation")]
        [Required(ErrorMessage = "EmployeeDesignation  can't be empty")]
        public string EmployeeDesignation { get; set; } = String.Empty;

        [DisplayName("Employee MailId")]
        [Required(ErrorMessage = "EmployeeMailId  can't be empty")]
        public string EmployeeMailId { get; set; } = String.Empty;

        [DisplayName("Salary")]
        [Required(ErrorMessage = "Salary can't be empty")]
        [DataType(DataType.Currency, ErrorMessage = "Salary is not valid")]
        [Range(0.01, 10000000, ErrorMessage = "Price must be greater than 0")]
        public int EmployeeSalary { get; set; } 


        [DefaultValue("Y")]
        public string IsActive { get; set; } = "Y";
    }
}
