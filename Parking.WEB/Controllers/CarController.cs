using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Parking.BLL.DTO;
using Parking.BLL.Interfaces;
using Parking.BLL.Params;
using Parking.DAL.Models;

namespace Parking.WEB.Controllers;
[ApiController]
[Route("api/car")]
public class CarController:ControllerBase
{
    private readonly ICarService _service;
    private readonly IMapper _mapper;
   

    public CarController(ICarService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] CarParams parameters)
    {
        var res = await _service.Get(parameters);
        var cars = _mapper.Map<IEnumerable<CarDto>>(res);
        return Ok(cars);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CarDto carDto)
    {
        var car = _mapper.Map<Car>(carDto);
        var valResult = await _service.Validation(car);
        if (valResult.IsValid)
        {
            await _service.Create(car);
            return Ok();
        }
        return BadRequest(valResult.Errors.Select(x => new { Error = x.ErrorMessage, Code = x.ErrorCode }).ToList());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        var res = await _service.GetById(id);
        var cars = _mapper.Map<Car>(res);
        return Ok(cars);
    }

    [HttpPut]
    public async Task<IActionResult> Update(CarDto carDto)
    {
        var car = _mapper.Map<Car>(carDto);
        await _service.Update(car);
        return Ok();
    }
}