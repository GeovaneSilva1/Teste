using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Teste.FornecedoresApi.Models;

namespace Teste.FornecedoresApi.DTOs
{
    public class FornecedoresDTO
    {
        public int Id {get;set;}

        [Required(ErrorMessage = "O Nome é Obrigatório!")]
        [MinLength(3)]
        [MaxLength(100)]
        public string? Nome {get;set;}

        [Required(ErrorMessage = "O email é Obrigatório!")]
        [MinLength(5)]
        [MaxLength(200)]
        public string? Email {get;set;}

        public string? EmpresaNome {get;set;}
        
        [JsonIgnore]
        public Empresa? Empresa {get;set;}
        public int EmpresaId {get;set;}

    }
}