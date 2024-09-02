using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Entities;

namespace Contract.DTOs;
public abstract class BaseDto<TDto, TEntity> 
    where TDto : class, new()
    where TEntity : class, IEntity, new()
{
  
    public TEntity ToEntity(IMapper mapper,TDto dto)
    {
        return mapper.Map<TEntity>(dto);
    }
 
    public static TDto FromEntity(IMapper mapper, TEntity model)
    {
        return mapper.Map<TDto>(model);
    }

 
}