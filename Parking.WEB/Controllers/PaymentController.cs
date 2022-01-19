using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Parking.BLL.DTO;
using Parking.BLL.Interfaces;
using Parking.BLL.Params;
using Parking.DAL.Models;

namespace Parking.WEB.Controllers;
[ApiController]
[Route("api/payment")]
public class PaymentController:ControllerBase
{
    private readonly IPaymentService _service;
    private readonly IMapper _mapper;

    public PaymentController(IPaymentService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] PaymentParams paymentParams)
    {
        var res = await _service.Get(paymentParams);
        var payments = _mapper.Map<IEnumerable<PaymentDto>>(res);
        return Ok(payments);
    }

    [HttpPost]
    public async Task<IActionResult> Create(PaymentDto paymentDto)
    {
        var payment = _mapper.Map<Payment>(paymentDto);
        await _service.Create(payment);
        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        var res = await _service.GetById(id);
        var payments = _mapper.Map<PaymentDto>(res);
        return Ok(payments);
    }

    [HttpPut]
    public async Task<IActionResult> Update(PaymentDto paymentDto)
    {
        var payment = _mapper.Map<Payment>(paymentDto);
        await _service.Update(payment);
        return Ok();
    }
}