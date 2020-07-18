using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Presentation.Api.Authorization;
using ProjetoApplication.Contracts;
using ProjetoApplication.Models;

namespace Projeto.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(UsuarioAutenticacaoModel model,
            [FromServices] IUsuarioApplicationService usuarioApplicationService,
            [FromServices] JwtConfiguration jwtConfiguration)
        {
            try
            {
                var usuario = usuarioApplicationService.GetByLoginAndSenha(model);

                if (usuario != null)
                {
                    return Ok(jwtConfiguration.GenerateToken(usuario.Login));
                }
                else
                {
                    return StatusCode(403, "Usuário não encontrado");
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}