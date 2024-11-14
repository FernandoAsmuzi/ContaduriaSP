using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Threading.Tasks;
using ContadSP.Models;
using iTextSharp.text.pdf.draw;
using ContadSP.Controllers;
using System;

namespace ContadSP.Services
{
    public class PdfService
    {
        public byte[] GenerarPdf(Pedido ultimoPedido, Provision prov, List<DetalleProvision> provisionDetalle)
        {
            using (var ms = new MemoryStream())
            {
                var document = new Document();
                var writer = PdfWriter.GetInstance(document, ms);
                document.Open();

                var smallFont = new Font(Font.FontFamily.HELVETICA, 8);

                // Crear una tabla con dos celdas
                var table = new PdfPTable(2);
                table.WidthPercentage = 100;
                table.SetWidths(new float[] { 2, 2 }); // Ajustar el ancho de las columnas

                // Agregar la imagen del logo a la primera celda
                var logo = Image.GetInstance("wwwroot/icon/logoPJ.png");
                logo.ScaleToFit(200f, 200f); // Ajustar el tamaño de la imagen
                var cellLogo = new PdfPCell(logo)
                {
                    Border = Rectangle.NO_BORDER,
                    HorizontalAlignment = Element.ALIGN_LEFT
                };
                table.AddCell(cellLogo);

                var titulo = new Paragraph($"PEDIDO DE PROVISION N° {ultimoPedido.id}")
                {
                    Alignment = Element.ALIGN_RIGHT
                };
                var cellTitulo = new PdfPCell(titulo)
                {
                    Border = Rectangle.NO_BORDER,
                    HorizontalAlignment = Element.ALIGN_RIGHT,
                    VerticalAlignment = Element.ALIGN_MIDDLE // Alinear verticalmente al centro
                };
                table.AddCell(cellTitulo);

                // Agregar la tabla al documento
                document.Add(table);

                document.Add(new Paragraph(" "));

                var lugarFecha = new Paragraph($"Lugar y Fecha: Poder Judicial San Pedro de Jujuy, {DateTime.Now.ToString("d 'de' MMMM 'de' yyyy")}", smallFont)
                {
                    IndentationLeft = 20f
                };
                document.Add(lugarFecha);

                var compraDestinada = new Paragraph("Compra destinada a: Poder Judicial San Pedro de Jujuy", smallFont)
                {
                    IndentationLeft = 20f
                };
                document.Add(compraDestinada);

                var paraUtilizarEn = new Paragraph($"Para utilizar en: {prov.Destino.destino}", smallFont)
                {
                    IndentationLeft = 20f
                };
                document.Add(paraUtilizarEn);

                var usuarioSolicitante = new Paragraph($"Usuario solicitante: {prov.Usuario.nombre_usuario}",smallFont)
                {
                    IndentationLeft = 20f
                };
                document.Add(usuarioSolicitante);

                var descripcion = new Paragraph($"Descripción: {prov.descripcion}", smallFont)
                {
                    IndentationLeft = 20f
                };
                document.Add(descripcion);

                LineSeparator line1 = new LineSeparator(1f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER, -2);
                document.Add(new Chunk(line1));

                // Crear una tabla
                var detailtable = new PdfPTable(6);
                detailtable.WidthPercentage = 100;
                detailtable.SetWidths(new float[] { 1, 1, 2, 1, 2, 2 });

                detailtable.AddCell(new PdfPCell(new Phrase("RENG.", smallFont)));
                detailtable.AddCell(new PdfPCell(new Phrase("CANT.", smallFont)));
                detailtable.AddCell(new PdfPCell(new Phrase("LETRA", smallFont)));
                detailtable.AddCell(new PdfPCell(new Phrase("UNIDAD", smallFont)));
                detailtable.AddCell(new PdfPCell(new Phrase("ARTICULO", smallFont)));
                detailtable.AddCell(new PdfPCell(new Phrase("ESPECIF.", smallFont)));


                int renglon = 1;
                foreach (var p in provisionDetalle)
                {
                    detailtable.AddCell(new PdfPCell(new Phrase(renglon.ToString(), smallFont)));
                    detailtable.AddCell(new PdfPCell(new Phrase(p.cantidad.ToString(), smallFont)));
                    
                    //Aqui se corta la cadena para sacar la parte de PESOS 00 /100 que trae el conversor
                    var letra = ConversorNumeroLetra.NumeroALetras(p.cantidad);
                    if(letra.Length > 12)
                    {
                        letra = letra.Substring(0, letra.Length - 13);
                    }
                    //

                    detailtable.AddCell(new PdfPCell(new Phrase(letra, smallFont)));
                    detailtable.AddCell(new PdfPCell(new Phrase(p.UnidadMedida.unidad, smallFont)));
                    detailtable.AddCell(new PdfPCell(new Phrase(p.Articulo.descripcion, smallFont)));
                    detailtable.AddCell(new PdfPCell(new Phrase(p.especificacion, smallFont)));
                    renglon++;
                }

                document.Add(detailtable);

                document.Add(new Paragraph($"Monto Aproximado: $ {prov.total_aprox}", smallFont));
                document.Add(new Paragraph($"Total aproximado letra: {prov.total_letra}", smallFont));


                // Agregar espacios de firma
                document.Add(new Paragraph("\n\n\n")); // Espacio antes de las firmas

                // Crear una tabla para las firmas
                var firmaTable = new PdfPTable(2);
                firmaTable.WidthPercentage = 100;

                // Celda para la firma del solicitante (izquierda)
                var firmaSolicitanteCell = new PdfPCell();
                firmaSolicitanteCell.Border = Rectangle.NO_BORDER;
                firmaSolicitanteCell.HorizontalAlignment = Element.ALIGN_CENTER;
                firmaSolicitanteCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                firmaSolicitanteCell.AddElement(new Paragraph("__________________________"));
                firmaSolicitanteCell.AddElement(new Paragraph("Firma Solicitante", new Font(Font.FontFamily.HELVETICA, 10, Font.NORMAL)));

                // Celda para el visto bueno de contaduría (derecha)
                var vistoBuenoCell = new PdfPCell();
                vistoBuenoCell.Border = Rectangle.NO_BORDER;
                vistoBuenoCell.HorizontalAlignment = Element.ALIGN_CENTER;
                vistoBuenoCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                vistoBuenoCell.AddElement(new Paragraph("__________________________"));
                vistoBuenoCell.AddElement(new Paragraph("Visto Bueno", new Font(Font.FontFamily.HELVETICA, 10, Font.NORMAL)));

                // Agregar las celdas a la tabla
                firmaTable.AddCell(firmaSolicitanteCell);
                firmaTable.AddCell(vistoBuenoCell);

                // Agregar la tabla de firmas al documento
                document.Add(firmaTable);

                document.Close();
                return ms.ToArray();
            }
        }
    }
}
