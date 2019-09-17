using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using Kancelaria.Models.Cases;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Kancelaria.Models
{
    public class PDF
    {
      
        public FileStreamResult GenerateCasePDF(Case _case)
        {
            MemoryStream workStream = new MemoryStream();
            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, workStream);
            writer.CloseStream = false;

            CreateCasePDF(document, writer, _case);

           
            byte[] byteInfo = workStream.ToArray();


            workStream.Write(byteInfo, 0, byteInfo.Length);
            workStream.Position = 0;

            return new FileStreamResult(workStream, "application/pdf");
        }


        private void CreatePdfNormalText(string html, string path)
        {
            TextReader reader = new StringReader(html);
            Document document = new Document(PageSize.A4, 30, 30, 30, 30);
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream("my.pdf", FileMode.Create));
            /*
             Sprawdzić jak z Downloadem dla roznych systemow np. dla telefonu
             */

            HtmlWorker worker = new HtmlWorker(document);
            document.Open();

            var bigFont = FontFactory.GetFont(BaseFont.TIMES_ROMAN, BaseFont.CP1257, 18, Font.BOLD);
            var para = new Paragraph(html, bigFont);
            document.Add(para);
            document.Close();
        }

        private void CreateCasePDF(Document document, PdfWriter writer, Case _case)
        {
            document.Open();
            //Nazwa Sprawy
            var bf = FontFactory.GetFont(BaseFont.TIMES_ROMAN, BaseFont.CP1257, 18, Font.BOLD);
            var para = new Paragraph(_case.Name, bf);
            para.Alignment = Element.ALIGN_CENTER;

            document.Add(para);
            document.Close();
        }

        //UŻYWANY DO OTWARCIA SPRAWY JAKO PDF
        public FileStreamResult FromExistingPDF(Case _case, string path)
        {

            //EXISTING PDF
            string template = path + "\\Data\\template.pdf";//"D:\\plik.pdf";
            //string path = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

            // open the reader
            PdfReader reader = new PdfReader(template);
            Rectangle size = reader.GetPageSizeWithRotation(1);
            Document document = new Document(size);

            // open the writer
            //FileStream fs = new FileStream(newFile, FileMode.Create, FileAccess.Write);
            MemoryStream workStream = new MemoryStream();
            PdfWriter writer = PdfWriter.GetInstance(document, workStream);
            document.Open();

            // the pdf content
            PdfContentByte cb = writer.DirectContent;

            // select the font properties
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1257, BaseFont.NOT_EMBEDDED);
            cb.SetColorFill(BaseColor.DarkGray);
            cb.SetFontAndSize(bf, 12);

            // write the text in the pdf content
            //cb.BeginText();
            //string text = "Some random łażaź...";
            // put the alignment and coordinates here
            //cb.ShowTextAligned(1, text, 520, 640, 0);
            //cb.EndText();
            float pageHeight = document.PageSize.Height;
            cb.BeginText();

            cb.SetTextMatrix(220, pageHeight - 24);
            cb.ShowText(document.PageSize.ToString() + " JESZCZE NIE SKOŃCZONE!!!");
            //Nazwa sprawy
            cb.SetTextMatrix(140, pageHeight - 80);
            cb.ShowText(_case.Name);
            //Data Przyjęcia
            cb.SetTextMatrix(140, pageHeight - 102);
            cb.ShowText(string.Format("{0}-{1}-{2}", _case.Date.Year, _case.Date.Month, _case.Date.Day));
            //Pelnomocnik
            cb.SetTextMatrix(140, pageHeight - 140);
            cb.ShowText(_case.Pelnomocnik);
            //Pelnomocnik
            cb.SetTextMatrix(140, pageHeight - 163);
            cb.ShowText(Basic.categoriesList[_case.basic.CaseCategory]);
            //Podmiot sprawy
            cb.SetTextMatrix(140, pageHeight - 185);
            cb.ShowText(Basic.subjectList[_case.basic.CaseSubject]);
            //Podmiot sprawy
            cb.SetTextMatrix(450, pageHeight - 162);
            cb.ShowText(Basic.casePositionList[_case.basic.CasePosition]);
            //Powód imie
            cb.SetTextMatrix(154, pageHeight - 238);
            cb.ShowText(_case.basic.S1Name);
            //Powód nazwisko
            cb.SetTextMatrix(154, pageHeight - 260);
            cb.ShowText(_case.basic.S1Surname);
            //Powód miejscowość
            cb.SetTextMatrix(154, pageHeight - 282);
            cb.ShowText(_case.basic.S1Town);
            //Powód firma
            cb.SetTextMatrix(154, pageHeight - 304);
            cb.ShowText(_case.basic.S1Company);
            //Powód kod pocztowy
            cb.SetTextMatrix(154, pageHeight - 324);
            cb.ShowText(_case.basic.S1PostCode);
            //Powód ulica
            cb.SetTextMatrix(154, pageHeight - 348);
            cb.ShowText(_case.basic.S1Street);
            //Powód nr budynku
            cb.SetTextMatrix(154, pageHeight - 370);
            cb.ShowText(_case.basic.S1BuildingNum);
            //Powód województwo
            cb.SetTextMatrix(154, pageHeight - 392);
            cb.ShowText(Basic.voivodshipList[int.Parse(_case.basic.S1Voivodship)]);
            //Powód powiat
            cb.SetTextMatrix(154, pageHeight - 414);
            cb.ShowText(_case.basic.S1County);
            //Powód NIP
            cb.SetTextMatrix(154, pageHeight - 436);
            cb.ShowText(_case.basic.S1NIP);
            //Powód PESEL
            cb.SetTextMatrix(154, pageHeight - 458);
            cb.ShowText(_case.basic.S1PESEL);
            //Powód nr dowodu
            cb.SetTextMatrix(154, pageHeight - 480);
            cb.ShowText(_case.basic.S1IdentityNum);
            //Powód tel stacjonarnny
            cb.SetTextMatrix(154, pageHeight - 502);
            cb.ShowText(_case.basic.S1TelHomeNum);
            //Powód tel komorkowy
            cb.SetTextMatrix(154, pageHeight - 522);
            cb.ShowText(_case.basic.S1TelCell);

            //Pozwany imie
            cb.SetTextMatrix(412, pageHeight - 238);
            cb.ShowText(_case.basic.S2Name);
            //Pozwany nazwisko
            cb.SetTextMatrix(412, pageHeight - 260);
            cb.ShowText(_case.basic.S2Surname);
            //Pozwany miejscowość
            cb.SetTextMatrix(412, pageHeight - 282);
            cb.ShowText(_case.basic.S2Town);
            //Pozwany firma
            cb.SetTextMatrix(412, pageHeight - 304);
            cb.ShowText(_case.basic.S2Company);
            //Pozwany kod pocztowy
            cb.SetTextMatrix(412, pageHeight - 324);
            cb.ShowText(_case.basic.S2PostCode);
            //Pozwany ulica
            cb.SetTextMatrix(412, pageHeight - 348);
            cb.ShowText(_case.basic.S2Street);
            //Pozwany nr budynku
            cb.SetTextMatrix(412, pageHeight - 370);
            cb.ShowText(_case.basic.S2BuildingNum);
            //Pozwany województwo
            cb.SetTextMatrix(412, pageHeight - 392);
            cb.ShowText(Basic.voivodshipList[int.Parse(_case.basic.S1Voivodship)]);
            //Pozwany powiat
            cb.SetTextMatrix(412, pageHeight - 414);
            cb.ShowText(_case.basic.S2County);
            //Pozwany NIP
            cb.SetTextMatrix(412, pageHeight - 436);
            cb.ShowText(_case.basic.S2NIP);
            //Pozwany PESEL
            cb.SetTextMatrix(412, pageHeight - 458);
            cb.ShowText(_case.basic.S2PESEL);
            //Pozwany nr dowodu
            cb.SetTextMatrix(412, pageHeight - 480);
            cb.ShowText(_case.basic.S2IdentityNum);
            //Pozwany tel stacjonarnny
            cb.SetTextMatrix(412, pageHeight - 502);
            cb.ShowText(_case.basic.S2TelHomeNum);
            //Pozwany tel komorkowy
            cb.SetTextMatrix(412, pageHeight - 522);
            cb.ShowText(_case.basic.S2TelCell);


            cb.SetFontAndSize(bf, 9);
            
            //REPETYTORIUM
            //Dokumenty
            cb.SetTextMatrix(90, pageHeight - 586);
            cb.ShowText(_case.repetytorium.Documents == true ? "TAK" : "NIE");
            //Ewidencja
            cb.SetTextMatrix(90, pageHeight - 606);
            cb.ShowText(_case.repetytorium.Record == true ? "TAK" : "NIE");

            cb.EndText();
            
            // create the new page and add it to the pdf
            PdfImportedPage page = writer.GetImportedPage(reader, 1);
            cb.AddTemplate(page, 0, 0);

            //KOLEJNA STRONA
            document.NewPage();
            PdfImportedPage page2 = writer.GetImportedPage(reader, 2);
            cb.AddTemplate(page2, 0, 0);
            document.NewPage();
            PdfImportedPage page3 = writer.GetImportedPage(reader, 3);
            cb.AddTemplate(page3, 0, 0);
            document.NewPage();
            PdfImportedPage page4 = writer.GetImportedPage(reader, 4);
            cb.AddTemplate(page4, 0, 0);
            document.NewPage();
            PdfImportedPage page5 = writer.GetImportedPage(reader, 5);
            cb.AddTemplate(page5, 0, 0);
            document.NewPage();
            PdfImportedPage page6 = writer.GetImportedPage(reader, 6);
            cb.AddTemplate(page6, 0, 0);
            document.NewPage();
            PdfImportedPage page7 = writer.GetImportedPage(reader, 7);
            cb.AddTemplate(page7, 0, 0);
            if (_case.repetytorium.Additional == 1)
            {
                document.NewPage();
                PdfImportedPage page8 = writer.GetImportedPage(reader, 8);
                cb.AddTemplate(page8, 0, 0);
            }

            document.Close();
            reader.Close();
            //END EXISTING PDF

            writer.CloseStream = true;

            //CreateCasePDF(document, writer);


            byte[] byteInfo = workStream.ToArray();


            workStream.Write(byteInfo, 0, byteInfo.Length);
            workStream.Position = 0;

            return new FileStreamResult(workStream, "application/pdf");
        }


    }

    /*
        public class PDF
    {
        public string htmlBody { get; set; }
        public Case Case {get;set;}

        public FileStreamResult GenerateCasePDF(Case _case)
        {
            MemoryStream workStream = new MemoryStream();
            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, workStream);
            writer.CloseStream = false;

            CreateCasePDF(document, writer);

           
            byte[] byteInfo = workStream.ToArray();


            workStream.Write(byteInfo, 0, byteInfo.Length);
            workStream.Position = 0;

            return new FileStreamResult(workStream, "application/pdf");
        }

        private void createHtmlPDFinBrowser(Document document, PdfWriter writer, string html)
        {
            TextReader reader = new StringReader(html);
            HtmlWorker worker = new HtmlWorker(document);
            document.Open();
            try
            {
                FontFactory.Register("C:\\Windows\\Fonts\\ARIALUNI.TTF", "FONT");
            }
            catch
            {
                document.Close();
                return;
            }

            iTextSharp.text.html.simpleparser.StyleSheet ST = new iTextSharp.text.html.simpleparser.StyleSheet();
            ST.LoadTagStyle("body", "encoding", "Identity-H");
            worker.Style = ST;
            worker.StartDocument();
            worker.Parse(reader);
            worker.EndDocument();
            worker.Close();
            document.Close();
        }



        private void CreatePdfNormalText(string html, string path)
        {
            TextReader reader = new StringReader(html);
            Document document = new Document(PageSize.A4, 30, 30, 30, 30);
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream("my.pdf", FileMode.Create));


    HtmlWorker worker = new HtmlWorker(document);
    document.Open();

            var bigFont = FontFactory.GetFont(BaseFont.TIMES_ROMAN, BaseFont.CP1257, 18, Font.BOLD);
    var para = new Paragraph(html, bigFont);
    document.Add(para);
            document.Close();
        }

        private void CreateCasePDF(Document document, PdfWriter writer)
        {
            document.Open();



            //Nazwa Sprawy
            var bf = FontFactory.GetFont(BaseFont.TIMES_ROMAN, BaseFont.CP1257, 18, Font.BOLD);
            var para = new Paragraph(Case.Name, bf);
            para.Alignment = Element.ALIGN_CENTER;

            document.Add(para);
            document.Close();
        }

    public void FromExistingPDF()
        {

            //EXISTING PDF
            string oldFile = "D:\\plik.pdf";
            string newFile = "D:\\newFile.pdf";

            // open the reader
            PdfReader reader = new PdfReader(oldFile);
            Rectangle size = reader.GetPageSizeWithRotation(1);
            Document document = new Document(size);

            // open the writer
            FileStream fs = new FileStream(newFile, FileMode.Create, FileAccess.Write);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.Open();

            // the pdf content
            PdfContentByte cb = writer.DirectContent;

            // select the font properties
            BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetColorFill(BaseColor.DarkGray);
            cb.SetFontAndSize(bf, 8);

            // write the text in the pdf content
            cb.BeginText();
            string text = "Some random blablablabla...";
            // put the alignment and coordinates here
            cb.ShowTextAligned(1, text, 520, 640, 0);
            cb.EndText();
            cb.BeginText();
            text = "Other random blabla...";
            // put the alignment and coordinates here
            cb.ShowTextAligned(2, text, 100, 200, 0);
            cb.EndText();

            // create the new page and add it to the pdf
            PdfImportedPage page = writer.GetImportedPage(reader, 1);
            cb.AddTemplate(page, 0, 0);

            //KOLEJNA STRONA
            document.NewPage();
            PdfImportedPage page2 = writer.GetImportedPage(reader, 2);
            cb.AddTemplate(page2, 0, 0);

            // close the streams and voilá the file should be changed :)
            document.Close();
            //fs.Close();
            //writer.Close();
            reader.Close();
            //END EXISTING PDF
        }
     */
}
