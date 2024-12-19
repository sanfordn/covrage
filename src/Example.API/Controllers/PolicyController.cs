using Covrage;
using Example.API.Domain.Policies;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Example.API.ModelBinders;

namespace Example.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PolicyController : ControllerBase
{
    private readonly IPolicyIssuance _policyIssuance;

    // Constructor for dependency injection
    public PolicyController(IPolicyIssuance policyIssuance)
    {
        _policyIssuance = policyIssuance;
    }

    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetPolicy(string policyNumber)
    {
        return Ok(await _policyIssuance.GetPolicyAsync(policyNumber));
    }

    [HttpPost]
    [Route("")]
    public async Task<IActionResult> IssuePolicy([FromBody][ModelBinder(BinderType = typeof(PolicyModelBinder))] Policy policy)
    {
        var result = await _policyIssuance.IssuePolicyAsync(policy);
        return CreatedAtAction(nameof(GetPolicy), new { policyNumber = result.PolicyNumber }, result);
    }
}
