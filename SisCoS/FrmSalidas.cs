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
    public partial class FrmSalidas : Form
    {
        private SqlConnection cn;
        private string id, desc;
        public FrmSalidas()
        {
            InitializeComponent();
            //cn = FrmPrincipal.cn;
            dgvDirectorio.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            txtDesc.Select();
            txtDesc.Focus();
        }

        private void FrmSalidas_Load(object sender, EventArgs e)
        {
            ReporteSalida();
        }

        private void ReporteSalida()
        {
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "sp_ReporteSalidas";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@desc", txtDesc.Text);
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
            ReporteSalida();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReporteSalida();
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
                ost.Cells[2, 1] = "Reporte de Salidas";
                ost.Cells[3, 1] = "CUADRO RESUMEN";
                ost.Cells[5, 1] = "Nª:";
                ost.Cells[5, 2] = "Cliente";
                ost.Cells[5, 3] = "Total";


               
                int k = 0;
                for (int i = 0; i < dgvDirectorio.Rows.Count; i++)
                {
                   


                    for (int j = 0; j < dgvDirectorio.Columns.Count; j++)
                    {

                        ost.Cells[i + 6, j + 2] = dgvDirectorio.Rows[i].Cells[j].Value.ToString();

                        
                        ost.Cells.EntireColumn.AutoFit();


                    }
                    ost.Cells[k + 6, 1] = (k + 1).ToString();
                    ost.get_Range("A5", "c" + (k + 6).ToString()).Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    ost.get_Range("A6", "c" + (k + 6).ToString()).RowHeight = 20;
                    ost.Columns["B"].ColumnWidth = 15;
                    ost.Columns["E"].ColumnWidth = 12;
                    ost.Columns["G"].ColumnWidth = 12;
                    k++;
                }
            }
            catch (Exception) { }
        }

        private void dgvDirectorio_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = dgvDirectorio.Rows[e.RowIndex].Cells["clmIdContrato"].Value.ToString();
            textBox2.Text = id;

            desc = dgvDirectorio.Rows[e.RowIndex].Cells["clmsalida"].Value.ToString();
            textBox1.Text = desc;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea Cambiar el Estado?", "Advertencia", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {

                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandText = "sp_modificarSalida";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@idSalida", SqlDbType.Int).Value = textBox1.Text;
                    cmd.Parameters.Add("@desc", SqlDbType.VarChar, 500).Value = textBox2.Text;
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Close();
                    MessageBox.Show("Datos Actualizados", "SisCoS");
                    ReporteSalida();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    
                }


                catch (SqlException ex) { MessageBox.Show(ex.Message, "SisCoS", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }
    }
}
