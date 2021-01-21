/*using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;

namespace hardWareViewer
{
    /// <summary>
    /// Класс отвечающий за печать списка объектов
    /// </summary>
    public class objectReport
    {
        public objectReport(System.Data.DataTable dtObject)
        {
            DisplayInExcel(dtObject);
        }


        void DisplayInExcel(System.Data.DataTable dtObject)
        {

            var excelApp = new Excel.Application();
            
            excelApp.Workbooks.Add();

            Excel.Worksheet workSheet = (Excel.Worksheet)excelApp.ActiveSheet;

            createHeader(workSheet);
            addTable(dtObject, workSheet);

            workSheet.Columns[1].AutoFit();
            workSheet.Columns[2].AutoFit();

            excelApp.Visible = true;
        }

        void createHeader(Excel.Worksheet workSheet)
        {
            workSheet.Cells[1, "A"] = "№";
            workSheet.Cells[1, "B"] = "Имя";
        }

        void addTable(System.Data.DataTable dtObject, Excel.Worksheet workSheet)
        {
            foreach (DataRow item in dtObject.Rows)
            {
                workSheet.Cells[Convert.ToInt32(item["index"].ToString()) + 1, "A"] = item["index"].ToString();
                workSheet.Cells[Convert.ToInt32(item["index"].ToString()) + 1, "B"] = item["cName"].ToString();
            }
        }
    }
}
*/