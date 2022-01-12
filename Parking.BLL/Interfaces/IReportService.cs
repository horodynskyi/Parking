using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Parking.BLL.Interfaces;

public interface IReportService<T>
{
    Document CreateDocument(string tittle,List<T> list);
}