using Academico.Entidades;
using Academico.Negocio;
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
    public partial class FormDocentes : Form
    {
        public FormDocentes()
        {
            InitializeComponent();
        }
        DocenteNegocio objNegocio = new DocenteNegocio();
        Docente objDocente = new Docente();


        private void FrmDocente_Load(object sender, EventArgs e)
        {
            DateTime fechaHoraActual = DateTime.Now;

            string fechaHoraFormateada = fechaHoraActual.ToString("dd-MM-yyyy h:mm tt");

            txtFechayHora.Text = fechaHoraFormateada;
        }

        bool Validar(string p1, string p2, string p3, string p4, string p5, string p6)
        {
            if (p1.Length == 0 || p2.Length == 0 || p3.Length == 0 || p4.Length == 0 || p5.Length == 0 || p6.Length == 0)
                return false;
            else
                return true;
        }

        void Limpiar(Control control)
        {
            foreach (Control c in control.Controls)
            {
                
                if (c is TextBox)
                {
                    TextBox textBox = (TextBox)c;
                    textBox.Text = "";
                }
                else if (c is CheckBox checkBox)
                {
                    checkBox.Checked = false;
                }
               
                else if (c.HasChildren)
                {
                    Limpiar(c);
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (Validar(txtNum_Doc.Text, txtNombre.Text, txtApellidos.Text, txtEmail.Text, txtTelefono.Text, txtFechayHora.Text) == true)
            {
                objDocente.Num_doc = txtNum_Doc.Text;
                objDocente.Nombre = txtNombre.Text;
                objDocente.Apellido = txtApellidos.Text;
                objDocente.Email = txtEmail.Text;
                objDocente.Telefono = txtTelefono.Text;

                DateTime HoraActual = DateTime.Now;

                string FechaActual = HoraActual.ToString("dd/MM/yyyy h:mm tt");

                txtFechayHora.Text = FechaActual;

                objDocente.Fecha_Registro = HoraActual;

                objDocente.Estado = (this.chkEstado.Checked == true) ? true : false;

                try
                {
                    objNegocio.Agregar(objDocente);
                    MessageBox.Show("Se ha registrado un nuevo Docente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar los Datos");
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            if (txtBuscar.Text == string.Empty)
            {
                dataDocente.DataSource = objNegocio.ListarDocentes();
            }
            else
            {
                dataDocente.DataSource = objNegocio.ListarDocentesXNombre(txtBuscar.Text);
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar(this);
        }

        private void btnEstudiante_Click(object sender, EventArgs e)
        {
            Form1 formularioE = new Form1();
            formularioE.Show();

            this.Hide();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (Validar(txtNum_Doc.Text, txtNombre.Text, txtApellidos.Text, txtEmail.Text, txtTelefono.Text, txtFechayHora.Text) == true)
            {
                objDocente = objNegocio.Buscar(Convert.ToInt32(txtId.Text));
                objDocente.Num_doc = txtNum_Doc.Text;
                objDocente.Nombre = txtNombre.Text;
                objDocente.Apellido = txtApellidos.Text;
                objDocente.Email = txtEmail.Text;
                objDocente.Telefono = txtTelefono.Text;

                DateTime HoraActual = DateTime.Now;

                objDocente.Fecha_Registro = HoraActual;

                objDocente.Estado = (this.chkEstado.Checked == true) ? true : false;
                try
                {
                    objNegocio.Actualizar(objDocente);
                    MessageBox.Show("Se ha actualizado el Docente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Primero Selecione el registro que desee Actualizar");
            }
        }

        private void dataDocente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dataDocente.CurrentRow.Cells[0].Value.ToString();
            txtNum_Doc.Text = dataDocente.CurrentRow.Cells[1].Value.ToString();
            txtNombre.Text = dataDocente.CurrentRow.Cells[2].Value.ToString();
            txtApellidos.Text = dataDocente.CurrentRow.Cells[3].Value.ToString();
            txtEmail.Text = dataDocente.CurrentRow.Cells[4].Value.ToString();
            txtTelefono.Text = dataDocente.CurrentRow.Cells[5].Value.ToString();
            txtFechayHora.Text = dataDocente.CurrentRow.Cells[6].Value.ToString();
            if (dataDocente.CurrentRow.Cells[7].Value is true)
            {
                this.chkEstado.Checked = true;
            }
            else
            {
                this.chkEstado.Checked = false;
            }
        }
        private void FrmDocente_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
