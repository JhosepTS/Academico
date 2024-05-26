using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Academico.Presentacion
{
    public partial class Reportes : Form
    {
        public Reportes()
        {
            InitializeComponent();
        }

        private void Reportes_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }

        public void CargarReporte(DataTable dataTable)
        {
            reportViewer1.LocalReport.ReportPath = "Reportes/InformeEstudiantes.rdlc";

            ReportDataSource dataSource = new ReportDataSource("DataSetEstudiantes", dataTable);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(dataSource);

            reportViewer1.RefreshReport();
        }
    }
}
