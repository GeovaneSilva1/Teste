using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Teste.FornecedoresApi.DTOs;
using Teste.FornecedoresApi.Models;
using Teste.FornecedoresApi.Repositorios;

namespace Teste.FornecedoresApi.Servicos
{
    public class EmpresaService : IEmpresaService
    {private readonly IEmpresaRepository _empresaRepository;
        private readonly IMapper _mapper;

        public EmpresaService(IEmpresaRepository empresaRepository, IMapper mapper)
        {
            _empresaRepository = empresaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmpresaDTO>> GetEmpresas()
        {
            var empresasEntity = await _empresaRepository.GetAll();
            return _mapper.Map<IEnumerable<EmpresaDTO>>(empresasEntity);
        }

        public async Task<IEnumerable<EmpresaDTO>> GetEmpresasFornecedores()
        {
            var empresasEntity = await _empresaRepository.GetEmpresasFornecedores();
            return _mapper.Map<IEnumerable<EmpresaDTO>>(empresasEntity);
        }

        public async Task<EmpresaDTO> GetEmpresasById(int id)
        {
            var empresasEntity = await _empresaRepository.GetById(id);
            return _mapper.Map<EmpresaDTO>(empresasEntity);
        }

        public async Task AddEmpresa(EmpresaDTO empresaDTO)
        {
            var empresasEntity = _mapper.Map<Empresa>(empresaDTO);
            await _empresaRepository.Create(empresasEntity);
            empresaDTO.EmpresaId = empresasEntity.EmpresaId;
        }

        public async Task UpdateEmpresa(EmpresaDTO empresaDTO)
        {
            var empresasEntity = _mapper.Map<Empresa>(empresaDTO);
            await _empresaRepository.Update(empresasEntity);
        }

        public async Task RemoveEmpresa(int id)
        {
            var empresasEntity = _empresaRepository.GetById(id).Result;
            await _empresaRepository.Delete(empresasEntity.EmpresaId);
        }
    }
}