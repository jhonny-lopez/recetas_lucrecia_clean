using RecetasLucrecia.Application.Contracts.Persistance;
using RecetasLucrecia.Domain.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasLucrecia.Application.Employees.UseCases.CreateEmployee
{
    public class CreateEmployeeUseCase
    {
        private readonly IRepository<Employee> _repository;
        private readonly IUnitOfWork _unitOfWork;

        private IOutputPort _outputPort;

        public void SetOutputPort(IOutputPort port)
        {
            _outputPort = port;
        }

        public CreateEmployeeUseCase(IRepository<Employee> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task ExecuteAsync(CreateEmployeeModel model)
        {
            try
            {
                var employee = new Employee();

                employee.EmailAddress = model.EmailAddress;
                employee.FirstName = model.FirstName;
                employee.LastName = model.LastName;

                await _repository.AddAsync(employee);

                await _unitOfWork.SaveAsync();

                _outputPort.Ok(employee.Id);
            }
            catch (Exception ex)
            {
                _outputPort.NotValid(ex.Message);
            }
        }
    }
}
