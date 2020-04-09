using iTextSharp.text;
using iTextSharp.text.pdf;
using ResilienceData.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using static ResilienceReporting.ChartHelper;


namespace ResilienceReporting
{
    public static class IndividualReport
    {
        private static BaseFont bfTimes = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
        public static byte[] CreateReport() {


            var doc = new Document(PageSize.A4);
            using var ms = new MemoryStream();
            var writer = PdfWriter.GetInstance(doc, ms);
            doc.Open();

            var cb = writer.DirectContent;
            var under = writer.DirectContentUnder;
            var result = new ResultForChart();
            result = GetMockResult();

            //CreatePage1(cb);
            //CreatePage2(cb);



            CreateHeaderFooter(cb);
            CreateGrid(cb);
            AddImageBehindGrid(under);
            CreateCenterLine(cb);
            DrawBar(cb, "Supported", result.Supported);
            DrawBar(cb, "Isolated", result.Isolated);
            DrawBar(cb, "Purposeful", result.Purposeful);
            DrawBar(cb, "Aimless", result.Aimless);
            DrawBar(cb, "Confident", result.Confident);
            DrawBar(cb, "Fearful", result.Fearful);
           // DrawBar(cb, "Adaptable", result.Adaptable);
            DrawBar(cb, "Fixed", result.Fixed);
            doc.Close();

            return ms.ToArray();
            //return ms.ToArray();
        }

        //private static void CreatePage2(PdfContentByte cb)
        //{
        //    var img = Image.GetInstance("C:\\Users\\sMOOT\\source\repos\\ResilienceAssessmentSystem\\ResilienceReporting\\Images\\footer.png");
        //    img.SetAbsolutePosition(0, 0);
        //    cb.AddImage(img, false);

       

        //private static void CreatePage1(PdfContentByte cb)
        //{
        //    var img = Image.GetInstance("C:\\Users\\sMOOT\\source\repos\\ResilienceAssessmentSystem\\ResilienceReporting\\Images\\footer.png");
        //    img.SetAbsolutePosition(0, 0);
        //    cb.AddImage(img, false);
        //}

        private static void AddImageBehindGrid(PdfContentByte under)
        {
            var path = "C:\\Users\\sMOOT\\source\\repos\\ResilienceAssessmentSystem\\ResilienceReporting\\Images\\iceberg.jpg";

            var img = Image.GetInstance(path);
            img.SetAbsolutePosition(50, 130);
            img.ScaleAbsoluteWidth((PageSize.A4).Width - 100);
            img.ScaleAbsoluteHeight(500);
            under.AddImage(img, false);
        }

        private static void DrawBar(PdfContentByte cb,string barName, double val)
        {
            float llx = 0;
            float lly=0;
            float urx=0;
            float ury=0;
            int barWidth = 20;
            float v = (float)val;

            switch (barName)
            {
                case "Supported":
                    llx = mm(40);
                    urx = llx + barWidth;
                    lly = ft(150);
                    ury = ft(150 - v * 20);
                    break;
                case "Isolated":
                    llx = mm(40);
                    urx = llx + barWidth;
                    lly = ft(150);
                    ury = ft(150 + v * 20);
                    break;
                case "Purposeful":
                    llx = mm(80);
                    urx = llx + barWidth;
                    lly = ft(150);
                    ury = ft(150 - v * 20);
                    break;
                case "Aimless":
                    llx = mm(80);
                    urx = llx + barWidth;
                    lly = ft(150);
                    ury = ft(150 + v * 20);
                    break;
                case "Confident":
                    llx = mm(120);
                    urx = llx + barWidth;
                    lly = ft(150);
                    ury = ft(150 - v * 20);
                    break;
                case "Fearful":
                    llx = mm(120);
                    urx = llx + barWidth;
                    lly = ft(150);
                    ury = ft(150 + v * 20);
                    break;
                case "Adaptable":
                    llx = mm(160);
                    urx = llx + barWidth;
                    lly = ft(150);
                    ury = ft(150 - v * 20);
                    break;
                case "Fixed":
                    llx = mm(160);
                    urx = llx + barWidth;
                    lly = ft(150);
                    ury = ft(150 + v * 20);
                    break;
                default:
                    break;
            }

            var rec = new Rectangle(llx, lly, urx, ury);
            rec.Border = Rectangle.BOX;
            rec.BorderWidth = 1;
            rec.BorderColor = new BaseColor(50, 50, 50);
            rec.BackgroundColor = BaseColor.Blue;
            cb.Rectangle(rec);
        }

