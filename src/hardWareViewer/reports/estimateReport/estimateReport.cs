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
    class estimateReport
    {
        int posFooter = 1;
        public estimateReport(DataRow current)
        {
            ExcelUnLoad report = new ExcelUnLoad();

            report = addHeader(report, current);
            report = addHeaderColumn(report);
            report = addTable(report, Convert.ToInt32(current["id"].ToString()));
            report = addFooter(report, current);

            report.Show();
        }

        /// <summary>
        /// Заголовок сметы
        /// </summary>
        /// <param name="report">Отчет</param>
        /// <param name="current">Текущая смета</param>
        /// <returns>Отчет</returns>
        ExcelUnLoad addHeader(ExcelUnLoad report, DataRow current)
        {
            DataTable dtDep = readSQL.getSingleDepartamens(Convert.ToInt32(current["id_Dep"].ToString()));
            report.Merge(1, 1, 1, 7);
            report.AddSingleValue("Смета на закупку компьютерного оборудования/комплектующих", 1, 1);
            report.SetFontSize(1, 1, 1, 1, 14);
            report.SetFontBold(1, 1, 1, 1);
            report.SetCellAlignmentToCenter(1, 1, 1, 1);

            report.Merge(2, 1, 2, 2);
            report.AddSingleValue("Дата создания сметы:", 2, 1);
            report.Merge(3, 1, 3, 2);
            report.AddSingleValue("Наименование сметы:", 3, 1);
            report.Merge(4, 1, 4, 2);
            report.AddSingleValue("Название сметы:", 4, 1);
            report.Merge(5, 1, 5, 2);
            report.AddSingleValue("Отдел:", 5, 1);

            report.AddSingleValue(current["Date"].ToString(), 2, 3);
            report.AddSingleValue(current["EstimateName"].ToString(), 3, 3);
            report.AddSingleValue(current["EstimateDetail"].ToString(), 4, 3);
            report.AddSingleValue(dtDep.Rows[0]["cName"].ToString(), 5, 3);

            report.SetFontBold(2, 1, 5, 1);

            return report;
        }

        /// <summary>
        /// Шапка таблицы
        /// </summary>
        /// <param name="report">Отчет</param>
        /// <returns>Отчет</returns>
        ExcelUnLoad addHeaderColumn(ExcelUnLoad report)
        {
            report.AddSingleValue("№ п/п", 7, 1);
            report.SetColumnWidth(7, 1, 7, 1, 5);
            report.AddSingleValue("Тип оборудования/ комплектующих", 7, 2);
            report.SetColumnWidth(7, 2, 7, 2, 17);
            report.AddSingleValue("Наименование оборудования/ комплектующих", 7, 3);
            report.SetColumnWidth(7, 3, 7, 3, 20);
            report.AddSingleValue("Кол-во", 7, 4);
            report.AddSingleValue("Цена", 7, 5);
            report.SetColumnWidth(7, 5, 7, 5, 11);
            report.AddSingleValue("Сумма", 7, 6);
            report.AddSingleValue("Комментарии", 7, 7);
            report.SetColumnWidth(7, 7, 7, 7, 20);

            report.SetCellAlignmentToCenter(7, 1, 7, 7);
            report.SetFontBold(7, 1, 7, 7);
            report.SetBorders(7, 1, 7, 7);
            report.SetWrapText(7, 1, 7, 7);

            return report;
        }

        /// <summary>
        /// Таблица
        /// </summary>
        /// <param name="report">Отчет</param>
        /// <param name="id">id Сметы</param>
        /// <returns>Отчет</returns>
        ExcelUnLoad addTable(ExcelUnLoad report, int id)
        {
            int row = 8;

            DataTable dtTable = readSQL.getContentEstimate(id);

            dtTable.Select("Purchase = 0 or Purchase = 1");

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

            dtTable.Columns["row"].SetOrdinal(0);
            dtTable.Columns["nameType"].SetOrdinal(1);
            dtTable.Columns["cName"].SetOrdinal(2);
            dtTable.Columns["Count"].SetOrdinal(3);
            dtTable.Columns["Price"].SetOrdinal(4);
            dtTable.Columns["summa"].SetOrdinal(5);
            dtTable.Columns["Comments"].SetOrdinal(6);

            int count = dtTable.Rows.Count;

            report.AddMultiValue(dtTable, row, 1);

            report.SetBorders(row, 1, row + count - 1, 7);
            report.SetCellAlignmentToCenter(row, 1, row + count - 1, 1);
            report.SetCellAlignmentToRight(row, 4, row + count - 1, 6);

            row += count;
            posFooter = row;

            return report;
        }

        /// <summary>
        /// Подвал сметы
        /// </summary>
        /// <param name="report">Отчет</param>
        /// <param name="current">Текущая смета</param>
        /// <returns>Отчет</returns>
        ExcelUnLoad addFooter(ExcelUnLoad report, DataRow current)
        {
            int posStart = posFooter;
            report.AddSingleValue("Итого:", posFooter++, 5);
            report.AddSingleValue("Доставка:", posFooter++, 5);
            report.AddSingleValue("Итого с доставкой:", posFooter++, 5);

            report.SetBorders(posStart, 5, --posFooter, 5);
            report.SetWrapText(posStart, 5, posFooter, 5);
            report.SetFontBold(posStart, 5, posFooter, 5);

            posFooter = posStart;

            report.AddSingleValue(current["Shipping"].ToString(), posFooter++, 6);
            report.AddSingleValue(current["Delivery"].ToString(), posFooter++, 6);
            report.AddSingleValue(Convert.ToString(Convert.ToDecimal(current["Shipping"].ToString()) + Convert.ToDecimal(current["Delivery"].ToString())), posFooter++, 6);

            report.SetBorders(posStart, 6, --posFooter, 6);
            report.SetCellAlignmentToRight(posStart, 6, posFooter, 6);

            return report;
        }
    }
}
