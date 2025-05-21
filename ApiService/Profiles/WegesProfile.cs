using ApiModel.NeoModels;

using AutoMapper;

using SharedKernel.DTO;

namespace ApiService.Profiles;
public class WegesProfile : Profile
{
    public WegesProfile()
    {
        //CODCAES
        CreateMap<Entidade, EntidadeDTO>().ReverseMap();

        CreateMap<Estabelecimento, EstabelecimentoDTO>();

        CreateMap<EstabelecimentoDTO, Estabelecimento>();
        CreateMap<DirecaoClinica, DirecaoClinicaDTO>().ReverseMap();
        CreateMap<Servico, ServicoDTO>().ReverseMap();
        CreateMap<CertificadoERS, CertificadoErsDTO>();
        CreateMap<CertificadoErsDTO, CertificadoERS>();

        CreateMap<LicencaERS, LicencaErsDTO>().ReverseMap();
    }
}

