using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasLucrecia.Application.Employees.UseCases.CreateEmployee
{
    public interface IOutputPort
    {
        void Ok(int employeeId);
        void NotValid(string errorMessage);
    }
}
