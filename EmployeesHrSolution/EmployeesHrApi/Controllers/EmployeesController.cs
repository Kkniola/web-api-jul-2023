using EmployeesHrApi.Data;
using EmployeesHrApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeesHrApi.Controllers;

//controllers should always be public
public class EmployeesController : ControllerBase //other common option to inherit from == Controller
{
    private readonly EmployeeDataContext _context;

    public EmployeesController(EmployeeDataContext context)
    {
        _context = context;
    }


    //GET /employees
    [HttpGet("/employees")] //attribute - when someone does a GET request on this instance of this server, this is what we should run
    public async Task<ActionResult> GetEmployeesAsync()
    {
        var employees = await _context.Employees
            .Select(emp => new EmployeesSummaryResponseModel
            {
                Id = emp.Id.ToString(),
                FirstName = emp.FirstName,
                LastName = emp.LastName,
                Department = emp.Department,
                Email = emp.Email,

            })
            .ToListAsync();

        var response = new EmployeesResponseModel
        {
            Employees = employees
        };
        return Ok(response);
    }
}
