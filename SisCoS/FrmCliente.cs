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

namespace SisCoS
{
    public partial class FrmCliente : Form
    {
        ApisPeru ApisPeru = new ApisPeru();
        private MySqlConnection cn;

        public FrmCliente()
        {
            InitializeComponent();
            cn = FrmPrincipal.cn;
        }




        private void limpiarControls()
        {
            txtRUC.Text = "";
            txtNombre.Text = "";
            txtOficina.Text = "";
            txtDireccion.Text = "";
            txttelefono.Text = "";
            txtmail.Text = "";
            txtNombre.Select();
            txtNombre.Focus();
        }

        private void txtRUC_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloNumeros(e);
        }

        private void txttelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloNumeros(e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "" && txtRUC.Text != "" && txtDireccion.Text != "")
            {
                try
                {

                    MySqlCommand cmd = cn.CreateCommand();
                    cmd.CommandText = "sp_guardarCliente";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_nombre", MySqlDbType.VarChar, 80).Value = txtNombre.Text;
                    cmd.Parameters.Add("_oficina", MySqlDbType.VarChar, 80).Value = txtOficina.Text;
                    cmd.Parameters.Add("_direccion", MySqlDbType.VarChar, 100).Value = txtDireccion.Text;
                    cmd.Parameters.Add("_telefono", MySqlDbType.VarChar, 50).Value = txttelefono.Text;
                    cmd.Parameters.Add("_RUC", MySqlDbType.VarChar, 11).Value = txtRUC.Text;
                    cmd.Parameters.Add("_mail", MySqlDbType.VarChar, 50).Value = txtmail.Text;

                    MySqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        if (dr.GetString(1).ToString().CompareTo("exito") == 0)
                        {
                            MessageBox.Show(dr.GetString(0), "ATIPANA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            limpiarControls();
                        }
                        else
                        {
                            MessageBox.Show(dr.GetString(0), "ATIPANA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    dr.Close();
                    MessageBox.Show("Cliente registrado");
                    limpiarControls();
                }
                catch (MySqlException ex) { MessageBox.Show(ex.Message, "ATIPANA", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else
            {
                MessageBox.Show("Los campos con * son obligatorios", "ATIPANA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            consultarCliente();
        }
        private void consultarCliente()
        {
            try
            {
                if (txtRUC.Text.Length == 11)
                {
                    dynamic respuesta = ApisPeru.Get("https://dniruc.apisperu.com/api/v1/ruc/" + txtRUC.Text + "?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJlbWFpbCI6ImxtdGltYW5hZ0BnbWFpbC5jb20ifQ.udFejq_ZQw4kqP6wfRGX1RaKaksh-lFwcqlM7p9Y1dU");
                    txtNombre.Text = respuesta.razonSocial.ToString();
                    txtDireccion.Text = respuesta.direccion.ToString();
                }
                else if (txtRUC.Text.Length == 8)
                {
                    dynamic respuesta = ApisPeru.Get("https://dniruc.apisperu.com/api/v1/dni/" + txtRUC.Text + "?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJlbWFpbCI6ImxtdGltYW5hZ0BnbWFpbC5jb20ifQ.udFejq_ZQw4kqP6wfRGX1RaKaksh-lFwcqlM7p9Y1dU");
                    txtNombre.Text = respuesta.nombres.ToString() + " " + respuesta.apellidoPaterno.ToString() + " " + respuesta.apellidoMaterno.ToString();
                }

                else
                {
                    MessageBox.Show("Ingrese un número de documento válido.", "ATIPANA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception)
            {

                MessageBox.Show("Ingrese un número de documento válido.", "ATIPANA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
