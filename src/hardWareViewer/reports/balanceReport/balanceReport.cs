using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Nwuram.Framework.ToExcelNew;

namespace hardWareViewer
{
    /// <summary>
    /// Формирование сметы
    /// </summary>
    class balanceReport
    {
        int posFooter = 1;
        decimal amount = 0;
        public balanceReport(int id, DateTime date)
        {
            ExcelUnLoad report = new ExcelUnLoad();

            report = addHeader(report);
            report = addHeaderColumn(report);
            report = addTable(report, id, date);
            report = addFooter(report);

            report.Show();
        }

        /// <summary>
        /// Заголовок отчета по оборудованию ожидающим постоновки на баланс
        /// </summary>
        /// <param name="report">Отчет</param>
        /// <returns>Отчет</returns>
        ExcelUnLoad addHeader(ExcelUnLoad report)
        {
            report.Merge(1, 1, 1, 7);
            report.AddSingleValue("Отчет \"Оборудование, ожидающее постановки на баланс\"", 1, 1);
            report.SetFontSize(1, 1, 1, 1, 14);
            report.SetFontBold(1, 1, 1, 1);
            report.SetCellAlignmentToCenter(1, 1, 1, 1);

            report.Merge(2, 1, 2, 2);
            report.AddSingleValue("Дата выгрузки:", 2, 1);

            report.AddSingleValue(DateTime.Now.ToShortDateString(), 2, 3);

            report.SetFontBold(2, 1, 2, 1);

            return report;
        }

        /// <summary>
        /// Шапка таблицы
        /// </summary>
        /// <param name="report">Отчет</param>
        /// <returns>Отчет</returns>
        ExcelUnLoad addHeaderColumn(ExcelUnLoad report)
        {
            report.AddSingleValue("№ п/п", 3, 1);
            report.SetColumnWidth(3, 1, 3, 1, 5);
            report.AddSingleValue("Тип оборудования/ комплектующих", 3, 2);
            report.SetColumnWidth(3, 2, 3, 2, 18);
            report.AddSingleValue("Наименование оборудования/ комплектующих", 3, 3);
            report.SetColumnWidth(3, 3, 3, 3, 19);
            report.AddSingleValue("Количество", 3, 4);
            report.SetColumnWidth(3, 4, 3, 4, 12);
            report.Merge(3, 5, 3, 6);
            report.AddSingleValue("Итоговая сумма, руб", 3, 5);
            report.SetColumnWidth(3, 5, 3, 5, 10);
            report.SetColumnWidth(3, 6, 3, 6, 10);
            report.AddSingleValue("Дата выдачи денежных средств", 3, 7);
            report.SetColumnWidth(3, 7, 3, 7, 13);

            report.SetCellAlignmentToCenter(3, 1, 3, 7);
            report.SetFontBold(3, 1, 3, 7);
            report.SetBorders(3, 1, 3, 7);
            report.SetWrapText(3, 1, 3, 7);

            return report;
        }

        /// <summary>
        /// Таблица
        /// </summary>
        /// <param name="report">Отчет</param>
        /// <param name="id">id Сметы</param>
        /// <param name="date">Дата выдачи денежных средств</param>
        /// <returns>Отчет</returns>
        ExcelUnLoad addTable(ExcelUnLoad report, int id, DateTime date)
        {
            int row = 4;

            DataTable dtTable = readSQL.getContentEstimate(id);

            dtTable.Select("Status = 1");

            dtTable.Columns.Remove("isSelect");
            dtTable.Columns.Remove("id_ComponentsHardware");
            dtTable.Columns.Remove("TypeComponentsHardware");
            dtTable.Columns.Remove("Link");
            dtTable.Columns.Remove("Description");
            dtTable.Columns.Remove("isLink");
            dtTable.Columns.Remove("id");
            dtTable.Columns.Remove("Status");
            dtTable.Columns.Remove("nameStatus");
            dtTable.Columns.Remove("nameStatusConfirm");
            dtTable.Columns.Remove("StatusConfirmation");
            dtTable.Columns.Remove("Purchase");
            dtTable.Columns.Remove("namePurchase");
            dtTable.Columns.Remove("Delivery");
            dtTable.Columns.Remove("id_component_link");
            dtTable.Columns.Remove("sort");
            dtTable.Columns.Remove("pos");
            dtTable.Columns.Remove("nameTypeLinkView");
            dtTable.Columns.Remove("StatusBuild");
            dtTable.Columns.Remove("Comments");

            DataColumn dc = new DataColumn();
            dc.ColumnName = "dateEdit";
            dc.DataType = typeof(String);
            dc.DefaultValue = date.ToShortDateString();
            dtTable.Columns.Add(dc);

            dtTable.Columns["row"].SetOrdinal(0);
            dtTable.Columns["nameType"].SetOrdinal(1);
            dtTable.Columns["cName"].SetOrdinal(2);
            dtTable.Columns["Count"].SetOrdinal(3);
            dtTable.Columns["Price"].SetOrdinal(4);
            dtTable.Columns["summa"].SetOrdinal(5);
            dtTable.Columns["dateEdit"].SetOrdinal(6);

            int count = dtTable.Rows.Count;
            for (int i = row; i < row + count; i++)
            {
                report.Merge(i, 5, i, 6);
            }

            report.AddMultiValue(dtTable, row, 1);

            report.SetBorders(row, 1, row + count - 1, 7);
            report.SetCellAlignmentToCenter(row, 1, row + count - 1, 1);
            report.SetCellAlignmentToRight(row, 4, row + count - 1, 7);
            report.SetCellAlignmentToJustify(row, 3, row + count - 1, 3);
            report.SetWrapText(row, 3, row + count - 1, 3);

            amount = Convert.ToDecimal(dtTable.Compute("sum(summa)", "").ToString());

            row += count;
            posFooter = row;

            return report;
        }

        /// <summary>
        /// Подвал сметы
        /// </summary>
        /// <param name="report">Отчет</param>
        /// <returns>Отчет</returns>
        ExcelUnLoad addFooter(ExcelUnLoad report)
        {
            report.AddSingleValue("Итого:", posFooter, 5);

            report.SetBorders(posFooter, 5, posFooter, 5);
            report.SetFontBold(posFooter, 5, posFooter, 5);
            report.SetCellAlignmentToRight(posFooter, 5, posFooter, 5);


            report.AddSingleValue(amount.ToString(), posFooter, 6);

            report.SetBorders(posFooter, 6, posFooter, 6);
            report.SetCellAlignmentToRight(posFooter, 6, posFooter, 6);

            return report;
        }
    }
}
