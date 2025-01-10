using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste.FornecedoresApi.DTOs;

namespace Teste.FornecedoresApi.Servicos
{
    public interface IEmpresaService
    {
        //o Serviço deve retornar os DTos para o cliente (Consumidor)
        Task<IEnumerable<EmpresaDTO>> GetEmpresas();
        Task<IEnumerable<EmpresaDTO>> GetEmpresasFornecedores();
        Task<EmpresaDTO> GetEmpresasById(int id);
        Task AddEmpresa(EmpresaDTO empresaDto);
        Task UpdateEmpresa(EmpresaDTO empresaDto);
        Task RemoveEmpresa(int id);
    }
}