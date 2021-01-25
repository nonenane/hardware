using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace hardWareViewer.listHardware
{
    public static class reportHistory
    {
        public static void createReport(int id_hardware,DateTime startDate,DateTime endDate,string strType,int type,List<string> listFilter)
        {
            DataTable dtReport = new DataTable();
            if(id_hardware!=0)
                dtReport = readSQL.getReportHistory(id_hardware,null,null,null);
            else
                dtReport = readSQL.getReportHistory(id_hardware, startDate, endDate, type);

            if (dtReport == null) { MessageBox.Show("Нет данных для выгрузки!","Информирование"); ; return; }
            if (dtReport.Rows.Count == 0) { MessageBox.Show("Нет данных для выгрузки!", "Информирование"); ; return; }


            if (listFilter != null)
            {
                EnumerableRowCollection<DataRow> rowsFind = dtReport.AsEnumerable().Where(r => listFilter.Contains(r.Field<string>("cName").Trim()));
                if(rowsFind.Count()==0) { MessageBox.Show("Нет данных для выгрузки!", "Информирование"); ; return; }

                dtReport = rowsFind.CopyToDataTable();
            }

            Nwuram.Framework.ToExcelNew.ExcelUnLoad report = new Nwuram.Framework.ToExcelNew.ExcelUnLoad();

            int indexRow = 1;

            string[] listTitle = new string[] { "Инв. номер", @"Оборудование\Комплектующее", @"Наименование оборуд.\комплект.", @"Дата добавления оборудования", "Параметр", "Значение До", "Значение после", "Время изменения", "Кто изменил" };

            report.Merge(indexRow, 1, indexRow, listTitle.Length);
            report.AddSingleValue("Отчёт по изменению в оборудовании", indexRow, 1);
            report.SetFontSize(indexRow, 1, indexRow, 1, 16);
            report.SetFontBold(indexRow, 1, indexRow, 1);
            indexRow++;


            if (id_hardware == 0)
            {

                report.Merge(indexRow, 1, indexRow, listTitle.Length);
                report.AddSingleValue("Период с "+ startDate.ToShortDateString()+ " по "+ endDate.ToShortDateString() + "", indexRow, 1);
                indexRow++;

                report.Merge(indexRow, 1, indexRow, listTitle.Length);
                report.AddSingleValue("Условие: " + strType, indexRow, 1);
                indexRow++;
            }

            report.Merge(indexRow, 1, indexRow, listTitle.Length);
            report.AddSingleValue("Дата и время выгрузки: " + DateTime.Now.ToString(), indexRow, 1);
            indexRow++;

            report.Merge(indexRow, 1, indexRow, listTitle.Length);
            report.AddSingleValue("Выгрузил: " + Nwuram.Framework.Settings.User.UserSettings.User.FullUsername, indexRow, 1);
            indexRow++;
            indexRow++;
            int startPos = indexRow;
            for (int i = 0; i < listTitle.Length; i++)
            {
                report.AddSingleValue(listTitle[i], indexRow, i + 1);
                report.SetBorders(indexRow, i + 1, indexRow, i + 1);
                report.SetCellAlignmentToCenter(indexRow, i + 1, indexRow, i + 1);

            }
            indexRow++;


            //EnumerableRowCollection<DataRow> 
            var rowCollect = from hosp in dtReport.AsEnumerable()
                             group hosp by new { id_jHardware = hosp["id_jHardware"], id_Creator = hosp["id_Creator"], DateCreate = hosp["DateCreate"] } into grp
                             orderby grp.Key.id_jHardware ascending, grp.Key.DateCreate ascending
                             select new
                             {
                                 id_jHardware = grp.Key.id_jHardware,
                                 id_Creator = grp.Key.id_Creator,
                                 DateCreate = grp.Key.DateCreate,
                             };

            foreach (var rC in rowCollect)
            {
                DataRow[] row = dtReport.Select(string.Format("id_jHardware = {0} and id_Creator = {1} AND DateCreate = '{2}'", rC.id_jHardware, rC.id_Creator, rC.DateCreate));

                report.Merge(indexRow, 1, indexRow + row.Count()-1, 1);
                report.Merge(indexRow, 2, indexRow + row.Count()-1, 2);
                report.Merge(indexRow, 3, indexRow + row.Count()-1, 3);
                report.Merge(indexRow, 8, indexRow + row.Count() - 1, 8);
                report.Merge(indexRow, 9, indexRow + row.Count() - 1, 9);
                report.AddSingleValue(row[0]["InventoryNumber"].ToString(), indexRow, 1);
                report.AddSingleValue(row[0]["TypeComponentsHardware"].ToString(), indexRow, 2);
                report.AddSingleValue(row[0]["nameOb"].ToString(), indexRow, 3);
                report.AddSingleValue(row[0]["DateCreate"].ToString(), indexRow, 8);
                report.AddSingleValue(row[0]["FIO"].ToString(), indexRow, 9);
                report.SetCellAlignmentToJustify(indexRow, 1, indexRow, 9);
                report.SetCellAlignmentToCenter(indexRow, 1, indexRow, 1);
                report.SetCellAlignmentToCenter(indexRow, 2, indexRow, 2);
                report.SetCellAlignmentToCenter(indexRow, 3, indexRow, 3);
                report.SetCellAlignmentToCenter(indexRow, 8, indexRow, 8);
                report.SetCellAlignmentToCenter(indexRow, 9, indexRow, 9);

                foreach (DataRow r in row)
                {
                    report.AddSingleValue(r["DateCreateHardWare"].ToString(), indexRow, 4);
                    report.AddSingleValue(r["cName"].ToString(), indexRow, 5);
                    report.AddSingleValue(r["valueOld"].ToString(), indexRow, 6);
                    report.AddSingleValue(r["valueNew"].ToString(), indexRow, 7);

                    report.SetCellAlignmentToCenter(indexRow, 4, indexRow, 4);

                    if ((bool)r["isDeleteRow"])
                    {
                        report.SetCellColor(indexRow, 1, indexRow, listTitle.Length, Color.Green);
                    }
                    report.SetBorders(indexRow, 1, indexRow, listTitle.Length);
                    indexRow++;
                }

            }

            indexRow++;
            report.SetCellColor(indexRow, 1, indexRow, 1, Color.Green);
            report.AddSingleValue("Удалённые записи",indexRow, 2);

            /*
            foreach (DataRow r in dtReport.Rows)
            {
                report.AddSingleValue(r["InventoryNumber"].ToString(), indexRow, 1);
                report.AddSingleValue(r["TypeComponentsHardware"].ToString(), indexRow, 2);
                report.AddSingleValue(r["nameOb"].ToString(), indexRow, 3);
                report.AddSingleValue(r["cName"].ToString(), indexRow, 4);
                report.AddSingleValue(r["valueOld"].ToString(), indexRow, 5);
                report.AddSingleValue(r["valueNew"].ToString(), indexRow, 6);
                report.AddSingleValue(r["DateCreate"].ToString(), indexRow, 7);
                report.AddSingleValue(r["FIO"].ToString(), indexRow, 8);
                report.SetBorders(indexRow, 1, indexRow, listTitle.Length);
                indexRow++;
            }
            */

            report.SetColumnAutoSize(startPos, 1, indexRow, listTitle.Length);
            report.Show();
        }
    }
}
