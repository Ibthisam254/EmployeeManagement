using EmployeeManagement.Application.Contracts;
using EmployeeManagement.Application.Models;
using EmployeeManagement.DataAccess.Contracts;
using EmployeeManagement.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.Application.Services
{
    public class EmployeeService : IEmployeeService

    {
        #region PRIVATEINSTANCEFIELD
        private readonly IEmployeeRepository _employeeRepository;
        #endregion

        #region CONSTRUCTOR
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        #endregion

        #region PUBLICMETHOD
        public EmployeeDto GetEmployeeById(int id)
        {
            var employeeDto = _employeeRepository.GetEmployeeById(id);

            return MapEmployeeDatatoDto(employeeDto);
        }
        public IEnumerable<EmployeeDto> GetEmployees()
        {

            var getEmployees = _employeeRepository.GetEmployees();
            return MapEmployeeDataToDto(getEmployees);
        }
        public bool InsertEmployee(EmployeeDto insertEmployee)
        {

            var empdata = new EmployeeData()
            {
                Name=insertEmployee.Name,
                Age=insertEmployee.Age,
                Address=insertEmployee.Address,
                Department=insertEmployee.Department
            };
             _employeeRepository.InsertEmployee(empdata);

            return true;
        }
        public bool UpdateEmployee(EmployeeDto updateEmployee) 
        {
            var updateData = new EmployeeData() 
            {
                Id   = updateEmployee.Id,
                Name = updateEmployee.Name,
                Department = updateEmployee.Department,
                Age = updateEmployee.Age,
                Address = updateEmployee.Address
            };
            _employeeRepository.UpdateEmployee(updateData);
            
            return true;
            
        }

        public bool DeleteEmployee(int employeeId)
        {
            var deleteData = _employeeRepository.DeleteEmployee(employeeId);
            return deleteData;
        }
        #endregion

        #region PRIVATEMETHOD

        private EmployeeDto MapEmployeeDatatoDto(EmployeeData employeeDto)
        {
            return new EmployeeDto()
            {
                Id = employeeDto.Id,
                Name = employeeDto.Name,
                Department = employeeDto.Department,
                Age = employeeDto.Age,
                Address = employeeDto.Address
            };
        }

         private IEnumerable<EmployeeDto> MapEmployeeDataToDto(IEnumerable<EmployeeData> listOfEmployee)
        {
            var employeeDtoList = new List<EmployeeDto>();
            foreach (var item in listOfEmployee)
            {
                var employeedto = new EmployeeDto()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Department = item.Department,
                    Age = item.Age,
                    Address = item.Address
                };
                employeeDtoList.Add(employeedto);
            }
            return employeeDtoList;

         }
        
        #endregion







        
    }
}
