using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Word = Microsoft.Office.Interop.Word;

namespace SisCoS
{
    public partial class OrdenServicio : Form
    {
        public SqlConnection cn;
        public static string id, nom, ofi, idpro, nombpro, stock, precioventa, idMaquinaria, descm;
        public OrdenServicio()
        {
            InitializeComponent();
            //cn = FrmPrincipal.cn;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmBuscarTercero bt = new FrmBuscarTercero();
            bt.ShowDialog();
            txtCliente.Text = nom;
            txtOficina.Text = ofi;
        }

        private void OrdenServicio_Load(object sender, EventArgs e)
        {
            generarCodigo1();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmBuscarMaquinaria frmbm = new FrmBuscarMaquinaria();
            frmbm.ShowDialog();
            txtMaquinaria.Text = descm;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FrmBuscarServicio frmbm = new FrmBuscarServicio();
            frmbm.ShowDialog();
            txtPro.Text = nombpro;
            txtPrecioV.Text = precioventa;
        }
        decimal subTotal = 0;
        decimal sttock = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            if (txtCliente.Text == "")
            {
                MessageBox.Show("Debe Seleccionar un Cliente");
                return;



            }
            // sttock = decimal.Parse(stock);
            //foreach (ListViewItem item in listView1.Items)
            //{
            //    if (item.SubItems[0].Text == idpro)
            //        sttock -= int.Parse(item.SubItems[3].Text);
            //}
            //if (int.Parse(txtCantidad.Text) > sttock)
            //{
            //    MessageBox.Show("La Cantidad debe ser menor o igual al Stock");
            //    txtCantidad.Text = sttock.ToString();
            //    return;
            //}
            subTotal += Math.Ceiling(decimal.Parse(txtPrecioV.Text) * decimal.Parse(txtCantidad.Text));
            txtTotal.Text = subTotal.ToString();
            txtIGV.Text = Convert.ToString(subTotal * 18 / 100);
            txtSubTotal.Text = Convert.ToString(subTotal - decimal.Parse(txtIGV.Text));
            foreach (ListViewItem item in listView1.Items)
            {
                if (idpro == item.SubItems[0].Text)
                {
                    item.SubItems[3].Text = (int.Parse(txtCantidad.Text) + int.Parse(item.SubItems[3].Text)).ToString();
                    item.SubItems[4].Text = (decimal.Parse(item.SubItems[3].Text) * decimal.Parse(item.SubItems[2].Text)).ToString();
                    return;
                }
            }
            ListViewItem items = listView1.Items.Add(idpro);
            items.SubItems.Add(txtPro.Text);
            items.SubItems.Add(txtPrecioV.Text);
            items.SubItems.Add(txtCantidad.Text);
            items.SubItems.Add((decimal.Parse(txtCantidad.Text) * decimal.Parse(txtPrecioV.Text)).ToString());
            items.SubItems.Add(sttock.ToString());

            txtPro.Clear();
            txtPrecioV.Clear();
            txtCantidad.Clear();
        }

        void generarCodigo1()
        {

            DataSet ds = generarCodigoS();
            DataTable dt = ds.Tables[0];
            DataRow dr = dt.Rows[0];
            String codigo = dr["Codigo"].ToString();
            txtCorrelativo.Text = codigo;
        }

        public DataSet generarCodigoS()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            da = new SqlDataAdapter("SP_GenerarCodigoS", cn);
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
           // decimal subTotal = 0;
            if (listView1.SelectedItems.Count > 0)
            {
                listView1.Items.Remove(listView1.SelectedItems[0]);
                foreach (ListViewItem item in listView1.Items)
                {
                    subTotal += (decimal.Parse(item.SubItems[2].Text) * decimal.Parse(item.SubItems[3].Text));
                }
                txtSubTotal.Text = subTotal.ToString();
                txtIGV.Text = Convert.ToString(subTotal * 18 / 100);
                txtTotal.Text = Convert.ToString(subTotal + decimal.Parse(txtIGV.Text));

            }

            else
                MessageBox.Show("Seleccione una Fila");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea Registrar los Datos Ingresados", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    SqlCommand cmd = cn.CreateCommand();

                    cmd.CommandText = "sp_OrdenServicio";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idOrdenServicio", txtCorrelativo.Text);
                    cmd.Parameters.AddWithValue("@Cot_fecha", dtpFecha.Value);
                    cmd.Parameters.AddWithValue("@Cot_hora", DtpHora.Value);
                    cmd.Parameters.AddWithValue("@Cot_subtotal", decimal.Parse(txtSubTotal.Text));
                    cmd.Parameters.AddWithValue("@Cot_IGV", decimal.Parse(txtIGV.Text));
                    cmd.Parameters.AddWithValue("@Cot_total", decimal.Parse(txtTotal.Text));
                    cmd.Parameters.AddWithValue("@idCliente", id);
                    cmd.Parameters.AddWithValue("@idMaquinaria", idMaquinaria);
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Close();
                    foreach (ListViewItem item in listView1.Items)
                    {
                        SqlCommand cmdd = cn.CreateCommand();
                        cmdd.CommandText = "SP_DetalleOrdenServicio";
                        cmdd.CommandType = CommandType.StoredProcedure;
                        cmdd.Parameters.AddWithValue("@idOrdenServicio", txtCorrelativo.Text);
                        cmdd.Parameters.AddWithValue("@idServicio", item.SubItems[0].Text);
                        cmdd.Parameters.AddWithValue("@precio", decimal.Parse(item.SubItems[2].Text));
                        cmdd.Parameters.AddWithValue("@cantidad", decimal.Parse(item.SubItems[3].Text));
                        cmdd.Parameters.AddWithValue("@subtotal", decimal.Parse(item.SubItems[4].Text));
                        SqlDataReader drd = cmdd.ExecuteReader();
                        drd.Close();

                        //SqlCommand cmdds = cn.CreateCommand();
                        //cmdds.CommandText = "SP_ActualizarStock";
                        //cmdds.CommandType = CommandType.StoredProcedure;
                        //cmdds.Parameters.AddWithValue("@codigo", item.SubItems[0].Text);
                        //cmdds.Parameters.AddWithValue("@stock", (int.Parse(item.SubItems[5].Text) - int.Parse(item.SubItems[3].Text)));
                        //SqlDataReader drs = cmdds.ExecuteReader();
                        //drs.Close();

                    }

                    MessageBox.Show("Orde de Servicio N°"+txtCorrelativo.Text+", Realizada");
                    limpiar();
                    generarCodigo1();

                }
                catch (SqlException ex) { MessageBox.Show(ex.Message, "Sistema Pagos", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            }

        }

        void limpiar()
        {
            txtCliente.Text = "";
            txtOficina.Text = "";
            txtMaquinaria.Text = "";
            listView1.Items.Clear();
        }

    }
}