        private static void CreateCenterLine(PdfContentByte cb)
        {
            cb.MoveTo(mm(25), ft(150));
            cb.LineTo(mm(185), ft(150));
            cb.SetLineWidth(3);
            cb.SaveState();
            cb.SetRgbColorStroke(0, 0, 0);
            cb.SetLineDash(20,5,1);
            cb.Stroke();
            cb.RestoreState();
        }

        private static void CreateHeaderFooter(PdfContentByte cb)
        {
            var path = "C:\\Users\\sMOOT\\source\\repos\\ResilienceAssessmentSystem\\ResilienceReporting\\Images\\footer.png";
            var img = Image.GetInstance(path);
            img.SetAbsolutePosition(0, 0);
            img.ScaleAbsoluteWidth(PageSize.A4.Width);
            img.ScaleAbsoluteHeight(70);
            cb.AddImage(img, false);

            path = "C:\\Users\\sMOOT\\source\\repos\\ResilienceAssessmentSystem\\ResilienceReporting\\Images\\header.png";
            img = Image.GetInstance(path);
            img.SetAbsolutePosition(0, PageSize.A4.Top-mm(35));
            img.ScaleAbsoluteWidth(PageSize.A4.Width);
            img.ScaleAbsoluteHeight(mm(35));
            cb.AddImage(img, false);

    }

