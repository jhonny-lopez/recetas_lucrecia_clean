using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecetasLucrecia.Application.Employees.UseCases.UpdateEmployee;
using RecetasLucrecia.Domain.Employees;

namespace RecetasLucrecia.API.Employees.Presenters
{
    public class UpdateEmployeePresenter : IOutputPort
    {
        public IActionResult ActionResult { get; set; }
        public void NotFound()
        {
            ActionResult = new NotFoundResult();
        }

        public void NotValid(string errorMessage)
        {
            ActionResult = new StatusCodeResult(500);
        }

        public void Ok(Employee employee)
        {
            ActionResult = new OkObjectResult(new
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                EmailAddress = employee.EmailAddress
            });
        }
    }
}
