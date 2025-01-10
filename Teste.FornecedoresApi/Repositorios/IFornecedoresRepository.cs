using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste.FornecedoresApi.Models;

namespace Teste.FornecedoresApi.Repositorios
{
    public interface IFornecedoresRepository
    {
        Task<IEnumerable<Fornecedores>> GetAll();
        Task<Fornecedores> GetById(int id);
        Task<Fornecedores> Create(Fornecedores fornecedores);
        Task<Fornecedores> Update(Fornecedores fornecedores);
        Task<Fornecedores> Delete(int id);
        
    }
}