using Controladores;
using System;
using System.Windows.Forms;

namespace TPParcial
{
    public partial class MainForm : Form
    {
        // Instancias de los Repositorios (se inician una sola vez)
        private readonly RepositorioReserva _repoReserva = new RepositorioReserva();
        private readonly RepositorioLaboratorio _repoLab;

        public MainForm()
        {
            InitializeComponent();
            _repoLab = new RepositorioLaboratorio(_repoReserva); // Inyectar dependencia

            // Requisito: Uso habilitado de Lunes a Viernes de 7:00 a 23:00hs y Sábados de 08:00 a 12:00hs.
            this.Text = "Sistema de Reservas (UAI) - L-V: 7-23hs, S: 8-12hs";
        }

        // --- Gestión de Reservas ---
        private void MenuItemGestionReservas_Click(object sender, EventArgs e)
        {
            // Pasar la dependencia al formulario de Reservas
            ReservaController controller = new ReservaController(_repoReserva);
            ReservaForm reservaForm = new ReservaForm(controller);
            reservaForm.ShowDialog();
        }

        // --- Gestión de Laboratorios ---
        private void MenuItemGestionLaboratorios_Click(object sender, EventArgs e)
        {
            // Pasar la dependencia al formulario de Laboratorios
            LaboratorioController controller = new LaboratorioController(_repoLab);
            LabForm labForm = new LabForm(controller);
            labForm.ShowDialog();
        }

        // --- Generación de Reportes ---
        private void MenuItemGeneracionReportes_Click(object sender, EventArgs e)
        {
            ReporteController controller = new ReporteController(_repoReserva, _repoLab);
            MessageBox.Show(controller.GenerarReporteUsoLaboratorios(), "Reporte");
        }

        // --- Salir ---
        private void MenuItemSalir_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Requisito: Permite finalizar la ejecución de la aplicación.
        }

        // --- Integrantes del desarrollo ---
        private void MenuItemIntegrantes_Click(object sender, EventArgs e)
        {
            // Requisito: Apellido, nombres, mail institucional de contacto.
            string info = "Integrantes del desarrollo:\n" +
                          "Apellido, Nombres, mail@institucional.uai.edu.ar";
            MessageBox.Show(info, "Información del Desarrollador");
        }
    }
}