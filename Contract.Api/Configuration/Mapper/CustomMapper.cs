using AutoMapper;
using Contract.DTOs.Request;

namespace Contract.Configuration.Mapper;

public class CustomMapper:Profile
{
    public CustomMapper()
    {
        CreateMap<Model.Entities.Contract, ContractRequest>().ReverseMap();
        CreateMap<Model.Entities.Contract, DTOs.embeded.Contract>()
            .ForMember(p=>p.StartDate,c=>c.MapFrom(d=>d.StartDate.ToShortDateString()))
            .ForMember(p=>p.EndDate,c=>c.MapFrom(d=>d.EndDate.ToShortDateString()))
            .ReverseMap();
    }
}