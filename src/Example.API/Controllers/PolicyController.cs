
using Covrage;
using Example.API.Domain.Policies;
using Microsoft.AspNetCore.Mvc;

namespace Example.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PolicyController(IPolicyIssuance _policyIssuance) : ControllerBase
{
    [HttpGet]
    [Route("")]
    public IActionResult GetPolicy()
    {
        _policyIssuance.IssuePolicyAsync(new AnnuityPolicy() { PolicyNumber = "12345" });
        return Ok("Policy endpoint is working");
    }
}
