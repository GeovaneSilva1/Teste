using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Teste.FornecedoresApi.Models;
using Teste.FornecedoresApi.DTOs;

namespace Teste.FornecedoresApi.DTOs.Mapeamentos
{
    
    public class MappingProfile: Profile
    {
        //Perfis de mapeamento
        public MappingProfile()
        {
            CreateMap<Empresa,EmpresaDTO>().ReverseMap();

            CreateMap<FornecedoresDTO,Fornecedores>();

            CreateMap<Fornecedores,FornecedoresDTO>()
                .ForMember(x => x.EmpresaNome, opt => opt.MapFrom(src => src.Empresa.Nome));
        }
    }
}
