using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Parking.BLL.DTO;
using Parking.BLL.Interfaces;
using Parking.DAL.Models;

namespace Parking.WEB.Controllers;
[ApiController]
[Route("api/user")]
public class UserController:ControllerBase
{
    private readonly IUserService _service;
    private readonly IMapper _mapper;

    public UserController(IUserService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var res = await _service.Get();
        var users = _mapper.Map<IEnumerable<UserDto>>(res);
        return Ok(users);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody]UserDto userDto)
    {
        if (userDto == null) return BadRequest("Invalid JSON");
        var user = _mapper.Map<User>(userDto);
        var valResult = await _service.Validation(user);
        if (valResult.IsValid)
        {
            await _service.Create(user);
            return Ok();
        }
        return BadRequest(valResult.Errors.Select(x => new { Error = x.ErrorMessage, Code = x.ErrorCode }).ToList());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        var res = await _service.GetById(id);
        
        var users = _mapper.Map<User>(res);
        return Ok(users);
    }

    [HttpPut]
    public async Task<IActionResult> Update(UserDto userDto)
    {
        var user = _mapper.Map<User>(userDto);
        var valResult = await _service.Validation(user);
        if (valResult.IsValid)
        {
            await _service.Update(user);
            return Ok();
        }
        return BadRequest(valResult.Errors.Select(x => new { Error = x.ErrorMessage, Code = x.ErrorCode }).ToList());
        
    }
}