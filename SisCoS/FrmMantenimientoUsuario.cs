using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
//using System.Data.SqlClient;
using System.Threading;

namespace SisCoS
{
    public partial class FrmMantenimientoUsuario : Form
    {
        private MySqlConnection cn;
        private string id, nom, user, pass;
        public FrmMantenimientoUsuario()
        {
            InitializeComponent();
            cn = FrmPrincipal.cn;
            dgvDirectorio.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
            
        }

        private void FrmMantenimientoUsuario_Load(object sender, EventArgs e)
        {
            getDirectorio();
        }

        private void getDirectorio()
        {
            try
            {
                MySqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "sp_getusuarios";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("_usuario", txtUsuario.Text);
                MySqlDataReader dr = cmd.ExecuteReader();
                DataTable dta = new DataTable();
                dta.Load(dr);
                dgvDirectorio.DataSource = dta;
                dr.Close();
            }
            catch (MySqlException) { }
        }

        private void txtUsuario_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

       
        private void dgvDirectorio_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = dgvDirectorio.Rows[e.RowIndex].Cells["clmIdUsuario"].Value.ToString();
            txtid.Text = id;
            
            user = dgvDirectorio.Rows[e.RowIndex].Cells["clmUsuario"].Value.ToString();
            txtUsuarios.Text = user;

            pass = dgvDirectorio.Rows[e.RowIndex].Cells["clmPass"].Value.ToString();
            txtPass.Text = pass;

            nom = dgvDirectorio.Rows[e.RowIndex].Cells["clmNombre"].Value.ToString();
            txtNombre.Text = nom;
        }

       

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (txtUsuarios.Text != "" && txtPass.Text != "" && txtNombre.Text != "")
            {

                if (MessageBox.Show("Desea Modificar los Datos Ingresados", "SisCoS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {

                        MySqlCommand cmd = cn.CreateCommand();
                        cmd.CommandText = "sp_modificarUsuario";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("_id", MySqlDbType.VarChar, 5).Value = txtid.Text;
                        cmd.Parameters.Add("_usuario", MySqlDbType.VarChar, 20).Value = txtUsuarios.Text;
                        cmd.Parameters.Add("_pass", MySqlDbType.VarChar, 20).Value = txtPass.Text;
                        cmd.Parameters.Add("_nombre", MySqlDbType.VarChar, 150).Value = txtNombre.Text;
                        MySqlDataReader dr = cmd.ExecuteReader();
                        dr.Close();
                        MessageBox.Show("Datos del usuario Actualizados", "ATIPANA");
                        getDirectorio();
                        txtid.Text = "";
                        txtUsuarios.Text = "";
                        txtNombre.Text = "";
                        txtPass.Text = "";




                    }


                    catch (MySqlException ex) { MessageBox.Show(ex.Message, "SisCoS", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            getDirectorio();
        }

        private void dgvDirectorio_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("Desea Eliminar el usuario", "ATIPANA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {

                    MySqlCommand cmd = cn.CreateCommand();
                    cmd.CommandText = "sp_modificarUsuarioEstado";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_id", MySqlDbType.VarChar, 5).Value = txtid.Text;
                    MySqlDataReader dr = cmd.ExecuteReader();
                    dr.Close();
                    MessageBox.Show("Datos del usuario ha sida dado de baja", "ATIPANA");
                    getDirectorio();
                    txtid.Text = "";
                    txtUsuarios.Text = "";
                    txtNombre.Text = "";
                    txtPass.Text = "";




                }


                catch (MySqlException ex) { MessageBox.Show(ex.Message, "SisCoS", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloLetras(e);
            //if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            //{
            //    MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    e.Handled = true;
            //    return;
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();

        }
    }
}
