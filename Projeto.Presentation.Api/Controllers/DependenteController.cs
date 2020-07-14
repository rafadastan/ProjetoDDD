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
    public class DependenteController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(DependenteCadastroModel model,
            [FromServices] IDependenteApplicationService dependenteApplicationService)
        {
            try
            {
                dependenteApplicationService.Insert(model);
                return Ok("Dependente Cadastrado com sucesso.");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(DependenteEdicaoModel model,
            [FromServices] IDependenteApplicationService dependenteApplicationService)
        {
            try
            {
                dependenteApplicationService.Update(model);
                return Ok("Dependente Alterado com sucesso.");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id,
            [FromServices] IDependenteApplicationService dependenteApplicationService)
        {
            try
            {
                dependenteApplicationService.Delete(id);
                return Ok("Dependente Excluído com sucesso.");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }


        [HttpGet]
        public IActionResult GetAll([FromServices] IDependenteApplicationService dependenteApplicationService)
        {
            try
            {
                return Ok(dependenteApplicationService.GetAll());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id,
            [FromServices] IDependenteApplicationService dependenteApplicationService)
        {
            try
            {
                return Ok(dependenteApplicationService.GetById(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

    }
}