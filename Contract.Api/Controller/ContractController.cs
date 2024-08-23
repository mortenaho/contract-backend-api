﻿using System.Security.Claims;
using AutoMapper;
using Contract.DTOs.Request;
using Contract.DTOs.Response;
using Contract.Repository;
using Contract.Repository.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Contract.Controller;

[ApiController]
[Route("api/v1/[controller]/[action]")]
public class ContractController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public ContractController(IMapper mapper,IUnitOfWork  unitOfWork)
    {
        _unitOfWork = unitOfWork;
        this._mapper = mapper;
    }

    [Authorize]
    [HttpGet]
    public GeneralResponse<IEnumerable<DTOs.embeded.Contract>> Get()
    {
        var res = _unitOfWork.Contract.GetAll().ToList();
        var mapperRes=_mapper.Map<List<DTOs.embeded.Contract>>(res);
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
        var res = _unitOfWork.Contract.GetById(id);
        var mapperRes=_mapper.Map<DTOs.embeded.Contract>(res);
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
        var contract = _mapper.Map<Model.Entities.Contract>(request);
        contract.UserId = userId;
        _unitOfWork.Contract.Add(contract);
        _unitOfWork.Save();
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
        var contract = _mapper.Map<Model.Entities.Contract>(request);
        contract.UserId = userId;
        _unitOfWork.Contract.Update(contract);
        _unitOfWork.Save();
        return new GeneralResponse()
        {
            ResponseCode = 100,
            ResponseMessage = "operation is success full"
        };
    }
}