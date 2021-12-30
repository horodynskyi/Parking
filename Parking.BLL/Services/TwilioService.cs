using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;
using Parking.BLL.Interfaces;
using Parking.BLL.Options;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Parking.BLL.Services;

public class TwilioService:ITwilioService
{
    private readonly TwilioOptions _options;
   
    public TwilioService(IOptions<TwilioOptions> options)
    {
        _options = options.Value;
        
 
        
    }

    public string SendNotification(string text, string phoneNumber)
    {
        TwilioClient.Init(_options.accountSid,_options.authToken);
        var message = MessageResource.Create(
            body: text,
            from: new Twilio.Types.PhoneNumber("+16076008470"),
            to: new PhoneNumber(phoneNumber)
        );
        return message.Sid;
    }
}