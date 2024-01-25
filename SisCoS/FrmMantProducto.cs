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
    public partial class FrmMantProducto : Form
    {
        private SqlConnection cn;
        private string id, desc, stock, pc, pv;
        public FrmMantProducto()
        {
            InitializeComponent();
            //cn = FrmPrincipal.cn;
            dgvDirectorio.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            txtDesc.Select();
            txtDesc.Focus();
        }

        private void FrmMantProducto_Load(object sender, EventArgs e)
        {
            getProducto();
            cargarCategorias();
            cargarMedida();
            cargarMarca();
            cargarProcedencia();
        }

        private void getProducto()
        {
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "sp_getProducto";
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

        private void txtDesc_TextChanged(object sender, EventArgs e)
        {
            getProducto();
        }

        private void cargarCategorias()
        {
            try
            {

                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "sp_CmbCategoria";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dta = new DataTable();
                dta.Load(dr);
                cmbCat.DataSource = dta;
                cmbCat.DisplayMember = "Descripcion";
                cmbCat.ValueMember = "idCategoria";

            }
            catch (SqlException ex) { MessageBox.Show(ex.Message, "Sistema de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void cargarMedida()
        {
            try
            {

                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "sp_CmbMedida";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dta = new DataTable();
                dta.Load(dr);
                cmbMed.DataSource = dta;
                cmbMed.DisplayMember = "Descripcion";
                cmbMed.ValueMember = "idMedida";

            }
            catch (SqlException ex) { MessageBox.Show(ex.Message, "Sistema de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void dgvDirectorio_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = dgvDirectorio.Rows[e.RowIndex].Cells["clmIdProducto"].Value.ToString();
            txtid.Text = id;

            desc = dgvDirectorio.Rows[e.RowIndex].Cells["clmDescripcion"].Value.ToString();
            txtdescrip.Text = desc;

           
            stock = dgvDirectorio.Rows[e.RowIndex].Cells["clmStock"].Value.ToString();
            txtStock.Text = stock;

            pv = dgvDirectorio.Rows[e.RowIndex].Cells["clmPrecioV"].Value.ToString();
            txtPV.Text = pv;

            pc = dgvDirectorio.Rows[e.RowIndex].Cells["clmPrecioC"].Value.ToString();
            txtCompra.Text = pc;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro que desea Modificar la fila", "Advertencia", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {

                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandText = "sp_modificarProducto";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", SqlDbType.Char, 5).Value = txtid.Text;
                    cmd.Parameters.Add("@desc", SqlDbType.VarChar, 50).Value = txtdescrip.Text;
                    cmd.Parameters.Add("@cat", SqlDbType.Char, 5).Value = cmbCat.SelectedValue.ToString();
                    cmd.Parameters.Add("@stock", SqlDbType.Int).Value = txtStock.Text;
                    cmd.Parameters.Add("@precioC", SqlDbType.Decimal).Value = txtCompra.Text;
                    cmd.Parameters.Add("@precioV", SqlDbType.Decimal).Value = txtPV.Text;
                    cmd.Parameters.Add("@idMed", SqlDbType.Char, 5).Value = cmbMed.SelectedValue.ToString();
                    cmd.Parameters.Add("@idMar", SqlDbType.Char, 5).Value = cmbMarca.SelectedValue.ToString();
                    cmd.Parameters.Add("@idPro", SqlDbType.Char, 5).Value = cmbPro.SelectedValue.ToString();

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Close();
                    MessageBox.Show("Datos del usuario Actualizados", "SisCoS");
                    getProducto();
                    txtid.Text = "";
                    txtdescrip.Text = "";
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
                    cmd.CommandText = "sp_modificarProductoEstado";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", SqlDbType.Char, 5).Value = txtid.Text;
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Close();
                    MessageBox.Show("Datos Eliminador", "SisCoS");
                    getProducto();
                    txtid.Text = "";
                    txtdescrip.Text = "";

                }


                catch (SqlException ex) { MessageBox.Show(ex.Message, "SisCoS", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
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
                cmbMarca.DataSource = dta;
                cmbMarca.DisplayMember = "Descripcion";
                cmbMarca.ValueMember = "idMarca";

            }
            catch (SqlException ex) { MessageBox.Show(ex.Message, "Sistema de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }


        private void cargarProcedencia()
        {
            try
            {

                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "sp_CmbProcedencia";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dta = new DataTable();
                dta.Load(dr);
                cmbPro.DataSource = dta;
                cmbPro.DisplayMember = "Descripcion";
                cmbPro.ValueMember = "idProcedencia";

            }
            catch (SqlException ex) { MessageBox.Show(ex.Message, "Sistema de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Error); }
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
                ost.Cells[2, 1] = "Reporte de Productos";
                ost.Cells[3, 1] = "CUADRO RESUMEN";
                ost.Cells[5, 1] = "Nª:";
                ost.Cells[5, 2] = "Código:";
                ost.Cells[5, 3] = "Descripción";
                ost.Cells[5, 4] = "Categoría";
                ost.Cells[5, 5] = "Stock";
                ost.Cells[5, 6] = "P. Compra";
                ost.Cells[5, 7] = "P. Venta";

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
                    ost.get_Range("A5", "g" + (k + 6).ToString()).Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    ost.get_Range("A6", "g" + (k + 6).ToString()).RowHeight = 20;
                    ost.Columns["B"].ColumnWidth = 15;
                    ost.Columns["E"].ColumnWidth = 12;
                    ost.Columns["G"].ColumnWidth = 12;
                    k++;
                }
            }
            catch (Exception) { }
        }


    }
}
