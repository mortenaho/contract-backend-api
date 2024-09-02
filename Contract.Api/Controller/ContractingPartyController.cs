using AutoMapper;
using Contract.DTOs.embeded;
using Contract.DTOs.Request;
using Data.Repository;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace Contract.Controller;
[ApiController]
public class ContractingPartyController : CrudController<ContractingPartyRequest,ContractingPartyDetail,ContractingParty>
{
    public ContractingPartyController(IGenericRepository<ContractingParty> repository, IMapper mapper) : base(repository, mapper)
    {
    }
}