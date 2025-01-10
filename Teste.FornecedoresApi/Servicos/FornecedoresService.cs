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
    public class FornecedoresService: IFornecedoresService
    {
        private readonly IMapper _mapper;
        private IFornecedoresRepository _fornecedoresRepository;

        public FornecedoresService(IMapper mapper, IFornecedoresRepository fornecedoresRepository)
        {
            _mapper = mapper;
            _fornecedoresRepository = fornecedoresRepository;
        }
        public async Task<IEnumerable<FornecedoresDTO>> GetFornecedores()
        {
            var fornecedoresEntity = await _fornecedoresRepository.GetAll();
            return _mapper.Map<IEnumerable<FornecedoresDTO>>(fornecedoresEntity);
        }

        public async Task<FornecedoresDTO> GetFornecedoresById(int id)
        {
            var fornecedoresEntity = await _fornecedoresRepository.GetById(id);
            return _mapper.Map<FornecedoresDTO>(fornecedoresEntity);
        }

        public async Task AddFornecedores(FornecedoresDTO fornecedoresDTO)
        {
            var fornecedoresEntity = _mapper.Map<Fornecedores>(fornecedoresDTO);
            await _fornecedoresRepository.Create(fornecedoresEntity);
            fornecedoresDTO.Id = fornecedoresEntity.Id;
        }

        public async Task UpdateFornecedores(FornecedoresDTO fornecedoresDTO)
        {
            var fornecedoresEntity = _mapper.Map<Fornecedores>(fornecedoresDTO);
            await _fornecedoresRepository.Update(fornecedoresEntity);
        }

        public async Task RemoveFornecedores(int id)
        {
            var fornecedoresEntity = await _fornecedoresRepository.GetById(id);
            if (fornecedoresEntity is not null)
                await _fornecedoresRepository.Delete(fornecedoresEntity.Id);
            
        }
    }
}