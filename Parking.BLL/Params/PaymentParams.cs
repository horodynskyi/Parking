namespace Parking.BLL.Params;

public class PaymentParams:QueryStringParameters
{
    public int MinSum { get; set; } = 0;
    public int MaxSum { get; set; }
    public int minDate { get; set; } = 0;
    public int maxDate { get; set; } = DateTime.Now.Year;
    public bool ValidSumRange => MinSum<MaxSum;
    public bool ValidDateRange => minDate < maxDate;
}