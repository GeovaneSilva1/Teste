using Microsoft.EntityFrameworkCore;
using Teste.FornecedoresApi.Models;

namespace Teste.FornecedoresApi.Context;
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Empresa> Empresas {get;set;}
        public DbSet<Fornecedores> Fornecedores {get;set;}

    //Fluent API
    protected override void OnModelCreating(ModelBuilder mb)
    {
        //Empresas
        mb.Entity<Empresa>().HasKey(c => c.EmpresaId);

        mb.Entity<Empresa>().
        Property(c => c.Nome).
        HasMaxLength(100).
        IsRequired();

        //Fornecedores
        mb.Entity<Fornecedores>().
        Property(c => c.Nome).
        HasMaxLength(100).
        IsRequired();

        mb.Entity<Fornecedores>().
        Property(c => c.Email).
        HasMaxLength(255).
        IsRequired();
        
        mb.Entity<Empresa>().
        HasMany(g => g.Fornecedores).
        WithOne(c => c.Empresa).
        IsRequired().
        OnDelete(DeleteBehavior.Cascade);

        mb.Entity<Empresa>().
        HasData(
            new Empresa
            {
                EmpresaId = 1,
                Nome = "Ambev",
            },
            new Empresa 
            {
                EmpresaId = 2,
                Nome = "Coca-Cola",
            }
        );
        
    }

}