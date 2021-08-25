    using System;

namespace Builder
{
    class Program
    {
        public class Report
        {
            public string ReportType { get; set; }
            public string ReportHeader { get; set; }
            public string ReportFooter { get; set; }
            public string ReportContent { get; set; }
            public void DisplayReport()
            {
                Console.WriteLine("Report Type :" + ReportType);
                Console.WriteLine("Header :" + ReportHeader);
                Console.WriteLine("Content :" + ReportContent);
                Console.WriteLine("Footer :" + ReportFooter);
            }
        }

        public abstract class ReportBuilder
        {
            internal Report ReportObject { get; set; }

            protected ReportBuilder()
            {
                ReportObject = new Report(); 
            }

            public abstract void SetReportType();
            public abstract void SetReportHeader();
            public abstract void SetReportContent();
            public abstract void SetReportFooter();
            //public void CreateNewReport()
            //{
            //    reportObject = new Report();
            //}
            public Report GetReport()
            {
                return ReportObject;
            }
        }

        class ExcelReport : ReportBuilder
        {
            public override void SetReportContent()
            {
                ReportObject.ReportContent = "Excel Content Section";
            }
            public override void SetReportFooter()
            {
                ReportObject.ReportFooter = "Excel Footer";
            }
            public override void SetReportHeader()
            {
                ReportObject.ReportHeader = "Excel Header";
            }
            public override void SetReportType()
            {
                ReportObject.ReportType = "Excel";
            }
        }

        public class PDFReport : ReportBuilder
        {
            public override void SetReportContent()
            {
                ReportObject.ReportContent = "PDF Content Section";
            }
            public override void SetReportFooter()
            {
                ReportObject.ReportFooter = "PDF Footer";
            }
            public override void SetReportHeader()
            {
                ReportObject.ReportHeader = "PDF Header";
            }
            public override void SetReportType()
            {
                ReportObject.ReportType = "PDF";
            }
        }

        public class ReportDirector
        {
            public Report MakeReport(ReportBuilder reportBuilder)
            {
                //reportBuilder.CreateNewReport();
                reportBuilder.SetReportType();
                reportBuilder.SetReportHeader();
                reportBuilder.SetReportContent();
                reportBuilder.SetReportFooter();
                return reportBuilder.GetReport();
            }
        }

        static void Main(string[] args)
        {
            // Client Code
            Report report;
            ReportDirector reportDirector = new ReportDirector();
            // Construct and display Reports
            PDFReport pdfReport = new PDFReport();
            report = reportDirector.MakeReport(pdfReport);
            report.DisplayReport();
            Console.WriteLine("-------------------");
            ExcelReport excelReport = new ExcelReport();
            report = reportDirector.MakeReport(excelReport);
            report.DisplayReport();

            ReportBuilder reportBuilder;
            reportBuilder = new PDFReport();
            reportDirector.MakeReport(reportBuilder);
            reportBuilder.ReportObject.DisplayReport();

            Console.ReadKey();
        }
    }
}
