

using Microsoft.AspNetCore.Mvc;
using Parking.BLL.Interfaces;
using Twilio.AspNet.Core;

namespace Parking.WEB.Controllers;
[ApiController]
[Route("sms")]
public class SmsController:ControllerBase
{
    private readonly ITwilioService _service;

    public SmsController(ITwilioService service)
    {
        _service = service;
    }

    [HttpPost]
    public string Sendms()
    {
       var msg = _service.SendNotification("Го в доту", "+380508727999");
       return msg;
    }
    
}