using Application.Employees.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Employees.Commands
{
    public class EmployeeCreateCommand : IRequest<EmployeeCreateCommandResult>
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
        [Required]
        public int RestaurantID { get; set; }
        public bool IsManager { get; set; } = false;
        public bool IsDeliveryProvider { get; set; } = false;
    }
}
