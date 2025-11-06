using System.Windows.Forms;

namespace TPParcial
{
    public partial class ReservaForm
    {
        private System.ComponentModel.IContainer components = null;

        // Controles referenciados por la lógica del formulario
        private ComboBox cmbTipoReserva;
        private ComboBox cmbFrecuencia;
        private Label lblFechaFinalizacion;
        private DateTimePicker dtpFechaFinalizacion;
        private Label lblFrecuencia;
        private Label lblCantSemanas;
        private TextBox txtCantSemanas;
        private TextBox txtCarrera;
        private TextBox txtAsignatura;
        private TextBox txtAnio;
        private TextBox txtComision;
        private TextBox txtProfesor;
        private DateTimePicker dtpFechaComienzo;
        private Button btnGuardar;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.cmbTipoReserva = new ComboBox();
            this.cmbFrecuencia = new ComboBox();
            this.lblFechaFinalizacion = new Label();
            this.dtpFechaFinalizacion = new DateTimePicker();
            this.lblFrecuencia = new Label();
            this.lblCantSemanas = new Label();
            this.txtCantSemanas = new TextBox();
            this.txtCarrera = new TextBox();
            this.txtAsignatura = new TextBox();
            this.txtAnio = new TextBox();
            this.txtComision = new TextBox();
            this.txtProfesor = new TextBox();
            this.dtpFechaComienzo = new DateTimePicker();
            this.btnGuardar = new Button();

            // Algunas propiedades mínimas para evitar que los controles estén en blanco
            this.cmbTipoReserva.Name = "cmbTipoReserva";
            this.cmbTipoReserva.TabIndex = 0;
            this.cmbTipoReserva.Location = new System.Drawing.Point(12, 12);

            this.cmbFrecuencia.Name = "cmbFrecuencia";
            this.cmbFrecuencia.TabIndex = 1;
            this.cmbFrecuencia.Location = new System.Drawing.Point(12, 40);

            this.lblFechaFinalizacion.Name = "lblFechaFinalizacion";
            this.lblFechaFinalizacion.Text = "Fecha Finalización";
            this.lblFechaFinalizacion.Location = new System.Drawing.Point(12, 70);

            this.dtpFechaFinalizacion.Name = "dtpFechaFinalizacion";
            this.dtpFechaFinalizacion.Location = new System.Drawing.Point(120, 70);

            this.lblFrecuencia.Name = "lblFrecuencia";
            this.lblFrecuencia.Text = "Frecuencia";
            this.lblFrecuencia.Location = new System.Drawing.Point(12, 40);

            this.lblCantSemanas.Name = "lblCantSemanas";
            this.lblCantSemanas.Text = "Cant. Semanas";
            this.lblCantSemanas.Location = new System.Drawing.Point(12, 100);

            this.txtCantSemanas.Name = "txtCantSemanas";
            this.txtCantSemanas.Location = new System.Drawing.Point(120, 100);

            this.txtCarrera.Name = "txtCarrera";
            this.txtCarrera.Location = new System.Drawing.Point(12, 130);

            this.txtAsignatura.Name = "txtAsignatura";
            this.txtAsignatura.Location = new System.Drawing.Point(12, 160);

            this.txtAnio.Name = "txtAnio";
            this.txtAnio.Location = new System.Drawing.Point(12, 190);

            this.txtComision.Name = "txtComision";
            this.txtComision.Location = new System.Drawing.Point(12, 220);

            this.txtProfesor.Name = "txtProfesor";
            this.txtProfesor.Location = new System.Drawing.Point(12, 250);

            this.dtpFechaComienzo.Name = "dtpFechaComienzo";
            this.dtpFechaComienzo.Location = new System.Drawing.Point(12, 280);

            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Location = new System.Drawing.Point(12, 320);

            // Suscribir los eventos a los métodos (coinciden con los renombrados en ReservaForm.cs)
            this.cmbTipoReserva.SelectedIndexChanged += new System.EventHandler(this.CmbTipoReserva_SelectedIndexChanged);
            this.btnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);

            // Agregar controles al formulario
            this.Controls.Add(this.cmbTipoReserva);
            this.Controls.Add(this.cmbFrecuencia);
            this.Controls.Add(this.lblFechaFinalizacion);
            this.Controls.Add(this.dtpFechaFinalizacion);
            this.Controls.Add(this.lblFrecuencia);
            this.Controls.Add(this.lblCantSemanas);
            this.Controls.Add(this.txtCantSemanas);
            this.Controls.Add(this.txtCarrera);
            this.Controls.Add(this.txtAsignatura);
            this.Controls.Add(this.txtAnio);
            this.Controls.Add(this.txtComision);
            this.Controls.Add(this.txtProfesor);
            this.Controls.Add(this.dtpFechaComienzo);
            this.Controls.Add(this.btnGuardar);

            // Propiedades básicas del formulario
            this.Text = "Reserva";
            this.ClientSize = new System.Drawing.Size(480, 380);
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
}