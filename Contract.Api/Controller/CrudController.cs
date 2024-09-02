using System.Security.Claims;
using AutoMapper;
using Common.ModelBuilder;
using Contract.DTOs;
using Contract.DTOs.Request;
using Contract.DTOs.Response;
using Data.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Entities;

namespace Contract.Controller
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class CrudController<TDto, TSelectDto, TEntity> : ControllerBase
        where TEntity : class, IEntity, new()
    {
        protected readonly IGenericRepository<TEntity> Repository;
        protected readonly IMapper Mapper;

        public CrudController(IGenericRepository<TEntity> repository, IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }

        [HttpGet]
        public GeneralResponse<IEnumerable<TSelectDto>> Get()
        {
            var res = Repository.TableNoTracking.WhereNotDeleted().ToList();
            var mapperRes = Mapper.Map<List<TSelectDto>>(res);
            return new GeneralResponse<IEnumerable<TSelectDto>>()
            {
                ResponseCode = 100,
                ResponseMessage = "Operation success",
                ResponseBody = mapperRes
            };
        }

        [HttpGet("{id}")]
        public GeneralResponse<TSelectDto> Get(long id)
        {
            var res = Repository.GetById(id);
            if (res == null)
            {
                return new GeneralResponse<TSelectDto>()
                {
                    ResponseCode = 404,
                    ResponseMessage = "Not found"
                };
            }
            var mapperRes = Mapper.Map<TSelectDto>(res);
            return new GeneralResponse<TSelectDto>()
            {
                ResponseCode = 100,
                ResponseMessage = "Operation success",
                ResponseBody = mapperRes
            };
        }

        [HttpPost]
        public GeneralResponse Add(TDto request)
        {
            var entity = Mapper.Map<TEntity>(request);
            Repository.Add(entity);
            return new GeneralResponse()
            {
                ResponseCode = 100,
                ResponseMessage = "Operation successful"
            };
        }

        [HttpPut]
        public GeneralResponse Update(TDto request)
        { 
            var entity = Mapper.Map<TEntity>(request);
            Repository.Update(entity);
            return new GeneralResponse()
            {
                ResponseCode = 100,
                ResponseMessage = "Operation successful"
            };
        }

        [HttpDelete("{id}")]
        public GeneralResponse Delete(long id)
        {
            Repository.Delete(id);
            return new GeneralResponse()
            {
                ResponseCode = 100,
                ResponseMessage = "Operation successful"
            };
        }
    }
}
