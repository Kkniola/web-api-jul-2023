using Microsoft.AspNetCore.Mvc;

namespace EmployeesHrApi.Controllers;

//controllers should always be public
public class EmployeesController : ControllerBase //other common option to inherit from == Controller
{
    //GET /employees
    [HttpGet("/employees")] //attribute - when someone does a GET request on this instance of this server, this is what we should run
    public async Task<ActionResult> GetEmployeesAsync()
    {
        return Ok("Tacos are good, I might have some for lunch");
    }
}
