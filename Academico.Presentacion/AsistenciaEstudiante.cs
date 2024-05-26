using Academico.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Academico.Presentacion
{
    public partial class AsistenciaEstudiante : Form
    {
        private List<Asistencia> asistencias = new List<Asistencia>();
        private List<Estudiante> estudiantes = new List<Estudiante>();
        private string connectionString = "Data Source=JHOSEP\\SQLEXPRESS;Initial Catalog=Jhosep;Persist Security Info=True;User ID=sa;Password=jhosep;TrustServerCertificate=True";
        public AsistenciaEstudiante()
        {
            InitializeComponent();
            txtFecha.Text = DateTime.Today.ToString("yyyy-MM-dd");
            InicializarDataGridView();
            CargarEstudiantesDesdeBaseDeDatos();
            CargarAsistenciasDesdeBaseDeDatos();
            txtNombres.ReadOnly = true;
            btnRegistrarSalida.Enabled = false;

        }

        private void AsistenciaEstudiante_Load(object sender, EventArgs e)
        {

        }


        private void btnRegistrarEntrada_Click(object sender, EventArgs e)
        {
            if (ValidarEstudianteRegistrado(txtNumDocumento.Text))
            {
                txtHoraEntrada.Text = DateTime.Now.ToString("HH:mm:ss");
                RegistrarAsistenciaEntrada();
                btnRegistrarEntrada.Enabled = false;
                btnRegistrarSalida.Enabled = false;
                LimpiarCampos();
                MessageBox.Show("Hora de entrada registrada. Puede cerrar el programa y volver más tarde para registrar la salida.", "Entrada registrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("El estudiante no está registrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegistrarSalida_Click(object sender, EventArgs e)
        {
            if (ValidarEstudianteRegistrado(txtNumDocumento.Text))
            {
                txtHoraSalida.Text = DateTime.Now.ToString("HH:mm:ss");
                RegistrarAsistenciaSalida();
                btnRegistrarSalida.Enabled = false;
                btnRegistrarEntrada.Enabled = true;
                ActualizarDataGridView();
                LimpiarCampos();
                MessageBox.Show("Hora de salida registrada.", "Salida registrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("El estudiante no está registrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LimpiarCampos()
        {
            txtNumDocumento.Text = string.Empty;
            txtNombres.Text = string.Empty;
            txtFecha.Text = DateTime.Today.ToString("yyyy-MM-dd");
            txtHoraEntrada.Text = string.Empty;
            txtHoraSalida.Text = string.Empty;
            btnRegistrarEntrada.Enabled = true;
            btnRegistrarSalida.Enabled = false;
        }

        private void btnLimpiarCampos_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
        private void CargarEstudiantesDesdeBaseDeDatos()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Num_Doc, Nombres FROM Estudiantes";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                estudiantes.Add(new Estudiante
                                {
                                    num_doc = reader["Num_Doc"].ToString(),
                                    nombres = reader["Nombres"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los estudiantes desde la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ObtenerNombreEstudiante(string numDocumento)
        {
            var estudiante = estudiantes.FirstOrDefault(e => e.num_doc == numDocumento);
            return estudiante != null ? estudiante.nombres : string.Empty;
        }

        private void txtNumDocumento_TextChanged(object sender, EventArgs e)
        {
            string nombreEstudiante = ObtenerNombreEstudiante(txtNumDocumento.Text);
            txtNombres.Text = nombreEstudiante;

            if (!string.IsNullOrEmpty(nombreEstudiante))
            {
                btnRegistrarEntrada.Enabled = !HayAsistenciaRegistradaSinSalida(txtNumDocumento.Text);
                btnRegistrarSalida.Enabled = HayAsistenciaRegistradaSinSalida(txtNumDocumento.Text);
            }
            else
            {
                btnRegistrarEntrada.Enabled = false;
                btnRegistrarSalida.Enabled = false;
            }
        }

        private void InicializarDataGridView()
        {
            dgvAsistencias.ColumnCount = 5;
            dgvAsistencias.Columns[0].Name = "Num Documento";
            dgvAsistencias.Columns[1].Name = "Nombres";
            dgvAsistencias.Columns[2].Name = "Fecha";
            dgvAsistencias.Columns[3].Name = "Hora Entrada";
            dgvAsistencias.Columns[4].Name = "Hora Salida";
            dgvAsistencias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void ActualizarDataGridView()
        {
            dgvAsistencias.Rows.Clear();
            foreach (var asistencia in asistencias)
            {
                dgvAsistencias.Rows.Add(asistencia.NumDocumento, asistencia.Nombres, asistencia.Fecha, asistencia.HoraEntrada, asistencia.HoraSalida);
            }
        }

        private void RegistrarAsistenciaEntrada()
        {
            Asistencia nuevaAsistencia = new Asistencia
            {
                NumDocumento = txtNumDocumento.Text,
                Nombres = txtNombres.Text,
                Fecha = txtFecha.Text,
                HoraEntrada = txtHoraEntrada.Text,
                HoraSalida = null
            };

            asistencias.Add(nuevaAsistencia); 
            GuardarAsistenciaEnBaseDeDatos(nuevaAsistencia); 
            ActualizarDataGridView(); 
        }

        private void RegistrarAsistenciaSalida()
        {
            var asistencia = asistencias.FirstOrDefault(a => a.NumDocumento == txtNumDocumento.Text && a.Fecha == txtFecha.Text && string.IsNullOrEmpty(a.HoraSalida));
            if (asistencia != null)
            {
                asistencia.HoraSalida = txtHoraSalida.Text;
                ActualizarAsistenciaEnBaseDeDatos(asistencia);
            }
        }

        private void GuardarAsistenciaEnBaseDeDatos(Asistencia asistencia)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Asistencia (NumDocumento, Fecha, HoraEntrada) VALUES (@NumDocumento, @Fecha, @HoraEntrada)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NumDocumento", asistencia.NumDocumento);
                        command.Parameters.AddWithValue("@Fecha", asistencia.Fecha);
                        command.Parameters.AddWithValue("@HoraEntrada", asistencia.HoraEntrada);
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Hora de entrada registrada correctamente en la base de datos.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar la hora de entrada en la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarAsistenciaEnBaseDeDatos(Asistencia asistencia)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Asistencia SET HoraSalida = @HoraSalida WHERE NumDocumento = @NumDocumento AND Fecha = @Fecha AND HoraEntrada = @HoraEntrada";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@HoraSalida", asistencia.HoraSalida);
                        command.Parameters.AddWithValue("@NumDocumento", asistencia.NumDocumento);
                        command.Parameters.AddWithValue("@Fecha", asistencia.Fecha);
                        command.Parameters.AddWithValue("@HoraEntrada", asistencia.HoraEntrada);
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Hora de salida registrada correctamente en la base de datos.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar la hora de salida en la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarAsistenciasDesdeBaseDeDatos()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                        SELECT A.NumDocumento, E.Nombres, A.Fecha, A.HoraEntrada, A.HoraSalida
                        FROM Asistencia A
                        JOIN Estudiantes E ON A.NumDocumento = E.Num_Doc";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Asistencia asistencia = new Asistencia
                                {
                                    NumDocumento = reader["NumDocumento"].ToString(),
                                    Nombres = reader["Nombres"].ToString(),
                                    Fecha = Convert.ToDateTime(reader["Fecha"]).ToString("yyyy-MM-dd"),
                                    HoraEntrada = TimeSpan.Parse(reader["HoraEntrada"].ToString()).ToString(@"hh\:mm\:ss"),
                                    HoraSalida = reader["HoraSalida"] != DBNull.Value ? TimeSpan.Parse(reader["HoraSalida"].ToString()).ToString(@"hh\:mm\:ss") : string.Empty
                                };
                                asistencias.Add(asistencia);
                            }
                        }
                    }
                }
                ActualizarDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las asistencias desde la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarEstudianteRegistrado(string numDocumento)
        {
            return estudiantes.Any(e => e.num_doc == numDocumento);
        }

        private bool HayAsistenciaRegistradaSinSalida(string numDocumento)
        {
            return asistencias.Any(a => a.NumDocumento == numDocumento && string.IsNullOrEmpty(a.HoraSalida));
        }
    }

   
    
}

