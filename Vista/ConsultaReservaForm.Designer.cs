using System.Windows.Forms;

namespace TPParcial
{
    public partial class ConsultaReservaForm
    {
        private System.ComponentModel.IContainer components = null;

        // Controles referenciados por ConsultaReservaForm.cs
        private DataGridView dgvReservas;
        private Label lblResultados;
        private TextBox txtFiltroProfesor;
        private TextBox txtFiltroAsignatura;
        private DateTimePicker dtpFiltroFecha;
        private Button btnConsultar;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.dgvReservas = new DataGridView();
            this.lblResultados = new Label();
            this.txtFiltroProfesor = new TextBox();
            this.txtFiltroAsignatura = new TextBox();
            this.dtpFiltroFecha = new DateTimePicker();
            this.btnConsultar = new Button();

            // dgvReservas
            this.dgvReservas.Name = "dgvReservas";
            this.dgvReservas.Location = new System.Drawing.Point(12, 80);
            this.dgvReservas.Size = new System.Drawing.Size(760, 360);
            this.dgvReservas.AutoGenerateColumns = true;
            this.dgvReservas.AllowUserToAddRows = false;
            this.dgvReservas.ReadOnly = true;

            // lblResultados
            this.lblResultados.Name = "lblResultados";
            this.lblResultados.Text = "Total de Resultados: 0";
            this.lblResultados.Location = new System.Drawing.Point(12, 450);
            this.lblResultados.AutoSize = true;

            // txtFiltroProfesor
            this.txtFiltroProfesor.Name = "txtFiltroProfesor";
            this.txtFiltroProfesor.Location = new System.Drawing.Point(12, 12);
            this.txtFiltroProfesor.Size = new System.Drawing.Size(200, 20);

            // txtFiltroAsignatura
            this.txtFiltroAsignatura.Name = "txtFiltroAsignatura";
            this.txtFiltroAsignatura.Location = new System.Drawing.Point(220, 12);
            this.txtFiltroAsignatura.Size = new System.Drawing.Size(200, 20);

            // dtpFiltroFecha
            this.dtpFiltroFecha.Name = "dtpFiltroFecha";
            this.dtpFiltroFecha.Location = new System.Drawing.Point(430, 12);
            this.dtpFiltroFecha.Format = DateTimePickerFormat.Short;
            this.dtpFiltroFecha.Size = new System.Drawing.Size(120, 20);

            // btnConsultar
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.Location = new System.Drawing.Point(560, 10);
            this.btnConsultar.Size = new System.Drawing.Size(100, 24);
            this.btnConsultar.Click += new System.EventHandler(this.BtnConsultar_Click);

            // Agregar controles al formulario
            this.Controls.Add(this.dgvReservas);
            this.Controls.Add(this.lblResultados);
            this.Controls.Add(this.txtFiltroProfesor);
            this.Controls.Add(this.txtFiltroAsignatura);
            this.Controls.Add(this.dtpFiltroFecha);
            this.Controls.Add(this.btnConsultar);

            // Propiedades básicas del formulario
            this.Text = "Consulta de Reservas";
            this.ClientSize = new System.Drawing.Size(784, 481);
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