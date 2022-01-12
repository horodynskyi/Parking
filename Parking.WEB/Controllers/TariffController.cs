using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Parking.BLL.DTO;
using Parking.BLL.Interfaces;
using Parking.DAL.Models;

namespace Parking.WEB.Controllers;
[ApiController]
[Route("api/tariff")]
public class TariffController:ControllerBase
{
    private readonly ITariffService _service;
    private readonly IMapper _mapper;

    public TariffController(ITariffService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var res = await _service.Get();
        var tariffs = _mapper.Map<IEnumerable<TariffDto>>(res);
        return Ok(tariffs);
    }

    [HttpPost]
    public async Task<IActionResult> Create(TariffDto tariffDto)
    {
        var tariff = _mapper.Map<Tariff>(tariffDto);
        var valResult = await _service.Validation(tariff);
        if (valResult.IsValid)
        {
            await _service.Create(tariff);
            return Ok();
        }
        return BadRequest(valResult.Errors.Select(x => new { Error = x.ErrorMessage, Code = x.ErrorCode }).ToList());
        
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        var res = await _service.GetById(id);
        var tariffs = _mapper.Map<TariffDto>(res);
        return Ok(tariffs);
    }

    [HttpPut]
    public async Task<IActionResult> Update(TariffDto tariffDto)
    {
        var tariff = _mapper.Map<Tariff>(tariffDto);
        var valResult = await _service.Validation(tariff);
        if (valResult.IsValid)
        {
            await _service.Update(tariff);
            return Ok();
            
        }
        return BadRequest(valResult.Errors.Select(x => new { Error = x.ErrorMessage, Code = x.ErrorCode }).ToList());
      
    }
}