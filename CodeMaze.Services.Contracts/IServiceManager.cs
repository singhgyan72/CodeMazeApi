﻿namespace CodeMaze.Services.Contracts
{
    public interface IServiceManager
    {
        ICompanyService CompanyService { get; }

        IEmployeeService EmployeeService { get; }

        IAuthenticationService AuthenticationService { get; }
    }
}
