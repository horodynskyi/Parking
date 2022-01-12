using iTextSharp.text;
using iTextSharp.text.pdf;
using Parking.BLL.Interfaces;

namespace Parking.BLL.Services;

public class ReportService<T>:IReportService<T> where T:class,new()
{
    private Document _document;
    private FileStream _fs;
    private PdfWriter _writer;
    public ReportService( PdfWriter writer)
    {
        
        _writer = writer;
        _document = new Document(PageSize.A4, 25, 25, 30, 30);
    }

    public Document CreateDocument(string tittle,List<T> list)
    {
        try
        {
            _fs = new FileStream($"{tittle}-{DateTime.Now.ToString("yy-MM-dd")}.pdf", FileMode.Create, FileAccess.Write);
            // FileStream _fs = new FileStream($"{tittle}-{DateTime.Now.ToString("yy-MM-dd")}.pdf", FileMode.Create, FileAccess.Write,FileShare.None,4096,FileOptions.DeleteOnClose);
            _writer = PdfWriter.GetInstance(_document,_fs);
            _document.Open();
            _document.Add(CreateHeader(tittle));
            _document.Add(CreateTable(list));
            _document.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        return _document;
    }

    private Paragraph CreateHeader(string tittle)
    {
        var header = new Paragraph(tittle);
        header.SpacingAfter = 25f;
        header.Alignment = 1;
        return new Paragraph();
    }
    private PdfPTable CreateTable(List<T> list)
    {
        
        var props = typeof(T).GetProperties();
        PdfPTable table = new PdfPTable(props.Length);
        foreach (var prop in props)
        {
            table.AddCell(prop.Name);
        }
        foreach (var item in list)
        {
            foreach (var prop in props)
            {
                table.AddCell(""+ prop.GetValue(item));
            }
        }

        return table;
    }
    
}