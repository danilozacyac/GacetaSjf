using System;
using System.Collections.ObjectModel;
using System.Linq;
using GacetaSjf.Dao;
using MantesisVerIusCommonObjects.Dto;
using Microsoft.Office.Interop.Word;
using ScjnUtilities;
using System.IO;
using System.Collections.Generic;
using GacetaSjf.Singletons;

namespace GacetaSjf.Reportes
{
    public class WordReports
    {

        private readonly ObservableCollection<TesisDto> listaTesis;
        private readonly ObservableCollection<Documento> listaDocumentos;

        Microsoft.Office.Interop.Word.Application oWord;
        Microsoft.Office.Interop.Word.Document oDoc;
        object oMissing = System.Reflection.Missing.Value;
        object oEndOfDoc = "\\endofdoc";

        public WordReports(ObservableCollection<TesisDto> listaTesis)
        {
            this.listaTesis = listaTesis;
        }

        public WordReports(IEnumerable<Documento> listaDocumentos)
        {
            this.listaDocumentos = new ObservableCollection<Documento>(listaDocumentos);
        }


        public void ListadoDeTesisTabla()
        {
            oWord = new Microsoft.Office.Interop.Word.Application();
            oDoc = oWord.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing);
            oDoc.PageSetup.Orientation = WdOrientation.wdOrientLandscape;

            string filePath = Path.GetTempFileName() + ".docx";

            try
            {
                //Insert a paragraph at the beginning of the document.
                Microsoft.Office.Interop.Word.Paragraph oPara1;
                oPara1 = oDoc.Content.Paragraphs.Add(ref oMissing);
                //oPara1.Range.ParagraphFormat.Space1;
                oPara1.Range.Text = "SUPREMA CORTE DE JUSTICIA DE LA NACIÓN";

                oPara1.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oPara1.Range.Font.Bold = 1;
                oPara1.Range.Font.Size = 10;
                oPara1.Range.Font.Name = "Arial";
                oPara1.Format.SpaceAfter = 0;    //24 pt spacing after paragraph.
                oPara1.Range.InsertParagraphAfter();
                oPara1.Range.Text = "GACETA DEL SEMANARIO JUDICIAL DE LA FEDERACIÓN";
                oPara1.Range.InsertParagraphAfter();
                oPara1.Range.InsertParagraphAfter();
                oPara1.Range.Text = "TOTAL:   " + listaTesis.Count() + " Tesis";
                oPara1.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                oPara1.Range.InsertParagraphAfter();
                oPara1.Range.InsertParagraphAfter();


                int fila = 1;
                Range wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;

                Table oTable = oDoc.Tables.Add(wrdRng, listaTesis.Count + 2, 5, ref oMissing, ref oMissing);
                //oTable.Rows[1].HeadingFormat = 1;
                oTable.Range.ParagraphFormat.SpaceAfter = 6;
                oTable.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oTable.Range.Font.Size = 9;
                oTable.Range.Font.Name = "Arial";
                oTable.Range.Font.Bold = 0;
                oTable.Borders.Enable = 1;

                oTable.Columns[1].SetWidth(40, WdRulerStyle.wdAdjustSameWidth);
                oTable.Columns[2].SetWidth(70, WdRulerStyle.wdAdjustSameWidth);
                oTable.Columns[3].SetWidth(100, WdRulerStyle.wdAdjustSameWidth);
                oTable.Columns[4].SetWidth(320, WdRulerStyle.wdAdjustSameWidth);
                oTable.Columns[5].SetWidth(110, WdRulerStyle.wdAdjustSameWidth);


                oTable.Cell(fila, 1).Range.Text = "#";
                oTable.Cell(fila, 2).Range.Text = "Reg. Digital";
                oTable.Cell(fila, 3).Range.Text = "Tesis";
                oTable.Cell(fila, 4).Range.Text = "Rubro (Título/subtítulo)";
                oTable.Cell(fila, 5).Range.Text = "Localización";

                oTable.Cell(fila, 1).Range.Font.Bold = 1;
                oTable.Cell(fila, 2).Range.Font.Bold = 1;
                oTable.Cell(fila, 3).Range.Font.Bold = 1;
                oTable.Cell(fila, 4).Range.Font.Bold = 1;
                oTable.Cell(fila, 5).Range.Font.Bold = 1;


                fila++;
                int consecutivo = 1;

                foreach (TesisDto print in listaTesis)
                {
                    oTable.Cell(fila, 1).Range.Text = consecutivo.ToString();
                    oTable.Cell(fila, 2).Range.Text = print.Ius.ToString();
                    oTable.Cell(fila, 3).Range.Text = print.Tesis;
                    oTable.Cell(fila, 4).Range.Text = print.Rubro;
                    oTable.Cell(fila, 4).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphJustify;
                    oTable.Cell(fila, 5).Range.Text = print.LocAbr;
                    // oTable.Cell(fila, 3).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphJustify;

                    fila++;
                    consecutivo++;
                }


                foreach (Section wordSection in oDoc.Sections)
                {
                    object pagealign = WdPageNumberAlignment.wdAlignPageNumberRight;
                    object firstpage = true;
                    wordSection.Footers[WdHeaderFooterIndex.wdHeaderFooterPrimary].PageNumbers.Add(ref pagealign, ref firstpage);
                }

                oWord.ActiveDocument.SaveAs(filePath);
                oWord.ActiveDocument.Saved = true;
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,WordReports", "ListadoDeTesis");
            }
            finally
            {
                oWord.Visible = true;
                //oDoc.Close();

            }
        }



