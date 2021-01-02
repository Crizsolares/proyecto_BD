using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Kernel.Geom;
using iText.Layout.Element;
using iText.Kernel.Font;
using iText.IO.Font.Constants;
using System.Data;
using iText.Layout.Properties;

namespace NOMINA23
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        private conectarid cbd = new conectarid();
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        private void crea_pdf(string Fechaa )
        {
            DataTable tabla = new DataTable();
            tabla = cbd.genra_reporte(Fechaa);



            // Declare an object variable.
            object sumarti, sumTotal;
            sumarti = tabla.Compute("Sum(num_arti)", string.Empty);
            sumTotal = tabla.Compute("Sum(total)", string.Empty);



            PdfWriter pdfWriter = new PdfWriter("C:\\Users\\crizs\\proyecto_BD\\Reporte.pdf");
            PdfDocument pdf = new PdfDocument(pdfWriter);
            Document document = new Document(pdf, PageSize.A4);

            document.SetMargins(90, 20, 55, 20);
            PdfFont fontColumnas = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
            PdfFont fontContenido = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

            string[] columnas = { "Fecha", "Articulos", "Total" };
            float[] tamanio = { 6, 2, 2 };
            iText.Layout.Element.Table tablaimprime = new iText.Layout.Element.Table(UnitValue.CreatePercentArray(tamanio));
            tablaimprime.SetWidth(UnitValue.CreatePercentValue(100));
            foreach (string columna in columnas)
            {
                tablaimprime.AddHeaderCell(new Cell().Add(new Paragraph(columna).SetFont(fontColumnas)));
            }

            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                for (int j = 0; j < tabla.Columns.Count; j++)
                {
                    tablaimprime.AddCell(new Cell().Add(new Paragraph(tabla.Rows[i][j].ToString()).SetFont(fontContenido)));
                }
            }
            tablaimprime.AddCell(new Cell().Add(new Paragraph("Total: ").SetFont(fontColumnas)));
            tablaimprime.AddCell(new Cell().Add(new Paragraph(sumarti.ToString()).SetFont(fontColumnas)));
            tablaimprime.AddCell(new Cell().Add(new Paragraph(sumTotal.ToString()).SetFont(fontColumnas)));

            document.Add(tablaimprime);
            document.Close();

            var logo = new iText.Layout.Element.Image(iText.IO.Image.ImageDataFactory.Create("C:/Users/crizs/proyecto_BD/logo.png")).SetWidth(50);
            var logot = new iText.Layout.Element.Image(iText.IO.Image.ImageDataFactory.Create("C:/Users/crizs/proyecto_BD/logo_t.jpeg")).SetWidth(80);

            var plogo = new Paragraph("").Add(logo);
            var plogo_t = new Paragraph("").Add(logot);

            var titulo = new Paragraph("Reporte Semanal de Ventas");
            titulo.SetTextAlignment(TextAlignment.CENTER);
            titulo.SetFontSize(12);
            var dfecha = DateTime.Now.ToString("yyyy-MM-dd");
            var dhora = DateTime.Now.ToString("hh:mm:ss");
            var fecha = new Paragraph("Fecha: " + dfecha + "\nHora: " + dhora);
            /*hay que crear un pdf apartir del anteriro para gregar encabezado y pie de pagina*/
            PdfDocument pdfdoc = new PdfDocument(new PdfReader("C:\\Users\\crizs\\proyecto_BD\\Reporte.pdf"), new PdfWriter("C:\\Users\\crizs\\proyecto_BD\\ReportePdf.pdf"));
            Document doc = new Document(pdfdoc);

            int numeros = pdfdoc.GetNumberOfPages();

            for (int i = 1; i <= numeros; i++)
            {
                PdfPage pagina = pdfdoc.GetPage(i);
                float y = (pdfdoc.GetPage(i).GetPageSize().GetTop() - 15);
                doc.ShowTextAligned(plogo, 40, y + 8, i, TextAlignment.CENTER, VerticalAlignment.TOP, 0);
                doc.ShowTextAligned(plogo_t, 270, y + 8, i, TextAlignment.CENTER, VerticalAlignment.TOP, 0);
                doc.ShowTextAligned(titulo, 270, y - 50, i, TextAlignment.CENTER, VerticalAlignment.TOP, 0);
                doc.ShowTextAligned(fecha, 520, y - 15, i, TextAlignment.CENTER, VerticalAlignment.TOP, 0);

                doc.ShowTextAligned(new Paragraph(string.Format("página {0} de {1}", i, numeros)), pdfdoc.GetPage(1).GetPageSize().GetWidth() / 2, pdfdoc.GetPage(i).GetPageSize().GetBottom() + 30, i, TextAlignment.CENTER, VerticalAlignment.TOP, 0);



            }
            doc.Close();
        }

        protected void genera_pdf_Click(object sender, EventArgs e)
        {
            string fecha = Fechafin.SelectedDate.ToString();
           
            crea_pdf(fecha);
        }
    }
}