using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecetasLucrecia.API.Employees.Presenters;
using RecetasLucrecia.Application.Employees.UseCases.CreateEmployee;
using RecetasLucrecia.Application.Employees.UseCases.GetEmployeeById;
using RecetasLucrecia.Application.Employees.UseCases.UpdateEmployee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecetasLucrecia.API.Employees
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly CreateEmployeeUseCase _createUseCase;
        private readonly GetEmployeeByIdUseCase _getByIdUseCase;
        private readonly UpdateEmployeeUseCase _updateUseCase;

        public EmployeesController(CreateEmployeeUseCase createUseCase, GetEmployeeByIdUseCase getByIdUseCase, UpdateEmployeeUseCase updateUseCase)
        {
            _createUseCase = createUseCase;
            _getByIdUseCase = getByIdUseCase;
            _updateUseCase = updateUseCase;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddEmployee([FromForm] CreateEmployeeModel model)
        {
            var presenter = new CreateEmployeePresenter();

            _createUseCase.OutputPort = presenter;
            await _createUseCase.ExecuteAsync(model);

            return presenter.ActionResult;
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var presenter = new GetEmployeeByIdPresenter();

            _getByIdUseCase.SetOutputPort(presenter);
            await _getByIdUseCase.ExecuteAsync(id);

            return presenter.ActionResult;
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateEmployee([FromBody] UpdateEmployeeModel model)
        {
            var presenter = new UpdateEmployeePresenter();

            _updateUseCase.SetOutputPort(presenter);
            await _updateUseCase.ExecuteAsync(model);

            return presenter.ActionResult;
        }
    }
}
