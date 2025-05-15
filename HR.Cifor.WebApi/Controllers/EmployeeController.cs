using HR.Cifor.Models;
using HR.Cifor.WebApi.Services.EmployeeServices;
using Microsoft.AspNetCore.Mvc;

namespace HR.Cifor.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly EmployeeService employeeService;

    public EmployeesController(EmployeeService employeeService)
    {
        this.employeeService = employeeService;
    }

    [HttpGet]
    public async Task<ActionResult<List<EmployeeModel>>> GetAll()
    {
        var employees = await employeeService.GetAllAsync();
        return Ok(employees);
    }

    [HttpGet("{employeeId}")]
    public async Task<ActionResult<EmployeeModel>> GetById(string employeeId)
    {
        var employee = await employeeService.GetByIdAsync(employeeId);
        if (employee == null)
            return NotFound();

        return Ok(employee);
    }

    [HttpGet("search")]
    public async Task<ActionResult<List<EmployeeModel>>> Search([FromQuery] string? name, [FromQuery] string? department)
    {
        var employees = await employeeService.SearchAsync(name, department);
        return Ok(employees);
    }

    [HttpPost]
    public async Task<ActionResult<EmployeeModel>> Add(EmployeeModel employeeModel)
    {
        if (employeeModel == null)
            return BadRequest();

        var created = await employeeService.AddAsync(employeeModel);
        return CreatedAtAction(nameof(GetById), new { employeeId = created.EmployeeId }, created);
    }

    [HttpPut("{employeeId}")]
    public async Task<IActionResult> Update(string employeeId, EmployeeModel employeeModel)
    {
        if (employeeModel == null || employeeId != employeeModel.EmployeeId)
            return BadRequest();

        var updated = await employeeService.UpdateAsync(employeeId, employeeModel);
        if (!updated)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{employeeId}")]
    public async Task<IActionResult> Delete(string employeeId)
    {
        var deleted = await employeeService.DeleteAsync(employeeId);
        if (!deleted)
            return NotFound();

        return NoContent();
    }
}
