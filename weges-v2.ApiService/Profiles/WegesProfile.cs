using AutoMapper;

using weges_v2.ApiModel.Models;
using weges_v2.SharedKernel.DTO;

namespace weges_v2.ApiService.Profiles;
public class WegesProfile : Profile
{
    public WegesProfile()
    {
        //CODCAES
        CreateMap<CodCae, CodCaeDTO>().ReverseMap();
        //ENTIDADE
        CreateMap<Entidade, EntidadeDTO>().ReverseMap();

    }
}

