using Microsoft.AspNetCore.Mvc;

namespace BillyAuthenticationApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthenticationController : ControllerBase
{
    [HttpGet]
    public string Get()
    {
        return "Ok";
    }

}