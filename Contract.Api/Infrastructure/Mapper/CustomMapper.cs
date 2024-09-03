using AutoMapper;
using Contract.DTOs.Request;

namespace Contract.Configuration.Mapper;

public class CustomMapper:Profile
{
    public CustomMapper()
    {
        CreateMap<Entities.Contract, ContractRequest>().ReverseMap();
        CreateMap<Entities.Contract, DTOs.embeded.Contract>()
            .ForMember(p => p.StartDate, c => c.MapFrom(d => d.StartDate.ToString("yyyy/MM/dd")))
            .ForMember(p => p.EndDate, c => c.MapFrom(d => d.EndDate.ToString("yyyy/MM/dd")))
            .ForPath(p => p.ContractingName, c => c.MapFrom(d => d.ContractingParty.ContractingPartyName))
            .ForPath(p => p.ContractingPartyId, c => c.MapFrom(d => d.ContractingParty.ContractingPartyId));
        
        CreateMap<DTOs.embeded.Contract,Entities.Contract>()
            .ForMember(p => p.StartDate, c => c.MapFrom(d =>DateTime.Parse(d.StartDate)))
            .ForMember(p => p.EndDate, c => c.MapFrom(d => DateTime.Parse(d.EndDate)));
        CreateMap<Entities.ContractingParty, ContractingPartyRequest>().ReverseMap();
        CreateMap<Entities.ContractingParty, DTOs.embeded.ContractingPartyDetail>().ReverseMap();
        
    }
}