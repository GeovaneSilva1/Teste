using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste.FornecedoresApi.DTOs;

namespace Teste.FornecedoresApi.Servicos
{
    public interface IFornecedoresService
    {
        Task<IEnumerable<FornecedoresDTO>> GetFornecedores();
        Task<FornecedoresDTO> GetFornecedoresById(int id);
        Task AddFornecedores(FornecedoresDTO fornecedoresDTO);
        Task UpdateFornecedores(FornecedoresDTO fornecedoresDTO);
        Task RemoveFornecedores(int id);
        
    }
}