using ApiModel.Models;

using AutoMapper;

using SharedKernel.DTO;

namespace ApiService.Profiles;
public class WegesProfile : Profile
{
    public WegesProfile()
    {
        //CODCAES
        CreateMap<CodCae, CodCaeDTO>().ReverseMap();
        //ENTIDADE
        CreateMap<Entidade, EntidadeDTO>().ReverseMap();

        CreateMap<Estabelecimento, EstabelecimentoDTO>().ReverseMap();
        CreateMap<DirecaoClinica, DirecaoClinicaDTO>().ReverseMap();
        CreateMap<Servico, ServicoDTO>().ReverseMap();
        CreateMap<CertificadoERS, CertificadoErsDTO>()
             .ForMember(dest => dest.Ficheiro, opt => opt.MapFrom(src => src.Ficheiro));
        CreateMap<CertificadoErsDTO, CertificadoERS>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Ficheiro, opt => opt.MapFrom(src => src.Ficheiro)); ;

        CreateMap<LicencaERS, LicencaErsDTO>().ReverseMap();
        CreateMap<Tipologia, TipologiaDTO>().ReverseMap();
        CreateMap<Colaborador, ColaboradorDTO>().ReverseMap();
        CreateMap<Colaborador, CorpoClinicoDTO>().ReverseMap();
        CreateMap<Ficheiro, FicheiroDTO>().ReverseMap();
    }
}

