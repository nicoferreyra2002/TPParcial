using System.Windows.Forms;

public partial class LabForm
{
    private System.ComponentModel.IContainer components = null;

    // Controles referenciados por LabForm.cs
    private TextBox txtPiso;
    private TextBox txtCapacidad;
    private Button btnGuardar;

    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();

        this.txtPiso = new TextBox();
        this.txtCapacidad = new TextBox();
        this.btnGuardar = new Button();

        this.txtPiso.Name = "txtPiso";
        this.txtPiso.Location = new System.Drawing.Point(12, 12);

        this.txtCapacidad.Name = "txtCapacidad";
        this.txtCapacidad.Location = new System.Drawing.Point(12, 44);

        this.btnGuardar.Name = "btnGuardar";
        this.btnGuardar.Text = "Guardar";
        this.btnGuardar.Location = new System.Drawing.Point(12, 76);

        // Suscribir evento (coincide con el manejador existente en LabForm.cs)
        this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

        this.Controls.Add(this.txtPiso);
        this.Controls.Add(this.txtCapacidad);
        this.Controls.Add(this.btnGuardar);

        this.Text = "Laboratorio";
        this.ClientSize = new System.Drawing.Size(300, 140);
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }
}