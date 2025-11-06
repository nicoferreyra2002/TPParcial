using System;
using System.Windows.Forms;
using Controladores;
using TPParcial.Modelo; // Necesario para usar el Controller

namespace TPParcial
{
    public partial class ReservaForm : Form
    {
        private readonly ReservaController _controller;

        // El formulario debe recibir el controlador (Inyección de Dependencia)
        public ReservaForm(ReservaController controller)
        {
            InitializeComponent();
            _controller = controller;

            CargarOpciones();
            HabilitarControlesPorTipo();
        }

        private void CargarOpciones()
        {
            // Cargar el ComboBox de Tipo de Reserva
            cmbTipoReserva.Items.Add("Reserva Cuatrimestral");
            cmbTipoReserva.Items.Add("Reserva Eventual");
            cmbTipoReserva.SelectedIndex = 0; // Selecciona Cuatrimestral por defecto

            // Cargar el ComboBox de Frecuencia (solo Cuatrimestral)
            cmbFrecuencia.Items.Add("Semanal");
            cmbFrecuencia.Items.Add("Quincenal");
            cmbFrecuencia.SelectedIndex = 0;
        }

        // Manejar la visibilidad de los controles según el tipo de reserva seleccionado
        private void HabilitarControlesPorTipo()
        {
            bool esCuatrimestral = cmbTipoReserva.SelectedItem.ToString() == "Reserva Cuatrimestral";

            // Controles de Reserva Cuatrimestral
            lblFechaFinalizacion.Visible = esCuatrimestral;
            dtpFechaFinalizacion.Visible = esCuatrimestral;
            lblFrecuencia.Visible = esCuatrimestral;
            cmbFrecuencia.Visible = esCuatrimestral;

            // Controles de Reserva Eventual
            lblCantSemanas.Visible = !esCuatrimestral;
            txtCantSemanas.Visible = !esCuatrimestral;

            // Nota: En la Reserva Eventual, dtpFechaComienzo es "Fecha Comienzo Reserva"
        }

        private void CmbTipoReserva_SelectedIndexChanged(object sender, EventArgs e)
        {
            HabilitarControlesPorTipo();
        }

        // --- Evento de Guardar Reserva (Alta o Modificación) ---
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Obtener datos comunes
                string carrera = txtCarrera.Text;
                string asignatura = txtAsignatura.Text;
                // Usar TryParse para una validación robusta y evitar errores de formato
                if (!int.TryParse(txtAnio.Text, out int anio))
                {
                    throw new InvalidInputException("El campo Año debe ser un número válido.");
                }
                string comision = txtComision.Text;
                string profesor = txtProfesor.Text;

                Reserva nuevaReserva;

                // 2. Crear la reserva según el tipo
                if (cmbTipoReserva.SelectedItem.ToString() == "Reserva Cuatrimestral")
                {
                    // Requisitos Cuatrimestral
                    DateTime inicio = dtpFechaComienzo.Value;
                    DateTime fin = dtpFechaFinalizacion.Value;
                    string frecuencia = cmbFrecuencia.SelectedItem.ToString();

                    nuevaReserva = new ReservaCuatrimestral(carrera, asignatura, anio, comision, profesor,
                                                            inicio, fin, frecuencia);
                }
                else
                {
                    // Requisitos Eventual
                    DateTime inicio = dtpFechaComienzo.Value; // Fecha Comienzo Reserva
                    if (!int.TryParse(txtCantSemanas.Text, out int semanas))
                    {
                        throw new InvalidInputException("El campo 'Semanas' debe ser un número entero válido.");
                    }

                    nuevaReserva = new ReservaEventual(carrera, asignatura, anio, comision, profesor,
                                                       inicio, semanas);
                }

                // 3. Llamar al Controller
                _controller.AltaReserva(nuevaReserva);

                MessageBox.Show("Reserva ingresada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (InvalidInputException ex)
            {
                // Requisito: Validar convenientemente las entradas de datos utilizando excepciones
                MessageBox.Show($"Error de validación de datos: {ex.Message}", "Error de Entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (FormatException)
            {
                // Captura si intenta parsear un texto a un tipo numérico (si no se usa TryParse en todos lados)
                MessageBox.Show("Error: Verifique que todos los campos numéricos contengan números válidos.", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                // Capturar errores generales, incluyendo posibles DataMovementException
                MessageBox.Show($"Ocurrió un error al guardar la reserva: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}