using core.api.mediar.MediaR;
using core.api.mediar.Model;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core.api.mediar.Controllers
{
    //[Route("api/[controller]")] // Using a default rout mapped in Startup.cs: <server>:<port>/Login
    public class LoginController : Controller
    {

        private readonly IMediator _mediator;

        public LoginController([FromServices] IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] Credential credencial)
        {
            var response = await _mediator.Send(new LoginRequest { Credencial = credencial});

            if (!response.IsAuthenticated)
            {
                return BadRequest(response.Mensagem);
            }
            return Ok(response);
        }
    }
}
