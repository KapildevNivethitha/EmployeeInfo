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

        public List<EmployeeDetailsInfo> GetEmployeeDetails(string IsDeleted)
        {
            return _context.EmployeeDetailsInfo.Where(x => x.IsActive == IsDeleted).ToList();
        }

        public EmployeeDetailsInfo GetEmployeeDetails(int Id)
        {
            return _context.EmployeeDetailsInfo.Find(Id);
        }

        public int UpdateEmployeeDetails(EmployeeDetailsInfo employeeDetails)
        {
            if (_context.EmployeeDetailsInfo != null)
            {
                _context.Entry(employeeDetails).State = EntityState.Modified;
                return _context.SaveChanges();
            }
            else
            {
                return 99;
            }
        }

        public int AddEmployeeDetails(EmployeeDetailsInfo employeeDetails)
        {
            if (_context.EmployeeDetailsInfo != null)
            {
                _context.EmployeeDetailsInfo.Add(employeeDetails);
                return _context.SaveChanges();
            }
            else
            {
                return 99;
            }
        }

        public int DeleteEmployeeDetails(int Id)
        {
            if (_context.EmployeeDetailsInfo != null)
            {
                var employeeDetails = _context.EmployeeDetailsInfo.Find(Id);
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
