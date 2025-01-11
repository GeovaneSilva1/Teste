using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Teste.FornecedoresApi.DTOs;
using Teste.FornecedoresApi.Models;
using Teste.FornecedoresApi.Servicos;

namespace Teste.FornecedoresApi.Controlers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FornecedoresController : ControllerBase
    {
        private readonly IFornecedoresService _FornecedoresService;
        public FornecedoresController(IFornecedoresService fornecedoresService)
        {
            _FornecedoresService = fornecedoresService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FornecedoresDTO>>> Get()
        {
            var fornecedoresDTO = await _FornecedoresService.GetFornecedores();
            if (fornecedoresDTO is null)
                return NotFound("Fornecedores não encontrados.");
            
            return Ok(fornecedoresDTO);
        }

        [HttpGet("{id:int}", Name = "GetFornecedores")]
        public async Task<ActionResult<FornecedoresDTO>> Get(int id)
        {
            var fornecedoresDTO = await _FornecedoresService.GetFornecedoresById(id);
            if (fornecedoresDTO is null)
                return BadRequest("Fornecedor não encontrado.");
            
            return Ok(fornecedoresDTO);
        }

        [HttpPost]
        public async Task<ActionResult<FornecedoresDTO>> Post([FromBody] FornecedoresDTO fornecedoresDTO)
        {
            if (fornecedoresDTO is null)
                return BadRequest("Dados de Fornecedores Inválidos");

            await _FornecedoresService.AddFornecedores(fornecedoresDTO);

            var crianovo = new CreatedAtRouteResult("GetFornecedores", new {id = fornecedoresDTO.Id}, fornecedoresDTO);
            return Ok(crianovo);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<FornecedoresDTO>> Put(int id,[FromBody] FornecedoresDTO fornecedoresDTO)
        {
            if ((fornecedoresDTO is null) || (id != fornecedoresDTO.Id))
                return BadRequest("Dados Inválidos");

            await _FornecedoresService.UpdateFornecedores(fornecedoresDTO);

            return Ok(fornecedoresDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<FornecedoresDTO>> Delete(int id)
        {
            var fornecedoresDTO = _FornecedoresService.GetFornecedoresById(id);

            if (fornecedoresDTO is null)
                return NotFound("Fornecedores não encontrado.");
            
            await _FornecedoresService.RemoveFornecedores(id);

            return Ok(fornecedoresDTO);
        }
    }
}