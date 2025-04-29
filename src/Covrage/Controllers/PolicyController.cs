using Microsoft.AspNetCore.Mvc;

namespace Covrage.Controllers;

[ApiController]
[Route("[controller]")]
public class PolicyController : ControllerBase
{
    private readonly IPolicyIssuance _policyIssuance;

    public PolicyController(IPolicyIssuance policyIssuance)
    {
        _policyIssuance = policyIssuance;
    }

    [HttpGet("{policyNumber}")]
    public async Task<IActionResult> GetPolicy(string policyNumber)
    {
        var policy = await _policyIssuance.GetPolicyAsync(policyNumber);
        if (policy == null)
        {
            return NotFound();
        }
        return Ok(policy);
    }

    [HttpPost]
    public async Task<IActionResult> IssuePolicy(Policy policy)
    {
        var result = await _policyIssuance.IssuePolicyAsync(policy);
        return CreatedAtAction(nameof(GetPolicy), new { policyNumber = result.PolicyNumber }, result);
    }
}
