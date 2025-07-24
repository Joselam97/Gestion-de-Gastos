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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrincipalForm));
            this.lblNombre = new System.Windows.Forms.Label();
            this.pictureBoxAvatar = new System.Windows.Forms.PictureBox();
            this.btnGrupos = new System.Windows.Forms.Button();
            this.btnGastos = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(353, 9);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 19);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "label1";
            this.lblNombre.Click += new System.EventHandler(this.lblNombre_Click);
            // 
            // pictureBoxAvatar
            // 
        
            this.pictureBoxAvatar.Location = new System.Drawing.Point(318, 64);
            this.pictureBoxAvatar.Name = "pictureBoxAvatar";
            this.pictureBoxAvatar.Size = new System.Drawing.Size(189, 201);
            this.pictureBoxAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxAvatar.TabIndex = 1;
            this.pictureBoxAvatar.TabStop = false;
            // 
            // btnGrupos
            // 
            this.btnGrupos.Location = new System.Drawing.Point(171, 143);
            this.btnGrupos.Name = "btnGrupos";
            this.btnGrupos.Size = new System.Drawing.Size(75, 23);
            this.btnGrupos.TabIndex = 3;
            this.btnGrupos.Text = "Grupos";
            this.btnGrupos.UseVisualStyleBackColor = true;
            this.btnGrupos.Click += new System.EventHandler(this.btnGrupos_Click);
            // 
            // btnGastos
            // 
            this.btnGastos.Location = new System.Drawing.Point(171, 204);
            this.btnGastos.Name = "btnGastos";
            this.btnGastos.Size = new System.Drawing.Size(75, 23);
            this.btnGastos.TabIndex = 4;
            this.btnGastos.Text = "Gastos";
            this.btnGastos.UseVisualStyleBackColor = true;
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Location = new System.Drawing.Point(153, 303);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(112, 23);
            this.btnCerrarSesion.TabIndex = 5;
            this.btnCerrarSesion.Text = "Cerrar Sesion";
            this.btnCerrarSesion.UseVisualStyleBackColor = true;
            // 
            // PrincipalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 362);
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
    }
}