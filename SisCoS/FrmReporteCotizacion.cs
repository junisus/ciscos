using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;
using System.Collections;
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;



namespace SisCoS
{
    public partial class FrmReporteCotizacion : Form
    {
        private SqlConnection cn;
        public FrmReporteCotizacion()
        {
            InitializeComponent();
            //cn = FrmPrincipal.cn;
            dgvDirectorio.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            txtCodigo.Select();
            txtCodigo.Focus();
        }

        private void FrmReporteCotizacion_Load(object sender, EventArgs e)
        {
            ReporteCotizar();
        }

        private void ReporteCotizar()
        {
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "sp_ReporteCotizacion";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@desc", txtCodigo.Text);
                cmd.Parameters.AddWithValue("@fecha1", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@fecha2", dateTimePicker2.Value);

                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dta = new DataTable();
                dta.Load(dr);
                dgvDirectorio.DataSource = dta;
                dr.Close();
            }
            catch (SqlException) { }
        }

        private void txtDesc_TextChanged(object sender, EventArgs e)
        {
            ReporteCotizar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            exportarExcel();
        }

        private void exportarExcel()
        {

            try
            {

                Excel.Application oxl;
                Excel._Workbook owb;
                Excel._Worksheet ost;
                oxl = new Excel.Application();
                oxl.Visible = true;
                owb = (Excel._Workbook)(oxl.Workbooks.Add(Missing.Value));
                ost = (Excel._Worksheet)owb.ActiveSheet;
                ost.get_Range("A1", "K1").Merge();
                ost.get_Range("A2", "K2").Merge();
                ost.get_Range("A3", "K3").Merge();
                // ost.get_Range("A3", "K3").HorizontalAlignment = 10;
                ost.get_Range("A2", "k100").Font.FontStyle = "Arial Narrow";
                ost.get_Range("A2", "k100").Font.Bold = true;
                ost.get_Range("A2", "k100").Font.Size = 9;
                ost.Cells[1, 1] = "MR TECH SOLUTIONS";
                ost.Cells[2, 1] = "Reporte de Cotizaciones";
                ost.Cells[3, 1] = "CUADRO RESUMEN";
                ost.Cells[5, 1] = "Nª:";
                ost.Cells[5, 2] = "ClienteCódigo";
                ost.Cells[5, 3] = "Cliente";
                ost.Cells[5, 4] = "Total";
                ost.Cells[5, 5] = "Días Transcurrido";

                //oxl.Cells.EntireColumn.AutoFit();
                int k = 0;
                for (int i = 0; i < dgvDirectorio.Rows.Count; i++)
                {
                    // DataTable dt = Mostrar1();


                    for (int j = 0; j < dgvDirectorio.Columns.Count; j++)
                    {

                        ost.Cells[i + 6, j + 2] = dgvDirectorio.Rows[i].Cells[j].Value.ToString();

                        //ost.Cells[k + 6, 3].NumberFormat = ("yyyy-MM-dd");
                        //ost.Cells[k + 6, 4].NumberFormat = String.Format("hh:mm:ss");
                        //ost.Cells[k + 6, 5].NumberFormat = String.Format("hh:mm:ss");
                        ost.Cells.EntireColumn.AutoFit();


                    }
                    ost.Cells[k + 6, 1] = (k + 1).ToString();
                    ost.get_Range("A5", "e" + (k + 6).ToString()).Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    ost.get_Range("A6", "e" + (k + 6).ToString()).RowHeight = 20;
                    ost.Columns["B"].ColumnWidth = 15;
                    ost.Columns["E"].ColumnWidth = 12;
                    ost.Columns["G"].ColumnWidth = 12;
                    k++;
                }
            }
            catch (Exception) { }
        }

        private void dgvDirectorio_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FrmDetalleCotizacion frmdc = new FrmDetalleCotizacion();
            frmdc.Show();
            //frmdc.txtCodigo.Text = dgvDirectorio.Rows[e.RowIndex].Cells["clmIdCotizacion"].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReporteCotizar();
        }

        private void dgvDirectorio_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow row in dgvDirectorio.Rows)
                if (Convert.ToInt32(row.Cells[3].Value) > 10)
                {
                    row.DefaultCellStyle.BackColor = Color.Green;
                }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

    }
}
