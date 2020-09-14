using AdministracaoContas.Api.ViewModels;
using AdministracaoContas.Business.Models;
using AutoMapper;

namespace AdministracaoContas.Api.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Despesa, DespesaViewModel>().ReverseMap();
        }
    }
}
