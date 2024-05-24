using Covrage.API.Domain;
using Covrage.API.Mapping;
using Covrage.API.Contracts.Responses;
using Covrage.API.Contracts.Requests;
using FastEndpoints;

namespace Covrage.API.Endpoints;
public class CreatePolicyEndpoint(Covrage.API.Services.IPolicyService _policyService) : Endpoint<CreatePolicyRequest, CreatePolicyResponse>
{
    public override void Configure()
    {
        Get("/api/policy");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreatePolicyRequest request, CancellationToken cancellationToken)
    {
        Policy policy = request.ToPolicy();
        await _policyService.CreateAsync(policy);

        CreatePolicyResponse response = policy.ToCreatePolicyResponse();

        await SendCreatedAtAsync<CreatePolicyEndpoint>(new { policy.Id }, response, generateAbsoluteUrl: true, cancellation: cancellationToken);
    }
}
