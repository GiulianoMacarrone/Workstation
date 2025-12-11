using BE.Modelo;
using System.Collections.Generic;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace BLL.Exportador
{
    public class ExportadorDataSheet
    {
        public void ExportarHistorialFlota(List<HistorialEstadoBE> historial, string rutaArchivo)
        {
            using (SpreadsheetDocument documento = SpreadsheetDocument.Create(rutaArchivo, SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart workbookPart = documento.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                SheetData sheetData = new SheetData();

                Worksheet worksheet = new Worksheet(sheetData);
                worksheetPart.Worksheet = worksheet;

                Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());
                Sheet sheet = new Sheet()
                {
                    Id = workbookPart.GetIdOfPart(worksheetPart),
                    SheetId = 1,
                    Name = "Historial Flota"
                };
                sheets.Append(sheet);

                Row headerRow = new Row();
                headerRow.Append(
                    CrearCell("Fecha Estado"),
                    CrearCell("Matrícula"),
                    CrearCell("Marca"),
                    CrearCell("Modelo"),
                    CrearCell("Estado"),
                    CrearCell("Motivo"),
                    CrearCell("N° OT"),
                    CrearCell("Registrado Por")
                );
                sheetData.Append(headerRow);

                foreach (var item in historial)
                {
                    Row row = new Row();
                    row.Append(
                        CrearCell(item.fechaEstado.ToString("dd/MM/yyyy")),
                        CrearCell(item.matricula),
                        CrearCell(item.marca),
                        CrearCell(item.modelo),
                        CrearCell(item.estadoRegistrado.ToString()),
                        CrearCell(item.motivo),
                        CrearCell(item.numeroOT),
                        CrearCell(item.registradoPor)
                    );
                    sheetData.Append(row);
                }
                workbookPart.Workbook.Save();
            }
        }

        private Cell CrearCell(string valor)
        {
            return new Cell()
            {
                CellValue = new CellValue(valor ?? ""),
                DataType = CellValues.String
            };
        }
    }
}

