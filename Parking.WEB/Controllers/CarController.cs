using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Parking.BLL.DTO;
using Parking.BLL.Interfaces;
using Parking.BLL.Services;
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
    public async Task<IActionResult> Get()
    {
        var res = _service.Get();
        var users = _mapper.Map<IEnumerable<CarDto>>(res);
        return Ok(res);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CarUserDto dto)
    {
        var car = _mapper.Map<Car>(dto);
        var user = _mapper.Map<User>(dto);
        await _service.Create(car);
        return Ok();
    }


}