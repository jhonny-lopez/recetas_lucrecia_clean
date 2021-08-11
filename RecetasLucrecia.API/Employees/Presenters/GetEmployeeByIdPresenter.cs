using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecetasLucrecia.API.Employees.Models;
using RecetasLucrecia.Application.Employees.UseCases.GetEmployeeById;
using RecetasLucrecia.Domain.Employees;

namespace RecetasLucrecia.API.Employees.Presenters
{
    public class GetEmployeeByIdPresenter : IOutputPort
    {
        public IActionResult ActionResult { get; set; }
        public void NotFound()
        {
            ActionResult = new NotFoundResult();
        }

        public void Ok(Employee employee)
        {
            GetEmployeeByIdModel model = new GetEmployeeByIdModel();
            
            model.EmailAddress = employee.EmailAddress;
            model.FullName = $"{employee.FirstName} {employee.LastName}";
            model.Id = employee.Id;

            ActionResult = new OkObjectResult(model);
        }
    }
}
