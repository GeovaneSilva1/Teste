using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Teste.FornecedoresApi.Models;

namespace Teste.FornecedoresApi.DTOs
{
    public class EmpresaDTO
    {
        public int EmpresaId {get;set;}
        
        [Required(ErrorMessage = "O Nome é Obrigatório!")]
        [MinLength(3)]
        [MaxLength(100)]
        public string? Nome {get;set;}
        public ICollection<Fornecedores>? Fornecedores {get;set;}
    }
}