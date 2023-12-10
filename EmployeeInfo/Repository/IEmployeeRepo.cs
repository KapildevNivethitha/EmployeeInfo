using EmployeeInfo.Models;

namespace EmployeeInfo.Repository
{
    public interface IEmployeeRepo
    {
        List<EmployeeDetailsInfo> GetEmployeeDetails(string IsActive = "Y");
        EmployeeDetailsInfo GetEmployeeDetails(int Id);
        int UpdateEmployeeDetails(EmployeeDetailsInfo employeeDetails);
        int AddEmployeeDetails(EmployeeDetailsInfo employeeDetails);
        int DeleteEmployeeDetails(int Id);

        //List<LoginDetails> GetUserDetails(LoginDetails userDetails);
    }
}
