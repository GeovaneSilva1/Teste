using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste.FornecedoresApi.Models;

namespace Teste.FornecedoresApi.Repositorios
{
    public interface IEmpresaRepository
    {
        Task<IEnumerable<Empresa>> GetAll();
        Task<IEnumerable<Empresa>> GetEmpresasFornecedores();
        Task<Empresa> GetById(int id);
        Task<Empresa> Create(Empresa empresa);
        Task<Empresa> Update(Empresa empresa);
        Task<Empresa> Delete(int id);

    }
}