using Microsoft.AspNetCore.Mvc;
using RecetasLucrecia.Application.Employees.UseCases.CreateEmployee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecetasLucrecia.API.Employees.Presenters
{
    public class CreateEmployeePresenter : IOutputPort
    {
        public IActionResult ActionResult { get; set; }
        public void NotValid(string errorMessage)
        {
            ActionResult = new BadRequestObjectResult(errorMessage);
        }

        public void Ok(int employeeId)
        {
            ActionResult = new OkObjectResult(employeeId);
        }
    }
}
