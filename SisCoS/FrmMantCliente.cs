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
    public partial class FrmMantCliente : Form
    {
        private MySqlConnection cn;
        private string id, nom, ofi, dir, tel, RUC, email;
        public FrmMantCliente()
        {
            InitializeComponent();
            cn = FrmPrincipal.cn;
            dgvDirectorioC.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            getDirectorio();
            txtCliente.Select();
            txtCliente.Focus();
        }

        
       

        private void getDirectorio()
        {

            try
            {
                MySqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "sp_getDiretorioCliente";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("_usuario", txtCliente.Text);
                MySqlDataReader dr = cmd.ExecuteReader();
                DataTable dta = new DataTable();
                dta.Load(dr);
                dgvDirectorioC.DataSource = dta;
                dr.Close();
            }
            catch (MySqlException) { }
            }


        private void FrmMantCliente_Load(object sender, EventArgs e)
        {
        
        }

       

        private void txtCliente_KeyUp(object sender, KeyEventArgs e)
        {
           
        }

        private void limpiar()
        {
            
            txtCliente.Text = "";
            

        }

        private void dgvDirectorioC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = dgvDirectorioC.Rows[e.RowIndex].Cells["clmIdCliente"].Value.ToString();
            txtid.Text = id;

            nom = dgvDirectorioC.Rows[e.RowIndex].Cells["clmNombre"].Value.ToString();
            txtnom.Text = nom;

            ofi = dgvDirectorioC.Rows[e.RowIndex].Cells["clmOficina"].Value.ToString();
            txtofi.Text = ofi;

            dir = dgvDirectorioC.Rows[e.RowIndex].Cells["clmdireccion"].Value.ToString();
            txtdir.Text = dir;

            tel = dgvDirectorioC.Rows[e.RowIndex].Cells["clmTelefono"].Value.ToString();
            txtTel.Text = tel;

            RUC = dgvDirectorioC.Rows[e.RowIndex].Cells["clmRUC"].Value.ToString();
            txtRUC.Text = RUC;

            email = dgvDirectorioC.Rows[e.RowIndex].Cells["clmEmail"].Value.ToString();
            txtemail.Text = email;

        }

        private void txtCliente_TextChanged(object sender, EventArgs e)
        {
            getDirectorio();
        }

        private void txttel_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro que desea Modificar la fila", "Advertencia", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {

                    MySqlCommand cmd = cn.CreateCommand();
                    cmd.CommandText = "sp_modificarCliente";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_id", MySqlDbType.VarChar, 5).Value = txtid.Text;
                    cmd.Parameters.Add("_oficina", MySqlDbType.VarChar, 80).Value = txtofi.Text;
                    cmd.Parameters.Add("_direccion", MySqlDbType.VarChar, 100).Value = txtdir.Text;
                    cmd.Parameters.Add("_telefono", MySqlDbType.VarChar, 50).Value = txtTel.Text;
                    cmd.Parameters.Add("_email", MySqlDbType.VarChar, 50).Value = txtemail.Text;
                    MySqlDataReader dr = cmd.ExecuteReader();
                    dr.Close();
                    MessageBox.Show("Datos del usuario Actualizados", "ATIPANA");
                    getDirectorio();
                    txtCliente.Text = "";
                    getDirectorio();
                    txtid.Text = "";
                    txtnom.Text = "";
                    txtofi.Text = "";
                    txtdir.Text = "";
                    txtTel.Text = "";
                    txtRUC.Text = "";
                    txtemail.Text = "";

                }


                catch (MySqlException ex) { MessageBox.Show(ex.Message, "SisCoS", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void dgvDirectorioC_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("Esta seguro que desea eliminar la fila", "Advertencia", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {

                    MySqlCommand cmd = cn.CreateCommand();
                    cmd.CommandText = "sp_modificarClienteEstado";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_id", MySqlDbType.VarChar, 5).Value = txtid.Text;
                    MySqlDataReader dr = cmd.ExecuteReader();
                    dr.Close();
                    MessageBox.Show("Cliente dado de baja", "ATIPANA");
                    getDirectorio();
                    txtid.Text = "";
                    txtnom.Text = "";
                    txtofi.Text = "";
                    txtdir.Text = "";
                    txtTel.Text = "";
                    txtRUC.Text = "";
                    txtemail.Text = "";

                }


                catch (MySqlException ex) { MessageBox.Show(ex.Message, "SisCoS", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void txtRUC_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloNumeros(e);
        }

        private void txtTel_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloNumeros(e);
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
                ost.Cells[2, 1] = "Reporte de Clientes";
                ost.Cells[3, 1] = "CUADRO RESUMEN";
                ost.Cells[5, 1] = "Nª:";
                ost.Cells[5, 2] = "IdCliente";
                ost.Cells[5, 3] = "Nombre";
                ost.Cells[5, 4] = "Oficina";
                ost.Cells[5, 5] = "Dirección";
                ost.Cells[5, 6] = "Teléfono";
                ost.Cells[5, 7] = "RUC";
                ost.Cells[5, 8] = "Correo";


                //oxl.Cells.EntireColumn.AutoFit();
                int k = 0;
                for (int i = 0; i < dgvDirectorioC.Rows.Count; i++)
                {
                    // DataTable dt = Mostrar1();


                    for (int j = 0; j < dgvDirectorioC.Columns.Count; j++)
                    {

                        ost.Cells[i + 6, j + 2] = dgvDirectorioC.Rows[i].Cells[j].Value.ToString();

                        //ost.Cells[k + 6, 3].NumberFormat = ("yyyy-MM-dd");
                        //ost.Cells[k + 6, 4].NumberFormat = String.Format("hh:mm:ss");
                        //ost.Cells[k + 6, 5].NumberFormat = String.Format("hh:mm:ss");
                        ost.Cells.EntireColumn.AutoFit();


                    }
                    ost.Cells[k + 6, 1] = (k + 1).ToString();
                    ost.get_Range("A5", "h" + (k + 6).ToString()).Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    ost.get_Range("A6", "h" + (k + 6).ToString()).RowHeight = 20;
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
