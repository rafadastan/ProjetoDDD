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
    public class PlanoController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(PlanoCadastroModel model,
            [FromServices] IPlanoApplicationService planoApplicationService)
        {
            try
            {
                planoApplicationService.Insert(model);
                return Ok("Plano Cadastrado com sucesso.");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(PlanoEdicaoModel model,
            [FromServices] IPlanoApplicationService planoApplicationService)
        {
            try
            {
                planoApplicationService.Update(model);
                return Ok("Plano Alterado com sucesso.");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id,
            [FromServices] IPlanoApplicationService planoApplicationService)
        {
            try
            {
                planoApplicationService.Delete(id);
                return Ok("Plano Excluído com sucesso.");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }


        [HttpGet]
        public IActionResult GetAll([FromServices] IPlanoApplicationService planoApplicationService)
        {
            try
            {
                return Ok(planoApplicationService.GetAll());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id,
            [FromServices] IPlanoApplicationService planoApplicationService)
        {
            try
            {
                return Ok(planoApplicationService.GetById(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

    }
}