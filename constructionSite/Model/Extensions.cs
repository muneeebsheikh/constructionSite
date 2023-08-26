using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace constructionSite.Model
{
    public static class Extensions
    {
        private static readonly Font contentFont = new Font(Font.FontFamily.HELVETICA, 10, 0);
        private static readonly Font headingFont = new Font(Font.FontFamily.HELVETICA, 8, 1);
        private static readonly float CellMinimumHeight = 20;
        static readonly IElement __NEWLINE__ = new Phrase(Chunk.NEWLINE);
        static readonly IElement __SEPARATOR__ = new Chunk($"------------------------------------------------------------");
        static readonly Chunk __SYSTEMGENERATED__ = new Chunk("**** THIS IS A SYSTEM GENERATED FILE *****", new Font(Font.FontFamily.HELVETICA, 12, 1));
        static readonly Paragraph __EOF__ = new Paragraph(@"------------ END OF FILE ------------", new Font(Font.FontFamily.HELVETICA, 12, 1))
        {
            Alignment = Element.ALIGN_CENTER
        };

        public static void ShowDialogWithMargin(this PrintPreviewDialog printPreviewDialog1)
        {
            
            printPreviewDialog1.Document.OriginAtMargins = true;
            printPreviewDialog1.Document.DefaultPageSettings.Margins.Top = 100;
            //printPreviewDialog1.Document.DefaultPageSettings.Margins.Bottom = 0;
            printPreviewDialog1.Document.DefaultPageSettings.Margins.Left = 0;
            //printPreviewDialog1.Document.DefaultPageSettings.Margins.Right = 0;

            printPreviewDialog1.ShowDialog();
        }

        public static int GetVisibleColCount(this DataGridView dg)
        {
            int count = 0;
            foreach(DataGridViewColumn col in dg.Columns)
            {
                if (col.Visible)
                {
                    count++;
                }
            }
            return count;
        }
        public static void PrintPDF(DataGridView dataGridView, string fileName, string ContentHeading = "")
        {
            var _log = new Logger.Logger("Extensions");
            _log.Info("PrintPDF started");
            _log.Info($"filename: {fileName}");
            fileName = fileName.Trim();
            _log.Info($"Grid row count: {dataGridView.Rows.Count}");
            if (dataGridView.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog
                {
                    Filter = "PDF (*.pdf)|*.pdf",
                    FileName = $"{fileName}.pdf",
                    OverwritePrompt = true
                };
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var filePath = Path.GetFullPath(sfd.FileName);
                        PdfPTable pdfTable = new PdfPTable(dataGridView.GetVisibleColCount());
                        //pdfTable.DefaultCell.Padding = 3;
                        List<float> colWidhths = new List<float>();
                        foreach (DataGridViewColumn column in dataGridView.Columns)
                        {
                            if (column.Visible)
                                colWidhths.Add(column.Width);
                        }
                        pdfTable.SetTotalWidth(colWidhths.ToArray());
                        pdfTable.WidthPercentage = 100;
                        pdfTable.HorizontalAlignment = Element.ALIGN_CENTER;

                        foreach (DataGridViewColumn column in dataGridView.Columns)
                        {
                            if (column.Visible)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, headingFont));
                                pdfTable.AddCell(cell);
                            }
                        }
                        foreach (DataGridViewRow row in dataGridView.Rows)
                        {
                            row.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                if (cell.OwningColumn.Visible)
                                {

                                    PdfPCell c = new PdfPCell(new Phrase(cell.Value.ToString(), contentFont));
                                    c.MinimumHeight = CellMinimumHeight;
                                    pdfTable.AddCell(c);
                                }
                            }
                        }

                        using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                        {
                            Document pdfDoc = new Document(PageSize.A4, 30f, 30f, 20f, 10f);
                            PdfWriter.GetInstance(pdfDoc, stream);
                            pdfDoc.Open();
                            var title = !string.IsNullOrEmpty(ContentHeading) ? ContentHeading : $"Title: {fileName}";
                            title = $"Date: {DateTime.Now:dd-MMM-yyyy hh:mm tt}\n{title}";
                            IElement titleElement = new Phrase(title + Chunk.NEWLINE, new Font(Font.FontFamily.HELVETICA, 12, 1));
                            
                            
                            
                            
                            //IElement contentHeadingChunk = new Chunk(ContentHeading + Chunk.NEWLINE, new Font(Font.FontFamily.HELVETICA, 12, 1));

                            #region First Page Spaces
                            pdfDoc.Add(__NEWLINE__);
                            pdfDoc.Add(__NEWLINE__);
                            pdfDoc.Add(__NEWLINE__);
                            #endregion

                            pdfDoc.Add(__SYSTEMGENERATED__);
                            
                            pdfDoc.Add(__NEWLINE__);
                            pdfDoc.Add(__SEPARATOR__);
                            pdfDoc.Add(__NEWLINE__);

                            pdfDoc.Add(titleElement);
                            
                            pdfDoc.Add(__NEWLINE__);
                            
                            pdfDoc.Add(pdfTable);
                            
                            pdfDoc.Add(__EOF__);
                            pdfDoc.Close();
                            stream.Close();
                        }
                        MessageBox.Show($"File generated successfully! {filePath}");

                        System.Diagnostics.Process.Start(filePath);

                    }
                    catch(Exception ex)
                    {
                        _log.Error(ex, "");
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                _log.Info("No Data Found to print!");
                MessageBox.Show("No Data Found to print!");
            }
        }

    }
}
