//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Runtime.InteropServices;
//using Microsoft.Office.Interop.Excel;
//using OfficeOpenXml.Core;
namespace Deposits.SubDep {
    class Excel {
        private static System.IO.FileInfo file = new System.IO.FileInfo(DataDetails.ExcelLocation);
        private OfficeOpenXml.ExcelPackage excelPackage = new OfficeOpenXml.ExcelPackage(file);
        public OfficeOpenXml.ExcelWorksheet deposits { get; }
        public OfficeOpenXml.ExcelWorksheet creditCard { get; }
        public Excel() {
            var wb = excelPackage.Workbook;
            foreach (var sheet in wb.Worksheets) {
                if (sheet.Name.Contains("צבירוש") || sheet.Name.Contains("deposit")) {
                    this.deposits = sheet;
                } else if (sheet.Name.Contains("credit")) {
                    this.creditCard = sheet;
                }
            }
            if (deposits == null) {
                deposits = wb.Worksheets.Add("deposits");
            }
            if (creditCard == null) {
                creditCard = wb.Worksheets.Add("credit card");
            }

        }
        public void UpdateDeposits() {

        }
    }
}
