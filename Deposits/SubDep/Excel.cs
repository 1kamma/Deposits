//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Runtime.InteropServices;

namespace Deposits.SubDep {
    class Excel {

        Microsoft.Office.Interop.Excel.Workbooks wb;
        public Excel() {
            wb.Open(@"D:\Drive\מסמכים\מסמכים לסנכרון\צבירוש.xlsx");

        }
    }
}
