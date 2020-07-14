using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoApplication.Contracts;
using ProjetoApplication.Models;

namespace Projeto.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(ClienteCadastroModel model,
            [FromServices] IClienteApplicationService clienteApplicationService)
        {
            try
            {
                clienteApplicationService.Insert(model);
                return Ok("Cliente Cadastrado com sucesso.");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(ClienteEdicaoModel model,
            [FromServices] IClienteApplicationService clienteApplicationService)
        {
            try
            {
                clienteApplicationService.Update(model);
                return Ok("Cliente Alterado com sucesso.");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id,
            [FromServices] IClienteApplicationService clienteApplicationService)
        {
            try
            {
                clienteApplicationService.Delete(id);
                return Ok("Cliente Excluído com sucesso.");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }


        [HttpGet]
        public IActionResult GetAll([FromServices] IClienteApplicationService clienteApplicationService)
        {
            try
            {
                return Ok(clienteApplicationService.GetAll());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id,
            [FromServices] IClienteApplicationService clienteApplicationService)
        {
            try
            {
                return Ok(clienteApplicationService.GetById(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}