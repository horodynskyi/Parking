using Twilio.Types;

namespace Parking.BLL.Options;

public class TwilioOptions
{
    public const string Twilio = "Twilio";
    public string accountSid { get; set; } = String.Empty;
    public string authToken { get; set; } = String.Empty;
    public string senderNumber { get; set; } = String.Empty;

    public PhoneNumber GetPhoneNumber()
    {
        return new PhoneNumber(senderNumber);
    }
}