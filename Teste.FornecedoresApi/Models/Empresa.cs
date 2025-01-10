namespace Teste.FornecedoresApi.Models;
    public class Empresa
    {
        public int EmpresaId {get;set;}
        public string? Nome {get;set;}
        public ICollection<Fornecedores>? Fornecedores {get;set;}
    }