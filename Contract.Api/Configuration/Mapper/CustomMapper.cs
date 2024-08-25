using AutoMapper;
using Contract.DTOs.Request;

namespace Contract.Configuration.Mapper;

public class CustomMapper:Profile
{
    public CustomMapper()
    {
        CreateMap<Entities.Contract, ContractRequest>().ReverseMap();
        CreateMap<Entities.Contract, DTOs.embeded.Contract>()
            .ForMember(p=>p.StartDate,c=>c.MapFrom(d=>d.StartDate.ToString("yyyy/MM/dd")))
            .ForMember(p=>p.EndDate,c=>c.MapFrom(d=>d.EndDate.ToString("yyyy/MM/dd")))
            .ReverseMap();
    }
}