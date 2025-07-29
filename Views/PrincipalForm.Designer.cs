namespace GestionDeGastos.Views
{
    partial class PrincipalForm
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
            this.lblNombre = new System.Windows.Forms.Label();
            this.pictureBoxAvatar = new System.Windows.Forms.PictureBox();
            this.btnGrupos = new System.Windows.Forms.Button();
            this.btnGastos = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.btnGestionarGrupos = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSaldo = new System.Windows.Forms.Button();
            this.btnReporteGastos = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(248, 54);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 19);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "label1";
            this.lblNombre.Click += new System.EventHandler(this.lblNombre_Click);
            // 
            // pictureBoxAvatar
            // 
            this.pictureBoxAvatar.Location = new System.Drawing.Point(252, 98);
            this.pictureBoxAvatar.Name = "pictureBoxAvatar";
            this.pictureBoxAvatar.Size = new System.Drawing.Size(171, 143);
            this.pictureBoxAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxAvatar.TabIndex = 1;
            this.pictureBoxAvatar.TabStop = false;
            // 
            // btnGrupos
            // 
            this.btnGrupos.Location = new System.Drawing.Point(48, 98);
            this.btnGrupos.Name = "btnGrupos";
            this.btnGrupos.Size = new System.Drawing.Size(112, 23);
            this.btnGrupos.TabIndex = 3;
            this.btnGrupos.Text = "Grupos";
            this.btnGrupos.UseVisualStyleBackColor = true;
            this.btnGrupos.Click += new System.EventHandler(this.btnGrupos_Click);
            // 
            // btnGastos
            // 
            this.btnGastos.Location = new System.Drawing.Point(48, 156);
            this.btnGastos.Name = "btnGastos";
            this.btnGastos.Size = new System.Drawing.Size(112, 23);
            this.btnGastos.TabIndex = 4;
            this.btnGastos.Text = "Ingresar Gastos";
            this.btnGastos.UseVisualStyleBackColor = true;
            this.btnGastos.Click += new System.EventHandler(this.btnGastos_Click);
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Location = new System.Drawing.Point(145, 308);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(112, 23);
            this.btnCerrarSesion.TabIndex = 5;
            this.btnCerrarSesion.Text = "Cerrar Sesion";
            this.btnCerrarSesion.UseVisualStyleBackColor = true;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // btnGestionarGrupos
            // 
            this.btnGestionarGrupos.Location = new System.Drawing.Point(48, 127);
            this.btnGestionarGrupos.Name = "btnGestionarGrupos";
            this.btnGestionarGrupos.Size = new System.Drawing.Size(112, 23);
            this.btnGestionarGrupos.TabIndex = 6;
            this.btnGestionarGrupos.Text = "Gestionar Grupos";
            this.btnGestionarGrupos.UseVisualStyleBackColor = true;
            this.btnGestionarGrupos.Click += new System.EventHandler(this.btnGestionarGrupos_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(183, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 19);
            this.label1.TabIndex = 7;
            this.label1.Text = "Inicio";
            // 
            // btnSaldo
            // 
            this.btnSaldo.Location = new System.Drawing.Point(48, 214);
            this.btnSaldo.Name = "btnSaldo";
            this.btnSaldo.Size = new System.Drawing.Size(112, 23);
            this.btnSaldo.TabIndex = 8;
            this.btnSaldo.Text = "Calcular Saldo Neto";
            this.btnSaldo.UseVisualStyleBackColor = true;
            this.btnSaldo.Click += new System.EventHandler(this.btnSaldo_Click);
            // 
            // btnReporteGastos
            // 
            this.btnReporteGastos.Location = new System.Drawing.Point(48, 185);
            this.btnReporteGastos.Name = "btnReporteGastos";
            this.btnReporteGastos.Size = new System.Drawing.Size(112, 23);
            this.btnReporteGastos.TabIndex = 9;
            this.btnReporteGastos.Text = "Reporte Gastos";
            this.btnReporteGastos.UseVisualStyleBackColor = true;
            this.btnReporteGastos.Click += new System.EventHandler(this.btnReporteGastos_Click);
            // 
            // PrincipalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 362);
            this.Controls.Add(this.btnReporteGastos);
            this.Controls.Add(this.btnSaldo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGestionarGrupos);
            this.Controls.Add(this.btnCerrarSesion);
            this.Controls.Add(this.btnGastos);
            this.Controls.Add(this.btnGrupos);
            this.Controls.Add(this.pictureBoxAvatar);
            this.Controls.Add(this.lblNombre);
            this.Name = "PrincipalForm";
            this.Text = "PrincipalForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAvatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.PictureBox pictureBoxAvatar;
        private System.Windows.Forms.Button btnGrupos;
        private System.Windows.Forms.Button btnGastos;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Button btnGestionarGrupos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSaldo;
        private System.Windows.Forms.Button btnReporteGastos;
    }
}