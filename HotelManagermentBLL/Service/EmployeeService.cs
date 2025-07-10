using HotelManagermentDAL.Models;
using HotelManagermentDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagermentBLL.Service
{
    public class EmployeeService
    {
        private readonly EmployeeRepository _repo;

        public EmployeeService()
        {
            _repo = new EmployeeRepository();
        }

        public List<Employee> GetAllEmployees() => _repo.GetAll();

        public void Register(Employee emp) => _repo.Add(emp);

        public void Delete(int id) => _repo.Delete(id);
    }
}
