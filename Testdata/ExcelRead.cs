using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace Sparkassignment.Testdata
{
    class ExcelRead
    {

        public static Excel.Workbook eworkbook;
        public static Excel.Application excel2;
        public static Excel.Worksheet ws;
        public static Excel.Range xlRange;
        public static String test;
        public static List<String> ReadExcel(String path, int Sheet)
        {
            Excel.Application excel2 = new Excel.Application();
            eworkbook = excel2.Workbooks.Open(path);
            ws = eworkbook.Worksheets[Sheet];

            Excel.Range xlRange = ws.UsedRange;
            List<String> data = new List<String>();
            for (int i = 2; i < xlRange.Rows.Count + 1; i++)
            {
                for (int j = 1; j < xlRange.Columns.Count + 1; j++)
                {
                    if (xlRange.Cells[i, j] != null)
                    {


                        data.Add(Convert.ToString(xlRange.Cells[i, j].Value2));
                    }
                    else
                        break;


                }
            }


            return data;
        }
    }
}
