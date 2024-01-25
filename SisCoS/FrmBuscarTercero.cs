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

namespace SisCoS
{
    public partial class FrmBuscarTercero : Form
    {
        private SqlConnection cn;
        public string id, nom, ofi;
        public OrdenServicio frmc = new OrdenServicio();
        public FrmBuscarTercero()
        {
            InitializeComponent();
            //cn = FrmPrincipal.cn;
        }

        private void FrmBuscarTercero_Load(object sender, EventArgs e)
        {
            getCliente();
        }

        private void getCliente()
        {

            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "sp_BuscarTercero";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCliente", txtCliente.Text);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dta = new DataTable();
                dta.Load(dr);
                dgvDirectorioC.DataSource = dta;
                dr.Close();
            }
            catch (SqlException) { }
        }

        private void txtCliente_TextChanged(object sender, EventArgs e)
        {
            getCliente();
        }

        private void dgvDirectorioC_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            OrdenServicio.id = dgvDirectorioC.Rows[e.RowIndex].Cells[0].Value.ToString();
            OrdenServicio.nom = dgvDirectorioC.Rows[e.RowIndex].Cells[1].Value.ToString();

            OrdenServicio.ofi = dgvDirectorioC.Rows[e.RowIndex].Cells[2].Value.ToString();



            this.Dispose();
            this.Close();
        }
    }
}
