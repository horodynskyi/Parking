using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Parking.BLL.DTO;
using Parking.BLL.Interfaces;
using Parking.DAL.Models;

namespace Parking.WEB.Controllers;
[ApiController]
[Route("api/arrival")]
public class ArrivalController:ControllerBase
{
    private readonly IArrivalService _service;
    private readonly IMapper _mapper;

    public ArrivalController(IArrivalService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var res = await _service.Get();
        var arrivals = _mapper.Map<IEnumerable<Arrival>>(res);
        return Ok(arrivals);
    }

    [HttpPost]
    public async Task<IActionResult> Create(ArrivalDto arrivalDto)
    {
        var arrival = _mapper.Map<Arrival>(arrivalDto);
        var valResult = await _service.Validation(arrival);
        if (valResult.IsValid)
        {
            await _service.Create(arrival);
            return Ok();
        }
        return BadRequest(valResult.Errors.Select(x => new { Error = x.ErrorMessage, Code = x.ErrorCode }).ToList());
       
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        var res = await _service.GetById(id);
        var arrivals = _mapper.Map<Arrival>(res);
        return Ok(arrivals);
    }

    [HttpPut]
    public async Task<IActionResult> Update(ArrivalDto arrivalDto)
    {
        var arrival = _mapper.Map<Arrival>(arrivalDto);
        var valResult = await _service.Validation(arrival);
        if (valResult.IsValid)
        {
            await _service.Update(arrival);
            return Ok();
        }
        return BadRequest(valResult.Errors.Select(x => new { Error = x.ErrorMessage, Code = x.ErrorCode }).ToList());
        
    }
}