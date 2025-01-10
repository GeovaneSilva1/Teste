namespace Teste.FornecedoresApi.Models;

    public class Fornecedores
    {
        public int Id {get;set;}
        public string? Nome {get;set;}
        public string? Email {get;set;}
        public Empresa? Empresa {get;set;}
        public int EmpresaId {get;set;}

    }