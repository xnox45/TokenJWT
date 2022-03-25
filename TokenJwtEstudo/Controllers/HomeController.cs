using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TokenJwtEstudo.Controllers
{
    [ApiController]
    [Route("Auth")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Route("Anonymous")]
        [AllowAnonymous]
        public string Anonymous() => "Anônimo";

        [HttpGet]
        [Route("Authenticated")]
        [Authorize]
        public string Authenticated() => $"Autenticado - {User.Identity.Name}"; //Objeto da Classe Claims

        [HttpGet]
        [Route("Employee")]
        [Authorize(Roles = "dev,vendedor")] // só acessa quem for do tipo dev e vendedor
        public string Employee() => $"Funcionário: {User.Claims}";

        [HttpGet]
        [Route("dev")]
        [Authorize(Roles = "dev")]
        public string dev() => $"dev: {User.Identity.Name}";
    }
}
