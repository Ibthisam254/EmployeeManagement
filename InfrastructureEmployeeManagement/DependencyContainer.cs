using EmployeeManagement.Application.Contracts;
using EmployeeManagement.Application.Services;
using EmployeeManagement.DataAccess.Contracts;
using EmployeeManagement.DataAccess.Repository;
using EmployeeManagement.UI.Providers.ApiClients;
using EmployeeManagement.UI.Providers.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfrastructureEmployeeManagement
{
    public static class DependencyContainer
    {
        public static void ConfigureService(this IServiceCollection services, IConfiguration configuration) 
        {
            #region Application

            services.AddScoped<IEmployeeService, EmployeeService>();

            #endregion

            #region DataAccess

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            #endregion

            #region Providers

            services.AddHttpClient<IEmployeeApiClient, EmployeeApiClient>(httpClient =>
            {
                httpClient.BaseAddress = new Uri("https://localhost:5001");
            });

            #endregion
        }
    }
}
