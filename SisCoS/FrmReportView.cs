using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace SisCoS
{
    public partial class FrmReportView : Form
    {
        public static List<ReporteCotizacion> reporte = new List<ReporteCotizacion>();
        public static List<Producto> producto = new List<Producto>();
        public static List<Concepto> concepto = new List<Concepto>();
        public static List<GastosNaviera> naviera = new List<GastosNaviera>();
        public static List<DepositoTemporal> depTemp = new List<DepositoTemporal>();
        public static List<AlmacenDPW> almacen = new List<AlmacenDPW>();
        public static List<DerechosImpuestos> derechos = new List<DerechosImpuestos>();

        public FrmReportView()
        {
            InitializeComponent();
            
            ReportDocument reportDocument = new ReportDocument();
            ReportDocument reportDocument2 = new ReportDocument();
            ReportDocument reportDocument3 = new ReportDocument();
            ReportDocument reportDocument4 = new ReportDocument();
            ReportDocument reportDocument5 = new ReportDocument();
            ReportDocument reportDocument6 = new ReportDocument();
            ReportDocument reportDocument7 = new ReportDocument();

            reportDocument.Load("C:/Users/valle/source/repos/SisCoS/SisCoS/CrystalReport1.rpt");
            reportDocument2.Load("C:/Users/valle/source/repos/SisCoS/SisCoS/CrystalReport2.rpt");
            reportDocument3.Load("C:/Users/valle/source/repos/SisCoS/SisCoS/CrystalReport3.rpt");
            reportDocument4.Load("C:/Users/valle/source/repos/SisCoS/SisCoS/CrystalReport4.rpt");
            reportDocument5.Load("C:/Users/valle/source/repos/SisCoS/SisCoS/CrystalReport5.rpt");
            reportDocument6.Load("C:/Users/valle/source/repos/SisCoS/SisCoS/CrystalReport6.rpt");
            reportDocument7.Load("C:/Users/valle/source/repos/SisCoS/SisCoS/CrystalReport7.rpt");

            reportDocument.DataSourceConnections.Clear();
            reportDocument2.DataSourceConnections.Clear();
            reportDocument3.DataSourceConnections.Clear();
            reportDocument4.DataSourceConnections.Clear();
            reportDocument5.DataSourceConnections.Clear();
            reportDocument6.DataSourceConnections.Clear();
            reportDocument7.DataSourceConnections.Clear();
            
            reportDocument.Subreports["CrystalReport2.rpt"].SetDataSource(concepto); // Donde ds3 es el DataSet para tu subinforme
            reportDocument.SetDataSource(reporte);
            reportDocument.Subreports["CrystalReport3.rpt"].SetDataSource(naviera); // Donde ds3 es el DataSet para tu subinforme
            reportDocument.Subreports["CrystalReport4.rpt"].SetDataSource(depTemp); // Donde ds3 es el DataSet para tu subinforme
            reportDocument.Subreports["CrystalReport5.rpt"].SetDataSource(almacen); // Donde ds3 es el DataSet para tu subinforme
            reportDocument.Subreports["CrystalReport6.rpt"].SetDataSource(derechos); // Donde ds3 es el DataSet para tu subinforme
            reportDocument.SetDataSource(reporte);
            reportDocument.Subreports["CrystalReport7.rpt"].SetDataSource(producto); // Donde ds3 es el DataSet para tu subinforme

            reportDocument.Refresh();

            crystalReportViewer1.ReportSource = reportDocument;
        }
    }
}
