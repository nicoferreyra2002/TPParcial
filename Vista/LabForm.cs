using System.Windows.Forms;
using Controladores;

public partial class LabForm : Form
{
    private LaboratorioController _controller;

    public LabForm(LaboratorioController controller)
    {
        InitializeComponent();
        _controller = controller; // El formulario recibe el controlador
    }

    // Evento de un botón "Guardar" de tu formulario
    private void btnGuardar_Click(object sender, System.EventArgs e)
    {
        try
        {
            // Simulación de obtención de datos de TextBoxes
            string piso = txtPiso.Text;
            int capacidad = int.Parse(txtCapacidad.Text);

            _controller.AltaLaboratorio(piso, capacidad);
            MessageBox.Show("Laboratorio agregado con éxito.");
        }
        catch (InvalidInputException ex)
        {
            MessageBox.Show($"Error de validación: {ex.Message}", "Error");
        }
        catch (System.Exception ex)
        {
            // Capturar otros errores generales
            MessageBox.Show($"Error: {ex.Message}", "Error");
        }
    }
}