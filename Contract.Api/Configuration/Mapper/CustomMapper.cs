using AutoMapper;
using Contract.DTOs.Request;

namespace Contract.Configuration.Mapper;

public class CustomMapper:Profile
{
    public CustomMapper()
    {
        CreateMap<Model.Entities.Contract, ContractRequest>().ReverseMap();
        CreateMap<Model.Entities.Contract, DTOs.embeded.Contract>().ReverseMap();
    }
}