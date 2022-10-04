using EmployeeManagement.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.DataAccess.Contracts
{
    public interface IEmployeeRepository
    {
        IEnumerable<EmployeeData> GetEmployees();
        EmployeeData GetEmployeeById(int id);
        bool InsertEmployee(EmployeeData insertEmployee);
        bool UpdateEmployee(EmployeeData updateEmployee);
        bool DeleteEmployee(int employeeId);

    }
}
