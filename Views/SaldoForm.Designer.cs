namespace GestionDeGastos.Views
{
    partial class SaldoForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.rdbPersonal = new System.Windows.Forms.RadioButton();
            this.rdbGrupal = new System.Windows.Forms.RadioButton();
            this.cmbGrupos = new System.Windows.Forms.ComboBox();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpFin = new System.Windows.Forms.DateTimePicker();
            this.txtPresupuesto = new System.Windows.Forms.TextBox();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.lstReporte = new System.Windows.Forms.ListView();
            this.lblResultado = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rdbPersonal
            // 
            this.rdbPersonal.Checked = true;
            this.rdbPersonal.Location = new System.Drawing.Point(20, 41);
            this.rdbPersonal.Name = "rdbPersonal";
            this.rdbPersonal.Size = new System.Drawing.Size(100, 20);
            this.rdbPersonal.TabIndex = 1;
            this.rdbPersonal.TabStop = true;
            this.rdbPersonal.Text = "Personal";
            this.rdbPersonal.CheckedChanged += new System.EventHandler(this.rdbPersonal_CheckedChanged);
            // 
            // rdbGrupal
            // 
            this.rdbGrupal.Location = new System.Drawing.Point(130, 40);
            this.rdbGrupal.Name = "rdbGrupal";
            this.rdbGrupal.Size = new System.Drawing.Size(73, 20);
            this.rdbGrupal.TabIndex = 2;
            this.rdbGrupal.Text = "Grupal";
            this.rdbGrupal.CheckedChanged += new System.EventHandler(this.rdbGrupal_CheckedChanged);
            // 
            // cmbGrupos
            // 
            this.cmbGrupos.Enabled = false;
            this.cmbGrupos.Location = new System.Drawing.Point(209, 40);
            this.cmbGrupos.Name = "cmbGrupos";
            this.cmbGrupos.Size = new System.Drawing.Size(150, 21);
            this.cmbGrupos.TabIndex = 3;
            // 
            // dtpInicio
            // 
            this.dtpInicio.Location = new System.Drawing.Point(20, 99);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(200, 20);
            this.dtpInicio.TabIndex = 4;
            // 
            // dtpFin
            // 
            this.dtpFin.Location = new System.Drawing.Point(230, 99);
            this.dtpFin.Name = "dtpFin";
            this.dtpFin.Size = new System.Drawing.Size(200, 20);
            this.dtpFin.TabIndex = 5;
            // 
            // txtPresupuesto
            // 
            this.txtPresupuesto.Location = new System.Drawing.Point(20, 150);
            this.txtPresupuesto.Name = "txtPresupuesto";
            this.txtPresupuesto.Size = new System.Drawing.Size(200, 20);
            this.txtPresupuesto.TabIndex = 6;
            // 
            // btnCalcular
            // 
            this.btnCalcular.Location = new System.Drawing.Point(230, 145);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(100, 25);
            this.btnCalcular.TabIndex = 7;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(522, 391);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(100, 25);
            this.btnVolver.TabIndex = 8;
            this.btnVolver.Text = "Volver";
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // lstReporte
            // 
            this.lstReporte.HideSelection = false;
            this.lstReporte.Location = new System.Drawing.Point(20, 185);
            this.lstReporte.Name = "lstReporte";
            this.lstReporte.Size = new System.Drawing.Size(602, 180);
            this.lstReporte.TabIndex = 9;
            this.lstReporte.UseCompatibleStateImageBehavior = false;
            this.lstReporte.View = System.Windows.Forms.View.Details;
            // 
            // lblResultado
            // 
            this.lblResultado.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblResultado.Location = new System.Drawing.Point(17, 391);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(300, 20);
            this.lblResultado.TabIndex = 10;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(180, 5);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(300, 30);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Calcular Saldo Neto";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Fecha inicio";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(227, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Fecha final";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Presupuesto";
            // 
            // SaldoForm
            // 
            this.ClientSize = new System.Drawing.Size(663, 442);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.rdbPersonal);
            this.Controls.Add(this.rdbGrupal);
            this.Controls.Add(this.cmbGrupos);
            this.Controls.Add(this.dtpInicio);
            this.Controls.Add(this.dtpFin);
            this.Controls.Add(this.txtPresupuesto);
            this.Controls.Add(this.btnCalcular);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.lstReporte);
            this.Controls.Add(this.lblResultado);
            this.Name = "SaldoForm";
            this.Text = "Calcular Saldo Neto";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.RadioButton rdbPersonal;
        private System.Windows.Forms.RadioButton rdbGrupal;
        private System.Windows.Forms.ComboBox cmbGrupos;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.DateTimePicker dtpFin;
        private System.Windows.Forms.TextBox txtPresupuesto;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.ListView lstReporte;
        private System.Windows.Forms.Label lblResultado;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}