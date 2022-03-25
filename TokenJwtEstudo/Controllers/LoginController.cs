using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TokenJwtEstudo.Model;
using TokenJwtEstudo.Service;
using TokenJwtEstudo.Repository;

namespace TokenJwtEstudo.Controllers
{
    [ApiController]
    [Route("v1")]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<dynamic>> AuthenticationAsync([FromBody] User model)
        {
            //Recuperar Usuario
            var user = UserRepository.Get(model.UserName, model.Password);

            if (user == null)
                return NotFound(new { Message = "Usuário ou senha invalidos" });

            //Gera o token
            var token = TokenService.GenerateToken(user);

            user.Password = "";

            //retornar Dados
            return new
            {
                user = user,
                token = token
            };
        }
    }
}
