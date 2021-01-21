using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace hardWareViewer.reports.memoReport
{
    public partial class frmMemoReport : Form
    {
        memoCrystalReport report;

        public frmMemoReport(DataRowView drvData, DataTable dtData)
        {
            InitializeComponent();

            memoReport dsMemo = new memoReport();
            report = new memoCrystalReport();

            InsertDataSet(dsMemo, dtData);
            StaticData(dsMemo, drvData);
            
            report.SetDataSource(dsMemo);
            crvReport.ReportSource = report;
        }

        /// <summary>
        /// Функция заполнения DataSet'a данными
        /// </summary>
        /// <param name="dsMemo">Таблица в которую добавляются данные</param>
        /// <param name="dtData">Данные переданные для заполнения таблицы в отчете</param>
        private void InsertDataSet(memoReport dsMemo, DataTable dtData)
        {
            foreach (DataRow dtItem in dtData.Rows)
            {
                dsMemo.Tables["dsMemo"].Rows.Add(
                    dtItem["id"].ToString().Trim(), 
                    dtItem["cName"].ToString(),
                    dtItem["Count"].ToString().Trim(),
                    decimal.Parse(dtItem["Price"].ToString()),
                    decimal.Parse(dtItem["summa"].ToString()) + (dtItem["Delivery"].ToString() != "" ? decimal.Parse(dtItem["Delivery"].ToString()) : 0),
                    dtItem["link"].ToString(),
                    (dtItem["Delivery"].ToString() != "" ? decimal.Parse(dtItem["Delivery"].ToString()) : 0)
                );
            }
        }

        /// <summary>
        /// Функция заполнения single данных
        /// </summary>
        /// <param name="dsMemo">Таблица с данными</param>
        /// <param name="drvData">Общие данные для отчета</param>
        /// <param name="dtDataDep">Данные о отделах</param>
        private void StaticData(memoReport dsMemo, DataRowView drvData)
        {
            decimal delivery = Convert.ToDecimal(drvData["Delivery"].ToString());
            report.DataDefinition.FormulaFields["Delivery"].Text = "$" + delivery.ToString().Replace(",", ".");
            decimal shipping = Convert.ToDecimal(drvData["Shipping"].ToString());

            report.DataDefinition.FormulaFields["total"].Text = "$" + (shipping + delivery).ToString().Replace(",",".");
            report.DataDefinition.FormulaFields["fTotal"].Text = "toText(" + (shipping + delivery).ToString().Replace(",", ".") + ", 2) + \" руб.\"";
            report.DataDefinition.FormulaFields["comment"].Text = "\"" + drvData["EstimateName"].ToString() + "\"";
        }
    }
}
