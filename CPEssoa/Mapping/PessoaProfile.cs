using AutoMapper;
using CPEssoaAPI.Domain.Entities;
using CPEssoaAPI.ViewModels;

namespace CPEssoaAPI.Mapping
{
    public class PessoaProfile : Profile
    {
        public PessoaProfile()
        {
            CreateMap<Pessoa, PessoaViewModel>();
        }
    }
}