        private static void CreateGrid(PdfContentByte cb)
        {
            var rectangeList = new List<Rectangle>();
            rectangeList.Add(new Rectangle(mm(25), ft(70),  mm(65), ft(60)));        /*top labels*/
            rectangeList.Add(new Rectangle(mm(65), ft(70),  mm(105), ft(60)));
            rectangeList.Add(new Rectangle(mm(105), ft(70), mm(145), ft(60)));
            rectangeList.Add(new Rectangle(mm(145), ft(70), mm(185), ft(60)));

            rectangeList.Add(new Rectangle(mm(25),  ft(90), mm(65),  ft(70)));
            rectangeList.Add(new Rectangle(mm(65),  ft(90), mm(105), ft(70)));
            rectangeList.Add(new Rectangle(mm(105), ft(90), mm(145), ft(70)));
            rectangeList.Add(new Rectangle(mm(145), ft(90), mm(185), ft(70)));

            rectangeList.Add(new Rectangle(mm(25),  ft(110), mm(65),  ft(90)));
            rectangeList.Add(new Rectangle(mm(65),  ft(110), mm(105), ft(90)));
            rectangeList.Add(new Rectangle(mm(105), ft(110), mm(145), ft(90)));
            rectangeList.Add(new Rectangle(mm(145), ft(110), mm(185), ft(90)));

            rectangeList.Add(new Rectangle(mm(25),  ft(130), mm(65),  ft(110)));
            rectangeList.Add(new Rectangle(mm(65),  ft(130), mm(105), ft(110)));
            rectangeList.Add(new Rectangle(mm(105), ft(130), mm(145), ft(110)));
            rectangeList.Add(new Rectangle(mm(145), ft(130), mm(185), ft(110)));

            rectangeList.Add(new Rectangle(mm(25),  ft(150), mm(65),  ft(130)));
            rectangeList.Add(new Rectangle(mm(65),  ft(150), mm(105), ft(130)));
            rectangeList.Add(new Rectangle(mm(105), ft(150), mm(145), ft(130)));
            rectangeList.Add(new Rectangle(mm(145), ft(150), mm(185), ft(130)));

            rectangeList.Add(new Rectangle(mm(25),  ft(170), mm(65),  ft(150)));
            rectangeList.Add(new Rectangle(mm(65),  ft(170), mm(105), ft(150)));
            rectangeList.Add(new Rectangle(mm(105), ft(170), mm(145), ft(150)));
            rectangeList.Add(new Rectangle(mm(145), ft(170), mm(185), ft(150)));

            rectangeList.Add(new Rectangle(mm(25),  ft(190), mm(65),  ft(170)));
            rectangeList.Add(new Rectangle(mm(65),  ft(190), mm(105), ft(170)));
            rectangeList.Add(new Rectangle(mm(105), ft(190), mm(145), ft(170)));
            rectangeList.Add(new Rectangle(mm(145), ft(190), mm(185), ft(170)));

            rectangeList.Add(new Rectangle(mm(25),  ft(210), mm(65),  ft(190)));
            rectangeList.Add(new Rectangle(mm(65),  ft(210), mm(105), ft(190)));
            rectangeList.Add(new Rectangle(mm(105), ft(210), mm(145), ft(190)));
            rectangeList.Add(new Rectangle(mm(145), ft(210), mm(185), ft(190)));

            rectangeList.Add(new Rectangle(mm(25),  ft(230), mm(65),  ft(210)));
            rectangeList.Add(new Rectangle(mm(65),  ft(230), mm(105), ft(210)));
            rectangeList.Add(new Rectangle(mm(105), ft(230), mm(145), ft(210)));
            rectangeList.Add(new Rectangle(mm(145), ft(230), mm(185), ft(210)));
            
            rectangeList.Add(new Rectangle(mm(25),  ft(240), mm(65),  ft(230)));
            rectangeList.Add(new Rectangle(mm(65),  ft(240), mm(105), ft(230)));
            rectangeList.Add(new Rectangle(mm(105), ft(240), mm(145), ft(230)));
            rectangeList.Add(new Rectangle(mm(145), ft(240), mm(185), ft(230)));  /*bottom labels*/


            foreach (var rec in rectangeList)
            {
                rec.Border = Rectangle.BOX;
                rec.BorderWidth = 0.5f;
                rec.BorderColor = new BaseColor(50, 50, 50);
                cb.Rectangle(rec);
            }

            //Add labels to grid
            cb.BeginText();
            cb.SetFontAndSize(bfTimes, 16);
            cb.ShowTextAligned(Element.ALIGN_CENTER, "Supported",   mm(45), ft(67), 0);
            cb.ShowTextAligned(Element.ALIGN_CENTER, "Purposeful",  mm(85), ft(67), 0);
            cb.ShowTextAligned(Element.ALIGN_CENTER, "Confident",   mm(125), ft(67), 0);
            cb.ShowTextAligned(Element.ALIGN_CENTER, "Adaptable",   mm(165), ft(67), 0);
            
            cb.ShowTextAligned(Element.ALIGN_CENTER, "Isolated",    mm(45),  ft(237), 0);
            cb.ShowTextAligned(Element.ALIGN_CENTER, "Aimless",     mm(85),  ft(237), 0);
            cb.ShowTextAligned(Element.ALIGN_CENTER, "Fearful",     mm(125), ft(237), 0);
            cb.ShowTextAligned(Element.ALIGN_CENTER, "Fixed",       mm(165), ft(237), 0);


            cb.ShowTextAligned(Element.ALIGN_CENTER, "4",  mm(15), ft(72), 0);
            cb.ShowTextAligned(Element.ALIGN_CENTER, "3",  mm(15), ft(92), 0);
            cb.ShowTextAligned(Element.ALIGN_CENTER, "2",  mm(15), ft(112), 0);
            cb.ShowTextAligned(Element.ALIGN_CENTER, "1",  mm(15), ft(132), 0);
            cb.ShowTextAligned(Element.ALIGN_CENTER, "0",  mm(15), ft(152), 0);
            cb.ShowTextAligned(Element.ALIGN_CENTER, "-1", mm(15), ft(172), 0);
            cb.ShowTextAligned(Element.ALIGN_CENTER, "-2", mm(15), ft(192), 0);
            cb.ShowTextAligned(Element.ALIGN_CENTER, "-3", mm(15), ft(212), 0);
            cb.ShowTextAligned(Element.ALIGN_CENTER, "-4", mm(15), ft(232), 0);
           


            cb.EndText();

        }

       
    }
}
