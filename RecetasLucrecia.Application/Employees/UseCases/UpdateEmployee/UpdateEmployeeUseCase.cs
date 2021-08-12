using RecetasLucrecia.Application.Contracts.Persistance;
using RecetasLucrecia.Domain.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasLucrecia.Application.Employees.UseCases.UpdateEmployee
{
    public class UpdateEmployeeUseCase
    {
        private readonly IRepository<Employee> _repository;
        private readonly IUnitOfWork _unitOfWork;

        private IOutputPort _outputPort;

        public UpdateEmployeeUseCase(IRepository<Employee> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public void SetOutputPort(IOutputPort port)
        {
            _outputPort = port;
        }

        public IOutputPort GetOutputPort()
        {
            return _outputPort;
        }

        public async Task ExecuteAsync(UpdateEmployeeModel model)
        {
            try
            {
                var employee = _repository.Get(model.Id);

                if (employee == null)
                {
                    _outputPort.NotFound();
                }
                else
                {
                    employee.EmailAddress = model.EmailAddress;
                    employee.FirstName = model.FirstName;
                    employee.LastName = model.LastName;

                    await _unitOfWork.SaveAsync();
                    _outputPort.Ok(employee);
                }
            }
            catch (Exception ex)
            {
                _outputPort.NotValid(ex.Message);
            }
        }
    }
}
