using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SisCoS
{
    public partial class FrmContrato : Form
    {
        public SqlConnection cn;
        public static string id, nom, ofi, idpro, nombpro, stock, precioventa, idMaquinaria, descm;
        public FrmContrato()
        {
            InitializeComponent();
            //cn = FrmPrincipal.cn;
        }

        private void FrmContrato_Load(object sender, EventArgs e)
        {
            generarCodigo1();
        }

        public DataSet generarCodigo()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            da = new SqlDataAdapter("SP_GenerarCodigoCon", cn);
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

        void generarCodigo1()
        {

            DataSet ds = generarCodigo();
            DataTable dt = ds.Tables[0];
            DataRow dr = dt.Rows[0];
            String codigo = dr["Codigo"].ToString();
            txtCorrelativo.Text = codigo;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmBuscarCotizacion frmco = new FrmBuscarCotizacion();
            frmco.ShowDialog();
            txtIDC.Text = id;
            txtCliente.Text = nom;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtIDC.Text == "")
            {
                MessageBox.Show("Debe Seleccionar una Cotización");
            }

                if (MessageBox.Show("Desea Registrar los Datos Ingresados", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        SqlCommand cmd = cn.CreateCommand();

                        cmd.CommandText = "SP_Contrato";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idContrato", txtCorrelativo.Text);
                        cmd.Parameters.AddWithValue("@idCotizacion", txtIDC.Text);
                        cmd.Parameters.AddWithValue("@Con_fecha", dtpFecha.Value);
                        cmd.Parameters.AddWithValue("@Con_hora", DtpHora.Value);
                        cmd.Parameters.AddWithValue("@Con_inicio", dtpInicio.Value);
                        cmd.Parameters.AddWithValue("@Con_fin", dtpFin.Value);
                        cmd.Parameters.AddWithValue("@Con_detalle", txtObservación.Text);
                        SqlDataReader dr = cmd.ExecuteReader();
                        dr.Close();


                        MessageBox.Show("Contrato Realizado");
                    }
                    catch (SqlException ex) {  }


                }
            }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        }

        
    }
