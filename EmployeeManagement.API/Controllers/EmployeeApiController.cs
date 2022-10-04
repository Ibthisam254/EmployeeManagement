using EmployeeManagement.API.Models;
using EmployeeManagement.Application.Contracts;
using EmployeeManagement.Application.Models;
using EmployeeManagement.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.API.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeApiController : ControllerBase
    {
        #region PRIVATEFIELD 
        private readonly IEmployeeService _employeeService;
        #endregion
        #region CONSTRUCTOR
        public EmployeeApiController(IEmployeeService employeeService)
        {
            this._employeeService = employeeService;
        }
        #endregion
        #region PUBLICMETHOD

        [HttpGet]
        [Route("{employeeId}")]
        public IActionResult GetEmployeeById([FromRoute] int employeeId)
        {
            try
            {
                if (employeeId < 0)
                {
                    throw new ArgumentException("Invalid Employee Id");
                }
                var getEmployeeById = _employeeService.GetEmployeeById(employeeId);
                if (getEmployeeById == null) 
                {
                    throw new ArgumentException("Employee Not Found");
                }
                return Ok(getEmployeeById);
            }

            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("get-all")]
        public IActionResult GetEmployees()
        {
            try
            {
                var getEmployees = _employeeService.GetEmployees();
                return Ok(getEmployees);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        [HttpPost]
        [Route("insert-employees")]
        public IActionResult InsertEmployees([FromBody] EmployeeDetailedViewModel employeeDetailedViewModel)
        {
            try
            {

                var employeeDto = new EmployeeDto()
                {
                    Name = employeeDetailedViewModel.Name,
                    Address = employeeDetailedViewModel.Address,
                    Age = employeeDetailedViewModel.Age,
                    Department = employeeDetailedViewModel.Department
                };

                var insertEmployees = _employeeService.InsertEmployee(employeeDto);
                return Ok(insertEmployees);
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        [HttpPut]
        [Route("update-employees")]
        public IActionResult UpdateEmployees([FromBody] EmployeeDetailedViewModel employeeDetailedViewModel)
        {
            try
            {
                var updateData = new EmployeeDto()
                {
                    Id = employeeDetailedViewModel.Id,
                    Name = employeeDetailedViewModel.Name,
                    Department = employeeDetailedViewModel.Department,
                    Age = employeeDetailedViewModel.Age,
                    Address = employeeDetailedViewModel.Address

                };

                var updateEmployees = _employeeService.UpdateEmployee(updateData);
                return Ok(updateEmployees);
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        [HttpDelete]
        [Route("delete/{employeeId}")]
        public IActionResult DeleteEmployees([FromRoute] int employeeId)
        {
            try
            {

                if (employeeId < 0)
                {
                    throw new ArgumentException("Invalid Employee Id");
                }
                var deleteEmployee = _employeeService.DeleteEmployee(employeeId);

                return Ok(deleteEmployee);
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        #endregion
        #region PRIVATEMETHOD
        
        
        #endregion
        //Create Employee Insert, Update and Delete Endpoint here
    }
}
