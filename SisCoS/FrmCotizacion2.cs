using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
//using System.Data.SqlClient;
using Word= Microsoft.Office.Interop.Word;



namespace SisCoS
{
    public partial class FrmCotizacion2 : Form
    {
        public MySqlConnection cn;
        FrmDetalleCotizacion fDetalle;

        public static string id, nom, ofi, idpro, nombpro, stock, precioventa, idMaquinaria, descm, tarifa,
            t1, id1, np1, pv1,
            t2, id2, np2, pv2,
            t4, id4, np4, pv4,
            id5, np5, pv5,
            id6, np6, pv6;

        public FrmCotizacion2()
        {
            
            InitializeComponent();
            cn = FrmPrincipal.cn;
        }

        CProdimientoN objn = new CProdimientoN();
   

        private void FrmCotizacion_Load(object sender, EventArgs e)
        {
            button1.Visible = true;
            bt_search_concept.Visible = true;
            bt_delete_concept.Visible = true;

            txtCorrelativo.Text = objn.GenerarCodigo("tcotizacion");   
        }

        public DataSet generarCodigo()
        {
            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter();
            da = new MySqlDataAdapter("SP_GenerarCodigo", cn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmBuscarCliente frmBC = new FrmBuscarCliente();
            frmBC.ShowDialog();
            txtCliente.Text = nom;
            txtOficina.Text = ofi;  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmBuscarProducto frmBP = new FrmBuscarProducto();
            frmBP.ShowDialog();
        }
        
        decimal sttock = 0;
       
        private void groupBox9_Enter(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        decimal subTotal5 = 0;
        private void textBoxX4_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtsuma1_TextChanged(object sender, EventArgs e)
        {
            
        }
        decimal subTotal0 = 0;
        private void button15_Click(object sender, EventArgs e)
        {
            
        }

        private void lv_concept_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            fDetalle = new FrmDetalleCotizacion();
            fDetalle.Show();
        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void bt_save_naviera_Click(object sender, EventArgs e)
        { //NAVIERA
            if (MessageBox.Show("Desea Registrar los Datos Ingresados", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    MySqlCommand cmd = cn.CreateCommand();

                    cmd.CommandText = "sp_Cotizar";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("_idCotizacion", txtCorrelativo.Text);
                    cmd.Parameters.AddWithValue("_Cot_fecha", dtpFecha.Value);
                    cmd.Parameters.AddWithValue("_Cot_hora", DtpHora.Value);
                    cmd.Parameters.AddWithValue("_Cot_total", decimal.Parse(txtTotal.Text));
                    cmd.Parameters.AddWithValue("_idCliente", id);
                    MySqlDataReader dr = cmd.ExecuteReader();
                    dr.Close();

                    foreach (ListViewItem item in lv_concept.Items)
                    {
                        MySqlCommand cmdd = cn.CreateCommand();
                        cmdd.CommandText = "SP_DetalleCotizar";
                        cmdd.CommandType = CommandType.StoredProcedure;
                        cmdd.Parameters.AddWithValue("_idCotizacion", txtCorrelativo.Text);
                        cmdd.Parameters.AddWithValue("_idServicio", item.SubItems[0].Text);
                        cmdd.Parameters.AddWithValue("_precio", decimal.Parse(item.SubItems[3].Text));
                        cmdd.Parameters.AddWithValue("_subtotal", decimal.Parse(tb_subtotal_concept.Text));
                        MySqlDataReader drd = cmdd.ExecuteReader();
                        drd.Close();
                    }

                    foreach (ListViewItem item in lv_naviera.Items)
                    {
                        MySqlCommand cmdd = cn.CreateCommand();
                        cmdd.CommandText = "SP_DetalleCotizar";
                        cmdd.CommandType = CommandType.StoredProcedure;
                        cmdd.Parameters.AddWithValue("_idCotizacion", txtCorrelativo.Text);
                        cmdd.Parameters.AddWithValue("_idServicio", item.SubItems[0].Text);
                        cmdd.Parameters.AddWithValue("_precio", decimal.Parse(item.SubItems[3].Text));
                        cmdd.Parameters.AddWithValue("_subtotal", decimal.Parse(tb_subtotal_naviera.Text));
                        MySqlDataReader drd = cmdd.ExecuteReader();
                        drd.Close();

                    }

                    foreach (ListViewItem item in lv_dep.Items)
                    {
                        MySqlCommand cmdd = cn.CreateCommand();
                        cmdd.CommandText = "SP_DetalleCotizar";
                        cmdd.CommandType = CommandType.StoredProcedure;
                        cmdd.Parameters.AddWithValue("_idCotizacion", txtCorrelativo.Text);
                        cmdd.Parameters.AddWithValue("_idServicio", item.SubItems[0].Text);
                        cmdd.Parameters.AddWithValue("_precio", decimal.Parse(item.SubItems[3].Text));
                        cmdd.Parameters.AddWithValue("_subtotal", decimal.Parse(tb_subtotal_dep.Text));
                        MySqlDataReader drd = cmdd.ExecuteReader();
                        drd.Close();

                    }

                    foreach (ListViewItem item in lv_derechos.Items)
                    {
                        MySqlCommand cmdd = cn.CreateCommand();
                        cmdd.CommandText = "SP_DetalleCotizar";
                        cmdd.CommandType = CommandType.StoredProcedure;
                        cmdd.Parameters.AddWithValue("_idCotizacion", txtCorrelativo.Text);
                        cmdd.Parameters.AddWithValue("_idServicio", item.SubItems[0].Text);
                        cmdd.Parameters.AddWithValue("_precio", decimal.Parse(item.SubItems[3].Text));
                        cmdd.Parameters.AddWithValue("_subtotal", decimal.Parse(tb_subtotal_derechos.Text));
                        MySqlDataReader drd = cmdd.ExecuteReader();
                        drd.Close();

                    }

                    foreach (ListViewItem item in lv_otro.Items)
                    {
                        MySqlCommand cmdd = cn.CreateCommand();
                        cmdd.CommandText = "SP_DetalleCotizarA";
                        cmdd.CommandType = CommandType.StoredProcedure;
                        cmdd.Parameters.AddWithValue("_idCotizacion", txtCorrelativo.Text);
                        cmdd.Parameters.AddWithValue("_idProducto", item.SubItems[0].Text);
                        cmdd.Parameters.AddWithValue("_cantidad", item.SubItems[2].Text);
                        cmdd.Parameters.AddWithValue("_peso", decimal.Parse(item.SubItems[3].Text));
                        cmdd.Parameters.AddWithValue("_bl", item.SubItems[4].Text);
                        MySqlDataReader drd = cmdd.ExecuteReader();
                        drd.Close();

                    }

                    foreach (ListViewItem item in lv_colaterales.Items)
                    {
                        MySqlCommand cmdd = cn.CreateCommand();
                        cmdd.CommandText = "SP_DetalleCotizar";
                        cmdd.CommandType = CommandType.StoredProcedure;
                        cmdd.Parameters.AddWithValue("_idCotizacion", txtCorrelativo.Text);
                        cmdd.Parameters.AddWithValue("_idServicio", item.SubItems[0].Text);
                        cmdd.Parameters.AddWithValue("_precio", decimal.Parse(item.SubItems[2].Text));
                        cmdd.Parameters.AddWithValue("_subtotal", decimal.Parse(txtSubTotal10.Text));
                        MySqlDataReader drd = cmdd.ExecuteReader();
                        drd.Close();

                        MessageBox.Show("Cotización Realizada", "ATIPANA");
                        limpiar();

                        txtCorrelativo.Text = objn.GenerarCodigo("tcotizacion");

                    }
                }

                catch (MySqlException ex) { MessageBox.Show(ex.Message, "ATIPANA", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void bt_delete_naviera_Click(object sender, EventArgs e)
        {
            decimal subTotal2 = 0;

            if (lv_naviera.SelectedItems.Count > 0)
            {
                lv_naviera.Items.Remove(lv_naviera.SelectedItems[0]);
                foreach (ListViewItem item in lv_naviera.Items)
                {
                    subTotal2 += (decimal.Parse(item.SubItems[3].Text));
                }

                tb_subtotal_naviera.Text = subTotal2.ToString();
                txtTotal.Text = (decimal.Round(Convert.ToDecimal(tb_subtotal_concept.Text), 2) + decimal.Round(Convert.ToDecimal(tb_subtotal_naviera.Text), 2) + decimal.Round(Convert.ToDecimal(tb_subtotal_dep.Text), 2) + decimal.Round(Convert.ToDecimal(tb_subtotal_derechos.Text), 2)).ToString();
            }

            else
                MessageBox.Show("Seleccione una Fila");
        }

        private void bt_add_dep_Click(object sender, EventArgs e)
        {
            if (txtCliente.Text == "")
            {
                MessageBox.Show("Debe Seleccionar un Cliente");
                return;
            }
            //GASTOS DEP
            ClaseAyuda objp = new ClaseAyuda();
            DataSet ds = objp.buscarArticulow(tbX_service_dep.Text);
            DataTable dt = ds.Tables[0];

            Console.WriteLine($"Número de filas: {dt.Rows.Count}");

            DataRow dr;
            decimal subTotal1 = 0;
            decimal sttock = 0;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                ListViewItem item = lv_dep.Items.Add(dr["idServicio"].ToString());
                item.SubItems.Add(dr["Nombres"].ToString());
                item.SubItems.Add(dr["Tarifa"].ToString());
                item.SubItems.Add(tbX_price_dep.Text);
            }

            foreach (ListViewItem item in lv_dep.Items)
            {
                if (decimal.TryParse(item.SubItems[3].Text, out decimal result))
                {
                    subTotal1 += decimal.Round(result, 2);
                }
                else
                {
                    Console.WriteLine($"No se pudo convertir '{item.SubItems[3].Text}' a decimal");
                }
            }


            tb_subtotal_dep.Text = Convert.ToString(subTotal1);
            txtTotal.Text = (decimal.Round(Convert.ToDecimal(tb_subtotal_concept.Text), 2) + decimal.Round(Convert.ToDecimal(tb_subtotal_naviera.Text), 2) + decimal.Round(Convert.ToDecimal(tb_subtotal_dep.Text), 2) + decimal.Round(Convert.ToDecimal(tb_subtotal_derechos.Text), 2)).ToString();

            tbX_service_dep.Clear();
            tbX_price_dep.Clear();
            tbX_tariff_dep.Clear();
        }

        private void bt_save_dep_Click(object sender, EventArgs e)
        {
            //GASTOS DEP
            if (MessageBox.Show("Desea Registrar los Datos Ingresados", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    MySqlCommand cmd = cn.CreateCommand();

                    cmd.CommandText = "sp_Cotizar";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("_idCotizacion", txtCorrelativo.Text);
                    cmd.Parameters.AddWithValue("_Cot_fecha", dtpFecha.Value);
                    cmd.Parameters.AddWithValue("_Cot_hora", DtpHora.Value);
                    cmd.Parameters.AddWithValue("_Cot_total", decimal.Parse(txtTotal.Text));
                    cmd.Parameters.AddWithValue("_idCliente", id);
                    MySqlDataReader dr = cmd.ExecuteReader();
                    dr.Close();

                    foreach (ListViewItem item in lv_concept.Items)
                    {
                        MySqlCommand cmdd = cn.CreateCommand();
                        cmdd.CommandText = "SP_DetalleCotizar";
                        cmdd.CommandType = CommandType.StoredProcedure;
                        cmdd.Parameters.AddWithValue("_idCotizacion", txtCorrelativo.Text);
                        cmdd.Parameters.AddWithValue("_idServicio", item.SubItems[0].Text);
                        cmdd.Parameters.AddWithValue("_precio", decimal.Parse(item.SubItems[3].Text));
                        cmdd.Parameters.AddWithValue("_subtotal", decimal.Parse(tb_subtotal_concept.Text));
                        MySqlDataReader drd = cmdd.ExecuteReader();
                        drd.Close();
                    }

                    foreach (ListViewItem item in lv_naviera.Items)
                    {
                        MySqlCommand cmdd = cn.CreateCommand();
                        cmdd.CommandText = "SP_DetalleCotizar";
                        cmdd.CommandType = CommandType.StoredProcedure;
                        cmdd.Parameters.AddWithValue("_idCotizacion", txtCorrelativo.Text);
                        cmdd.Parameters.AddWithValue("_idServicio", item.SubItems[0].Text);
                        cmdd.Parameters.AddWithValue("_precio", decimal.Parse(item.SubItems[3].Text));
                        cmdd.Parameters.AddWithValue("_subtotal", decimal.Parse(tb_subtotal_naviera.Text));
                        MySqlDataReader drd = cmdd.ExecuteReader();
                        drd.Close();

                    }

                    foreach (ListViewItem item in lv_dep.Items)
                    {
                        MySqlCommand cmdd = cn.CreateCommand();
                        cmdd.CommandText = "SP_DetalleCotizar";
                        cmdd.CommandType = CommandType.StoredProcedure;
                        cmdd.Parameters.AddWithValue("_idCotizacion", txtCorrelativo.Text);
                        cmdd.Parameters.AddWithValue("_idServicio", item.SubItems[0].Text);
                        cmdd.Parameters.AddWithValue("_precio", decimal.Parse(item.SubItems[3].Text));
                        cmdd.Parameters.AddWithValue("_subtotal", decimal.Parse(tb_subtotal_dep.Text));
                        MySqlDataReader drd = cmdd.ExecuteReader();
                        drd.Close();

                    }

                    foreach (ListViewItem item in lv_derechos.Items)
                    {
                        MySqlCommand cmdd = cn.CreateCommand();
                        cmdd.CommandText = "SP_DetalleCotizar";
                        cmdd.CommandType = CommandType.StoredProcedure;
                        cmdd.Parameters.AddWithValue("_idCotizacion", txtCorrelativo.Text);
                        cmdd.Parameters.AddWithValue("_idServicio", item.SubItems[0].Text);
                        cmdd.Parameters.AddWithValue("_precio", decimal.Parse(item.SubItems[3].Text));
                        cmdd.Parameters.AddWithValue("_subtotal", decimal.Parse(tb_subtotal_derechos.Text));
                        MySqlDataReader drd = cmdd.ExecuteReader();
                        drd.Close();

                    }

                    foreach (ListViewItem item in lv_otro.Items)
                    {
                        MySqlCommand cmdd = cn.CreateCommand();
                        cmdd.CommandText = "SP_DetalleCotizarA";
                        cmdd.CommandType = CommandType.StoredProcedure;
                        cmdd.Parameters.AddWithValue("_idCotizacion", txtCorrelativo.Text);
                        cmdd.Parameters.AddWithValue("_idProducto", item.SubItems[0].Text);
                        cmdd.Parameters.AddWithValue("_cantidad", item.SubItems[2].Text);
                        cmdd.Parameters.AddWithValue("_peso", decimal.Parse(item.SubItems[3].Text));
                        cmdd.Parameters.AddWithValue("_bl", item.SubItems[4].Text);
                        MySqlDataReader drd = cmdd.ExecuteReader();
                        drd.Close();

                    }

                    foreach (ListViewItem item in lv_colaterales.Items)
                    {
                        MySqlCommand cmdd = cn.CreateCommand();
                        cmdd.CommandText = "SP_DetalleCotizar";
                        cmdd.CommandType = CommandType.StoredProcedure;
                        cmdd.Parameters.AddWithValue("_idCotizacion", txtCorrelativo.Text);
                        cmdd.Parameters.AddWithValue("_idServicio", item.SubItems[0].Text);
                        cmdd.Parameters.AddWithValue("_precio", decimal.Parse(item.SubItems[2].Text));
                        cmdd.Parameters.AddWithValue("_subtotal", decimal.Parse(txtSubTotal10.Text));
                        MySqlDataReader drd = cmdd.ExecuteReader();
                        drd.Close();

                        MessageBox.Show("Cotización Realizada", "ATIPANA");
                        limpiar();

                        txtCorrelativo.Text = objn.GenerarCodigo("tcotizacion");

                    }
                }

                catch (MySqlException ex) { MessageBox.Show(ex.Message, "ATIPANA", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void bt_delete_dep_Click(object sender, EventArgs e)
        {
            decimal subTotal2 = 0;

            if (lv_dep.SelectedItems.Count > 0)
            {
                lv_dep.Items.Remove(lv_dep.SelectedItems[0]);
                foreach (ListViewItem item in lv_dep.Items)
                {
                    subTotal2 += (decimal.Parse(item.SubItems[3].Text));
                }

                tb_subtotal_dep.Text = subTotal2.ToString();
                txtTotal.Text = (decimal.Round(Convert.ToDecimal(tb_subtotal_concept.Text), 2) + decimal.Round(Convert.ToDecimal(tb_subtotal_naviera.Text), 2) + decimal.Round(Convert.ToDecimal(tb_subtotal_dep.Text), 2) + decimal.Round(Convert.ToDecimal(tb_subtotal_derechos.Text), 2)).ToString();
            }

            else
                MessageBox.Show("Seleccione una Fila");
        }

        private void bt_add_derechos_Click(object sender, EventArgs e)
        {
            if (txtCliente.Text == "")
            {
                MessageBox.Show("Debe Seleccionar un Cliente");
                return;
            }
            //DERECHOS
            ClaseAyuda objp = new ClaseAyuda();
            DataSet ds = objp.buscarArticulo(tbX_service_derechos.Text);
            DataTable dt = ds.Tables[0];

            Console.WriteLine($"Número de filas: {dt.Rows.Count}");

            DataRow dr;
            decimal subTotal1 = 0;
            decimal sttock = 0;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                ListViewItem item = lv_derechos.Items.Add(dr["idServicio"].ToString());
                item.SubItems.Add(dr["Nombres"].ToString());
                item.SubItems.Add(dr["Tarifa"].ToString());
                item.SubItems.Add(tbX_price_derechos.Text);
            }

            foreach (ListViewItem item in lv_derechos.Items)
            {
                if (decimal.TryParse(item.SubItems[3].Text, out decimal result))
                {
                    subTotal1 += decimal.Round(result, 2);
                }
                else
                {
                    Console.WriteLine($"No se pudo convertir '{item.SubItems[3].Text}' a decimal");
                }
            }


            tb_subtotal_derechos.Text = Convert.ToString(subTotal1);
            txtTotal.Text = (decimal.Round(Convert.ToDecimal(tb_subtotal_concept.Text), 2) + decimal.Round(Convert.ToDecimal(tb_subtotal_naviera.Text), 2) + decimal.Round(Convert.ToDecimal(tb_subtotal_dep.Text), 2) + decimal.Round(Convert.ToDecimal(tb_subtotal_derechos.Text), 2)).ToString();

            tbX_service_derechos.Clear();
            tbX_price_derechos.Clear();
            tbX_tariff_derechos.Clear();
        }

        private void bt_save_derechos_Click(object sender, EventArgs e)
        {
            //DERECHOS
            if (MessageBox.Show("Desea Registrar los Datos Ingresados", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    MySqlCommand cmd = cn.CreateCommand();

                    cmd.CommandText = "sp_Cotizar";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("_idCotizacion", txtCorrelativo.Text);
                    cmd.Parameters.AddWithValue("_Cot_fecha", dtpFecha.Value);
                    cmd.Parameters.AddWithValue("_Cot_hora", DtpHora.Value);
                    cmd.Parameters.AddWithValue("_Cot_total", decimal.Parse(txtTotal.Text));
                    cmd.Parameters.AddWithValue("_idCliente", id);
                    MySqlDataReader dr = cmd.ExecuteReader();
                    dr.Close();

                    foreach (ListViewItem item in lv_concept.Items)
                    {
                        MySqlCommand cmdd = cn.CreateCommand();
                        cmdd.CommandText = "SP_DetalleCotizar";
                        cmdd.CommandType = CommandType.StoredProcedure;
                        cmdd.Parameters.AddWithValue("_idCotizacion", txtCorrelativo.Text);
                        cmdd.Parameters.AddWithValue("_idServicio", item.SubItems[0].Text);
                        cmdd.Parameters.AddWithValue("_precio", decimal.Parse(item.SubItems[3].Text));
                        cmdd.Parameters.AddWithValue("_subtotal", decimal.Parse(tb_subtotal_concept.Text));
                        MySqlDataReader drd = cmdd.ExecuteReader();
                        drd.Close();
                    }

                    foreach (ListViewItem item in lv_naviera.Items)
                    {
                        MySqlCommand cmdd = cn.CreateCommand();
                        cmdd.CommandText = "SP_DetalleCotizar";
                        cmdd.CommandType = CommandType.StoredProcedure;
                        cmdd.Parameters.AddWithValue("_idCotizacion", txtCorrelativo.Text);
                        cmdd.Parameters.AddWithValue("_idServicio", item.SubItems[0].Text);
                        cmdd.Parameters.AddWithValue("_precio", decimal.Parse(item.SubItems[3].Text));
                        cmdd.Parameters.AddWithValue("_subtotal", decimal.Parse(tb_subtotal_naviera.Text));
                        MySqlDataReader drd = cmdd.ExecuteReader();
                        drd.Close();

                    }

                    foreach (ListViewItem item in lv_dep.Items)
                    {
                        MySqlCommand cmdd = cn.CreateCommand();
                        cmdd.CommandText = "SP_DetalleCotizar";
                        cmdd.CommandType = CommandType.StoredProcedure;
                        cmdd.Parameters.AddWithValue("_idCotizacion", txtCorrelativo.Text);
                        cmdd.Parameters.AddWithValue("_idServicio", item.SubItems[0].Text);
                        cmdd.Parameters.AddWithValue("_precio", decimal.Parse(item.SubItems[3].Text));
                        cmdd.Parameters.AddWithValue("_subtotal", decimal.Parse(tb_subtotal_dep.Text));
                        MySqlDataReader drd = cmdd.ExecuteReader();
                        drd.Close();

                    }

                    foreach (ListViewItem item in lv_derechos.Items)
                    {
                        MySqlCommand cmdd = cn.CreateCommand();
                        cmdd.CommandText = "SP_DetalleCotizar";
                        cmdd.CommandType = CommandType.StoredProcedure;
                        cmdd.Parameters.AddWithValue("_idCotizacion", txtCorrelativo.Text);
                        cmdd.Parameters.AddWithValue("_idServicio", item.SubItems[0].Text);
                        cmdd.Parameters.AddWithValue("_precio", decimal.Parse(item.SubItems[3].Text));
                        cmdd.Parameters.AddWithValue("_subtotal", decimal.Parse(tb_subtotal_derechos.Text));
                        MySqlDataReader drd = cmdd.ExecuteReader();
                        drd.Close();

                    }

                    foreach (ListViewItem item in lv_otro.Items)
                    {
                        MySqlCommand cmdd = cn.CreateCommand();
                        cmdd.CommandText = "SP_DetalleCotizarA";
                        cmdd.CommandType = CommandType.StoredProcedure;
                        cmdd.Parameters.AddWithValue("_idCotizacion", txtCorrelativo.Text);
                        cmdd.Parameters.AddWithValue("_idProducto", item.SubItems[0].Text);
                        cmdd.Parameters.AddWithValue("_cantidad", item.SubItems[2].Text);
                        cmdd.Parameters.AddWithValue("_peso", decimal.Parse(item.SubItems[3].Text));
                        cmdd.Parameters.AddWithValue("_bl", item.SubItems[4].Text);
                        MySqlDataReader drd = cmdd.ExecuteReader();
                        drd.Close();

                    }

                    foreach (ListViewItem item in lv_colaterales.Items)
                    {
                        MySqlCommand cmdd = cn.CreateCommand();
                        cmdd.CommandText = "SP_DetalleCotizar";
                        cmdd.CommandType = CommandType.StoredProcedure;
                        cmdd.Parameters.AddWithValue("_idCotizacion", txtCorrelativo.Text);
                        cmdd.Parameters.AddWithValue("_idServicio", item.SubItems[0].Text);
                        cmdd.Parameters.AddWithValue("_precio", decimal.Parse(item.SubItems[2].Text));
                        cmdd.Parameters.AddWithValue("_subtotal", decimal.Parse(txtSubTotal10.Text));
                        MySqlDataReader drd = cmdd.ExecuteReader();
                        drd.Close();

                        MessageBox.Show("Cotización Realizada", "ATIPANA");
                        limpiar();

                        txtCorrelativo.Text = objn.GenerarCodigo("tcotizacion");

                    }
                }

                catch (MySqlException ex) { MessageBox.Show(ex.Message, "ATIPANA", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void button38_Click(object sender, EventArgs e)
        {
            decimal subTotal2 = 0;

            if (lv_derechos.SelectedItems.Count > 0)
            {
                lv_derechos.Items.Remove(lv_derechos.SelectedItems[0]);
                foreach (ListViewItem item in lv_derechos.Items)
                {
                    subTotal2 += (decimal.Parse(item.SubItems[3].Text));
                }

                tb_subtotal_derechos.Text = subTotal2.ToString();
                txtTotal.Text = (decimal.Round(Convert.ToDecimal(tb_subtotal_concept.Text), 2) + decimal.Round(Convert.ToDecimal(tb_subtotal_naviera.Text), 2) + decimal.Round(Convert.ToDecimal(tb_subtotal_dep.Text), 2) + decimal.Round(Convert.ToDecimal(tb_subtotal_derechos.Text), 2)).ToString();
            }

            else
                MessageBox.Show("Seleccione una Fila");
        }

        private void bt_search_naviera_Click(object sender, EventArgs e)
        {
            FrmBuscarServicioT frmbse = new FrmBuscarServicioT();
            frmbse.ShowDialog();
            tbX_service_naviera.Text = np1;
            tbX_price_naviera.Text = pv1;
            tbX_tariff_naviera.Text = t1;
        }

        private void bt_search_dep_Click(object sender, EventArgs e)
        {
            FrmBuscarServicioE frmbse = new FrmBuscarServicioE();
            frmbse.ShowDialog();
            tbX_service_dep.Text = np2;
            tbX_price_dep.Text = pv2;
            tbX_tariff_dep.Text = t2;
        }

        private void bt_search_derechos_Click(object sender, EventArgs e)
        {
            FrmBuscarServicioJ frmbse = new FrmBuscarServicioJ();
            frmbse.ShowDialog();
            tbX_service_derechos.Text = np4;
            tbX_price_derechos.Text = pv4;
            tbX_tariff_derechos.Text = t4;
        }

        private void txtsuma1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        decimal subTotal7 = 0;

        private void button23_Click(object sender, EventArgs e)
        {
            if (txtCliente.Text == "")
            {
                MessageBox.Show("Debe Seleccionar un Cliente");
                return;



            }

            foreach (ListViewItem item in lv_otro.Items)
            {
                if (id6 == item.SubItems[0].Text)
                {
                    item.SubItems[3].Text = (int.Parse(txtCantidad.Text) + int.Parse(item.SubItems[3].Text)).ToString();
                    item.SubItems[4].Text = (decimal.Parse(item.SubItems[3].Text) * decimal.Parse(item.SubItems[2].Text)).ToString();
                    return;
                }
            }
            ListViewItem items = lv_otro.Items.Add(id6);
            items.SubItems.Add(textBoxX2.Text);
            items.SubItems.Add(txtCantidad.Text);
            items.SubItems.Add(textBoxX3.Text);
            items.SubItems.Add(textBoxX4.Text);

            textBoxX2.Clear();
            txtCantidad.Clear();
            textBoxX3.Clear();
            textBoxX4.Clear();
        }

        private void button20_Click(object sender, EventArgs e)
        {
           
            if (txtCliente.Text == "")
            {
                MessageBox.Show("Debe Seleccionar un Cliente");
                return;



            }
            
            subTotal7 += decimal.Round((decimal.Parse(txtPrecioV10.Text)), 2);
            
            txtSubTotal10.Text = Convert.ToString(subTotal7);
            foreach (ListViewItem item in lv_colaterales.Items)
            {
                if (id5 == item.SubItems[0].Text)
                {
                    item.SubItems[3].Text = (int.Parse(txtCantidad.Text) + int.Parse(item.SubItems[3].Text)).ToString();
                    item.SubItems[4].Text = (decimal.Parse(item.SubItems[3].Text) * decimal.Parse(item.SubItems[2].Text)).ToString();
                    return;
                }
            }
            ListViewItem items = lv_colaterales.Items.Add(id5);
            items.SubItems.Add(txtPro10.Text);
            items.SubItems.Add(txtPrecioV10.Text);

            txtPro10.Clear();
            txtPrecioV10.Clear();
        }

        private void button24_Click(object sender, EventArgs e)
        {

        }

        private void lv__SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void superTabControl1_SelectedTabChanged(object sender, DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button31_Click(object sender, EventArgs e)
        {
            if (txtCliente.Text == "")
            {
                MessageBox.Show("Debe Seleccionar un Cliente");
                return;
            }
            //NAVIERA
            ClaseAyuda objp = new ClaseAyuda();
            DataSet ds = objp.buscarArticuloq(tbX_service_naviera.Text);
            DataTable dt = ds.Tables[0];

            Console.WriteLine($"Número de filas: {dt.Rows.Count}");

            DataRow dr;
            decimal subTotal1 = 0;
            decimal sttock = 0;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                ListViewItem item = lv_naviera.Items.Add(dr["idServicio"].ToString());
                item.SubItems.Add(dr["Nombres"].ToString());
                item.SubItems.Add(dr["Tarifa"].ToString());
                item.SubItems.Add(tbX_price_naviera.Text);
            }

            foreach (ListViewItem item in lv_naviera.Items)
            {
                if (decimal.TryParse(item.SubItems[3].Text, out decimal result))
                {
                    subTotal1 += decimal.Round(result, 2);
                }
                else
                {
                    Console.WriteLine($"No se pudo convertir '{item.SubItems[3].Text}' a decimal");
                }
            }


            tb_subtotal_naviera.Text = Convert.ToString(subTotal1);
            txtTotal.Text = (decimal.Round(Convert.ToDecimal(tb_subtotal_concept.Text), 2) + decimal.Round(Convert.ToDecimal(tb_subtotal_naviera.Text), 2) + decimal.Round(Convert.ToDecimal(tb_subtotal_dep.Text), 2) + decimal.Round(Convert.ToDecimal(tb_subtotal_derechos.Text), 2)).ToString();

            tbX_service_naviera.Clear();
            tbX_price_naviera.Clear();
            tbX_tariff_naviera.Clear();
        }

        private void bt_add_concepto_Click(object sender, EventArgs e)
        {
            if (txtCliente.Text == "")
            {
                MessageBox.Show("Debe Seleccionar un Cliente");
                return;
            }

            ClaseAyuda objp = new ClaseAyuda();
            DataSet ds = objp.buscarArticulot(tbX_service_concept.Text);
            DataTable dt = ds.Tables[0];

            Console.WriteLine($"Número de filas: {dt.Rows.Count}");

            DataRow dr;
            decimal subTotal1 = 0;
            decimal sttock = 0;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                ListViewItem item = lv_concept.Items.Add(dr["idServicio"].ToString());
                item.SubItems.Add(dr["Nombres"].ToString());
                item.SubItems.Add(dr["Tarifa"].ToString());
                item.SubItems.Add(tbX_price_concept.Text);
            }

            foreach (ListViewItem item in lv_concept.Items)
            {
                if (decimal.TryParse(item.SubItems[3].Text, out decimal result))
                {
                    subTotal1 += decimal.Round(result, 2);
                }
                else
                {
                    Console.WriteLine($"No se pudo convertir '{item.SubItems[3].Text}' a decimal");
                }
            }


            tb_subtotal_concept.Text = Convert.ToString(subTotal1);
            txtTotal.Text = (decimal.Round(Convert.ToDecimal(tb_subtotal_concept.Text), 2) + decimal.Round(Convert.ToDecimal(tb_subtotal_naviera.Text), 2) + decimal.Round(Convert.ToDecimal(tb_subtotal_dep.Text), 2) + decimal.Round(Convert.ToDecimal(tb_subtotal_derechos.Text), 2)).ToString();

            tbX_service_concept.Clear();
            tbX_price_concept.Clear();
            tbX_tariff_concept.Clear();
        }

        private void bt_save_concepto_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea Registrar los Datos Ingresados", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    MySqlCommand cmd = cn.CreateCommand();

                    cmd.CommandText = "sp_Cotizar";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("_idCotizacion", txtCorrelativo.Text);
                    cmd.Parameters.AddWithValue("_Cot_fecha", dtpFecha.Value);
                    cmd.Parameters.AddWithValue("_Cot_hora", DtpHora.Value);
                    cmd.Parameters.AddWithValue("_Cot_total", decimal.Parse(txtTotal.Text));
                    cmd.Parameters.AddWithValue("_idCliente", id);
                    MySqlDataReader dr = cmd.ExecuteReader();
                    dr.Close();

                    foreach (ListViewItem item in lv_concept.Items)
                    {
                        MySqlCommand cmdd = cn.CreateCommand();
                        cmdd.CommandText = "SP_DetalleCotizar";
                        cmdd.CommandType = CommandType.StoredProcedure;
                        cmdd.Parameters.AddWithValue("_idCotizacion", txtCorrelativo.Text);
                        cmdd.Parameters.AddWithValue("_idServicio", item.SubItems[0].Text);
                        cmdd.Parameters.AddWithValue("_precio", decimal.Parse(item.SubItems[3].Text));
                        cmdd.Parameters.AddWithValue("_subtotal", decimal.Parse(tb_subtotal_concept.Text));
                        MySqlDataReader drd = cmdd.ExecuteReader();
                        drd.Close();
                    }

                    foreach (ListViewItem item in lv_naviera.Items)
                    {
                        MySqlCommand cmdd = cn.CreateCommand();
                        cmdd.CommandText = "SP_DetalleCotizar";
                        cmdd.CommandType = CommandType.StoredProcedure;
                        cmdd.Parameters.AddWithValue("_idCotizacion", txtCorrelativo.Text);
                        cmdd.Parameters.AddWithValue("_idServicio", item.SubItems[0].Text);
                        cmdd.Parameters.AddWithValue("_precio", decimal.Parse(item.SubItems[3].Text));
                        cmdd.Parameters.AddWithValue("_subtotal", decimal.Parse(tb_subtotal_naviera.Text));
                        MySqlDataReader drd = cmdd.ExecuteReader();
                        drd.Close();

                    }

                    foreach (ListViewItem item in lv_dep.Items)
                    {
                        MySqlCommand cmdd = cn.CreateCommand();
                        cmdd.CommandText = "SP_DetalleCotizar";
                        cmdd.CommandType = CommandType.StoredProcedure;
                        cmdd.Parameters.AddWithValue("_idCotizacion", txtCorrelativo.Text);
                        cmdd.Parameters.AddWithValue("_idServicio", item.SubItems[0].Text);
                        cmdd.Parameters.AddWithValue("_precio", decimal.Parse(item.SubItems[3].Text));
                        cmdd.Parameters.AddWithValue("_subtotal", decimal.Parse(tb_subtotal_dep.Text));
                        MySqlDataReader drd = cmdd.ExecuteReader();
                        drd.Close();

                    }

                    foreach (ListViewItem item in lv_derechos.Items)
                    {
                        MySqlCommand cmdd = cn.CreateCommand();
                        cmdd.CommandText = "SP_DetalleCotizar";
                        cmdd.CommandType = CommandType.StoredProcedure;
                        cmdd.Parameters.AddWithValue("_idCotizacion", txtCorrelativo.Text);
                        cmdd.Parameters.AddWithValue("_idServicio", item.SubItems[0].Text);
                        cmdd.Parameters.AddWithValue("_precio", decimal.Parse(item.SubItems[3].Text));
                        cmdd.Parameters.AddWithValue("_subtotal", decimal.Parse(tb_subtotal_derechos.Text));
                        MySqlDataReader drd = cmdd.ExecuteReader();
                        drd.Close();

                    }

                    foreach (ListViewItem item in lv_otro.Items)
                    {
                        MySqlCommand cmdd = cn.CreateCommand();
                        cmdd.CommandText = "SP_DetalleCotizarA";
                        cmdd.CommandType = CommandType.StoredProcedure;
                        cmdd.Parameters.AddWithValue("_idCotizacion", txtCorrelativo.Text);
                        cmdd.Parameters.AddWithValue("_idProducto", item.SubItems[0].Text);
                        cmdd.Parameters.AddWithValue("_cantidad", item.SubItems[2].Text);
                        cmdd.Parameters.AddWithValue("_peso", decimal.Parse(item.SubItems[3].Text));
                        cmdd.Parameters.AddWithValue("_bl", item.SubItems[4].Text);
                        MySqlDataReader drd = cmdd.ExecuteReader();
                        drd.Close();

                    }

                    foreach (ListViewItem item in lv_colaterales.Items)
                    {
                        MySqlCommand cmdd = cn.CreateCommand();
                        cmdd.CommandText = "SP_DetalleCotizar";
                        cmdd.CommandType = CommandType.StoredProcedure;
                        cmdd.Parameters.AddWithValue("_idCotizacion", txtCorrelativo.Text);
                        cmdd.Parameters.AddWithValue("_idServicio", item.SubItems[0].Text);
                        cmdd.Parameters.AddWithValue("_precio", decimal.Parse(item.SubItems[2].Text));
                        cmdd.Parameters.AddWithValue("_subtotal", decimal.Parse(txtSubTotal10.Text));
                        MySqlDataReader drd = cmdd.ExecuteReader();
                        drd.Close();

                        MessageBox.Show("Cotización Realizada", "ATIPANA");
                        limpiar();

                        txtCorrelativo.Text = objn.GenerarCodigo("tcotizacion");

                    }
                }

                catch (MySqlException ex) { MessageBox.Show(ex.Message, "ATIPANA", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void bt_save_concepto_Click_1(object sender, EventArgs e)
        {

        }

        private void bt_add_concepto_Click_1(object sender, EventArgs e)
        {

        }

        private void superTabControlPanel2_Click(object sender, EventArgs e)
        {

        }

        private void bt_delete_concept_Click(object sender, EventArgs e)
        {
            decimal subTotal2 = 0;

            if (lv_concept.SelectedItems.Count > 0)
            {
                lv_concept.Items.Remove(lv_concept.SelectedItems[0]);
                foreach (ListViewItem item in lv_concept.Items)
                {
                    subTotal2 += (decimal.Parse(item.SubItems[3].Text));
                }

                tb_subtotal_concept.Text = subTotal2.ToString();
                txtTotal.Text = (decimal.Round(Convert.ToDecimal(tb_subtotal_concept.Text), 2) + decimal.Round(Convert.ToDecimal(tb_subtotal_naviera.Text), 2) + decimal.Round(Convert.ToDecimal(tb_subtotal_dep.Text), 2) + decimal.Round(Convert.ToDecimal(tb_subtotal_derechos.Text), 2)).ToString();
            }

            else
                MessageBox.Show("Seleccione una Fila");
        }

        private void bt_search_concept_Click(object sender, EventArgs e)
        {
            FrmBuscarServicio frmbse = new FrmBuscarServicio();
            frmbse.ShowDialog();
            tbX_service_concept.Text = nombpro;
            tbX_price_concept.Text = precioventa;
            tbX_tariff_concept.Text = tarifa;
        }
        
        private void button16_Click_1(object sender, EventArgs e)
        {
            decimal subTotal11 = 0;
            if (lv_colaterales.SelectedItems.Count > 0)
            {
                lv_colaterales.Items.Remove(lv_colaterales.SelectedItems[0]);
                foreach (ListViewItem item in lv_colaterales.Items)
                {
                    subTotal11 += (decimal.Parse(item.SubItems[2].Text));
                }

                tb_subtotal_colaterales.Text = subTotal11.ToString();
                txtTotal.Text = (decimal.Round(Convert.ToDecimal(tb_subtotal_concept.Text), 2) + decimal.Round(Convert.ToDecimal(tb_subtotal_naviera.Text), 2) + decimal.Round(Convert.ToDecimal(tb_subtotal_dep.Text), 2) + decimal.Round(Convert.ToDecimal(tb_subtotal_derechos.Text), 2)).ToString();
            }

            else
                MessageBox.Show("Seleccione una Fila");
        }

        private void button22_Click(object sender, EventArgs e)
        {
            FrmBuscarProducto frmbse = new FrmBuscarProducto();
            frmbse.ShowDialog();
            textBoxX2.Text = np6;
        }

        private void button16_Click(object sender, EventArgs e)
        {
           
        }

        private void button15_Click_1(object sender, EventArgs e)
        {
            FrmBuscarGasto gasto = new FrmBuscarGasto();
            gasto.ShowDialog();
            txtPro10.Text = np5;
            txtPrecioV10.Text = pv5;
        }

        private void listView6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        void limpiar()
        {
            txtCliente.Text = "";
            txtOficina.Text = "";
            lv_colaterales.Items.Clear();
            lv_concept.Items.Clear();
            lv_naviera.Items.Clear();
            lv_dep.Items.Clear();
            lv_derechos.Items.Clear();
        }

        public void generarword()
        {
           // int j = 1;
            object ObjMiss = System.Reflection.Missing.Value;
            Word.Application ObjWord = new Word.Application();
            string ruta = @"C:\sistema\hola\nuevo.docx";
            object parametro = ruta;
            object cotizacion = "cotis";
            object numeracion = "numero";
            object nombre1 = "nombre";
            object telefono1 = "telefono";
            object codigo1 = "fecha";
            object subtotal1 = "subtotal";
            object igv1 = "igv";
            object total1 = "total";
            object f1 = "ja";

            Word.Document ObjDoc = ObjWord.Documents.Open(parametro, ObjMiss);
            Word.Range coti = ObjDoc.Bookmarks.get_Item(ref cotizacion).Range;
            coti.Text = label1.Text;
            Word.Range nun = ObjDoc.Bookmarks.get_Item(ref numeracion).Range;
            nun.Text = txtCorrelativo.Text;
            Word.Range nom = ObjDoc.Bookmarks.get_Item(ref nombre1).Range;
            nom.Text = txtCliente.Text;
           
           
            Word.Range cod = ObjDoc.Bookmarks.get_Item(ref codigo1).Range;
            cod.Text = dtpFecha.Text;

            object rango1 = nom;
            object rango4 = cod;
            object rango5 = nun;
            object rango6 = coti;
            ObjDoc.Bookmarks.Add("nombre", ref rango1);
            ObjDoc.Bookmarks.Add("fecha", ref rango4);
            ObjDoc.Bookmarks.Add("numero", ref rango5);
            ObjDoc.Bookmarks.Add("cotis", ref rango6);


            int rowNum = lv_colaterales.Items.Count;
            int columnNum = lv_colaterales.Items[0].SubItems.Count;
            int rowIndex = 1;
            int columnIndex = 0;
            int j = 1;
            if (rowNum > 0)
            {


                ObjDoc.Paragraphs.First.Range.Font.Size = 18;
                ObjDoc.Paragraphs.First.Range.Font.Bold = 2;
                ObjDoc.Paragraphs.First.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;

                Microsoft.Office.Interop.Word.Range tableLocation = ObjDoc.Paragraphs.Last.Range;
                Microsoft.Office.Interop.Word.Table newTable = ObjDoc.Tables.Add(tableLocation, rowNum + 1, columnNum - 1);
                Microsoft.Office.Interop.Word.Range tableLocation1 = ObjDoc.Paragraphs.Last.Range;
                Microsoft.Office.Interop.Word.Table newTable1 = ObjDoc.Tables.Add(tableLocation1, 1, 1);
                newTable.Borders.Enable = 1;
                newTable1.Rows.Alignment = Word.WdRowAlignment.wdAlignRowRight;
                
                newTable.Select();
                ObjWord.Selection.Tables[1].Rows.Alignment = Microsoft.Office.Interop.Word.WdRowAlignment.wdAlignRowCenter;



                newTable.Cell(1, 1).Range.Text = "CONCEPTO";
                newTable.Cell(1, 1).Range.Bold = 2;
                newTable.Cell(1, 1).Range.Cells.Width = 300;
                newTable.Cell(1, 1).Range.Shading.BackgroundPatternColor = Word.WdColor.wdColorDarkBlue;
                newTable.Cell(1, 2).Range.Text = "Tarifa";
                newTable.Cell(1, 2).Range.Bold = 2;
                newTable.Cell(1, 2).Range.Cells.Width = 70;
                newTable.Cell(1, 2).Range.Shading.BackgroundPatternColor = Word.WdColor.wdColorDarkBlue;
                newTable.Cell(1, 3).Range.Text = "Sub Total";
                newTable.Cell(1, 3).Range.Bold = 2;
                newTable.Cell(1, 3).Range.Cells.Width = 70;
                newTable.Cell(1, 3).Range.Shading.BackgroundPatternColor = Word.WdColor.wdColorDarkBlue;

                newTable.Cell(rowIndex, columnIndex).Range.Bold = 2;

                foreach (ListViewItem item in lv_colaterales.Items)
                {
                    newTable.Cell(j + 1, 1).Range.Text = item.SubItems[1].Text;
                    newTable.Cell(j + 1, 1).Range.Cells.Width = 300;
                    newTable.Cell(j + 1, 2).Range.Text = item.SubItems[2].Text;
                    newTable.Cell(j + 1, 2).Range.Cells.Width = 70;
                    newTable.Cell(j + 1, 3).Range.Text = item.SubItems[3].Text;
                    newTable.Cell(j + 1, 3).Range.Cells.Width = 70;
                    newTable1.Cell(j + 2, 1).Range.Text = "SubTotal" + " " + "S/. " + tb_subtotal_concept.Text;
                    newTable1.Cell(j + 2, 1).Range.Cells.Width = 440;
                    newTable1.Cell(j + 2, 1).Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphRight;
                    j++;
                }

                ObjDoc.Words.Last.InsertBreak(Word.WdBreakType.wdLineBreak);


            }

            ObjDoc.Words.Last.InsertBreak(Word.WdBreakType.wdLineBreak);


            int rowNumA = lv_concept.Items.Count;
            int columnNumA = lv_concept.Items[0].SubItems.Count;
            int rowIndexA = 1;
            int columnIndexA = 0;
            int jj = 1;
            if (rowNumA > 0)
            {


                ObjDoc.Paragraphs.First.Range.Font.Size = 18;
                ObjDoc.Paragraphs.First.Range.Font.Bold = 2;
                ObjDoc.Paragraphs.First.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;

                Microsoft.Office.Interop.Word.Range tableLocation2 = ObjDoc.Paragraphs.Last.Range;
                Microsoft.Office.Interop.Word.Table newTable2 = ObjDoc.Tables.Add(tableLocation2, rowNumA + 1,  3);
                Microsoft.Office.Interop.Word.Range tableLocation3 = ObjDoc.Paragraphs.Last.Range;
                Microsoft.Office.Interop.Word.Table newTable3 = ObjDoc.Tables.Add(tableLocation3, 1, 1);
                newTable2.Borders.Enable = 1;
                newTable3.Rows.Alignment = Word.WdRowAlignment.wdAlignRowLeft;

                newTable2.Select();
                ObjWord.Selection.Tables[1].Rows.Alignment = Microsoft.Office.Interop.Word.WdRowAlignment.wdAlignRowCenter;
                ObjWord.Selection.Tables[1].Rows.Alignment = Microsoft.Office.Interop.Word.WdRowAlignment.wdAlignRowCenter;

                newTable2.Cell(jj + (j + 1) , 1).Range.Text = "GASTOS NAVIERA - MSC";
                newTable2.Cell(jj + (j + 1) , 1).Range.Bold = 2;
                newTable2.Cell(jj + (j + 1), 1).Range.Cells.Width = 300;
                newTable2.Cell(jj + (j + 1), 1).Range.Shading.BackgroundPatternColor = Word.WdColor.wdColorDarkBlue;
                newTable2.Cell(jj + (j + 1) , 2).Range.Text = "Tarifa";
                newTable2.Cell(jj + (j + 1) , 2).Range.Bold = 2;
                newTable2.Cell(jj + (j + 1), 2).Range.Cells.Width = 70;
                newTable2.Cell(jj + (j + 1), 2).Range.Shading.BackgroundPatternColor = Word.WdColor.wdColorDarkBlue;
                newTable2.Cell(jj + (j + 1) , 3).Range.Text = "Sub Total";
                newTable2.Cell(jj + (j + 1) , 3).Range.Bold = 2;
                newTable2.Cell(jj + (j + 1), 3).Range.Cells.Width = 70;
                newTable2.Cell(jj + (j + 1), 3).Range.Shading.BackgroundPatternColor = Word.WdColor.wdColorDarkBlue;


                newTable2.Cell(rowIndexA, columnIndexA).Range.Bold = 2;

                foreach (ListViewItem item in lv_concept.Items)
                {
                    newTable2.Cell(jj +(j + 2), 1).Range.Text = item.SubItems[1].Text;
                    newTable2.Cell(jj + (j + 2), 1).Range.Cells.Width = 300;
                    newTable2.Cell(jj + (j + 2), 2).Range.Text = item.SubItems[2].Text;
                    newTable2.Cell(jj + (j + 2), 2).Range.Cells.Width = 70;
                    newTable2.Cell(jj + (j + 2), 3).Range.Text = item.SubItems[3].Text;
                    newTable2.Cell(jj + (j + 2), 3).Range.Cells.Width = 70;
                    newTable3.Cell(jj + (j + 3), 1).Range.Text = "SubTotal" + " " + "S/." + tb_subtotal_naviera.Text;
                    newTable3.Cell(jj + (j + 3), 1).Range.Cells.Width = 440;
                    newTable3.Cell(jj + (j + 3), 1).Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphRight;
                    j++;
                }


            


        }



            int rowNumB = lv_dep.Items.Count;
            int columnNumB = lv_dep.Items[0].SubItems.Count;
            int rowIndexB = 1;
            int columnIndexB = 0;
            int jB = 1;

            if (rowNumA > 0)
            {


                ObjDoc.Paragraphs.First.Range.Font.Size = 18;
                ObjDoc.Paragraphs.First.Range.Font.Bold = 2;
                ObjDoc.Paragraphs.First.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;

                Microsoft.Office.Interop.Word.Range tableLocation4 = ObjDoc.Paragraphs.Last.Range;
                Microsoft.Office.Interop.Word.Table newTable4 = ObjDoc.Tables.Add(tableLocation4, rowNumB + 1, 3);
                Microsoft.Office.Interop.Word.Range tableLocation5 = ObjDoc.Paragraphs.Last.Range;
                Microsoft.Office.Interop.Word.Table newTable5 = ObjDoc.Tables.Add(tableLocation5, 1, 1);
                newTable4.Borders.Enable = 1;
                newTable5.Rows.Alignment = Word.WdRowAlignment.wdAlignRowLeft;

                newTable4.Select();
                ObjWord.Selection.Tables[1].Rows.Alignment = Microsoft.Office.Interop.Word.WdRowAlignment.wdAlignRowCenter;
                ObjWord.Selection.Tables[1].Rows.Alignment = Microsoft.Office.Interop.Word.WdRowAlignment.wdAlignRowCenter;

                newTable4.Cell(jB + (jB + (j + 2)), 1).Range.Text = "GASTOS DEP. TEMPORAL - TPE / MEDLOG";
                newTable4.Cell(jB + (jB + (j + 2)), 1).Range.Bold = 2;
                newTable4.Cell(jB + (jB + (j + 2)), 1).Range.Cells.Width = 300;
                newTable4.Cell(jB + (jB + (j + 2)), 1).Range.Shading.BackgroundPatternColor = Word.WdColor.wdColorDarkBlue;
                newTable4.Cell(jB + (jB + (j + 2)), 2).Range.Text = "Tarifa";
                newTable4.Cell(jB + (jB + (j + 2)), 2).Range.Bold = 2;
                newTable4.Cell(jB + (jB + (j + 2)), 2).Range.Cells.Width = 70;
                newTable4.Cell(jB + (jB + (j + 2)), 2).Range.Shading.BackgroundPatternColor = Word.WdColor.wdColorDarkBlue;
                newTable4.Cell(jB + (jB + (j + 2)), 3).Range.Text = "Sub Total";
                newTable4.Cell(jB + (jB + (j + 2)), 3).Range.Bold = 2;
                newTable4.Cell(jB + (jB + (j + 2)), 3).Range.Cells.Width = 70;
                newTable4.Cell(jB + (jB + (j + 2)), 3).Range.Shading.BackgroundPatternColor = Word.WdColor.wdColorDarkBlue;

                newTable4.Cell(rowIndex, columnIndex).Range.Bold = 2;





                foreach (ListViewItem item in lv_dep.Items)
                {
                    newTable4.Cell(jB + (jB + (j + 3)), 1).Range.Text = item.SubItems[1].Text;
                    newTable4.Cell(jB + (jB + (j + 3)), 1).Range.Cells.Width = 300;
                    newTable4.Cell(jB + (jB + (j + 3)), 2).Range.Text = item.SubItems[2].Text;
                    newTable4.Cell(jB + (jB + (j + 3)), 2).Range.Cells.Width = 70;
                    newTable4.Cell(jB + (jB + (j + 3)), 3).Range.Text = item.SubItems[3].Text;
                    newTable4.Cell(jB + (jB + (j + 3)), 3).Range.Cells.Width = 70;
                    newTable5.Cell(jB + (jB + (j + 4)), 1).Range.Text = "SubTotal" + " " + "S/." + tb_subtotal_dep.Text;
                    newTable5.Cell(jB + (jB + (j + 4)), 1).Range.Cells.Width = 440;
                    newTable5.Cell(jB + (jB + (j + 4)), 1).Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphRight;
                    j++;
                }





            }


            int rowNumC = lv_derechos.Items.Count;
            int columnNumC = lv_derechos.Items[0].SubItems.Count;
            int rowIndexC = 1;
            int columnIndexC = 0;
            int jC = 1;
            if (rowNumA > 0)
            {


                ObjDoc.Paragraphs.First.Range.Font.Size = 18;
                ObjDoc.Paragraphs.First.Range.Font.Bold = 2;
                ObjDoc.Paragraphs.First.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;

                Microsoft.Office.Interop.Word.Range tableLocation6 = ObjDoc.Paragraphs.Last.Range;
                Microsoft.Office.Interop.Word.Table newTable6 = ObjDoc.Tables.Add(tableLocation6, rowNumC + 1, 3);
                Microsoft.Office.Interop.Word.Range tableLocation7 = ObjDoc.Paragraphs.Last.Range;
                Microsoft.Office.Interop.Word.Table newTable7 = ObjDoc.Tables.Add(tableLocation7, 1, 1);
                newTable6.Borders.Enable = 1;
                newTable7.Rows.Alignment = Word.WdRowAlignment.wdAlignRowLeft;

                newTable6.Select();
                ObjWord.Selection.Tables[1].Rows.Alignment = Microsoft.Office.Interop.Word.WdRowAlignment.wdAlignRowCenter;
                ObjWord.Selection.Tables[1].Rows.Alignment = Microsoft.Office.Interop.Word.WdRowAlignment.wdAlignRowCenter;

                newTable6.Cell(jC + (jC +(jB + (j + 3))), 1).Range.Text = "DERECHPOS E IMPUESTOS";
                newTable6.Cell(jC + (jC + (jB + (j + 3))), 1).Range.Bold = 2;
                newTable6.Cell(jC + (jC + (jB + (j + 3))), 1).Range.Cells.Width = 300;
                newTable6.Cell(jC + (jC + (jB + (j + 3))), 1).Range.Shading.BackgroundPatternColor = Word.WdColor.wdColorDarkBlue;
                newTable6.Cell(jC + (jC + (jB + (j + 3))), 2).Range.Text = "Tarifa";
                newTable6.Cell(jC + (jC + (jB + (j + 3))), 2).Range.Bold = 2;
                newTable6.Cell(jC + (jC + (jB + (j + 3))), 2).Range.Cells.Width = 70;
                newTable6.Cell(jC + (jC + (jB + (j + 3))), 2).Range.Shading.BackgroundPatternColor = Word.WdColor.wdColorDarkBlue;
                newTable6.Cell(jC + (jC + (jB + (j + 3))), 3).Range.Text = "Sub Total";
                newTable6.Cell(jC + (jC + (jB + (j + 3))), 3).Range.Bold = 2;
                newTable6.Cell(jC + (jC + (jB + (j + 3))), 3).Range.Cells.Width = 70;
                newTable6.Cell(jC + (jC + (jB + (j + 3))),3).Range.Shading.BackgroundPatternColor = Word.WdColor.wdColorDarkBlue;

                newTable6.Cell(rowIndex, columnIndex).Range.Bold = 2;





                foreach (ListViewItem item in lv_derechos.Items)
                {
                    newTable6.Cell(jC + (jB + (jB + (j + 4))), 1).Range.Text = item.SubItems[1].Text;
                    newTable6.Cell(jC + (jB + (jB + (j + 4))), 1).Range.Cells.Width = 300;
                    newTable6.Cell(jC + (jB + (jB + (j + 4))), 2).Range.Text = item.SubItems[2].Text;
                    newTable6.Cell(jC + (jB + (jB + (j + 4))), 2).Range.Cells.Width = 70;
                    newTable6.Cell(jC + (jB + (jB + (j + 4))), 3).Range.Text = item.SubItems[3].Text;
                    newTable6.Cell(jC + (jB + (jB + (j + 4))), 3).Range.Cells.Width = 70;
                    newTable7.Cell(jC + (jB + (jB + (j + 5))), 1).Range.Text = "SubTotal" + " " + "S/." + tb_subtotal_derechos.Text;
                    newTable7.Cell(jC + (jB + (jB + (j + 5))), 1).Range.Cells.Width = 440;
                    newTable7.Cell(jC + (jB + (jB + (j + 5))), 1).Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphRight;
                    j++;
                }





            }

            ObjWord.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            generarword();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }
    }
}
    