        public void ListadoDeDocumentosTabla()
        {
            oWord = new Microsoft.Office.Interop.Word.Application();
            oDoc = oWord.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing);
            oDoc.PageSetup.Orientation = WdOrientation.wdOrientLandscape;

            string filePath = Path.GetTempFileName() + ".docx";

            try
            {
                //Insert a paragraph at the beginning of the document.
                Microsoft.Office.Interop.Word.Paragraph oPara1;
                oPara1 = oDoc.Content.Paragraphs.Add(ref oMissing);
                //oPara1.Range.ParagraphFormat.Space1;
                oPara1.Range.Text = "SUPREMA CORTE DE JUSTICIA DE LA NACIÓN";

                oPara1.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oPara1.Range.Font.Bold = 1;
                oPara1.Range.Font.Size = 10;
                oPara1.Range.Font.Name = "Arial";
                oPara1.Format.SpaceAfter = 0;    //24 pt spacing after paragraph.
                oPara1.Range.InsertParagraphAfter();
                oPara1.Range.Text = "GACETA DEL SEMANARIO JUDICIAL DE LA FEDERACIÓN";
                oPara1.Range.InsertParagraphAfter();
                oPara1.Range.InsertParagraphAfter();
                oPara1.Range.Text = "TOTAL:   " + listaDocumentos.Count() + " Ejecutorias";
                oPara1.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                oPara1.Range.InsertParagraphAfter();
                oPara1.Range.InsertParagraphAfter();


                int fila = 1;
                Range wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;

                Table oTable = oDoc.Tables.Add(wrdRng, listaDocumentos.Count + 2, 6, ref oMissing, ref oMissing);
                //oTable.Rows[1].HeadingFormat = 1;
                oTable.Range.ParagraphFormat.SpaceAfter = 6;
                oTable.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oTable.Range.Font.Size = 8;
                oTable.Range.Font.Name = "Arial";
                oTable.Range.Font.Bold = 0;
                oTable.Borders.Enable = 1;

                oTable.Columns[1].SetWidth(25, WdRulerStyle.wdAdjustSameWidth);
                oTable.Columns[2].SetWidth(40, WdRulerStyle.wdAdjustSameWidth);
                oTable.Columns[3].SetWidth(90, WdRulerStyle.wdAdjustSameWidth);
                oTable.Columns[4].SetWidth(300, WdRulerStyle.wdAdjustSameWidth);
                oTable.Columns[5].SetWidth(90, WdRulerStyle.wdAdjustSameWidth);
                oTable.Columns[6].SetWidth(160, WdRulerStyle.wdAdjustSameWidth);


                oTable.Cell(fila, 1).Range.Text = "#";
                oTable.Cell(fila, 2).Range.Text = "Reg. Digital";
                oTable.Cell(fila, 3).Range.Text = "Asunto";
                oTable.Cell(fila, 4).Range.Text = "Rubro (Título/subtítulo)";
                oTable.Cell(fila, 5).Range.Text = "Localización";

                if(listaDocumentos[0] is Ejecutoria)
                    oTable.Cell(fila, 6).Range.Text = "Promoventes";
                else if(listaDocumentos[0] is Votos)
                    oTable.Cell(fila, 6).Range.Text = "Emisor";
                else
                    oTable.Cell(fila, 6).Range.Text = "Instancia";

                oTable.Cell(fila, 1).Range.Font.Bold = 1;
                oTable.Cell(fila, 2).Range.Font.Bold = 1;
                oTable.Cell(fila, 3).Range.Font.Bold = 1;
                oTable.Cell(fila, 4).Range.Font.Bold = 1;
                oTable.Cell(fila, 5).Range.Font.Bold = 1;
                oTable.Cell(fila, 6).Range.Font.Bold = 1;


                fila++;
                int consecutivo = 1;

                foreach (Documento print in listaDocumentos)
                {
                    oTable.Cell(fila, 1).Range.Text = consecutivo.ToString();
                    oTable.Cell(fila, 2).Range.Text = print.Ius.ToString();
                    oTable.Cell(fila, 3).Range.Text = print.Asunto;
                    oTable.Cell(fila, 3).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                    oTable.Cell(fila, 4).Range.Text = print.Rubro;
                    oTable.Cell(fila, 4).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphJustify;
                    oTable.Cell(fila, 5).Range.Text = String.Empty;

                    if (print is Ejecutoria)
                        oTable.Cell(fila, 6).Range.Text = print.Promovente;
                    else if (print is Votos)
                        oTable.Cell(fila, 6).Range.Text = ((Votos)print).Emisor;
                    else
                        oTable.Cell(fila, 6).Range.Text = (from n in CompartidosSingleton.Instancias
                                                           where n.IdElemento == print.Sala
                                                           select n.Descripcion).ToList()[0];

                    oTable.Cell(fila, 6).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphJustify;
                    // oTable.Cell(fila, 3).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphJustify;

                    fila++;
                    consecutivo++;
                }


                foreach (Section wordSection in oDoc.Sections)
                {
                    object pagealign = WdPageNumberAlignment.wdAlignPageNumberRight;
                    object firstpage = true;
                    wordSection.Footers[WdHeaderFooterIndex.wdHeaderFooterPrimary].PageNumbers.Add(ref pagealign, ref firstpage);
                }

                oWord.ActiveDocument.SaveAs(filePath);
                oWord.ActiveDocument.Saved = true;
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,WordReports", "ListadoDeTesis");
            }
            finally
            {
                oWord.Visible = true;
                //oDoc.Close();

            }
        }

    }
}
