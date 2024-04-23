using Microsoft.AspNetCore.Mvc;
using Payments.Application.DTOs;
using Payments.Application.Interactors.Abstractions;

namespace Payments.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorizeController : ControllerBase
{
    private readonly IGetAuthorizationInteractor _getAuthorizationInteractor;

    public AuthorizeController(IGetAuthorizationInteractor getAuthorizationInteractor)
    {
        _getAuthorizationInteractor = getAuthorizationInteractor;
    }

    [HttpPost]
    public async Task<IActionResult> GetAuthorizePayment(AuthorizationRequestDTO authorizationRequest)
    {
        var result = await _getAuthorizationInteractor.Execute(authorizationRequest);
        return Ok(result);
    }
}
