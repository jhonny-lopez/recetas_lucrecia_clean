using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecetasLucrecia.API.Employees.Models
{
    public class GetEmployeeByIdModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
    }
}
