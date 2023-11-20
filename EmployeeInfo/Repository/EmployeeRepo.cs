using EmployeeInfo.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeInfo.Repository
{
    public class EmployeeRepo:IEmployeeRepo
    {
        private readonly ApplicationDBContext _context;
        public EmployeeRepo(ApplicationDBContext context)
        {
            _context = context;
        }

        public List<EmployeeDetails> GetEmployeeDetails(string IsDeleted)
        {
            return _context.EmployeeDetails.Where(x => x.IsActive == IsDeleted).ToList();
        }

        public EmployeeDetails GetEmployeeDetails(int Id)
        {
            return _context.EmployeeDetails.Find(Id);
        }

        public int UpdateEmployeeDetails(EmployeeDetails employeeDetails)
        {
            if (_context.EmployeeDetails != null)
            {
                _context.Entry(employeeDetails).State = EntityState.Modified;
                return _context.SaveChanges();
            }
            else
            {
                return 99;
            }
        }

        public int AddEmployeeDetails(EmployeeDetails employeeDetails)
        {
            if (_context.EmployeeDetails != null)
            {
                _context.EmployeeDetails.Add(employeeDetails);
                return _context.SaveChanges();
            }
            else
            {
                return 99;
            }
        }

        public int DeleteEmployeeDetails(int Id)
        {
            if (_context.EmployeeDetails != null)
            {
                var employeeDetails = _context.EmployeeDetails.Find(Id);
                employeeDetails.IsActive = "N";
                _context.Entry(employeeDetails).State = EntityState.Modified;
                return _context.SaveChanges();
            }
            else
            {
                return 99;
            }
        }

        //public List<LoginDetails> GetLoginDetails(LoginDetails loginDetails)
        //{
        //    return _context.LoginDetails.Where(x => x.LoginId == loginDetails.LoginId && x.Password == loginDetails.Password).ToList();
        //}
    }
}
