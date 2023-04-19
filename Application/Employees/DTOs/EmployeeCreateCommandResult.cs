using Application.Dishes.DTOs;
using Application.DTOs;

namespace Application.Employees.DTOs
{
    public class EmployeeCreateCommandResult : CommandResult
    {
        public int Id { get; set; }
        public static EmployeeCreateCommandResult Success(int id) => new EmployeeCreateCommandResult() { Id = id, Successed = true };
        public static EmployeeCreateCommandResult Failed => new EmployeeCreateCommandResult { Successed = false };
    }
}
