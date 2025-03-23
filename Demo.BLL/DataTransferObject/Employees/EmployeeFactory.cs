
namespace Demo.BLL.DataTransferObject.Employees
{
    public static class EmployeeFactory
    {
        public static EmployeeRequest ToRequestsMap(this EmployeeUpdateRequest employeeUpdateRequest) => new()
        {
            Address = employeeUpdateRequest.Address,
            Age = employeeUpdateRequest.Age,
            Email = employeeUpdateRequest.Email,
            EmployeeType = employeeUpdateRequest.EmployeeType,
            Gender = employeeUpdateRequest.Gender,
            HiringDate = employeeUpdateRequest.HiringDate,
            IsActive = employeeUpdateRequest.IsActive,
            Name = employeeUpdateRequest.Name,
            PhoneNumber = employeeUpdateRequest.PhoneNumber,
            Salary = employeeUpdateRequest.Salary
          

        };
    }
}
