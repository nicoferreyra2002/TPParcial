using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Controladores;
using TPParcial.Modelo;

namespace TPParcial
{
    public partial class ConsultaReservaForm : Form
    {
        private readonly ReservaController _controller;

        // Constructor que recibe el Controlador (Inyección de Dependencia)
        public ConsultaReservaForm(ReservaController controller)
        {
            InitializeComponent();
            _controller = controller;

            // Carga inicial al abrir el formulario
            CargarReservas(null);
        }

        // Método principal que llama al Controlador y actualiza el DataGridView
        private void CargarReservas(List<Reserva> resultados)
        {
            // Si no se pasaron resultados, obtener todas las reservas
            if (resultados == null)
            {
                // Asumimos que este método ya existe en el ReservaController
                resultados = _controller.ObtenerTodasLasReservas();
            }

            // Mapear los objetos Reserva a un tipo anónimo para la grilla (Uso de LINQ)
            var reservasVista = resultados.Select(r => new
            {
                ID = r.Id,
                Tipo = r.ObtenerDetalleTipo(), // Uso del método virtual
                Fecha_Inicio = r.GetFechaComienzo().ToShortDateString(), // Uso del método abstracto
                Asignatura = r.Asignatura,
                Profesor = r.Profesor,
                // Uso del operador condicional nulo ?. y ?? para evitar errores si LaboratorioAsignado es null
                Laboratorio = r.LaboratorioAsignado?.NumeroAsignado ?? 0,
                Carrera = r.Carrera
            }).ToList();

            dgvReservas.DataSource = reservasVista;
            dgvReservas.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            lblResultados.Text = $"Total de Resultados: {reservasVista.Count}";
        }

        // --- Evento de Consultar ---
        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtención de datos de los controles de la Vista
                string profesor = txtFiltroProfesor.Text.Trim();
                string asignatura = txtFiltroAsignatura.Text.Trim();
                DateTime fecha = dtpFiltroFecha.Value.Date; // Solo la fecha, sin hora

                List<Reserva> resultados = new List<Reserva>();

                // Lógica de priorización de filtros
                if (!string.IsNullOrEmpty(profesor))
                {
                    resultados = _controller.ConsultarPorProfesor(profesor);
                }
                else if (!string.IsNullOrEmpty(asignatura))
                {
                    resultados = _controller.ConsultarPorAsignatura(asignatura);
                }
                else
                {
                    // Si no hay texto, filtra solo por la fecha seleccionada
                    resultados = _controller.ConsultarPorFecha(fecha);
                }

                if (!resultados.Any())
                {
                    MessageBox.Show("No se encontraron reservas con los criterios de búsqueda.", "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                CargarReservas(resultados);
            }
            catch (Exception ex)
            {
                // Manejo de errores (ej. si el controlador lanza una excepción)
                MessageBox.Show($"Error al realizar la consulta: {ex.Message}", "Error de Consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
