using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teste.FornecedoresApi.DTOs;
using Teste.FornecedoresApi.Repositorios;
using Teste.FornecedoresApi.Servicos;

namespace Teste.FornecedoresApi.Controlers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaService _empresaService;

        public EmpresaController(IEmpresaService empresaService)
        {
            _empresaService = empresaService;
        }
        //Definindo os EndPoints
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpresaDTO>>> Get() //Get que retorna todas as Empresas
        {
            var EmpresaDTO = await _empresaService.GetEmpresas();
            if (EmpresaDTO is null)
                return NotFound("Empresa não encontrada.");

            return Ok(EmpresaDTO);
        }

        [HttpGet("fornecedores")]
        public async Task<ActionResult<IEnumerable<EmpresaDTO>>> GetEmpresasFornecedores()
        {
            var empresaDTO = await _empresaService.GetEmpresasFornecedores();
            if (empresaDTO is null)
                return NotFound("Fornecedor não encontrado");

            return Ok(empresaDTO);
        }

        [HttpGet("{id:int}", Name = "GetEmpresas")]
        public async Task<ActionResult<EmpresaDTO>> Get(int id)
        {
            var empresaDTO = await _empresaService.GetEmpresasById(id);
            if (empresaDTO is null)
                return BadRequest("Empresa não encontrada");
            
            return Ok(empresaDTO);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] EmpresaDTO empresaDTO)
        {
            if (empresaDTO is null)
                return BadRequest("Dados inválidos");
            
            await _empresaService.AddEmpresa(empresaDTO);

            return new CreatedAtRouteResult("GetEmpresa", new {id = empresaDTO.EmpresaId},empresaDTO);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] EmpresaDTO empresaDTO)
        {
            if ((id != empresaDTO.EmpresaId) || (empresaDTO is null))
                return BadRequest();

            await _empresaService.UpdateEmpresa(empresaDTO);
            return Ok(empresaDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<EmpresaDTO>> Delete(int id)
        {
            var empresaDTO = _empresaService.GetEmpresasById(id);
            if (empresaDTO is null)
                return NotFound("Empresa não encontrada");

            await _empresaService.RemoveEmpresa(id);
            return Ok(empresaDTO);

        }
    }
}