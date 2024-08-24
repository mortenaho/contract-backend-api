using System.Security.Claims;
using AutoMapper;
using Common.ModelBuilder;
using Contract.DTOs.Request;
using Contract.DTOs.Response;
using Data;
using Data.Repository;
using Data.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Contract.Controller;

[ApiController]
[Route("api/v1/[controller]/[action]")]
public class ContractController : ControllerBase
{
    private readonly IGenericRepository<Entities.Contract> repositiry;
    private readonly IMapper _mapper;

    public ContractController(IMapper mapper, IGenericRepository<Entities.Contract> _repositiry)
    {
        repositiry = _repositiry;
        this._mapper = mapper;
    }
    
    
    [Authorize]
    [HttpGet]
    public GeneralResponse<IEnumerable<DTOs.embeded.Contract>> Get()
    {
        var res = repositiry.TableNoTracking.WhereNotDeleted().ToList();
        var mapperRes = _mapper.Map<List<DTOs.embeded.Contract>>(res);
        return new GeneralResponse<IEnumerable<DTOs.embeded.Contract>>()
        {
            ResponseCode = 100,
            ResponseMessage = "operation success",
            ResponseBody = mapperRes
        };
    }

    [Authorize]
    [HttpGet("{id}")]
    public GeneralResponse<DTOs.embeded.Contract> Get(long id)
    {
        var res = repositiry.GetById(id);
        var mapperRes = _mapper.Map<DTOs.embeded.Contract>(res);
        return new GeneralResponse<DTOs.embeded.Contract>()
        {
            ResponseCode = 100,
            ResponseMessage = "operation success",
            ResponseBody = mapperRes
        };
    }

    [Authorize]
    [HttpPost]
    public GeneralResponse Add(ContractRequest request)
    {
        string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var contract = _mapper.Map<Entities.Contract>(request);
        contract.UserId = userId;
        repositiry.Add(contract);
        
        return new GeneralResponse()
        {
            ResponseCode = 100,
            ResponseMessage = "operation is success full"
        };
    }

    [Authorize]
    [HttpPut]
    public GeneralResponse Update(ContractRequest request)
    {
        string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var contract = _mapper.Map<Entities.Contract>(request);
        contract.UserId = userId;
        repositiry.Update(contract);
        
        return new GeneralResponse()
        {
            ResponseCode = 100,
            ResponseMessage = "operation is success full"
        };
    }

    [Authorize]
    [HttpDelete("{id}")]
    public GeneralResponse Delete(long id)
    {
        string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        repositiry.Delete(id);
        
        return new GeneralResponse()
        {
            ResponseCode = 100,
            ResponseMessage = "operation is success full"
        };
    }
}