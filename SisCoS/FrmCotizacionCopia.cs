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
    public partial class FrmCotizacionCopia : Form
    {
        public MySqlConnection cn;
        

        public static string id, nom, ofi, idpro, nombpro, stock, precioventa, idMaquinaria, descm, tarifa,
            t1, id1, np1, pv1,
            t2, id2, np2, pv2,
            t4, id4, np4, pv4,
            id5, np5, pv5,
            id6, np6, pv6;

        public FrmCotizacionCopia()
        {
            
            InitializeComponent();
            cn = FrmPrincipal.cn;
        }
        CProdimientoN objn = new CProdimientoN();
   

        private void FrmCotizacion_Load(object sender, EventArgs e)
        {
            
            button1.Visible = true;
            button3.Visible = true;
            button4.Visible = true;


            button9.Visible = false;
            button10.Visible = false;

            button11.Visible = false;
            button12.Visible = false;
            button13.Visible = false;
            button14.Visible = false;
            button17.Visible = false;
            button18.Visible = false;
            button19.Visible = false;
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

        

        //void generarCodigo1()
        //{

        //    DataSet ds = generarCodigo();
        //    DataTable dt = ds.Tables[0];
        //    DataRow dr = dt.Rows[0];
        //    String codigo = dr["Codigo"].ToString();
        //    txtCorrelativo.Text = codigo;
        //}

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
            //txtPro.Text = nombpro;
            //txtPrecioV.Text = precioventa;
            //txtCantidad.Select();

        }
        
        decimal sttock = 0;
       
        
        

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                button8.Visible = false;
                button3.Visible = false;
                button9.Visible = false;
                button10.Visible = false;

                button11.Visible = true;
                button12.Visible = true;
                button13.Visible = false;
                button14.Visible = false;
                button4.Visible = false;
                button17.Visible = false;
                button18.Visible = true;
                button19.Visible = false;
            }
        }

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

        private void txtsuma1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void button17_Click(object sender, EventArgs e)
        {
            decimal subTotal2 = 0;
            if (listView2.SelectedItems.Count > 0)
            {
                listView2.Items.Remove(listView2.SelectedItems[0]);
                foreach (ListViewItem item in listView2.Items)
                {
                    subTotal2 += (decimal.Parse(item.SubItems[3].Text));
                }
                txtSubTotal1.Text = subTotal2.ToString();
                //txtIGV.Text = Convert.ToString(subTotal * 18 / 100);
                //txtTotal.Text = Convert.ToString(subTotal + decimal.Parse(txtIGV.Text));
                //  txtTotal.Text = Convert.ToString(decimal.Round(subTotal2, 2) + decimal.Round(subTotal, 2) + decimal.Round(subTotal1, 2) + decimal.Round(subTotal4, 2));
                txtTotal.Text = (decimal.Round(Convert.ToDecimal(txtSubTotal.Text), 2) + decimal.Round(Convert.ToDecimal(txtSubTotal1.Text), 2) + decimal.Round(Convert.ToDecimal(txtSubTotal2.Text), 2) + decimal.Round(Convert.ToDecimal(txtSubTotal4.Text), 2)).ToString();
            }

            else
                MessageBox.Show("Seleccione una Fila");
        }

        private void button18_Click(object sender, EventArgs e)
        {
            decimal subTotal1 = 0;
            if (listView3.SelectedItems.Count > 0)
            {
                listView3.Items.Remove(listView3.SelectedItems[0]);
                foreach (ListViewItem item in listView3.Items)
                {
                    subTotal1 += (decimal.Parse(item.SubItems[3].Text));
                }
                txtSubTotal2.Text = subTotal1.ToString();
                //txtIGV.Text = Convert.ToString(subTotal * 18 / 100);
                //txtTotal.Text = Convert.ToString(subTotal + decimal.Parse(txtIGV.Text));
                // txtTotal.Text = Convert.ToString(decimal.Round(subTotal2, 2) + decimal.Round(subTotal, 2) + decimal.Round(subTotal1, 2) + decimal.Round(subTotal4, 2));
                txtTotal.Text = (decimal.Round(Convert.ToDecimal(txtSubTotal.Text), 2) + decimal.Round(Convert.ToDecimal(txtSubTotal1.Text), 2) + decimal.Round(Convert.ToDecimal(txtSubTotal2.Text), 2) + decimal.Round(Convert.ToDecimal(txtSubTotal4.Text), 2)).ToString();
            }

            else
                MessageBox.Show("Seleccione una Fila");
        }

        private void button19_Click(object sender, EventArgs e)
        {
            decimal subTotal4 = 0;
            if (listView4.SelectedItems.Count > 0)
            {
                listView4.Items.Remove(listView4.SelectedItems[0]);
                foreach (ListViewItem item in listView4.Items)
                {
                    subTotal4 += (decimal.Parse(item.SubItems[3].Text));
                }
                txtSubTotal4.Text = subTotal4.ToString();
                //txtIGV.Text = Convert.ToString(subTotal * 18 / 100);
                //txtTotal.Text = Convert.ToString(subTotal + decimal.Parse(txtIGV.Text));
                //txtTotal.Text = Convert.ToString(decimal.Round(subTotal2, 2) + decimal.Round(subTotal, 2) + decimal.Round(subTotal1, 2) + decimal.Round(subTotal4, 2));
                txtTotal.Text = (decimal.Round(Convert.ToDecimal(txtSubTotal.Text), 2) + decimal.Round(Convert.ToDecimal(txtSubTotal1.Text), 2) + decimal.Round(Convert.ToDecimal(txtSubTotal2.Text), 2) + decimal.Round(Convert.ToDecimal(txtSubTotal4.Text), 2)).ToString();
            }

            else
                MessageBox.Show("Seleccione una Fila");
        }

        decimal subTotal7 = 0;

        private void button23_Click(object sender, EventArgs e)
        {
            if (txtCliente.Text == "")
            {
                MessageBox.Show("Debe Seleccionar un Cliente");
                return;



            }

           // subTotal7 += decimal.Round((decimal.Parse(txtPrecioV10.Text)), 2);

          //  txtSubTotal10.Text = Convert.ToString(subTotal7);
            foreach (ListViewItem item in listView5.Items)
            {
                if (id6 == item.SubItems[0].Text)
                {
                    item.SubItems[3].Text = (int.Parse(txtCantidad.Text) + int.Parse(item.SubItems[3].Text)).ToString();
                    item.SubItems[4].Text = (decimal.Parse(item.SubItems[3].Text) * decimal.Parse(item.SubItems[2].Text)).ToString();
                    return;
                }
            }
            ListViewItem items = listView5.Items.Add(id6);
            items.SubItems.Add(textBoxX2.Text);
            items.SubItems.Add(textBoxX1.Text);
            items.SubItems.Add(textBoxX3.Text);
            items.SubItems.Add(textBoxX4.Text);

            textBoxX2.Clear();
           textBoxX1.Clear();
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
            foreach (ListViewItem item in listView6.Items)
            {
                if (id5 == item.SubItems[0].Text)
                {
                    item.SubItems[3].Text = (int.Parse(txtCantidad.Text) + int.Parse(item.SubItems[3].Text)).ToString();
                    item.SubItems[4].Text = (decimal.Parse(item.SubItems[3].Text) * decimal.Parse(item.SubItems[2].Text)).ToString();
                    return;
                }
            }
            ListViewItem items = listView6.Items.Add(id5);
            items.SubItems.Add(txtPro10.Text);
            items.SubItems.Add(txtPrecioV10.Text);

            txtPro10.Clear();
            txtPrecioV10.Clear();
        }

        private void button24_Click(object sender, EventArgs e)
        {

        }

        private void button16_Click_1(object sender, EventArgs e)
        {
            decimal subTotal11 = 0;
            if (listView6.SelectedItems.Count > 0)
            {
                listView6.Items.Remove(listView6.SelectedItems[0]);
                foreach (ListViewItem item in listView6.Items)
                {
                    subTotal11 += (decimal.Parse(item.SubItems[2].Text));
                }
                txtSubTotal10.Text = subTotal11.ToString();
                //txtIGV.Text = Convert.ToString(subTotal * 18 / 100);
                //txtTotal.Text = Convert.ToString(subTotal + decimal.Parse(txtIGV.Text));
                //txtTotal.Text = Convert.ToString(decimal.Round(subTotal2, 2) + decimal.Round(subTotal, 2) + decimal.Round(subTotal1, 2) + decimal.Round(subTotal4, 2));
                txtTotal.Text = (decimal.Round(Convert.ToDecimal(txtSubTotal.Text), 2) + decimal.Round(Convert.ToDecimal(txtSubTotal1.Text), 2) + decimal.Round(Convert.ToDecimal(txtSubTotal2.Text), 2) + decimal.Round(Convert.ToDecimal(txtSubTotal4.Text), 2)).ToString();
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
            //txtCantidad.Text = t4;
        }

        private void listView6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (txtCliente.Text == "")
            {
                MessageBox.Show("Debe Seleccionar un Cliente");
                return;



            }


            ClaseAyuda objp = new ClaseAyuda();
            DataSet ds = objp.buscarArticulow(txtPro.Text);
            DataTable dt = ds.Tables[0];
            DataRow dr;
            // sttock = int.Parse(stock);
            decimal subTotal1 = 0;
            decimal sttock = 0;




            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                ListViewItem item = listView3.Items.Add(dr["idServicio"].ToString());
                item.SubItems.Add(dr["Nombres"].ToString());
                item.SubItems.Add(dr["Tarifa"].ToString());
                item.SubItems.Add(txtPrecioV.Text);




            }
            foreach (ListViewItem item in listView3.Items)
            {
                subTotal1 += decimal.Round((decimal.Parse(item.SubItems[3].Text)), 2);
            }
            txtSubTotal2.Text = Convert.ToString(subTotal1);
            //txtTotal.Text = (decimal.Round(Convert.ToDecimal(txtSubTotal.Text), 2) + decimal.Round(Convert.ToDecimal(txtSubTotal1.Text), 2) + decimal.Round(Convert.ToDecimal(txtSubTotal2.Text), 2) + decimal.Round(Convert.ToDecimal(txtSubTotal4.Text), 2)).ToString();
            txtTotal.Text = (decimal.Round(Convert.ToDecimal(txtSubTotal.Text), 2) + decimal.Round(Convert.ToDecimal(txtSubTotal1.Text), 2) + decimal.Round(Convert.ToDecimal(txtSubTotal2.Text), 2) + decimal.Round(Convert.ToDecimal(txtSubTotal4.Text), 2)).ToString();

            txtPro.Clear();
            txtPrecioV.Clear();
            txtCantidad.Clear();
        }




        private void button13_Click(object sender, EventArgs e)
        {
            FrmBuscarServicioJ frmbse = new FrmBuscarServicioJ();
            frmbse.ShowDialog();
            txtPro.Text = np4;
            txtPrecioV.Text = pv4;
            txtCantidad.Text = t4;
        }



        

        private void button14_Click(object sender, EventArgs e)
        {
            if (txtCliente.Text == "")
            {
                MessageBox.Show("Debe Seleccionar un Cliente");
                return;



            }


            ClaseAyuda objp = new ClaseAyuda();
            DataSet ds = objp.buscarArticulo(txtPro.Text);
            DataTable dt = ds.Tables[0];
            DataRow dr;
            // sttock = int.Parse(stock);
            decimal subTotal4 = 0;
            decimal sttock = 0;




            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                ListViewItem item = listView4.Items.Add(dr["idServicio"].ToString());
                item.SubItems.Add(dr["Nombres"].ToString());
                item.SubItems.Add(dr["Tarifa"].ToString());
                item.SubItems.Add(txtPrecioV.Text);
                
               


            }
            foreach (ListViewItem item in listView4.Items)
            {
                subTotal4 += decimal.Round((decimal.Parse(item.SubItems[3].Text)), 2);
            }
            txtSubTotal4.Text = Convert.ToString(subTotal4);
            txtTotal.Text = (decimal.Round(Convert.ToDecimal(txtSubTotal.Text), 2) + decimal.Round(Convert.ToDecimal(txtSubTotal1.Text), 2) + decimal.Round(Convert.ToDecimal(txtSubTotal2.Text), 2) + decimal.Round(Convert.ToDecimal(txtSubTotal4.Text), 2)).ToString();


            txtPro.Clear();
            txtPrecioV.Clear();
            txtCantidad.Clear();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton4.Checked==true)
            {
                button8.Visible = false;
                button3.Visible = false;
                button9.Visible = false;
                button10.Visible = false;

                button11.Visible = false;
                button12.Visible = false;
                button13.Visible = true;
                button14.Visible = true;
                button4.Visible = false;
                button17.Visible = false;
                button18.Visible = false;
                button19.Visible = true;
            }
        }

        decimal sttock1 = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            if (txtCliente.Text == "")
            {
                MessageBox.Show("Debe Seleccionar un Cliente");
                return;



            }

            ClaseAyuda objp = new ClaseAyuda();
            DataSet ds = objp.buscarArticulot(txtPro.Text);
            DataTable dt = ds.Tables[0];
            DataRow dr;
            // sttock = int.Parse(stock);
            decimal subTotal = 0;
            decimal sttock = 0;




            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                ListViewItem item = listView1.Items.Add(dr["idServicio"].ToString());
                item.SubItems.Add(dr["Nombres"].ToString());
                item.SubItems.Add(dr["Tarifa"].ToString());
                item.SubItems.Add(txtPrecioV.Text);




            }
            foreach (ListViewItem item in listView1.Items)
            {
                subTotal += decimal.Round((decimal.Parse(item.SubItems[3].Text)), 2);
            }
            txtSubTotal.Text = Convert.ToString(subTotal);
            // txtTotal.Text = (decimal.Round(Convert.ToDecimal(txtSubTotal.Text), 2) + decimal.Round(Convert.ToDecimal(txtSubTotal1.Text), 2) + decimal.Round(Convert.ToDecimal(txtSubTotal2.Text), 2) + decimal.Round(Convert.ToDecimal(txtSubTotal4.Text), 2)).ToString();
            txtTotal.Text = (decimal.Round(Convert.ToDecimal(txtSubTotal.Text), 2) + decimal.Round(Convert.ToDecimal(txtSubTotal1.Text), 2) + decimal.Round(Convert.ToDecimal(txtSubTotal2.Text), 2) + decimal.Round(Convert.ToDecimal(txtSubTotal4.Text), 2)).ToString();

            txtPro.Clear();
            txtPrecioV.Clear();
            txtCantidad.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            decimal subTotal = 0;
            if (listView1.SelectedItems.Count > 0)
            {
                listView1.Items.Remove(listView1.SelectedItems[0]);
                foreach (ListViewItem item in listView1.Items)
                {
                    subTotal += (decimal.Parse(item.SubItems[3].Text));
                }
                txtSubTotal.Text = Convert.ToString(subTotal);
                //txtIGV.Text = Convert.ToString(subTotal * 18 / 100);
               // txtTotal.Text = Convert.ToString(decimal.Round(subTotal2, 2) + decimal.Round(subTotal, 2) + decimal.Round(subTotal1, 2) + decimal.Round(subTotal4, 2));


            }


            else
            {
                MessageBox.Show("Seleccione una Fila");
            }
           
        }

        private void button11_Click(object sender, EventArgs e)
        {
            FrmBuscarServicioE frmbse = new FrmBuscarServicioE();
            frmbse.ShowDialog();
            txtPro.Text = np2;
            txtPrecioV.Text = pv2;
            txtCantidad.Text = t2;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                button8.Visible = true;
                button3.Visible = true;
                button4.Visible = true;
                button9.Visible = false;
                button10.Visible = false;

                button11.Visible = false;
                button12.Visible = false;
                button13.Visible = false;
                button14.Visible = false;
                button17.Visible = false;
                button19.Visible = false;
            }
           
           
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                button9.Visible = true;
                button10.Visible = true;
                button8.Visible = false;
                button3.Visible = false;
                button11.Visible = false;
                button12.Visible = false;
                button13.Visible = false;
                button14.Visible = false;
                button4.Visible = false;
                button17.Visible = true;
                button18.Visible = false;
                button19.Visible = false;
            }
           
        }

        private void button9_Click(object sender, EventArgs e)
        {
            FrmBuscarServicioT frmbst = new FrmBuscarServicioT();
            frmbst.ShowDialog();
            txtPro.Text = np1;
            txtPrecioV.Text = pv1;
            txtCantidad.Text = t1;
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (txtCliente.Text == "")
            {
                MessageBox.Show("Debe Seleccionar un Cliente");
                return;

            }

            ClaseAyuda objp = new ClaseAyuda();
            DataSet ds = objp.buscarArticuloq(txtPro.Text);
            DataTable dt = ds.Tables[0];
            DataRow dr;
            // sttock = int.Parse(stock);
            decimal subTotal2 = 0;
            decimal sttock = 0;




            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                ListViewItem item = listView2.Items.Add(dr["idServicio"].ToString());
                item.SubItems.Add(dr["Nombres"].ToString());
                item.SubItems.Add(dr["Tarifa"].ToString());
                item.SubItems.Add(txtPrecioV.Text);




            }
            foreach (ListViewItem item in listView2.Items)
            {
                subTotal2 += decimal.Round((decimal.Parse(item.SubItems[3].Text)), 2);
            }
            txtSubTotal1.Text = Convert.ToString(subTotal2);
            // txtTotal.Text = (decimal.Round(Convert.ToDecimal(txtSubTotal.Text), 2) + decimal.Round(Convert.ToDecimal(txtSubTotal1.Text), 2) + decimal.Round(Convert.ToDecimal(txtSubTotal2.Text), 2) + decimal.Round(Convert.ToDecimal(txtSubTotal4.Text), 2)).ToString();
            txtTotal.Text = (decimal.Round(Convert.ToDecimal(txtSubTotal.Text), 2) + decimal.Round(Convert.ToDecimal(txtSubTotal1.Text), 2) + decimal.Round(Convert.ToDecimal(txtSubTotal2.Text), 2) + decimal.Round(Convert.ToDecimal(txtSubTotal4.Text), 2)).ToString();


            txtPro.Clear();
            txtPrecioV.Clear();
            txtCantidad.Clear();
        }

        void limpiar()
        {
            txtCliente.Text = "";
            txtOficina.Text = "";
           // txtMaquinaria.Text = "";
            listView1.Items.Clear();
            listView2.Items.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
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
                    //cmd.Parameters.AddWithValue("@Cot_IGV", decimal.Parse(txtIGV.Text));
                    //cmd.Parameters.AddWithValue("@Cot_total", decimal.Parse(txtTotal.Text));
                    cmd.Parameters.AddWithValue("_idCliente", id);
                    //cmd.Parameters.AddWithValue("_idUsuario", );
                    MySqlDataReader dr = cmd.ExecuteReader();
                    dr.Close();
                    foreach (ListViewItem item in listView1.Items)
                    {
                        MySqlCommand cmdd = cn.CreateCommand();
                        cmdd.CommandText = "SP_DetalleCotizar";
                        cmdd.CommandType = CommandType.StoredProcedure;
                        cmdd.Parameters.AddWithValue("_idCotizacion", txtCorrelativo.Text);
                        cmdd.Parameters.AddWithValue("_idServicio", item.SubItems[0].Text);
                        cmdd.Parameters.AddWithValue("_precio", decimal.Parse(item.SubItems[3].Text));
                        cmdd.Parameters.AddWithValue("_subtotal", decimal.Parse(txtSubTotal.Text));
                        MySqlDataReader drd = cmdd.ExecuteReader();
                        drd.Close();

                        //SqlCommand cmdds = cn.CreateCommand();
                        //cmdds.CommandText = "SP_ActualizarStock";
                        //cmdds.CommandType = CommandType.StoredProcedure;
                        //cmdds.Parameters.AddWithValue("@codigo", item.SubItems[0].Text);
                        //cmdds.Parameters.AddWithValue("@stock", (int.Parse(item.SubItems[5].Text) - int.Parse(item.SubItems[3].Text)));
                        //SqlDataReader drs = cmdds.ExecuteReader();
                        //drs.Close();

                    }


                    foreach (ListViewItem item in listView2.Items)
                    {
                        MySqlCommand cmdd = cn.CreateCommand();
                        cmdd.CommandText = "SP_DetalleCotizar";
                        cmdd.CommandType = CommandType.StoredProcedure;
                        cmdd.Parameters.AddWithValue("_idCotizacion", txtCorrelativo.Text);
                        cmdd.Parameters.AddWithValue("_idServicio", item.SubItems[0].Text);
                        cmdd.Parameters.AddWithValue("_precio", decimal.Parse(item.SubItems[3].Text));
                        cmdd.Parameters.AddWithValue("_subtotal", decimal.Parse(txtSubTotal1.Text));
                        MySqlDataReader drd = cmdd.ExecuteReader();
                        drd.Close();

                    }

                    foreach (ListViewItem item in listView3.Items)
                    {
                        MySqlCommand cmdd = cn.CreateCommand();
                        cmdd.CommandText = "SP_DetalleCotizar";
                        cmdd.CommandType = CommandType.StoredProcedure;
                        cmdd.Parameters.AddWithValue("_idCotizacion", txtCorrelativo.Text);
                        cmdd.Parameters.AddWithValue("_idServicio", item.SubItems[0].Text);
                        cmdd.Parameters.AddWithValue("_precio", decimal.Parse(item.SubItems[3].Text));
                        cmdd.Parameters.AddWithValue("_subtotal", decimal.Parse(txtSubTotal2.Text));
                        MySqlDataReader drd = cmdd.ExecuteReader();
                        drd.Close();

                    }

                    foreach (ListViewItem item in listView4.Items)
                    {
                        MySqlCommand cmdd = cn.CreateCommand();
                        cmdd.CommandText = "SP_DetalleCotizar";
                        cmdd.CommandType = CommandType.StoredProcedure;
                        cmdd.Parameters.AddWithValue("_idCotizacion", txtCorrelativo.Text);
                        cmdd.Parameters.AddWithValue("_idServicio", item.SubItems[0].Text);
                        cmdd.Parameters.AddWithValue("_precio", decimal.Parse(item.SubItems[3].Text));
                        cmdd.Parameters.AddWithValue("_subtotal", decimal.Parse(txtSubTotal4.Text));
                        MySqlDataReader drd = cmdd.ExecuteReader();
                        drd.Close();

                    }

                    foreach (ListViewItem item in listView5.Items)
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

                    foreach (ListViewItem item in listView6.Items)
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

                    }

                    MessageBox.Show("Cotización Realizada", "ATIPANA");
                    limpiar();

                    txtCorrelativo.Text = objn.GenerarCodigo("tcotizacion");
                    // generarCodigo1();

                }
                catch (MySqlException ex) { MessageBox.Show( ex.Message, "ATIPANA", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmBuscarMaquinaria frmbm = new FrmBuscarMaquinaria();
            frmbm.ShowDialog();
            //txtMaquinaria.Text = descm;
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


            int rowNum = listView1.Items.Count;
            int columnNum = listView1.Items[0].SubItems.Count;
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
                //Microsoft.Office.Interop.Word.Range tableLocation2 = ObjDoc.Paragraphs.Last.Range;
                //Microsoft.Office.Interop.Word.Table newTable2 = ObjDoc.Tables.Add(tableLocation2, 1, 1);
                //Microsoft.Office.Interop.Word.Range tableLocation3 = ObjDoc.Paragraphs.Last.Range;
                //Microsoft.Office.Interop.Word.Table newTable3 = ObjDoc.Tables.Add(tableLocation3, 1, 1);
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
                //newTable.Cell(1, 3).Range.Text = "P. Unitario";
                //newTable.Cell(1, 3).Range.Bold = 2;
                //newTable.Cell(1, 4).Range.Text = "Cantidad";
                //newTable.Cell(1, 4).Range.Bold = 2;
                newTable.Cell(1, 3).Range.Text = "Sub Total";
                newTable.Cell(1, 3).Range.Bold = 2;
                newTable.Cell(1, 3).Range.Cells.Width = 70;
                newTable.Cell(1, 3).Range.Shading.BackgroundPatternColor = Word.WdColor.wdColorDarkBlue;


                newTable.Cell(rowIndex, columnIndex).Range.Bold = 2;

                

                

                foreach (ListViewItem item in listView1.Items)
                {
                    newTable.Cell(j + 1, 1).Range.Text = item.SubItems[1].Text;
                    newTable.Cell(j + 1, 1).Range.Cells.Width = 300;
                    newTable.Cell(j + 1, 2).Range.Text = item.SubItems[2].Text;
                    newTable.Cell(j + 1, 2).Range.Cells.Width = 70;
                    newTable.Cell(j + 1, 3).Range.Text = item.SubItems[3].Text;
                    newTable.Cell(j + 1, 3).Range.Cells.Width = 70;
                    newTable1.Cell(j + 2, 1).Range.Text = "SubTotal" + " " + "S/. " + txtSubTotal.Text;
                    newTable1.Cell(j + 2, 1).Range.Cells.Width = 440;
                    newTable1.Cell(j + 2, 1).Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphRight;
                    //newTable1.Cell(j + 2, 1).Range.Shading.BackgroundPatternColor = Word.WdColor.wdColorLightBlue;
                    //newTable1.Cell(j + 2, 1).Range.Borders.OutsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
                    //newTable1.Cell(j + 2, 1).Range.Borders.OutsideColor = Word.WdColor.wdColorBlack;



                    j++;
                }

                ObjDoc.Words.Last.InsertBreak(Word.WdBreakType.wdLineBreak);


            }

            ObjDoc.Words.Last.InsertBreak(Word.WdBreakType.wdLineBreak);


            int rowNumA = listView2.Items.Count;
            int columnNumA = listView2.Items[0].SubItems.Count;
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
                //Microsoft.Office.Interop.Word.Range tableLocation2 = ObjDoc.Paragraphs.Last.Range;
                //Microsoft.Office.Interop.Word.Table newTable2 = ObjDoc.Tables.Add(tableLocation2, 1, 1);
                //Microsoft.Office.Interop.Word.Range tableLocation3 = ObjDoc.Paragraphs.Last.Range;
                //Microsoft.Office.Interop.Word.Table newTable3 = ObjDoc.Tables.Add(tableLocation3, 1, 1);
                newTable2.Borders.Enable = 1;
                newTable3.Rows.Alignment = Word.WdRowAlignment.wdAlignRowLeft;
                // newTable.Columns.Width = 80;

                newTable2.Select();
                ObjWord.Selection.Tables[1].Rows.Alignment = Microsoft.Office.Interop.Word.WdRowAlignment.wdAlignRowCenter;
                ObjWord.Selection.Tables[1].Rows.Alignment = Microsoft.Office.Interop.Word.WdRowAlignment.wdAlignRowCenter;
                //ObjWord.Selection.Tables[1].Columns[2].Width = 80;// Microsoft.Office.Interop.Word.WdRowAlignment.wdAlignRowCenter;

                newTable2.Cell(jj + (j + 1) , 1).Range.Text = "GASTOS NAVIERA - MSC";
                newTable2.Cell(jj + (j + 1) , 1).Range.Bold = 2;
                newTable2.Cell(jj + (j + 1), 1).Range.Cells.Width = 300;
                newTable2.Cell(jj + (j + 1), 1).Range.Shading.BackgroundPatternColor = Word.WdColor.wdColorDarkBlue;
                newTable2.Cell(jj + (j + 1) , 2).Range.Text = "Tarifa";
                newTable2.Cell(jj + (j + 1) , 2).Range.Bold = 2;
                newTable2.Cell(jj + (j + 1), 2).Range.Cells.Width = 70;
                newTable2.Cell(jj + (j + 1), 2).Range.Shading.BackgroundPatternColor = Word.WdColor.wdColorDarkBlue;
                //newTable.Cell(1, 3).Range.Text = "P. Unitario";
                //newTable.Cell(1, 3).Range.Bold = 2;
                //newTable.Cell(1, 4).Range.Text = "Cantidad";
                //newTable.Cell(1, 4).Range.Bold = 2;
                newTable2.Cell(jj + (j + 1) , 3).Range.Text = "Sub Total";
                newTable2.Cell(jj + (j + 1) , 3).Range.Bold = 2;
                newTable2.Cell(jj + (j + 1), 3).Range.Cells.Width = 70;
                newTable2.Cell(jj + (j + 1), 3).Range.Shading.BackgroundPatternColor = Word.WdColor.wdColorDarkBlue;


                newTable2.Cell(rowIndexA, columnIndexA).Range.Bold = 2;





                foreach (ListViewItem item in listView2.Items)
                {
                    newTable2.Cell(jj +(j + 2), 1).Range.Text = item.SubItems[1].Text;
                    newTable2.Cell(jj + (j + 2), 1).Range.Cells.Width = 300;
                    newTable2.Cell(jj + (j + 2), 2).Range.Text = item.SubItems[2].Text;
                    newTable2.Cell(jj + (j + 2), 2).Range.Cells.Width = 70;
                    newTable2.Cell(jj + (j + 2), 3).Range.Text = item.SubItems[3].Text;
                    newTable2.Cell(jj + (j + 2), 3).Range.Cells.Width = 70;
                    //newTable.Cell(j + 1, 4).Range.Text = item.SubItems[3].Text;
                    //newTable.Cell(j + 1, 5).Range.Text = item.SubItems[4].Text;
                    newTable3.Cell(jj + (j + 3), 1).Range.Text = "SubTotal" + " " + "S/." + txtSubTotal1.Text;
                    newTable3.Cell(jj + (j + 3), 1).Range.Cells.Width = 440;
                    newTable3.Cell(jj + (j + 3), 1).Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphRight;
                    //newTable3.Cell(jj + (j + 3), 1).Range.Shading.BackgroundPatternColor = Word.WdColor.wdColorLightBlue;
                    //newTable3.Cell(jj + (j + 3), 1).Range.Borders.OutsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
                    //newTable3.Cell(jj + (j + 3), 1).Range.Borders.OutsideColor = Word.WdColor.wdColorBlack;


                    j++;
                }


            


        }



            int rowNumB = listView3.Items.Count;
            int columnNumB = listView3.Items[0].SubItems.Count;
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
                //Microsoft.Office.Interop.Word.Range tableLocation2 = ObjDoc.Paragraphs.Last.Range;
                //Microsoft.Office.Interop.Word.Table newTable2 = ObjDoc.Tables.Add(tableLocation2, 1, 1);
                //Microsoft.Office.Interop.Word.Range tableLocation3 = ObjDoc.Paragraphs.Last.Range;
                //Microsoft.Office.Interop.Word.Table newTable3 = ObjDoc.Tables.Add(tableLocation3, 1, 1);
                newTable4.Borders.Enable = 1;
                newTable5.Rows.Alignment = Word.WdRowAlignment.wdAlignRowLeft;
                // newTable.Columns.Width = 80;

                newTable4.Select();
                ObjWord.Selection.Tables[1].Rows.Alignment = Microsoft.Office.Interop.Word.WdRowAlignment.wdAlignRowCenter;
                ObjWord.Selection.Tables[1].Rows.Alignment = Microsoft.Office.Interop.Word.WdRowAlignment.wdAlignRowCenter;
                //ObjWord.Selection.Tables[1].Columns[2].Width = 80;// Microsoft.Office.Interop.Word.WdRowAlignment.wdAlignRowCenter;

                newTable4.Cell(jB + (jB + (j + 2)), 1).Range.Text = "GASTOS DEP. TEMPORAL - TPE / MEDLOG";
                newTable4.Cell(jB + (jB + (j + 2)), 1).Range.Bold = 2;
                newTable4.Cell(jB + (jB + (j + 2)), 1).Range.Cells.Width = 300;
                newTable4.Cell(jB + (jB + (j + 2)), 1).Range.Shading.BackgroundPatternColor = Word.WdColor.wdColorDarkBlue;
                newTable4.Cell(jB + (jB + (j + 2)), 2).Range.Text = "Tarifa";
                newTable4.Cell(jB + (jB + (j + 2)), 2).Range.Bold = 2;
                newTable4.Cell(jB + (jB + (j + 2)), 2).Range.Cells.Width = 70;
                newTable4.Cell(jB + (jB + (j + 2)), 2).Range.Shading.BackgroundPatternColor = Word.WdColor.wdColorDarkBlue;
                //newTable.Cell(1, 3).Range.Text = "P. Unitario";
                //newTable.Cell(1, 3).Range.Bold = 2;
                //newTable.Cell(1, 4).Range.Text = "Cantidad";
                //newTable.Cell(1, 4).Range.Bold = 2;
                newTable4.Cell(jB + (jB + (j + 2)), 3).Range.Text = "Sub Total";
                newTable4.Cell(jB + (jB + (j + 2)), 3).Range.Bold = 2;
                newTable4.Cell(jB + (jB + (j + 2)), 3).Range.Cells.Width = 70;
                newTable4.Cell(jB + (jB + (j + 2)), 3).Range.Shading.BackgroundPatternColor = Word.WdColor.wdColorDarkBlue;

                newTable4.Cell(rowIndex, columnIndex).Range.Bold = 2;





                foreach (ListViewItem item in listView3.Items)
                {
                    newTable4.Cell(jB + (jB + (j + 3)), 1).Range.Text = item.SubItems[1].Text;
                    newTable4.Cell(jB + (jB + (j + 3)), 1).Range.Cells.Width = 300;
                    newTable4.Cell(jB + (jB + (j + 3)), 2).Range.Text = item.SubItems[2].Text;
                    newTable4.Cell(jB + (jB + (j + 3)), 2).Range.Cells.Width = 70;
                    newTable4.Cell(jB + (jB + (j + 3)), 3).Range.Text = item.SubItems[3].Text;
                    newTable4.Cell(jB + (jB + (j + 3)), 3).Range.Cells.Width = 70;
                    //newTable.Cell(j + 1, 4).Range.Text = item.SubItems[3].Text;
                    //newTable.Cell(j + 1, 5).Range.Text = item.SubItems[4].Text;
                    newTable5.Cell(jB + (jB + (j + 4)), 1).Range.Text = "SubTotal" + " " + "S/." + txtSubTotal2.Text;
                    newTable5.Cell(jB + (jB + (j + 4)), 1).Range.Cells.Width = 440;
                    newTable5.Cell(jB + (jB + (j + 4)), 1).Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphRight;
                    //newTable5.Cell(jB + (jB + (j + 4)), 1).Range.Shading.BackgroundPatternColor = Word.WdColor.wdColorLightBlue;
                    //newTable5.Cell(jB + (jB + (j + 4)), 1).Range.Borders.OutsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
                    //newTable5.Cell(jB + (jB + (j + 4)), 1).Range.Borders.OutsideColor = Word.WdColor.wdColorBlack;

                    j++;
                }





            }


            int rowNumC = listView4.Items.Count;
            int columnNumC = listView4.Items[0].SubItems.Count;
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
                //Microsoft.Office.Interop.Word.Range tableLocation2 = ObjDoc.Paragraphs.Last.Range;
                //Microsoft.Office.Interop.Word.Table newTable2 = ObjDoc.Tables.Add(tableLocation2, 1, 1);
                //Microsoft.Office.Interop.Word.Range tableLocation3 = ObjDoc.Paragraphs.Last.Range;
                //Microsoft.Office.Interop.Word.Table newTable3 = ObjDoc.Tables.Add(tableLocation3, 1, 1);
                newTable6.Borders.Enable = 1;
                newTable7.Rows.Alignment = Word.WdRowAlignment.wdAlignRowLeft;
                // newTable.Columns.Width = 80;

                newTable6.Select();
                ObjWord.Selection.Tables[1].Rows.Alignment = Microsoft.Office.Interop.Word.WdRowAlignment.wdAlignRowCenter;
                ObjWord.Selection.Tables[1].Rows.Alignment = Microsoft.Office.Interop.Word.WdRowAlignment.wdAlignRowCenter;
                //ObjWord.Selection.Tables[1].Columns[2].Width = 80;// Microsoft.Office.Interop.Word.WdRowAlignment.wdAlignRowCenter;

                newTable6.Cell(jC + (jC +(jB + (j + 3))), 1).Range.Text = "DERECHPOS E IMPUESTOS";
                newTable6.Cell(jC + (jC + (jB + (j + 3))), 1).Range.Bold = 2;
                newTable6.Cell(jC + (jC + (jB + (j + 3))), 1).Range.Cells.Width = 300;
                newTable6.Cell(jC + (jC + (jB + (j + 3))), 1).Range.Shading.BackgroundPatternColor = Word.WdColor.wdColorDarkBlue;
                newTable6.Cell(jC + (jC + (jB + (j + 3))), 2).Range.Text = "Tarifa";
                newTable6.Cell(jC + (jC + (jB + (j + 3))), 2).Range.Bold = 2;
                newTable6.Cell(jC + (jC + (jB + (j + 3))), 2).Range.Cells.Width = 70;
                newTable6.Cell(jC + (jC + (jB + (j + 3))), 2).Range.Shading.BackgroundPatternColor = Word.WdColor.wdColorDarkBlue;
                //newTable.Cell(1, 3).Range.Text = "P. Unitario";
                //newTable.Cell(1, 3).Range.Bold = 2;
                //newTable.Cell(1, 4).Range.Text = "Cantidad";
                //newTable.Cell(1, 4).Range.Bold = 2;
                newTable6.Cell(jC + (jC + (jB + (j + 3))), 3).Range.Text = "Sub Total";
                newTable6.Cell(jC + (jC + (jB + (j + 3))), 3).Range.Bold = 2;
                newTable6.Cell(jC + (jC + (jB + (j + 3))), 3).Range.Cells.Width = 70;
                newTable6.Cell(jC + (jC + (jB + (j + 3))),3).Range.Shading.BackgroundPatternColor = Word.WdColor.wdColorDarkBlue;

                newTable6.Cell(rowIndex, columnIndex).Range.Bold = 2;





                foreach (ListViewItem item in listView4.Items)
                {
                    newTable6.Cell(jC + (jB + (jB + (j + 4))), 1).Range.Text = item.SubItems[1].Text;
                    newTable6.Cell(jC + (jB + (jB + (j + 4))), 1).Range.Cells.Width = 300;
                    newTable6.Cell(jC + (jB + (jB + (j + 4))), 2).Range.Text = item.SubItems[2].Text;
                    newTable6.Cell(jC + (jB + (jB + (j + 4))), 2).Range.Cells.Width = 70;
                    newTable6.Cell(jC + (jB + (jB + (j + 4))), 3).Range.Text = item.SubItems[3].Text;
                    newTable6.Cell(jC + (jB + (jB + (j + 4))), 3).Range.Cells.Width = 70;
                    //newTable.Cell(j + 1, 4).Range.Text = item.SubItems[3].Text;
                    //newTable.Cell(j + 1, 5).Range.Text = item.SubItems[4].Text;
                    newTable7.Cell(jC + (jB + (jB + (j + 5))), 1).Range.Text = "SubTotal" + " " + "S/." + txtSubTotal4.Text;
                    newTable7.Cell(jC + (jB + (jB + (j + 5))), 1).Range.Cells.Width = 440;
                    newTable7.Cell(jC + (jB + (jB + (j + 5))), 1).Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphRight;
                    //newTable7.Cell(jC + (jB + (jB + (j + 5))), 1).Range.Shading.BackgroundPatternColor = Word.WdColor.wdColorLightBlue;
                    //newTable7.Cell(jC + (jB + (jB + (j + 5))), 1).Range.Borders.OutsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
                    //newTable7.Cell(jC + (jB + (jB + (j + 5))), 1).Range.Borders.OutsideColor = Word.WdColor.wdColorBlack;

                    j++;
                }





            }

            ObjWord.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            generarword();
           // ExportListView(listView1, @"C:\sistema\documento.docx");


        }

        public static void ExportListView(ListView listView, string filePath)
        {
            if (listView.Items.Count == 0)
            {
                MessageBox.Show("La lista está vacía.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Crear una instancia de Word
            Word.Application wordApp = new Word.Application();

            // Crear un documento de Word
            var document = wordApp.Documents.Add();

            // Agregar una tabla al documento
            var table = document.Tables.Add(document.Range(), listView.Items.Count + 1, listView.Columns.Count);

            // Establecer los estilos de la tabla
            table.Borders.Enable = 1;
            table.AllowAutoFit = true;

            // Establecer los encabezados de columna con estilo
            for (int col = 0; col < listView.Columns.Count; col++)
            {
                table.Cell(1, col + 1).Range.Text = listView.Columns[col].Text;
                table.Cell(1, col + 1).Range.Bold = 1;
                table.Cell(1, col + 1).Range.Font.Size = 12;
            }

            // Llenar la tabla con los datos del ListView
            for (int row = 0; row < listView.Items.Count; row++)
            {
                var item = listView.Items[row];
                for (int col = 0; col < listView.Columns.Count; col++)
                {
                    table.Cell(row + 2, col + 1).Range.Text = item.SubItems[col].Text;
                    table.Cell(row + 2, col + 1).Range.Font.Size = 10;
                }
            }

            // Guardar el documento de Word
            document.SaveAs2(filePath);

            // Cerrar Word
            wordApp.Quit();

            MessageBox.Show("Datos exportados correctamente a Word.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



        private void button8_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            FrmBuscarServicio frmbm = new FrmBuscarServicio();
            frmbm.ShowDialog();
            txtPro.Text = nombpro;
            txtPrecioV.Text = precioventa;
            txtCantidad.Text = tarifa;
        }

        

        

        
        }

        }
    

