using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoApplication.Contracts;
using ProjetoApplication.Models;

namespace Projeto.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(UsuarioCadastroModel model,
            [FromServices] IUsuarioApplicationService usuarioApplicationService)
        {
            try
            {
                usuarioApplicationService.Insert(model);
                return Ok("Usuário cadastrado com sucesso.");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get([FromServices] IUsuarioApplicationService usuarioApplicationService)
        {
            try
            {
                var login = User.Identity.Name;
                var usuario = usuarioApplicationService.GetByLogin(login);

                return Ok(usuario);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}