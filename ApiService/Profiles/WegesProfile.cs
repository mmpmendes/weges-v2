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
        CreateMap<CertificadoERS, CertificadoErsDTO>().ReverseMap();
        CreateMap<LicencaERS, LicencaErsDTO>().ReverseMap();
    }
}

