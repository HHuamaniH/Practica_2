
using iTextSharp.text;
using iTextSharp.text.pdf;
using CEntidad = CapaEntidad.DOC.Ent_Reporte_OBSERVATORIO;
using CLogica = CapaLogica.DOC.Log_Reporte_OBSERVATORIO;

namespace CapaLogica
{
    public class PDFFooter : PdfPageEventHelper
    {
        // write on top of document
        public override void OnOpenDocument(PdfWriter writer, Document document)
        {
            base.OnOpenDocument(writer, document);
            PdfPTable tabFot = new PdfPTable(new float[] { 1F });
            tabFot.SpacingAfter = 10F;
            PdfPCell cell;
            tabFot.TotalWidth = 300F;
            cell = new PdfPCell(new Phrase(""));
            cell.Border = 0;
            tabFot.AddCell(cell);
            tabFot.WriteSelectedRows(0, -1, 150, document.Top, writer.DirectContent);
        }

        // write on start of each page
        public override void OnStartPage(PdfWriter writer, Document document)
        {
            base.OnStartPage(writer, document);
        }

        // write on end of each page
        public override void OnEndPage(PdfWriter writer, Document document)
        {
            CEntidad oCEntidad = new CEntidad();
            CLogica oCLogica = new CLogica();
            oCEntidad = oCLogica.RegMostrarFechaObserv(oCEntidad);
            base.OnEndPage(writer, document);
            PdfPTable tabFot = new PdfPTable(new float[] { 1F });
            PdfPCell cell;
            tabFot.TotalWidth = 200F;
            cell = new PdfPCell(new Phrase("Reporte Actualizado al:" + oCEntidad.FECHA.ToString()));
            cell.Border = 0;
            tabFot.AddCell(cell);
            tabFot.WriteSelectedRows(0, -1, 40, 30, writer.DirectContent);
            //table.WriteSelectedRows(0, -1, doc.Left + 200, doc.Top, writer.DirectContent);
        }

        //write on close of document
        public override void OnCloseDocument(PdfWriter writer, Document document)
        {
            base.OnCloseDocument(writer, document);
        }
    }
}

