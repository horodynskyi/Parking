using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Parking.BLL.DTO;
using Parking.BLL.Interfaces;
using Parking.DAL.Models;

namespace Parking.WEB.Controllers;
[ApiController]
[Route("api/status")]
public class StatusController:ControllerBase
{
    private readonly IStatusService _service;
    private readonly IMapper _mapper;

    public StatusController(IStatusService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var res = await _service.Get();
        var statuses = _mapper.Map<IEnumerable<Status>>(res);
        return Ok(statuses);
    }

    [HttpPost]
    public async Task<IActionResult> Create(StatusDto statusDto)
    {
        var status = _mapper.Map<Status>(statusDto);
        var valResult = await _service.Validation(status);
        if (valResult.IsValid)
        {
            await _service.Create(status);
            return Ok();
        }
        return BadRequest(valResult.Errors.Select(x => new { Error = x.ErrorMessage, Code = x.ErrorCode }).ToList());
      
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        var res = await _service.GetById(id);
        var statuses = _mapper.Map<Status>(res);
        return Ok(statuses);
    }

    [HttpPut]
    public async Task<IActionResult> Update(StatusDto statusDto)
    {
        var status = _mapper.Map<Status>(statusDto);
        var valResult = await _service.Validation(status);
        if (valResult.IsValid)
        {
            await _service.Update(status);
            return Ok();
        }
        return BadRequest(valResult.Errors.Select(x => new { Error = x.ErrorMessage, Code = x.ErrorCode }).ToList());
        
    }
}