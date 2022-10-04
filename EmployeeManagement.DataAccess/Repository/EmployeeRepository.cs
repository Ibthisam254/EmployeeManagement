using EmployeeManagement.DataAccess.Contracts;
using EmployeeManagement.DataAccess.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.DataAccess.Repository
{
    /// <summary>
    /// Connect To Database and Perforum CRUD operations
    /// </summary>
    public class EmployeeRepository : IEmployeeRepository
    {
        #region CONSTANTFIELD
        private const string _getEmployeeId = "EXEC spGetEmployeeById_EMPLOYEE @Id";
        private const string _getEmployees = "EXEC spGetEmployees_EMPLOYEE";
        private const string _insert = "EXEC spINSERT_EMPLOYEE @Name,@Department,@Age,@Address";
        private const string _update = "EXEC spUPDATE_EMPLOYEE @Id,@Name,@Department,@Age,@Address";
        private const string _delete = "EXEC spDELETE_EMPLOYEE @Id";
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
            //Take data from Table By Id
            try
            {
                _sqlconnection.Open();

                var sqlCommand = new SqlCommand(cmdText: _getEmployeeId, _sqlconnection);
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

                var sqlCommand = new SqlCommand(cmdText: _getEmployees, _sqlconnection);

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
                var sqlCommand = new SqlCommand(cmdText:_insert, _sqlconnection);
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
                var sqlCommand = new SqlCommand(cmdText: _update, _sqlconnection);
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
                var sqlCommand = new SqlCommand(cmdText: _delete, _sqlconnection);
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
        //Create Methods For Table insert, update and Delete Here
    }
}
