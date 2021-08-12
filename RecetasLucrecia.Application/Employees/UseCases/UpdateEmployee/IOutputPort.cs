using RecetasLucrecia.Domain.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasLucrecia.Application.Employees.UseCases.UpdateEmployee
{
    public interface IOutputPort
    {
        void Ok(Employee employee);
        void NotFound();
        void NotValid(string errorMessage);
    }
}
