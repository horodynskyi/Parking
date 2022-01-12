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
    private HttpClient _client;
    public TwilioService(IOptions<TwilioOptions> options, HttpClient client)
    {
        _client = client;
        _options = options.Value;
    }

    public string SendNotification(string text, string phoneNumber)
    {
        TwilioClient.Init(_options.accountSid,_options.authToken);
        var message = MessageResource.Create(
            body: text,
            from: _options.GetPhoneNumber(),
            to: new PhoneNumber(phoneNumber)
        );
        return message.Sid;
    }

    public async Task<HttpResponseMessage> VerifyNumber(string phoneNumber)
    {
        _client.DefaultRequestHeaders.Add("X-Authy-API-Key", _options.authToken);
        var requestContent = new FormUrlEncodedContent(new[] {
            new KeyValuePair<string, string>("via", "sms"),
            new KeyValuePair<string, string>("phone_number", "0958550449"),
            new KeyValuePair<string, string>("country_code", "38"),
        });
        HttpResponseMessage response = await _client.PostAsync(
            "https://api.authy.com/protected/json/phones/verification/start",
            requestContent);
        return response;
    }
}