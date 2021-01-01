using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using System.Drawing;
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
    public partial class WebForm3 : System.Web.UI.Page
    {
        private conectarid cbd = new conectarid();
        private string fecha_corte;
        public string tablaPres = "";
        public string total = "";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void genera_corte_Click(object sender, EventArgs e)
        {
            fecha_corte = calFcorte.SelectedDate.ToString();

            string datReci = null;/*aqui recibiremos los datos*/
            string secReg = "";/*secmento por registro aqui*/
            string secCad = "";/*cada uno tiene un atributo*/
            /*controlaremos el siclo or la longitud de cadena y registro*/
            int lonReg = 0, lonCad = 0, caso = 0;
            double totalar = 0, totalmon = 0;
            // System.Windows.Forms.ListViewItem lista = new System.Windows.Forms.ListViewItem();





            datReci = cbd.genera_corte(fecha_corte);
            lonCad = datReci.Length;/*cuarda la longitud de la cadena que reciobio de la DB*/

            while (lonCad > 1)
            {
                tablaPres += "<tr>";/*abre renglon*/
                secReg = datReci.Substring(0, datReci.IndexOf("$"));/*guarda el primer registro  en secreg*/
                /*cortamos la cadena que ya tomamos*/
                datReci = datReci.Substring(datReci.IndexOf("$") + 1);
                lonReg = secReg.Length;/*longitud del registro*/
                while (lonReg > 1)/*para partir el registro*/
                {
                    secCad = secReg.Substring(0, secReg.IndexOf("|"));
                    secReg = secReg.Substring(secReg.IndexOf("|") + 1);

                    switch (caso)
                    {
                        case 0:
                            tablaPres += "<td class=\"td_t\">" + secCad + "</td>";

                            break;
                        case 1:
                            tablaPres += "<td class=\"td_t\">" + secCad + "</td>";
                            totalmon = totalmon + Double.Parse(secCad);
                            break;
                        case 2:
                            tablaPres += "<td class=\"td_t\">" + secCad + "</td>";
                            totalar = totalar + Double.Parse(secCad);
                            break;
                    }
                    caso++;

                    lonReg = secReg.Length;/*longitud de la cadena despues del corte*/
                }
                tablaPres += "</tr>";
                caso = 0;
                lonCad = datReci.Length;
            }

            total = "<tr  class=\"total\">" + "<th class=\"th_t\">" + "Total" + "</th>" + "<th class=\"th_t\">" + Convert.ToString(totalmon) + "</th>" + "<th class=\"th_t\">" + Convert.ToString(totalar) + "</th>" + "</tr>";
        }

        protected void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void genera_pdf_Click(object sender, EventArgs e)
        {
            crea_pdf();
        }

        private void crea_pdf()
        {
            DataTable tabla = new DataTable();
            tabla = cbd.genra_reporte("2020-12-31");



            // Declare an object variable.
            object sumarti, sumTotal;
            sumarti = tabla.Compute("Sum(num_arti)", string.Empty);
            sumTotal = tabla.Compute("Sum(total)", string.Empty);



            PdfWriter pdfWriter = new PdfWriter("C:\\Users\\crizs\\proyecto_BD\\Reporte.pdf");
            PdfDocument pdf = new PdfDocument(pdfWriter);
            Document document = new Document(pdf, PageSize.A4);

            document.SetMargins(60, 20, 55, 20);
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
        }
    }
}