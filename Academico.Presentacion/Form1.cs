using Academico.Entidades;
using Academico.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Microsoft.Reporting.WinForms;
using System.Data.SqlClient;

namespace Academico.Presentacion
{
    
    public partial class Form1 : Form
    {
        private AsistenciaEstudiante formularioAsistencia;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private string connectionString = "Data Source=JHOSEP\\SQLEXPRESS;Initial Catalog=Jhosep;Persist Security Info=True;User ID=sa;Password=jhosep;TrustServerCertificate=True";

        public Form1()
        {
            InitializeComponent();
            formularioAsistencia = new AsistenciaEstudiante();

        }
        EstudianteNegocio objNegocio = new EstudianteNegocio();
        Estudiante objEstudiante = new Estudiante();
        FuenteExterna objApi = new FuenteExterna();
 



        private void FrmEstudiante_Load(object sender, EventArgs e)
        {

        }

        void Limpiar()
        {
            foreach (Control c in Controls)
            {
                if (c is TextBox)
                {
                    c.Text = "";
                }
            }
            chkEstado.Checked = false;
        }
        bool Validar(String p1, string p2, String p3)
        {
            if (p1.Length == 0 || p2.Length == 0 || p3.Length == 0)
                return false;
            else
                return true;
        }

        private void consultarDNI()
        {
            try
            {
                if (txtNum_doc.Text.Length == 8 && int.TryParse(txtNum_doc.Text, out _))
                {
                    // Reemplazar 'objApi' con la instancia adecuada de tu clase FuenteExterna
                    dynamic respuesta = objApi.Get("https://dniruc.apisperu.com/api/v1/dni/" + txtNum_doc.Text + "?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJlbWFpbCI6ImxtdGltYW5hZ0BnbWFpbC5jb20ifQ.udFejq_ZQw4kqP6wfRGX1RaKaksh-lFwcqlM7p9Y1dU");

                    if (respuesta != null)
                    {
                        txtNombres.Text = $"{respuesta.nombres} {respuesta.apellidoPaterno} {respuesta.apellidoMaterno}";
                    }
                    else
                    {
                        MessageBox.Show("No se pudo obtener la información del DNI.", "Error en la consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese un número de documento válido.", "Documento inválido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (WebException webEx)
            {
                // Manejo específico para errores de red
                MessageBox.Show("Error de red: " + webEx.Message, "Error de red", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (JsonException jsonEx)
            {
                // Manejo específico para errores de deserialización
                MessageBox.Show("Error al procesar la respuesta: " + jsonEx.Message, "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Manejo genérico de excepciones
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (Validar(txtNum_doc.Text, txtNombres.Text, txtEmail.Text))
            {
                // Verificar si se proporcionó un ID válido
                if (!string.IsNullOrEmpty(txtId.Text))
                {
                    // Intentar buscar el estudiante por su ID
                    int idEstudiante;
                    if (int.TryParse(txtId.Text, out idEstudiante))
                    {
                        objEstudiante = objNegocio.Buscar(idEstudiante);

                        // Verificar si se encontró el estudiante
                        if (objEstudiante != null)
                        {
                            // Actualizar los detalles del estudiante
                            objEstudiante.num_doc = txtNum_doc.Text;
                            objEstudiante.nombres = txtNombres.Text;
                            objEstudiante.email = txtEmail.Text;
                            objEstudiante.Estado = chkEstado.Checked;

                            try
                            {
                                // Intentar actualizar el estudiante en la base de datos
                                objNegocio.Actualizar(objEstudiante);
                                MessageBox.Show("Se ha actualizado el Estudiante");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error al actualizar el estudiante: " + ex.Message);
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se encontró ningún estudiante con el ID proporcionado.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("El ID del estudiante no es válido.");
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese el ID del estudiante que desea actualizar.");
                }
            }
            else
            {
                MessageBox.Show("Por favor complete todos los campos antes de actualizar el estudiante.");
            }

        }

        private void datoEstudiante_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dataEstudiante.CurrentRow.Cells[0].Value.ToString();
            txtNum_doc.Text = dataEstudiante.CurrentRow.Cells[1].Value.ToString();
            txtNombres.Text = dataEstudiante.CurrentRow.Cells[2].Value.ToString();
            txtEmail.Text = dataEstudiante.CurrentRow.Cells[3].Value.ToString();
            if (dataEstudiante.CurrentRow.Cells[4].Value is true)
            {
                this.chkEstado.Checked = true;
            }
            else
            {
                this.chkEstado.Checked = false;
            }
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            if (txtBuscar.Text == string.Empty)
            {
                dataEstudiante.DataSource = objNegocio.ListarEstudiante();
            }
            else
            {
                dataEstudiante.DataSource = objNegocio.ListarEstudianteXNombre(txtBuscar.Text);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (Validar(txtNum_doc.Text, txtNombres.Text, txtEmail.Text))
            {
                // Crear un nuevo objeto Estudiante
                Estudiante nuevoEstudiante = new Estudiante();

                // Asignar los valores ingresados por el usuario al nuevo estudiante
                nuevoEstudiante.num_doc = txtNum_doc.Text;
                nuevoEstudiante.nombres = txtNombres.Text;
                nuevoEstudiante.email = txtEmail.Text;
                nuevoEstudiante.Estado = chkEstado.Checked;

                try
                {
                    // Agregar el nuevo estudiante a la base de datos
                    objNegocio.Agregar(nuevoEstudiante);
                    MessageBox.Show("Se ha registrado un nuevo estudiante");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al agregar el estudiante: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar los Datos");
            }
        }

        private void btnDocentes_Click(object sender, EventArgs e)
        {
            FormDocentes formularioD = new FormDocentes();
            formularioD.Show();

            this.Hide();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void chkEstado_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
         
        }

        private void BuscarDNI_Click(object sender, EventArgs e)
        {
            consultarDNI();
        }

        private void btnVerReporte_Click(object sender, EventArgs e)
        {
            DataTable dataTable = ObtenerDatosParaReporte();
            Reportes reportesForm = new Reportes();
            reportesForm.CargarReporte(dataTable);
            reportesForm.Show();
        }
        private DataTable ObtenerDatosParaReporte()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spEstudiantes", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            return dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            formularioAsistencia.ShowDialog();
        }
    }
}


