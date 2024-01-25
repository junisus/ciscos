using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Data.SqlClient;
using System.Collections;
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;

namespace SisCoS
{
    public partial class FrmMantMaquinaria : Form
    {
        private SqlConnection cn;
        private string id, desc, placa;
        public FrmMantMaquinaria()
        {
            InitializeComponent();
            //cn = FrmPrincipal.cn;
            dgvDirectorio.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            txtDesc.Select();
            txtDesc.Focus();
        }

        private void FrmMantMaquinaria_Load(object sender, EventArgs e)
        {
            getMaquinaria();
            cargarMarca();
            cargaModelo();
        }

        private void getMaquinaria()
        {
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "sp_getMaquinaria";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@desc", txtDesc.Text);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dta = new DataTable();
                dta.Load(dr);
                dgvDirectorio.DataSource = dta;
                dr.Close();
            }
            catch (SqlException) { }
        }

        private void cargarMarca()
        {
            try
            {

                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "sp_CmbMarca";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dta = new DataTable();
                dta.Load(dr);
                cmbMar.DataSource = dta;
                cmbMar.DisplayMember = "Descripcion";
                cmbMar.ValueMember = "idMarca";

            }
            catch (SqlException ex) { MessageBox.Show(ex.Message, "Sistema de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }


        private void cargaModelo()
        {
            try
            {

                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "sp_CmbModelo";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dta = new DataTable();
                dta.Load(dr);
                cmbMod.DataSource = dta;
                cmbMod.DisplayMember = "Descripcion";
                cmbMod.ValueMember = "idModelo";

            }
            catch (SqlException ex) { MessageBox.Show(ex.Message, "Sistema de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void dgvDirectorio_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = dgvDirectorio.Rows[e.RowIndex].Cells["clmIdMaquinaria"].Value.ToString();
            txtid.Text = id;

            desc = dgvDirectorio.Rows[e.RowIndex].Cells["clmDescripcion"].Value.ToString();
            txtdescrip.Text = desc;


            placa = dgvDirectorio.Rows[e.RowIndex].Cells["clmPlaca"].Value.ToString();
            txtPlaca.Text = placa;

           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro que desea Modificar la fila", "Advertencia", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {

                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandText = "sp_modificarMaquinaria";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", SqlDbType.Char, 5).Value = txtid.Text;
                    cmd.Parameters.Add("@desc", SqlDbType.VarChar, 50).Value = txtdescrip.Text;
                    cmd.Parameters.Add("@placa", SqlDbType.Char, 6).Value = txtPlaca.Text;
                    cmd.Parameters.Add("@idMarca", SqlDbType.Char, 5).Value = cmbMar.SelectedValue.ToString();
                    cmd.Parameters.Add("@idModelo", SqlDbType.Char, 5).Value = cmbMod.SelectedValue.ToString();
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Close();
                    MessageBox.Show("Datos del usuario Actualizados", "SisCoS");
                    getMaquinaria();
                    txtid.Text = "";
                    txtdescrip.Text = "";
                    txtPlaca.Text = "";
                }


                catch (SqlException ex) { MessageBox.Show(ex.Message, "SisCoS", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void dgvDirectorio_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("Esta seguro que desea eliminar la fila", "Advertencia", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {

                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandText = "sp_modificarMaquinariaEstado";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", SqlDbType.Char, 5).Value = txtid.Text;
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Close();
                    MessageBox.Show("Eliminado");
                    getMaquinaria();
                    txtid.Text = "";
                    txtdescrip.Text = "";

                }


                catch (SqlException ex) { MessageBox.Show(ex.Message, "SisCoS", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void txtDesc_TextChanged(object sender, EventArgs e)
        {
            getMaquinaria();
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
                ost.Cells[1, 1] = "MR TECH SOLUTIONS";
                ost.Cells[2, 1] = "Reporte de Maquinarias";
                ost.Cells[3, 1] = "CUADRO RESUMEN";
                ost.Cells[5, 1] = "Nª:";
                ost.Cells[5, 2] = "Id";
                ost.Cells[5, 3] = "Placa";
                ost.Cells[5, 4] = "Descripción";
                ost.Cells[5, 5] = "Marca";
                ost.Cells[5, 6] = "Modelo";


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
                    ost.get_Range("A5", "f" + (k + 6).ToString()).Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    ost.get_Range("A6", "f" + (k + 6).ToString()).RowHeight = 20;
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


    }
}
