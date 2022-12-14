using EmployeeManagement.UI.Models;
using EmployeeManagement.UI.Models.Provider;
using System.Collections.Generic;

namespace EmployeeManagement.UI.Providers.Contracts
{
    public interface IEmployeeApiClient
    {
        IEnumerable<EmployeeViewModel> GetAllEmployee();
        EmployeeDetailedViewModel GetEmployeeById(int id);
        bool DeleteEmployee(int employeeId);
        bool InsertEmployee(EmployeeDetailedViewModel employeeDetailedViewModel);
        bool updateEmployee(EmployeeDetailedViewModel employeeDetailedViewModel);


    }
}
