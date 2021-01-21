using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace hardWareViewer.journalActWriteOff
{
    class printReport
    {

        public static void printWriteOff(int id)
        {

            DataTable dtDataHead = readSQL.getActWriteOff(DateTime.Now, DateTime.Now, id);
            DataTable dtDataBody = readSQL.getContentWriteOff(id);


            Nwuram.Framework.ToExcelNew.ExcelUnLoad report = new Nwuram.Framework.ToExcelNew.ExcelUnLoad();
            int indexRow = 1;

            report.Merge(indexRow, 1, indexRow, 6);
            report.AddSingleValue("Акт списания оборудования", indexRow, 1);
            report.SetCellAlignmentToCenter(indexRow, 1, indexRow, 1);
            report.SetFontBold(indexRow, 1, indexRow, 1);
            report.SetFontSize(indexRow, 1, indexRow, 1, 16);
            indexRow++;
            indexRow++;

            report.Merge(indexRow, 5, indexRow, 6);
            report.AddSingleValue("Дата: " + ((DateTime)dtDataHead.Rows[0]["Date"]).ToShortDateString(), indexRow, 5);
            indexRow++;

            report.Merge(indexRow, 1, indexRow, 6);
            report.AddSingleValue("Причина: " + dtDataHead.Rows[0]["Reason"].ToString(), indexRow, 1);                       
            report.SetWrapText(indexRow, 1, indexRow, 1);
            //report.SetAutoFit(indexRow, 1, indexRow, 1);
            report.SetRowHeight(indexRow, 1, indexRow, 1, 60);
            indexRow++;
            indexRow++;


            report.AddSingleValue("№ п\\п", indexRow, 1);
            report.AddSingleValue("Наименование", indexRow, 2);
            report.AddSingleValue("Инвентарный номер", indexRow, 3);
            report.AddSingleValue("EAN", indexRow, 4);
            report.AddSingleValue("Местоположение", indexRow, 5);
            report.AddSingleValue("Комментарий", indexRow, 6);

            report.SetFontBold(indexRow, 1, indexRow, 6);
            report.SetBorders(indexRow, 1, indexRow, 6);
            report.SetCellAlignmentToCenter(indexRow, 1, indexRow, 6);
            indexRow++;

            foreach (DataRow row in dtDataBody.Rows)
            {
                report.AddSingleValue(row["npp"].ToString(), indexRow, 1);
                report.AddSingleValue(row["cName"].ToString(), indexRow, 2);
                report.AddSingleValue(row["InventoryNumber"].ToString(), indexRow, 3);
                report.AddSingleValue(row["EAN"].ToString(), indexRow, 4);
                report.AddSingleValue(row["nameLocation"].ToString(), indexRow, 5);
                //report.AddSingleValue(row[""].ToString(), indexRow, 6);                
                report.SetBorders(indexRow, 1, indexRow, 6);
                report.SetCellAlignmentToCenter(indexRow, 1, indexRow, 6);
                indexRow++;
            }
            indexRow++;

            report.Merge(indexRow, 1, indexRow, 6);
            report.AddSingleValue("ОЭЭС:", indexRow, 1);
            indexRow++;

            report.Merge(indexRow, 1, indexRow, 6);
            report.AddSingleValue("РБ5:", indexRow, 1);
            indexRow++;

            report.Merge(indexRow, 1, indexRow, 6);
            report.AddSingleValue("О1:", indexRow, 1);
            indexRow++;

            report.SetColumnAutoSize(5, 1, indexRow, 6);            
            report.SetPageSetup(1, 9999, false);               
            report.Show();
            
        }
    }
}
