using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Teste.FornecedoresApi.Context;
using Teste.FornecedoresApi.Models;

namespace Teste.FornecedoresApi.Repositorios
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly AppDbContext _Context;

        public EmpresaRepository(AppDbContext context)
        {
            _Context = context;
        }

        public async Task<IEnumerable<Empresa>> GetAll()
        {
            //Tem que ser alterado em produção, para não retornar tudo na memória
            return await _Context.Empresas.ToListAsync();
        }
        public async Task<IEnumerable<Empresa>> GetEmpresasFornecedores()
        {
            return await _Context.Empresas.Include(c=> c.Fornecedores).ToListAsync();
        }
        public async Task<Empresa> GetById(int id)
        {
            return await _Context.Empresas.Where(c=> c.EmpresaId == id).FirstOrDefaultAsync();
        }
        public async Task<Empresa> Create(Empresa empresa)
        {
            _Context.Empresas.Add(empresa);
            await _Context.SaveChangesAsync();
            return empresa;
        }
        public async Task<Empresa> Update(Empresa empresa)
        {
            _Context.Entry(empresa).State = EntityState.Modified;
            await _Context.SaveChangesAsync();
            return empresa;
        }
        public async Task<Empresa> Delete(int id)
        {
            var empresa = await GetById(id);
            _Context.Empresas.Remove(empresa);
            await _Context.SaveChangesAsync();
            return empresa;
        }
    }
}