using Covrage.Application.Issuance;
using Covrage.Domain.Policies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.OpenApi;

namespace Covrage.DependencyInjection.Api;

/// <summary>
/// Default implementation of IPolicyApiProvider that provides standard CRUD operations
/// for policies using minimal APIs.
/// </summary>
public class DefaultPolicyApiProvider : IPolicyApiProvider
{
    private const string RoutePrefix = "/api/policies";

    public void MapEndpoints(WebApplication app)
    {
        var group = app.MapGroup(RoutePrefix)
            .WithName("Policies");

        group.MapGet("/{policyNumber}", GetPolicy)
            .WithName("GetPolicy")
            .WithDescription("Get a policy by policy number");

        group.MapPost("/", IssuePolicy)
            .WithName("IssuePolicy")
            .WithDescription("Issue a new policy");

        group.MapPut("/{policyNumber}", UpdatePolicy)
            .WithName("UpdatePolicy")
            .WithDescription("Update an existing policy");

        group.MapDelete("/{policyNumber}", DeletePolicy)
            .WithName("DeletePolicy")
            .WithDescription("Delete a policy");

        group.MapGet("/", ListPolicies)
            .WithName("ListPolicies")
            .WithDescription("List all policies");
    }

    private async Task<IResult> GetPolicy(string policyNumber, IPolicyIssuance policyIssuance)
    {
        var policy = await policyIssuance.GetPolicyAsync(policyNumber);
        return policy == null ? Results.NotFound() : Results.Ok(policy);
    }

    private async Task<IResult> IssuePolicy(Policy policy, IPolicyIssuance policyIssuance)
    {
        var result = await policyIssuance.IssuePolicyAsync(policy);
        return Results.CreatedAtRoute("GetPolicy", new { policyNumber = result.PolicyNumber }, result);
    }

    private async Task<IResult> UpdatePolicy(string policyNumber, Policy policy, IPolicyIssuance policyIssuance)
    {
        // Note: This is a placeholder. The actual update logic would depend on your domain requirements.
        // For now, we'll just return a 501 Not Implemented.
        return Results.StatusCode(StatusCodes.Status501NotImplemented);
    }

    private async Task<IResult> DeletePolicy(string policyNumber, IPolicyIssuance policyIssuance)
    {
        // Note: This is a placeholder. The actual delete logic would depend on your domain requirements.
        // For now, we'll just return a 501 Not Implemented.
        return Results.StatusCode(StatusCodes.Status501NotImplemented);
    }

    private async Task<IResult> ListPolicies(IPolicyIssuance policyIssuance)
    {
        // Note: This is a placeholder. The actual list logic would depend on your domain requirements.
        // For now, we'll just return an empty list.
        return Results.Ok(new List<Policy>());
    }
}
