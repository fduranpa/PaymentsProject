using Microsoft.AspNetCore.Mvc;
using Payments.Application.DTOs;
using Payments.Application.Interactors.Abstractions;
using Swashbuckle.AspNetCore.Annotations;

namespace Payments.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorizationController : ControllerBase
{
    private readonly IGetAuthorizationInteractor _getAuthorizationInteractor;
    private readonly IGetApprovedAuthorizationsInteractor _getApprovedAuthorizationsInteractor;

    public AuthorizationController(IGetAuthorizationInteractor getAuthorizationInteractor, IGetApprovedAuthorizationsInteractor getApprovedAuthorizationsInteractor)
    {
        _getAuthorizationInteractor = getAuthorizationInteractor;
        _getApprovedAuthorizationsInteractor = getApprovedAuthorizationsInteractor;
    }

    [SwaggerOperation(Summary = "End Point for Authorize Payment")]
    [HttpPost]
    public async Task<IActionResult> AuthorizePayment(AuthorizationRequestDTO authorizationRequest)
    {
        var result = await _getAuthorizationInteractor.Execute(authorizationRequest);
        return Ok(result);
    }

    [SwaggerOperation(Summary = "End Point for get all authorizsations approved")]
    [HttpGet]
    public async Task<IActionResult> GetAllRegistersAuthorization()
    {
        var result = await _getApprovedAuthorizationsInteractor.Execute();
        return Ok(result);
    }
}
