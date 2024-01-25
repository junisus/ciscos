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
    public partial class FrmStock : Form
    {
        private SqlConnection cn;
        public FrmStock()
        {
            InitializeComponent();
            //cn = FrmPrincipal.cn;
            dgvStock.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            txtDesc.Select();
            txtDesc.Focus();
        }

        private void FrmStock_Load(object sender, EventArgs e)
        {
            getProductoStock();
        }

        private void getProductoStock()
        {
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "sp_getProductoStock";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@desc", txtDesc.Text);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dta = new DataTable();
                dta.Load(dr);
                dgvStock.DataSource = dta;
                dr.Close();

                
            }
            catch (SqlException) { }
        }

        private void txtDesc_TextChanged(object sender, EventArgs e)
        {
            getProductoStock();
        }

        

        private void dgvStock_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
        {
foreach (DataGridViewRow row in dgvStock.Rows)
                if (Convert.ToInt32(row.Cells[6].Value) < Convert.ToInt32(row.Cells[7].Value))
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                }
        }
    }
}
