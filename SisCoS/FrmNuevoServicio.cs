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
    public partial class FrmNuevoServicio : Form
    {
        MySqlConnection cn;
        public FrmNuevoServicio()
        {
            InitializeComponent();
            cn = FrmPrincipal.cn;
            txtDesc.Select();
            txtDesc.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void limpiarControls()
        {
            txtDesc.Text = "";
            textBoxX1.Text = "";
            
            txtDesc.Select();
            txtDesc.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtDesc.Text != "")
            {
                try
                {

                    MySqlCommand cmd = cn.CreateCommand();
                    cmd.CommandText = "sp_guardarServicio";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_descr", MySqlDbType.VarChar, 50).Value = txtDesc.Text;
                    cmd.Parameters.Add("_idtarifa", MySqlDbType.Int16).Value = cmbMed.SelectedValue.ToString();
                    cmd.Parameters.Add("_idTipo", MySqlDbType.Int16).Value = cmbTipo.SelectedValue.ToString();

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
                    MessageBox.Show("Servicio Registrado","ATIPANA");
                    limpiarControls();
                }
                catch (MySqlException ex) { MessageBox.Show(ex.Message, "ATIPANA", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else
            {
                MessageBox.Show("Los campos con * son obligatorios", "ATIPANA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FrmNuevoServicio_Load(object sender, EventArgs e)
        {
            cargarTarifa();
            cargarTipo();
        }

        private void cargarTarifa()
        {
            try
            {

                MySqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "sp_CmbTarifa";
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlDataReader dr = cmd.ExecuteReader();
                DataTable dta = new DataTable();
                dta.Load(dr);
                cmbMed.DataSource = dta;
                cmbMed.DisplayMember = "Descripcion";
                cmbMed.ValueMember = "id";

            }
            catch (MySqlException ex) { MessageBox.Show(ex.Message, "ATIPANA", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void cargarTipo()
        {
            try
            {

                MySqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "sp_CmbTipo";
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlDataReader dr = cmd.ExecuteReader();
                DataTable dta = new DataTable();
                dta.Load(dr);
                cmbTipo.DataSource = dta;
                cmbTipo.DisplayMember = "Descripcion";
                cmbTipo.ValueMember = "id";

            }
            catch (MySqlException ex) { MessageBox.Show(ex.Message, "ATIPANA", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
