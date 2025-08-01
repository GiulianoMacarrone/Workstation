using BE.Modelo;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Drawing;
using System.IO;

namespace BLL.Exportador
{
    public class ExportadorPDF
    {
        public void ImprimirOrdenDeTrabajo(OrdenDeTrabajo ot, string rutaDestino)
        {
            var doc = new Document(PageSize.A4, 40, 40, 40, 40);
            PdfWriter.GetInstance(doc, new FileStream(rutaDestino, FileMode.Create));
            doc.Open();

            var bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            var titleFont = new Font(bf, 14, Font.BOLD);
            var boldFont = new Font(bf, 10, Font.BOLD);
            var normalFont = new Font(bf, 10, Font.NORMAL);

            var container = new PdfPTable(1) { WidthPercentage = 100 };
            var containerCell = new PdfPCell
            {
                Border = Rectangle.BOX,
                Padding = 6f
            };

            var title = new Paragraph("ORDEN DE TRABAJO", titleFont)
            {
                Alignment = Element.ALIGN_CENTER
            };
            containerCell.AddElement(title);
            containerCell.AddElement(Chunk.NEWLINE);

            var header = new PdfPTable(4) { WidthPercentage = 100 };
            header.SetWidths(new float[] { 1.5f, 4f, 1.5f, 4f });

            header.AddCell(new PdfPCell(new Phrase("TITULO", boldFont)) { Border = Rectangle.NO_BORDER });
            header.AddCell(new PdfPCell(new Phrase(ot.titulo, normalFont)) { Border = Rectangle.NO_BORDER });
            header.AddCell(new PdfPCell(new Phrase("WORK RECORD", boldFont)) { Border = Rectangle.NO_BORDER });
            header.AddCell(new PdfPCell(new Phrase(ot.numeroOT, normalFont)) { Border = Rectangle.NO_BORDER });

            header.AddCell(new PdfPCell(new Phrase("FECHA", boldFont)) { Border = Rectangle.NO_BORDER });
            header.AddCell(new PdfPCell(new Phrase(ot.fechaInicio.ToString("dd/MM/yyyy"), normalFont)) { Border = Rectangle.NO_BORDER });
            header.AddCell(new PdfPCell(new Phrase("INTERVALO", boldFont)) { Border = Rectangle.NO_BORDER });
            header.AddCell(new PdfPCell(new Phrase(ot.trabajo.intervalo, normalFont)) { Border = Rectangle.NO_BORDER });

            header.AddCell(new PdfPCell(new Phrase("AERONAVE", boldFont)) { Border = Rectangle.NO_BORDER });
            header.AddCell(new PdfPCell(new Phrase(ot.aeronave, normalFont)) { Border = Rectangle.NO_BORDER });
            header.AddCell(new PdfPCell(new Phrase("MATRICULA", boldFont)) { Border = Rectangle.NO_BORDER });
            header.AddCell(new PdfPCell(new Phrase(ot.matricula, normalFont)) { Border = Rectangle.NO_BORDER });

            header.AddCell(new PdfPCell(new Phrase("SERIAL", boldFont)) { Border = Rectangle.NO_BORDER });
            var serialCell = new PdfPCell(new Phrase(ot.serial, normalFont))
            {
                Colspan = 3,
                Border = Rectangle.NO_BORDER
            };
            header.AddCell(serialCell);

            containerCell.AddElement(header);

            container.AddCell(containerCell);
            doc.Add(container);
            doc.Add(Chunk.NEWLINE);

            header.AddCell(new PdfPCell(new Phrase("REFERENCIA", boldFont)) { Border = Rectangle.NO_BORDER });
            var refCell = new PdfPCell(new Phrase(ot.trabajo.referencias, normalFont))
            {
                Colspan = 3,
                Border = Rectangle.NO_BORDER
            };
            header.AddCell(refCell);

            doc.Add(Chunk.NEWLINE);

            doc.Add(new Paragraph("Herramientas", boldFont));
            var toolsTable = new PdfPTable(3) { WidthPercentage = 100 };
            toolsTable.SetWidths(new float[] { 2f, 6f, 2f });
            toolsTable.AddCell(new PdfPCell(new Phrase("PN", boldFont)));
            toolsTable.AddCell(new PdfPCell(new Phrase("Descripción", boldFont)));
            toolsTable.AddCell(new PdfPCell(new Phrase("QTY", boldFont)));
            foreach (var h in ot.trabajo.listaHerramientas)
            {
                toolsTable.AddCell(new PdfPCell(new Phrase(h.PN, normalFont)));
                toolsTable.AddCell(new PdfPCell(new Phrase(h.Descripcion, normalFont)));
                toolsTable.AddCell(new PdfPCell(new Phrase(h.QTY.ToString(), normalFont)));
            }
            doc.Add(toolsTable);
            doc.Add(Chunk.NEWLINE);

            doc.Add(new Paragraph("Materiales", boldFont));
            var matsTable = new PdfPTable(3) { WidthPercentage = 100 };
            matsTable.SetWidths(new float[] { 2f, 6f, 2f });
            matsTable.AddCell(new PdfPCell(new Phrase("PN", boldFont)));
            matsTable.AddCell(new PdfPCell(new Phrase("Descripción", boldFont)));
            matsTable.AddCell(new PdfPCell(new Phrase("QTY", boldFont)));
            foreach (var m in ot.trabajo.listaMateriales)
            {
                matsTable.AddCell(new PdfPCell(new Phrase(m.PN, normalFont)));
                matsTable.AddCell(new PdfPCell(new Phrase(m.Descripcion, normalFont)));
                matsTable.AddCell(new PdfPCell(new Phrase(m.QTY.ToString(), normalFont)));
            }
            doc.Add(matsTable);
            doc.Add(Chunk.NEWLINE);

            doc.Add(new Paragraph("NOTA", boldFont));
            doc.Add(new Paragraph(ot.trabajo.nota, normalFont));
            doc.Add(Chunk.NEWLINE);

            doc.Add(new Paragraph("Tareas", boldFont));
            var taskTable = new PdfPTable(3) { WidthPercentage = 100 };
            taskTable.SetWidths(new float[] { 6f, 2f, 2f });
            taskTable.AddCell(new PdfPCell(new Phrase("Tarea", boldFont)));
            taskTable.AddCell(new PdfPCell(new Phrase("Mecánico", boldFont)));
            taskTable.AddCell(new PdfPCell(new Phrase("Inspector", boldFont)));
            foreach (var t in ot.listaTareasOT)
            {
                taskTable.AddCell(new PdfPCell(new Phrase(t.descripcion, normalFont)));
                taskTable.AddCell(new PdfPCell(new Phrase(t.nroMecanico ?? "", normalFont)));
                taskTable.AddCell(new PdfPCell(new Phrase(t.nroInspector ?? "", normalFont)));
            }
            doc.Add(taskTable);
            doc.Add(Chunk.NEWLINE);

            var signTable = new PdfPTable(2) 
            { 
                WidthPercentage = 30,
                HorizontalAlignment = Element.ALIGN_CENTER
            };
            signTable.SetWidths(new float[] { 1f, 1f });
            signTable.AddCell(new PdfPCell(new Phrase("Mecánico", boldFont))
            {
                Border = Rectangle.BOX,
                FixedHeight = 20f,   
                Padding = 4f
            });

            signTable.AddCell(new PdfPCell(new Phrase("Inspector", boldFont))
            {
                Border = Rectangle.BOX,
                FixedHeight = 20f,
                Padding = 4f
            });

            signTable.AddCell(new PdfPCell(new Phrase($"[{ot.mecanico}]")) 
            { 
                FixedHeight = 50,
                HorizontalAlignment = Element.ALIGN_CENTER,
                VerticalAlignment = Element.ALIGN_JUSTIFIED
            });
            signTable.AddCell(new PdfPCell(new Phrase($"[{ot.inspector}]")) 
            {
                FixedHeight = 50,
                HorizontalAlignment = Element.ALIGN_CENTER,
                VerticalAlignment = Element.ALIGN_JUSTIFIED
            });
            doc.Add(signTable);
            doc.Add(Chunk.NEWLINE);

            var certText =
                "It is hereby certified that the works specified in this document were carried out in accordance with " +
                "the maintenance rules applicable to EMPRESA, approved by the Civil Aviation Authority for the " +
                "Maintenance Organization and, in respect to that works, the aircraft is considered ready for " +
                "Return to Service in accordance with the aircraft manufacturer.";
            var certPara = new Paragraph(certText, normalFont) { Alignment = Element.ALIGN_JUSTIFIED };
            doc.Add(certPara);
            doc.Add(Chunk.NEWLINE);

            var fechaCierre = new Paragraph(
                $"Date/Fecha (dd/mm/yyyy): {ot.fechaCierre:dd/MM/yyyy}", normalFont)
            {
                Alignment = Element.ALIGN_LEFT
            };
            doc.Add(fechaCierre);

            doc.Close();
        }
    }
}