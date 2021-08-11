using RecetasLucrecia.Application.Contracts.Persistance;
using RecetasLucrecia.Domain.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasLucrecia.Application.Employees.UseCases.GetEmployeeById
{
    public class GetEmployeeByIdUseCase
    {
        private readonly IRepository<Employee> _repository;

        private IOutputPort _outputPort;

        public void SetOutputPort(IOutputPort port)
        {
            _outputPort = port;
        }

        public GetEmployeeByIdUseCase(IRepository<Employee> repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(int id)
        {
            var employee = _repository.Get(id);

            if (employee is null)
            {
                _outputPort.NotFound();
                return;
            }

            _outputPort.Ok(employee);
        }
    }
}
