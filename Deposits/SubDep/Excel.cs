//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Runtime.InteropServices;
//using Microsoft.Office.Interop.Excel;
//using OfficeOpenXml.Core;
//using HtmlAgilityPack;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Deposits.SubDep {
    class Excel {
        private static System.IO.FileInfo file = new System.IO.FileInfo(DataDetails.ExcelLocation);
        private OfficeOpenXml.ExcelPackage excelPackage = new OfficeOpenXml.ExcelPackage(file);
        public OfficeOpenXml.ExcelWorksheet deposits { get; }
        public OfficeOpenXml.ExcelWorksheet creditCard { get; }
        public OfficeOpenXml.ExcelWorksheet depositHistory { get; }
        public Excel() {
            var wb = excelPackage.Workbook;
            foreach (var sheet in wb.Worksheets) {
                if (sheet.Name.Contains("צבירוש") || sheet.Name.Contains("deposit")) {
                    this.deposits = sheet;
                } else if (sheet.Name.Contains("credit")) {
                    this.creditCard = sheet;
                } else if (sheet.Name.StartsWith("History")) {
                    this.depositHistory = sheet;
                }
            }
            if (deposits == null) {
                deposits = wb.Worksheets.Add("deposits");
            }
            if (creditCard == null) {
                creditCard = wb.Worksheets.Add("credit card");
            }
            if (depositHistory == null) {
                creditCard = wb.Worksheets.Add("History of Deposits");
            }

        }
        public void UpdateDeposits(string htmlPage) {
            HtmlAgilityPack.HtmlDocument document = new();
            document.LoadHtml(htmlPage);
            var s = document.DocumentNode.SelectNodes("//span");
            List<float> data = new List<float>();
            Regex regex = new Regex(@"(\d|.)+");

            foreach (var item in s) {
                if (item.Attributes["class"].Name == "bigLobbyImageSum") {
                    var v = regex.Match(item.Attributes["class"].Value).Value;
                    data.Add(float.Parse(v));
                }
            }
            this.deposits.Cells["B2:B5"].Value = data.ToArray();
        }
    }
}
