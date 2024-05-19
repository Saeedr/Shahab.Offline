using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shahab.Offline.BL;
using Shahab.Offline.Logging;
using Shahab.Offline.Model;
using System.Windows.Forms.DataVisualization.Charting;
using DevComponents.DotNetBar;

namespace Shahab.Offline.WinUI
{
    public partial class frmReportAll : Form
    {
        public frmReportAll()
        {
            InitializeComponent();
        }

        private void PupolateChart(int ParentCode,Chart chr,SeriesChartType cht)
        {
            Legend legend1 = new Legend();
            Series series1 = new Series();
            B_GetDatas BG = new B_GetDatas();
            List<M_ReportFamilyMainChart> Report = BG.GetFamilyMainChart(ParentCode);
            legend1.Docking = Docking.Right;
            foreach (M_ReportFamilyMainChart li in Report.OrderByDescending(c => c.Value).ToList<M_ReportFamilyMainChart>())
            {
                DataPoint dataPoint1 = new DataPoint(0D, li.Value);
                dataPoint1.AxisLabel = li.Value.ToString();
                dataPoint1.Font = new System.Drawing.Font("B Nazanin", 16F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(178)));
                dataPoint1.LegendText = li.Title;
                if (cht == SeriesChartType.Column)
                {
                    dataPoint1.Font = new System.Drawing.Font("B Nazanin", 14F, FontStyle.Bold);
                    dataPoint1.AxisLabel = li.Title;
                    series1.Label = "#VAL";
                    legend1.Docking = Docking.Bottom;
                    chr.ChartAreas["ChartArea1"].AxisX.LabelStyle.Font = new Font("B Nazanin", 12F, FontStyle.Bold);
                }
                series1.Points.Add(dataPoint1);
            }
            legend1.Alignment = System.Drawing.StringAlignment.Center;
            legend1.Font = new System.Drawing.Font("B Nazanin", 12F, FontStyle.Bold);
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            chr.Legends.Add(legend1);
            series1.ChartArea = "ChartArea1";
            series1.ChartType = cht;
            series1.Font = new System.Drawing.Font("B Nazanin", 12F, FontStyle.Bold);
            series1.Legend = "Legend1";
            series1.LegendText = "تعداد به تفکیک بیمه";
            chr.Series.Add(series1);
            chr.ChartAreas[0].AxisY.LabelStyle.Font = new Font("B Nazanin", 12F, FontStyle.Bold);
            chr.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chr.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chr.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
            chr.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
        }

        private void ExportChart(int ParentCode, string Title)
        {
            SaveFileDialog sd = new SaveFileDialog();
            sd.Filter = "XLS Files|*.xls|XLSX Files|*.xlsx";
            if (sd.ShowDialog() == DialogResult.OK)
            {
                System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
                string date = "تاریخ و ساعت گزارش : " + pc.GetDayOfMonth(DateTime.Today) + " / " + pc.GetMonth(DateTime.Today) + " / " + pc.GetYear(DateTime.Today) + " ( " + DateTime.Now.Minute + " : " + DateTime.Now.Hour + " )";
                string export = @"<html xmlns:o='urn:schemas-microsoft-com:office:office' xmlns:x='urn:schemas-microsoft-com:office:excel' xmlns='http://www.w3.org/TR/REC-html40'>
                <head><!--[if gte mso 9]><xml><x:ExcelWorkbook><x:ExcelWorksheets><x:ExcelWorksheet>
                <x:Name>Ark1</x:Name>
                <x:WorksheetOptions><x:DisplayGridlines/></x:WorksheetOptions></x:ExcelWorksheet></x:ExcelWorksheets></x:ExcelWorkbook></xml><![endif]-->
                <style>td{border:none;font-family: 'B Nazanin';} .title{font-weight:bold;text-align:center;}</style>
                <meta name=ProgId content=Excel.Sheet>
                </head><body>
                <meta http-equiv='Content-Type' content='text/html; charset=utf-8' />
                <table><tr><td colspan='2' style='font-size:15px;text-align:center;font-weight:bold;'><br />" + Title + @"</td><tr>
                <tr><td colspan='2' style='font-size:12px;text-align:center;direction:rtl;'>" + date + "</td><tr>";
                B_GetDatas BG = new B_GetDatas();
                List<M_ReportFamilyMainChart> Report = BG.GetFamilyMainChart(ParentCode);
                foreach (M_ReportFamilyMainChart li in Report.OrderByDescending(c => c.Value).ToList<M_ReportFamilyMainChart>())
                {
                    export += "<tr><td class='title'>" + li.Title + "</td><td style='text-align:center;'>" + li.Value + "</td></tr>";
                }
                export += "<tr><td class='title'>مجموع</td><td class='title'>" + Report.Sum(c => c.Value) + "</td></tr>";
                export += "</table></body></html>";
                System.IO.File.WriteAllText(sd.FileName, export);
                frmDeleteConfirm frm = new frmDeleteConfirm();
                frm.label1.Text = "نمودار " + Title + " با موفقیت ذخیره شد" + Environment.NewLine + "میخواهید فایل باز شود ؟";
                frm.ShowDialog();
                if (frm.Status == true)
                    System.Diagnostics.Process.Start(sd.FileName);
            }
        }

        private void frmReportAll_Load(object sender, EventArgs e)
        {
            label7.BringToFront();
            label7.Visible = true;
        }

        private void groupPanel2_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            PupolateChart(51, chart1, SeriesChartType.Doughnut);
            Application.DoEvents();
            PupolateChart(10, chart2, SeriesChartType.Doughnut);
            Application.DoEvents();
            PupolateChart(7, chart3, SeriesChartType.Pie);
            Application.DoEvents();
            PupolateChart(29, chart4, SeriesChartType.Pie);
            Application.DoEvents();
            PupolateChart(35, chart5, SeriesChartType.Column);
            Application.DoEvents();
            PupolateChart(43, chart6, SeriesChartType.Column);
            Application.DoEvents();
            panel1.Width = flowLayoutPanel1.Width - 30;
            panel2.Width = flowLayoutPanel1.Width - 30;
            panel3.Width = flowLayoutPanel1.Width - 30;
            panel4.Width = flowLayoutPanel1.Width - 30;
            panel5.Width = flowLayoutPanel1.Width - 30;
            panel6.Width = flowLayoutPanel1.Width - 30;
            label7.Visible = false;
        }

        private void frmReportAll_Resize(object sender, EventArgs e)
        {
            panel1.Width = flowLayoutPanel1.Width - 30;
            panel2.Width = flowLayoutPanel1.Width - 30;
            panel3.Width = flowLayoutPanel1.Width - 30;
            panel4.Width = flowLayoutPanel1.Width - 30;
            panel5.Width = flowLayoutPanel1.Width - 30;
            panel6.Width = flowLayoutPanel1.Width - 30;
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            ButtonX btn = sender as ButtonX;
            int ActionID = int.Parse(btn.Tag.ToString());
            string title = "";
            switch(ActionID)
            {
                case 51:
                    {
                        title = "میزان تحصیلات";
                    } break;
                case 10:
                    {
                        title = "تفکیک جنسیت";
                    } break;
                case 7:
                    {
                        title = "تفکیک ملیت";
                    } break;
                case 29:
                    {
                        title = "وضعیت تاهل";
                    } break;
                case 35:
                    {
                        title = "بیمه اول";
                    } break;
                case 43:
                    {
                        title = "بیمه دوم";
                    } break;
            }
            ExportChart(ActionID, title);
        }
    }
}
