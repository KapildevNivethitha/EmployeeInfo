using System.ComponentModel.DataAnnotations;

namespace EmployeeInfo.Models
{
    public class LoginDetails
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "LoginId can't be empty")]
        public string LoginId { get; set; }
        [Required(ErrorMessage = "Pasword can't be empty")]
        public string Password { get; set; }
    }
}
