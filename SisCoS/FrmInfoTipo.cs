using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using MySql.Data.MySqlClient;
//using System.Data.SqlClient;
using System.Collections;
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;
namespace SisCoS
{
    public partial class FrmInfoTipo : Form
    {
        private MySqlConnection cn;
        private string id, desc;
        public FrmInfoTipo()
        {
            InitializeComponent();
            cn = FrmPrincipal.cn;
            dgvDirectorio.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            txtDesc.Select();
            txtDesc.Focus();
        }

        private void FrmInfoTipo_Load(object sender, EventArgs e)
        {
            getTipo();
        }

        private void txtDesc_TextChanged(object sender, EventArgs e)
        {
            getTipo();
        }

        private void dgvDirectorio_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = dgvDirectorio.Rows[e.RowIndex].Cells["clmIdMedida"].Value.ToString();
            txtid.Text = id;

            desc = dgvDirectorio.Rows[e.RowIndex].Cells["clmDescripcion"].Value.ToString();
            txtdescrip.Text = desc;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                MySqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "sp_modificarTipoServicio";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("_id", MySqlDbType.Int32).Value = txtid.Text;
                cmd.Parameters.Add("_desc", MySqlDbType.VarChar, 20).Value = txtdescrip.Text;
                MySqlDataReader dr = cmd.ExecuteReader();
                dr.Close();
                MessageBox.Show("Datos Actualizados","ATIPANA");
                getTipo();
                txtid.Text = "";
                txtdescrip.Text = "";
            }


            catch (MySqlException ex) { MessageBox.Show(ex.Message, "ATIPANA", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }

        private void dgvDirectorio_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                MySqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "sp_modificarTServicioEstado";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("_id", MySqlDbType.VarChar, 5).Value = txtid.Text;
                MySqlDataReader dr = cmd.ExecuteReader();
                dr.Close();
                MessageBox.Show("Eliminado","ATIPANA");
                getTipo();
                txtid.Text = "";
                txtdescrip.Text = "";

            }


            catch (MySqlException ex) { MessageBox.Show(ex.Message, "ATIPANA", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }

        private void button2_Click(object sender, EventArgs e)
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
                ost.Cells[1, 1] = "ATIPANA";
                ost.Cells[2, 1] = "Reporte de Medidas";
                ost.Cells[3, 1] = "CUADRO RESUMEN";
                ost.Cells[5, 1] = "Nª:";
                ost.Cells[5, 2] = "IdTipoServicio";
                ost.Cells[5, 3] = "Descripción";

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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
           FrmNuevoTipo frmnms = new FrmNuevoTipo();
            
            frmnms.ShowDialog();
            getTipo();
        }

        private void getTipo()
        {
            try
            {
                MySqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "sp_getTipo";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("_desc", txtDesc.Text);
                MySqlDataReader dr = cmd.ExecuteReader();
                DataTable dta = new DataTable();
                dta.Load(dr);
                dgvDirectorio.DataSource = dta;
                dr.Close();
            }
            catch (MySqlException) { }
        }
    }
}
