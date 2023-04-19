using Application.Employees.DTOs;
using Application.Security.Interfaces.Repositories;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Employees.Commands
{
    public class EmployeeCreateCommandHandler : IRequestHandler<EmployeeCreateCommand, EmployeeCreateCommandResult>
    {
        private readonly IGenericRepository<Employee> employeeRepository;
        private readonly UserManager<ApplicationUser> userManager;

        public EmployeeCreateCommandHandler(IGenericRepository<Employee> employeeRepository, UserManager<ApplicationUser> userManager)
        {
            this.employeeRepository = employeeRepository;
            this.userManager = userManager;
        }

        public async Task<EmployeeCreateCommandResult> Handle(EmployeeCreateCommand request, CancellationToken cancellationToken)
        {
            var user = new ApplicationUser
            {
                UserName = request.UserName,
                Email = request.Email
            };
            var identityResult =  await userManager.CreateAsync(user, request.Password);
            if (!identityResult.Succeeded)
                return EmployeeCreateCommandResult.Failed;

            user = await userManager.FindByEmailAsync(request.Email);
            
            var employee = new Employee
            {
                ApplicationUserID = user.Id,
                RestaurantID = request.RestaurantID,
                EmploymentDate = DateTime.Now,
                IsManager = request.IsManager,
                IsDeliveryProvider = request.IsDeliveryProvider
            };

            employee = await employeeRepository.AddAsync(employee, cancellationToken);

            return EmployeeCreateCommandResult.Success(employee.Id);
        }
    }
}
