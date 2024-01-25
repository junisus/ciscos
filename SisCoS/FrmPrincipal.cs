using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace SisCoS
{
    public partial class FrmPrincipal : Form
    {
        FrmNuevoUsuario frmnu;
        FrmMantenimientoUsuario frmmu;
        FrmCliente frmc;
        FrmMantCliente frmmc;
        FrmNuevaMedida frmnm;
        FrmMantMedida frmmm;
        FrmCateg frmca;
        FrmMantCat frmmct;
        FrmNuevoServicio frns;
        MantenimientoServicio mnts;   
        FrmMaquinaria frmaq;
        FrmTipo frmt;
        FrmMantMaquinaria frmmmaq;
        FrmNuevaProcedencia frmnpro;
        FrmProcedencia frmpro;
        FrmCotizacion frmco;
        FrmContrato frmcon;
        FrmReporteCotizacion frmrcot;
        FrmStock fs;
        FrmReprteContratos frmcs;
        FrmNuevoTipo frmnms;
        FrmInfoTipo frmtt;
        FrmNuevoGasto frmng;
        FrmMantGasto frmmgg;
        //FrmCotizacion frmcot;
        FrmCotizacion2 frmcot;
        FrmProductos frmprod;
        FrmMantProductos frmmantp;
        FrmAsistenciaP frmasis;
        FrmControlAsistencia frmasisC;

        public string usuario;
        public static MySqlConnection cn;

        public FrmPrincipal(string usuario)
        {
            InitializeComponent();
            cn = Form2.cn;
            this.usuario = usuario;
            getDatos();
        }

        private void getDatos()
        {
            IPHostEntry host;
            string localIP = "";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    localIP = ip.ToString();
                }
            }
            String machineName = Environment.MachineName;
            lblIP.Text = localIP + "    ";
            lblPC.Text = machineName + "    ";
            lblUsuario.Text = usuario + "    ";
        }

        private void FrmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            cn.Close();
            this.Dispose();
            Application.Exit();
        }

        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Desea salir de la aplicación?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                cn.Close();
                this.Dispose();
                Application.Exit();
            }
            else
                e.Cancel = true;
        }


        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void nuevoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
        }

        private void detalleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void nuevaMedidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmnm = new FrmNuevaMedida();
            frmnm.MdiParent = this;
            frmnm.Show();
        }

        private void verMedidasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmmm = new FrmMantMedida();
            frmmm.MdiParent = this;
            frmmm.Show();
        }

        private void nuevaCategoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmca = new FrmCateg();
            frmca.MdiParent = this;
            frmca.Show();
        }

        private void verCategoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmmct = new FrmMantCat();
            frmmct.MdiParent = this;
            frmmct.Show();
        }

        private void nuevaProcedenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmnpro = new FrmNuevaProcedencia();
            frmnpro.MdiParent = this;
            frmnpro.Show();
        }

        private void verProcedenciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmpro = new FrmProcedencia();
            frmpro.MdiParent = this;
            frmpro.Show();
        }

        private void nuevoProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frns = new FrmNuevoServicio();
            frns.MdiParent = this;
            frns.Show();
        }

        private void verProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mnts = new MantenimientoServicio();
            mnts.MdiParent = this;
            mnts.Show();
        }

        private void parametrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmt = new FrmTipo();
            frmt.MdiParent = this;
            frmt.Show();
        }

        private void maquinariaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmaq = new FrmMaquinaria();
            frmaq.MdiParent = this;
            frmaq.Show();
        }

        private void verMaquinariasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmmmaq = new FrmMantMaquinaria();
            frmmmaq.MdiParent = this;
            frmmmaq.Show();
        }

        private void cotizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmco = new FrmCotizacion();
            frmco.MdiParent = this;
            frmco.Show();
        }

        private void contratoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmcon = new FrmContrato();
            frmcon.MdiParent = this;
            frmcon.Show();
        }

        private void verCotizacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmrcot = new FrmReporteCotizacion();
            frmrcot.MdiParent = this;
            frmrcot.Show();
        }

        private void verStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fs = new FrmStock();
            fs.MdiParent = this;
            fs.Show();
        }

        private void verContratosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmcs = new FrmReprteContratos();
            frmcs.MdiParent = this;
            frmcs.Show();
        }

        private void crearBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBackup frmbp = new FrmBackup();
            frmbp.MdiParent = this;
            frmbp.Show();
        }

        private void salidasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmSalidas frmsa = new FrmSalidas();
            frmsa.MdiParent = this;
            frmsa.Show();
        }

        private void lblUsuario_Click(object sender, EventArgs e)
        {

        }

        private void nuevaOrdenDeServicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrdenServicio os = new OrdenServicio();
            os.MdiParent = this;
            os.Show();
        }

        private void ribbonTabItem1_Click(object sender, EventArgs e)
        {

        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            frmmu = new FrmMantenimientoUsuario();
            frmmu.MdiParent = this;
            frmmu.Show();
        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            frmnu = new FrmNuevoUsuario();
            frmnu.MdiParent = this;
            frmnu.Show();
        }

        private void buttonItem4_Click(object sender, EventArgs e)
        {
            frmmc = new FrmMantCliente();
            frmmc.MdiParent = this;
            frmmc.Show();
        }

        private void buttonItem5_Click(object sender, EventArgs e)
        {
            frmc = new FrmCliente();
            frmc.MdiParent = this;
            frmc.Show();
        }

        private void buttonItem7_Click(object sender, EventArgs e)
        {
            frns = new FrmNuevoServicio();
            frns.MdiParent = this;
            frns.Show();
        }

        private void buttonItem6_Click(object sender, EventArgs e)
        {
            mnts = new MantenimientoServicio();
            mnts.MdiParent = this;
            mnts.Show();
        }

        private void buttonItem8_Click(object sender, EventArgs e)
        {
            frmnm = new FrmNuevaMedida();
            frmnm.MdiParent = this;
            frmnm.Show();
        }

        private void buttonItem9_Click(object sender, EventArgs e)
        {
            frmmm = new FrmMantMedida();
            frmmm.MdiParent = this;
            frmmm.Show();
        }

        private void buttonItem11_Click(object sender, EventArgs e)
        {
            frmnms = new FrmNuevoTipo();
            frmnms.MdiParent = this;
            frmnms.Show();
        }

        private void buttonItem10_Click(object sender, EventArgs e)
        {
            frmtt = new FrmInfoTipo();
            frmtt.MdiParent = this;
            frmtt.Show();
        }

        private void buttonItem12_Click(object sender, EventArgs e)
        {
            frmng = new FrmNuevoGasto();
            frmng.MdiParent = this;
            frmng.Show();
        }

        private void buttonItem13_Click(object sender, EventArgs e)
        {
            frmmgg = new FrmMantGasto();
            frmmgg.MdiParent = this;
            frmmgg.Show();
        }

        private void buttonItem14_Click(object sender, EventArgs e)
        {
            //frmcot = new FrmCotizacion();
            frmcot = new FrmCotizacion2();

            frmcot.MdiParent = this;
            frmcot.Show();


        }

        private void buttonItem15_Click(object sender, EventArgs e)
        {
            frmprod = new FrmProductos();
            frmprod.MdiParent = this;
            frmprod.Show();
        }

        private void buttonItem16_Click(object sender, EventArgs e)
        {
            frmmantp = new FrmMantProductos();
            frmmantp.MdiParent = this;
            frmmantp.Show();
        }

        private void buttonItem7_Click_1(object sender, EventArgs e)
        {
            frmasis = new FrmAsistenciaP();
            frmasis.MdiParent = this;
            frmasis.Show();
        }

        private void buttonItem8_Click_1(object sender, EventArgs e)
        {
            frmasisC = new FrmControlAsistencia();
            frmasisC.MdiParent = this;
            frmasisC.Show();
        }
    }
}
