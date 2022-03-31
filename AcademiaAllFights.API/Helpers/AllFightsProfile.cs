using AcademiaAllFights.API.Dtos;
using AcademiaAllFights.API.Models;
using AutoMapper;

namespace AcademiaAllFights.API.Helpers
{
    public class AllFightsProfile : Profile
    {
        public AllFightsProfile()
        {
            CreateMap<Aluno, AlunoDto>()
                .ForMember(
                    dest => dest.Idade,
                    opt => opt.MapFrom(src => src.DataNascimento.GetAge())
                )

            CreateMap<Usuario, UsuarioDto>().ReverseMap();

            CreateMap<Usuario, UsuarioLoginDto>().ReverseMap();

        }
    }
}
