namespace GestionDeGastos.Views
{
    partial class GastosForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.rdbPersonal = new System.Windows.Forms.RadioButton();
            this.rdbGrupal = new System.Windows.Forms.RadioButton();
            this.grpTipoGasto = new System.Windows.Forms.GroupBox();
            this.cmbGrupos = new System.Windows.Forms.ComboBox();
            this.lblGrupo = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblMonto = new System.Windows.Forms.Label();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.btnGuardarGasto = new System.Windows.Forms.Button();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.btnVolver = new System.Windows.Forms.Button();
            this.grpTipoGasto.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Candara", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(150, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(135, 23);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Registrar Gasto";
            // 
            // rdbPersonal
            // 
            this.rdbPersonal.Checked = true;
            this.rdbPersonal.Location = new System.Drawing.Point(10, 20);
            this.rdbPersonal.Name = "rdbPersonal";
            this.rdbPersonal.Size = new System.Drawing.Size(104, 24);
            this.rdbPersonal.TabIndex = 0;
            this.rdbPersonal.TabStop = true;
            this.rdbPersonal.Text = "Personal";
            this.rdbPersonal.CheckedChanged += new System.EventHandler(this.TipoGasto_CheckedChanged);
            // 
            // rdbGrupal
            // 
            this.rdbGrupal.Location = new System.Drawing.Point(10, 40);
            this.rdbGrupal.Name = "rdbGrupal";
            this.rdbGrupal.Size = new System.Drawing.Size(104, 24);
            this.rdbGrupal.TabIndex = 1;
            this.rdbGrupal.Text = "Grupal";
            this.rdbGrupal.CheckedChanged += new System.EventHandler(this.TipoGasto_CheckedChanged);
            // 
            // grpTipoGasto
            // 
            this.grpTipoGasto.Controls.Add(this.rdbPersonal);
            this.grpTipoGasto.Controls.Add(this.rdbGrupal);
            this.grpTipoGasto.Location = new System.Drawing.Point(30, 50);
            this.grpTipoGasto.Name = "grpTipoGasto";
            this.grpTipoGasto.Size = new System.Drawing.Size(200, 70);
            this.grpTipoGasto.TabIndex = 1;
            this.grpTipoGasto.TabStop = false;
            this.grpTipoGasto.Text = "Tipo de Gasto";
            // 
            // cmbGrupos
            // 
            this.cmbGrupos.Location = new System.Drawing.Point(310, 60);
            this.cmbGrupos.Name = "cmbGrupos";
            this.cmbGrupos.Size = new System.Drawing.Size(150, 21);
            this.cmbGrupos.TabIndex = 3;
            // 
            // lblGrupo
            // 
            this.lblGrupo.Location = new System.Drawing.Point(236, 60);
            this.lblGrupo.Name = "lblGrupo";
            this.lblGrupo.Size = new System.Drawing.Size(68, 23);
            this.lblGrupo.TabIndex = 2;
            this.lblGrupo.Text = "Grupo:";
            // 
            // lblNombre
            // 
            this.lblNombre.Location = new System.Drawing.Point(30, 140);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(64, 23);
            this.lblNombre.TabIndex = 4;
            this.lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(100, 140);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(204, 20);
            this.txtNombre.TabIndex = 5;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Location = new System.Drawing.Point(30, 180);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(64, 23);
            this.lblDescripcion.TabIndex = 6;
            this.lblDescripcion.Text = "Descripción:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(100, 180);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(360, 60);
            this.txtDescripcion.TabIndex = 7;
            // 
            // lblMonto
            // 
            this.lblMonto.Location = new System.Drawing.Point(30, 260);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(50, 23);
            this.lblMonto.TabIndex = 8;
            this.lblMonto.Text = "Monto:";
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(100, 260);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(150, 20);
            this.txtMonto.TabIndex = 9;
            // 
            // lblFecha
            // 
            this.lblFecha.Location = new System.Drawing.Point(280, 260);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(44, 23);
            this.lblFecha.TabIndex = 10;
            this.lblFecha.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(330, 260);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(147, 20);
            this.dtpFecha.TabIndex = 11;
            // 
            // btnGuardarGasto
            // 
            this.btnGuardarGasto.Location = new System.Drawing.Point(90, 349);
            this.btnGuardarGasto.Name = "btnGuardarGasto";
            this.btnGuardarGasto.Size = new System.Drawing.Size(140, 30);
            this.btnGuardarGasto.TabIndex = 12;
            this.btnGuardarGasto.Text = "Guardar Gasto";
            this.btnGuardarGasto.Click += new System.EventHandler(this.btnGuardarGasto_Click);
            // 
            // lblCategoria
            // 
            this.lblCategoria.Location = new System.Drawing.Point(30, 295);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(64, 23);
            this.lblCategoria.TabIndex = 13;
            this.lblCategoria.Text = "Categoría:";
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoria.Location = new System.Drawing.Point(100, 292);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(150, 21);
            this.cmbCategoria.TabIndex = 14;
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(387, 349);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(90, 30);
            this.btnVolver.TabIndex = 13;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // GastosForm
            // 
            this.ClientSize = new System.Drawing.Size(500, 406);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.grpTipoGasto);
            this.Controls.Add(this.lblGrupo);
            this.Controls.Add(this.cmbGrupos);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.lblMonto);
            this.Controls.Add(this.txtMonto);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.btnGuardarGasto);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.cmbCategoria);
            this.Controls.Add(this.btnVolver);
            this.Name = "GastosForm";
            this.Text = "Gastos";
            this.Load += new System.EventHandler(this.GastosForm_Load);
            this.grpTipoGasto.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.GroupBox grpTipoGasto;
        private System.Windows.Forms.RadioButton rdbPersonal;
        private System.Windows.Forms.RadioButton rdbGrupal;
        private System.Windows.Forms.ComboBox cmbGrupos;
        private System.Windows.Forms.Label lblGrupo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Button btnGuardarGasto;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.Button btnVolver;
    }
}
