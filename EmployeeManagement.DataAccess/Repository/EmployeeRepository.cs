using EmployeeManagement.DataAccess.Contracts;
using EmployeeManagement.DataAccess.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.DataAccess.Repository
{
    
    public class EmployeeRepository : IEmployeeRepository
    {
        #region CONSTANTFIELD
        private const string SP_GET_EmployeeBYId = "EXEC spGetEmployeeById_EMPLOYEE @Id";
        private const string SP_GET_Employees = "EXEC spGetEmployees_EMPLOYEE";
        private const string SP_Insert = "EXEC spINSERT_EMPLOYEE @Name,@Department,@Age,@Address";
        private const string SP_Update = "EXEC spUPDATE_EMPLOYEE @Id,@Name,@Department,@Age,@Address";
        private const string SP_Delete = "EXEC spDELETE_EMPLOYEE @Id";
        private const string _databaseConnection = "data source = (localdb)\\mssqllocaldb; database =EMPLOYEE_NEWDATABASE;";
        #endregion
        #region PRIVATEFIELD
        private SqlConnection _sqlconnection;
        #endregion
        #region PUBLICMETHOD
        public EmployeeRepository()
        {
            _sqlconnection = new SqlConnection(_databaseConnection);
        }
        public EmployeeData GetEmployeeById(int id)
        {
            
            try
            {
                _sqlconnection.Open();

                var sqlCommand = new SqlCommand(cmdText: SP_GET_EmployeeBYId, _sqlconnection);
                sqlCommand.Parameters.AddWithValue("Id", id);

                var sqlDataReader = sqlCommand.ExecuteReader();

                var employee = new EmployeeData();

                while (sqlDataReader.Read())
                {

                    employee.Id = (int)sqlDataReader["Id"];
                    employee.Name = (string)sqlDataReader["Name"];
                    employee.Department = (string)sqlDataReader["Department"];
                    employee.Age = (int)sqlDataReader["Age"];
                    employee.Address = (string)sqlDataReader["Address"];

                }
                return employee;


            }
            catch (System.Exception)
            {

                throw;
            }
            finally
            {
                _sqlconnection.Close();
            }
        }
        public IEnumerable<EmployeeData> GetEmployees()
        {
            //Take data from Table
            try
            {
                _sqlconnection.Open();

                var sqlCommand = new SqlCommand(cmdText: SP_GET_Employees, _sqlconnection);

                var sqlDataReader = sqlCommand.ExecuteReader();

                var listOfEmployee = new List<EmployeeData>();

                while (sqlDataReader.Read())
                {
                    listOfEmployee.Add(new EmployeeData()
                    {
                        Id = (int)sqlDataReader["Id"],
                        Name = (string)sqlDataReader["Name"],
                        Department = (string)sqlDataReader["Department"],

                    });
                }
                return listOfEmployee;
            }
            catch (System.Exception)
            {

                throw;
            }
            finally
            {
                _sqlconnection.Close();
            }

        }
        public bool InsertEmployee(EmployeeData insertEmployee)
        {
            try
            {
                _sqlconnection.Open();
                var sqlCommand = new SqlCommand(cmdText: SP_Insert, _sqlconnection);
                sqlCommand.Parameters.AddWithValue("Name", insertEmployee.Name);
                sqlCommand.Parameters.AddWithValue("Department", insertEmployee.Department);
                sqlCommand.Parameters.AddWithValue("Age", insertEmployee.Age);
                sqlCommand.Parameters.AddWithValue("Address", insertEmployee.Address);

                sqlCommand.ExecuteNonQuery();
                return true; ;
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                _sqlconnection.Close();
            }


        }
        public bool UpdateEmployee(EmployeeData updateEmployee)
        {
            try
            {
                _sqlconnection.Open();
                var sqlCommand = new SqlCommand(cmdText: SP_Update, _sqlconnection);
                sqlCommand.Parameters.AddWithValue("Id", updateEmployee.Id);
                sqlCommand.Parameters.AddWithValue("Name", updateEmployee.Name);
                sqlCommand.Parameters.AddWithValue("Department", updateEmployee.Department);
                sqlCommand.Parameters.AddWithValue("Age", updateEmployee.Age);
                sqlCommand.Parameters.AddWithValue("Address", updateEmployee.Address);

                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                _sqlconnection.Close();
            }

        }
        public bool DeleteEmployee(int employeeId)
        {
            try
            {
                _sqlconnection.Open();
                var sqlCommand = new SqlCommand(cmdText: SP_Delete, _sqlconnection);
                sqlCommand.Parameters.AddWithValue("Id", employeeId);

                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (System.Exception)
            {

                throw;
            }
            finally
            {
                _sqlconnection.Close();
            }

        }
        #endregion
        
    }
}
