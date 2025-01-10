using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Teste.FornecedoresApi.Context;
using Teste.FornecedoresApi.Models;

namespace Teste.FornecedoresApi.Repositorios
{
    public class FornecedoresRepository: IFornecedoresRepository
    {
        //Injeção de dependencia do contexto
        private readonly AppDbContext _Context;

        public FornecedoresRepository(AppDbContext context)
        {
            _Context = context;
        }

        public async Task<IEnumerable<Fornecedores>> GetAll()
        {
            return await _Context.Fornecedores.Include(c => c.Empresa).ToListAsync();
        }

        public async Task<Fornecedores> GetById(int id)
        {
            return await _Context.Fornecedores.Include(c => c.Empresa).Where(p=> p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Fornecedores> Create(Fornecedores fornecedores)
        {
             _Context.Fornecedores.Add(fornecedores);
            await _Context.SaveChangesAsync();
            return fornecedores;
        }

        public async Task<Fornecedores> Update(Fornecedores fornecedores)
        {
            _Context.Entry(fornecedores).State = EntityState.Modified;
            await _Context.SaveChangesAsync();
            return fornecedores;
        }
        public async Task<Fornecedores> Delete(int id)
        {
            var fornecedores = await GetById(id);
            _Context.Fornecedores.Remove(fornecedores);
            await _Context.SaveChangesAsync();
            return fornecedores;
        }

    }
}