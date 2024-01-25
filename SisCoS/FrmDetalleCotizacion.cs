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
using MySql.Data.MySqlClient;

namespace SisCoS
{
    public partial class FrmDetalleCotizacion : Form
    {
        private MySqlConnection cn;

        public string idCotizacion;

        public FrmDetalleCotizacion()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Normal;
            this.Height = 520;
            this.Width = 800;
            cn = FrmPrincipal.cn;
            dgvDirectorio.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
           
           
        }

        private void dgvDirectorio_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void bt_ver_reporte_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand("GetIdCompl", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idCotizacionParcial", tb_codigo.Text);

            if (cn.State != ConnectionState.Open)
            {
                cn.Open();
            }

            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                idCotizacion = dr["idCotizacion"].ToString();
            }
            cn.Close();

            Concepto concepto = new Concepto();
            List<Concepto> conceptos = concepto.GetConcepto(idCotizacion);

            foreach (Concepto c in conceptos)
            {
                FrmReportView.concepto.Add(c);
            }

            GastosNaviera naviera = new GastosNaviera();
            List<GastosNaviera> navieras = naviera.GetNaviera(idCotizacion);

            foreach (GastosNaviera c in navieras)
            {
                FrmReportView.naviera.Add(c);
            }

            DepositoTemporal dep = new DepositoTemporal();
            List<DepositoTemporal> deps = dep.GetDepositoTemporal(idCotizacion);

            foreach (DepositoTemporal c in deps)
            {
                FrmReportView.depTemp.Add(c);
            }

            AlmacenDPW almacen = new AlmacenDPW();
            List<AlmacenDPW> almacenes = almacen.GetAlmacenDPW(idCotizacion);

            foreach (AlmacenDPW c in almacenes)
            {
                FrmReportView.almacen.Add(c);
            }

            DerechosImpuestos derecho = new DerechosImpuestos();
            List<DerechosImpuestos> derechos = derecho.GetDerechos(idCotizacion);

            foreach (DerechosImpuestos c in derechos)
            {
                FrmReportView.derechos.Add(c);
            }

            Producto producto = new Producto();
            List<Producto> productos = producto.GetProducto(idCotizacion);

            foreach (Producto c in productos)
            {
                FrmReportView.producto.Add(c);
            }

            ReporteCotizacion reporte = new ReporteCotizacion();
            List<ReporteCotizacion> reportes = reporte.GetReporte(idCotizacion);

            foreach (ReporteCotizacion c in reportes)
            {
                FrmReportView.reporte.Add(c);
            }


            FrmReportView rep = new FrmReportView();
            rep.Show();
        }

        private void tb_codigo_TextChanged(object sender, EventArgs e)
        {
            getDetalleCotizar();
        }

        private void getDetalleCotizar()
        {
            try
            {
                MySqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "SP_BuscarCotizacionPorId";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("idCotizacionParcial", tb_codigo.Text);
                MySqlDataReader dr = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(dr);
                dgvDirectorio.DataSource = dt;

                dr.Close();
            }
            catch (SqlException) { }
        }

        private void FrmDetalleCotizacion_Load(object sender, EventArgs e)
        {
            getDetalleCotizar();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {

        }
    }
}
