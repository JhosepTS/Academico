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
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnEstudiante_Click(object sender, EventArgs e)
        {
            Form1 formularioEstudiantes = new Form1();
            formularioEstudiantes.StartPosition = FormStartPosition.CenterScreen;
            formularioEstudiantes.Show();
        }

        private void btnDocente_Click(object sender, EventArgs e)
        {
            FormDocentes formularioDocentes = new FormDocentes();
            formularioDocentes.StartPosition = FormStartPosition.CenterScreen;
            formularioDocentes.Show();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {

        }
    }
}
