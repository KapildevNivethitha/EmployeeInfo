using EmployeeInfo.Models;

namespace EmployeeInfo.Repository
{
    public interface IEmployeeRepo
    {
        List<EmployeeDetails> GetEmployeeDetails(string IsActive = "Y");
        EmployeeDetails GetEmployeeDetails(int Id);
        int UpdateEmployeeDetails(EmployeeDetails employeeDetails);
        int AddEmployeeDetails(EmployeeDetails employeeDetails);
        int DeleteEmployeeDetails(int Id);

        //List<LoginDetails> GetUserDetails(LoginDetails userDetails);
    }
}
