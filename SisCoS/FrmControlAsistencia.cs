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
using System.Collections;
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;

namespace SisCoS
{
    public partial class FrmControlAsistencia : Form
    {
        private MySqlConnection cn;
        public FrmControlAsistencia()
        {
            InitializeComponent();
            cn = FrmPrincipal.cn;
            dgvDirectorioC.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            getDirectorio();
            txtCliente.Select();
            txtCliente.Focus();
        }

        private void FrmControlAsistencia_Load(object sender, EventArgs e)
        {

        }

        private void getDirectorio()
        {

            try
            {
                MySqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "mostrar_turnos_con_correlativo";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("_descripcion", txtCliente.Text);
                MySqlDataReader dr = cmd.ExecuteReader();
                DataTable dta = new DataTable();
                dta.Load(dr);
                dgvDirectorioC.DataSource = dta;
                dr.Close();
            }
            catch (MySqlException) { }
        }
        private void limpiar()
        {

            txtCliente.Text = "";


        }

        private void getDirectorioA()
        {

            try
            {
                MySqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "mostrar_turnos_con_correlativoA";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("_descripcion", txtCliente.Text);
                cmd.Parameters.AddWithValue("_fecha_inicio", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("_fecha_fin", dateTimePicker2.Value);
                MySqlDataReader dr = cmd.ExecuteReader();
                DataTable dta = new DataTable();
                dta.Load(dr);
                dgvDirectorioC.DataSource = dta;
                dr.Close();
            }
            catch (MySqlException) { }
        }

        private void txtCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            getDirectorio();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value < dateTimePicker2.Value)
            {
                getDirectorioA();
            }
            else
            {
                MessageBox.Show("La Fecha de Inicio debe ser menor que la Fecha de Fin", "ATIPANA");
            }
        }
    }
}
