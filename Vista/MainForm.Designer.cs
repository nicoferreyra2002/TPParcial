using System.Windows.Forms;

namespace TPParcial
{
    public partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        // Controles referenciados por MainForm.cs
        private MenuStrip menuStrip1;
        private ToolStripMenuItem menuItemGestionReservas;
        private ToolStripMenuItem menuItemConsultaReservas; // <-- agregado
        private ToolStripMenuItem menuItemGestionLaboratorios;
        private ToolStripMenuItem menuItemGeneracionReportes;
        private ToolStripMenuItem menuItemSalir;
        private ToolStripMenuItem menuItemIntegrantes;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.menuStrip1 = new MenuStrip();
            this.menuItemGestionReservas = new ToolStripMenuItem();
            this.menuItemConsultaReservas = new ToolStripMenuItem();
            this.menuItemGestionLaboratorios = new ToolStripMenuItem();
            this.menuItemGeneracionReportes = new ToolStripMenuItem();
            this.menuItemIntegrantes = new ToolStripMenuItem();
            this.menuItemSalir = new ToolStripMenuItem();

            // menuStrip1
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";

            // menuItemGestionReservas
            this.menuItemGestionReservas.Name = "menuItemGestionReservas";
            this.menuItemGestionReservas.Text = "Gestión Reservas";
            this.menuItemGestionReservas.Click += new System.EventHandler(this.MenuItemGestionReservas_Click);

            // menuItemConsultaReservas
            this.menuItemConsultaReservas.Name = "menuItemConsultaReservas";
            this.menuItemConsultaReservas.Text = "Consulta Reservas";
            this.menuItemConsultaReservas.Click += new System.EventHandler(this.MenuItemConsultaReservas_Click);

            // menuItemGestionLaboratorios
            this.menuItemGestionLaboratorios.Name = "menuItemGestionLaboratorios";
            this.menuItemGestionLaboratorios.Text = "Gestión Laboratorios";
            this.menuItemGestionLaboratorios.Click += new System.EventHandler(this.MenuItemGestionLaboratorios_Click);

            // menuItemGeneracionReportes
            this.menuItemGeneracionReportes.Name = "menuItemGeneracionReportes";
            this.menuItemGeneracionReportes.Text = "Generación Reportes";
            this.menuItemGeneracionReportes.Click += new System.EventHandler(this.MenuItemGeneracionReportes_Click);

            // menuItemIntegrantes
            this.menuItemIntegrantes.Name = "menuItemIntegrantes";
            this.menuItemIntegrantes.Text = "Integrantes";
            this.menuItemIntegrantes.Click += new System.EventHandler(this.MenuItemIntegrantes_Click);

            // menuItemSalir
            this.menuItemSalir.Name = "menuItemSalir";
            this.menuItemSalir.Text = "Salir";
            this.menuItemSalir.Click += new System.EventHandler(this.MenuItemSalir_Click);

            // Agregar items al MenuStrip (se incluye la opción Consulta Reservas)
            this.menuStrip1.Items.AddRange(new ToolStripItem[]
            {
                this.menuItemGestionReservas,
                this.menuItemConsultaReservas,
                this.menuItemGestionLaboratorios,
                this.menuItemGeneracionReportes,
                this.menuItemIntegrantes,
                this.menuItemSalir
            });

            // Agregar controles al formulario
            this.Controls.Add(this.menuStrip1);

            // Propiedades básicas del formulario
            this.MainMenuStrip = this.menuStrip1;
            this.Text = "Main";
            this.ClientSize = new System.Drawing.Size(800, 450);
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