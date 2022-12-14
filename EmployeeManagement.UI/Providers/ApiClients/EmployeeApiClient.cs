using EmployeeManagement.UI.Models;
using EmployeeManagement.UI.Models.Provider;
using EmployeeManagement.UI.Providers.Contracts;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace EmployeeManagement.UI.Providers.ApiClients
{
    public class EmployeeApiClient : IEmployeeApiClient
    {
        private readonly HttpClient _httpClient;

        public EmployeeApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IEnumerable<EmployeeViewModel> GetAllEmployee()
        {
            //Consume /employee endpoint in the EmployeeManagementApi using _httpClient
            var response = _httpClient.GetAsync("https://localhost:44305/api/employee/get-all").Result;
            var employee = JsonConvert.DeserializeObject<IEnumerable<EmployeeViewModel>>(response.Content.ReadAsStringAsync().Result);
            return employee;
        }

        public EmployeeDetailedViewModel GetEmployeeById(int employeeId)
        {
            //Consume /{employeeId} endpoint in the EmployeeManagementApi using _httpClient
            var response = _httpClient.GetAsync("https://localhost:44305/api/employee/" + employeeId).Result;
            var employee = JsonConvert.DeserializeObject<EmployeeDetailedViewModel>(response.Content.ReadAsStringAsync().Result);
            return employee;
        }
        public bool DeleteEmployee(int employeeId)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(employeeId));
            var response = _httpClient.DeleteAsync("https://localhost:44305/api/employee/delete/" + employeeId).Result;
            return true;
        }
        public bool InsertEmployee(EmployeeDetailedViewModel employeeDetailedViewModel)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(employeeDetailedViewModel), Encoding.UTF8, "application/json");


            using (var response = _httpClient.PostAsync("https://localhost:44305/api/employee/insert-employees", stringContent).Result)
            {
                //response.Content.ReadAsStringAsync();
                return true;
            }
        }
        public bool updateEmployee(EmployeeDetailedViewModel employeeDetailedViewModel)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(employeeDetailedViewModel), Encoding.UTF8, "application/json");


            using (var response = _httpClient.PutAsync("https://localhost:44305/api/employee/update-employees", stringContent).Result)
            {
                //response.Content.ReadAsStringAsync();
                return true;
            }
        }



    }
}
