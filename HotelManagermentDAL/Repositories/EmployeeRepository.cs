using HotelManagermentDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagermentDAL.Repositories
{
    public class EmployeeRepository
    {
        private readonly HotelManagementV5Context _context;

        public EmployeeRepository()
        {
            _context = new HotelManagementV5Context();
        }

        public List<Employee> GetAll()
        {
            return _context.Employees.ToList();
        }

        public void Add(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var emp = _context.Employees.FirstOrDefault(e => e.Eid == id);
            if (emp != null)
            {
                _context.Employees.Remove(emp);
                _context.SaveChanges();
            }
        }
       
        public Employee? GetOne(string username, string password, string role)
        {
            using var context = new HotelManagementV5Context();
            return context.Employees
                          .FirstOrDefault(x => x.Username.ToLower() == username.ToLower() &&
                                               x.Pass == password);
                                              
        }
    }
}

