namespace GestionDeGastos.Views
{
    partial class GestionarGruposForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnVerGrupos = new System.Windows.Forms.Button();
            this.btnEliminarGrupo = new System.Windows.Forms.Button();
            this.btnModificarGrupo = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.lstGrupos = new System.Windows.Forms.ListBox();
            this.lblIntegrantes = new System.Windows.Forms.Label();
            this.lstIntegrantesActuales = new System.Windows.Forms.ListBox();
            this.lblUsuariosDisponibles = new System.Windows.Forms.Label();
            this.chkUsuarios = new System.Windows.Forms.CheckedListBox();
            this.btnAgregarUsuarios = new System.Windows.Forms.Button();
            this.txtNuevoNombreGrupo = new System.Windows.Forms.TextBox();
            this.btnCambiarNombre = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnVerGrupos
            // 
            this.btnVerGrupos.Location = new System.Drawing.Point(20, 24);
            this.btnVerGrupos.Name = "btnVerGrupos";
            this.btnVerGrupos.Size = new System.Drawing.Size(75, 23);
            this.btnVerGrupos.TabIndex = 0;
            this.btnVerGrupos.Text = "Ver Grupos";
            this.btnVerGrupos.UseVisualStyleBackColor = true;
            this.btnVerGrupos.Click += new System.EventHandler(this.btnVerGrupos_Click);
            // 
            // btnEliminarGrupo
            // 
            this.btnEliminarGrupo.Location = new System.Drawing.Point(342, 24);
            this.btnEliminarGrupo.Name = "btnEliminarGrupo";
            this.btnEliminarGrupo.Size = new System.Drawing.Size(122, 23);
            this.btnEliminarGrupo.TabIndex = 1;
            this.btnEliminarGrupo.Text = "Eliminar Grupo";
            this.btnEliminarGrupo.UseVisualStyleBackColor = true;
            this.btnEliminarGrupo.Click += new System.EventHandler(this.btnEliminarGrupo_Click);
            // 
            // btnModificarGrupo
            // 
            this.btnModificarGrupo.Location = new System.Drawing.Point(170, 24);
            this.btnModificarGrupo.Name = "btnModificarGrupo";
            this.btnModificarGrupo.Size = new System.Drawing.Size(150, 23);
            this.btnModificarGrupo.TabIndex = 2;
            this.btnModificarGrupo.Text = "Modificar Grupo";
            this.btnModificarGrupo.UseVisualStyleBackColor = true;
            this.btnModificarGrupo.Click += new System.EventHandler(this.btnModificarGrupo_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(192, 435);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(75, 23);
            this.btnVolver.TabIndex = 3;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // lstGrupos
            // 
            this.lstGrupos.FormattingEnabled = true;
            this.lstGrupos.Location = new System.Drawing.Point(23, 53);
            this.lstGrupos.Name = "lstGrupos";
            this.lstGrupos.Size = new System.Drawing.Size(109, 69);
            this.lstGrupos.TabIndex = 4;
            // 
            // lblIntegrantes
            // 
            this.lblIntegrantes.Location = new System.Drawing.Point(20, 203);
            this.lblIntegrantes.Name = "lblIntegrantes";
            this.lblIntegrantes.Size = new System.Drawing.Size(150, 20);
            this.lblIntegrantes.TabIndex = 5;
            this.lblIntegrantes.Text = "Integrantes actuales:";
            // 
            // lstIntegrantesActuales
            // 
            this.lstIntegrantesActuales.Location = new System.Drawing.Point(20, 225);
            this.lstIntegrantesActuales.Name = "lstIntegrantesActuales";
            this.lstIntegrantesActuales.Size = new System.Drawing.Size(150, 95);
            this.lstIntegrantesActuales.TabIndex = 6;
            this.lstIntegrantesActuales.DoubleClick += new System.EventHandler(this.lstIntegrantesActuales_DoubleClick);
            // 
            // lblUsuariosDisponibles
            // 
            this.lblUsuariosDisponibles.Location = new System.Drawing.Point(272, 203);
            this.lblUsuariosDisponibles.Name = "lblUsuariosDisponibles";
            this.lblUsuariosDisponibles.Size = new System.Drawing.Size(150, 20);
            this.lblUsuariosDisponibles.TabIndex = 7;
            this.lblUsuariosDisponibles.Text = "Usuarios disponibles:";
            // 
            // chkUsuarios
            // 
            this.chkUsuarios.Location = new System.Drawing.Point(275, 225);
            this.chkUsuarios.Name = "chkUsuarios";
            this.chkUsuarios.Size = new System.Drawing.Size(150, 94);
            this.chkUsuarios.TabIndex = 8;
            // 
            // btnAgregarUsuarios
            // 
            this.btnAgregarUsuarios.Location = new System.Drawing.Point(272, 326);
            this.btnAgregarUsuarios.Name = "btnAgregarUsuarios";
            this.btnAgregarUsuarios.Size = new System.Drawing.Size(82, 23);
            this.btnAgregarUsuarios.TabIndex = 9;
            this.btnAgregarUsuarios.Text = "Agregar";
            this.btnAgregarUsuarios.Click += new System.EventHandler(this.btnAgregarUsuarios_Click);
            // 
            // txtNuevoNombreGrupo
            // 
            this.txtNuevoNombreGrupo.Location = new System.Drawing.Point(170, 102);
            this.txtNuevoNombreGrupo.Name = "txtNuevoNombreGrupo";
            this.txtNuevoNombreGrupo.Size = new System.Drawing.Size(150, 20);
            this.txtNuevoNombreGrupo.TabIndex = 10;
            // 
            // btnCambiarNombre
            // 
            this.btnCambiarNombre.Location = new System.Drawing.Point(192, 128);
            this.btnCambiarNombre.Name = "btnCambiarNombre";
            this.btnCambiarNombre.Size = new System.Drawing.Size(112, 23);
            this.btnCambiarNombre.TabIndex = 11;
            this.btnCambiarNombre.Text = "Cambiar Nombre";
            this.btnCambiarNombre.Click += new System.EventHandler(this.btnCambiarNombre_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(189, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Grupo Seleccionado";
            // 
            // GestionarGruposForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 470);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstGrupos);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnModificarGrupo);
            this.Controls.Add(this.btnEliminarGrupo);
            this.Controls.Add(this.btnVerGrupos);
            this.Controls.Add(this.lblIntegrantes);
            this.Controls.Add(this.lstIntegrantesActuales);
            this.Controls.Add(this.lblUsuariosDisponibles);
            this.Controls.Add(this.chkUsuarios);
            this.Controls.Add(this.btnAgregarUsuarios);
            this.Controls.Add(this.txtNuevoNombreGrupo);
            this.Controls.Add(this.btnCambiarNombre);
            this.Name = "GestionarGruposForm";
            this.Text = "GestionarGruposForm";
            this.Load += new System.EventHandler(this.GestionarGruposForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnVerGrupos;
        private System.Windows.Forms.Button btnEliminarGrupo;
        private System.Windows.Forms.Button btnModificarGrupo;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.ListBox lstGrupos;
        private System.Windows.Forms.Label lblIntegrantes;
        private System.Windows.Forms.ListBox lstIntegrantesActuales;
        private System.Windows.Forms.Label lblUsuariosDisponibles;
        private System.Windows.Forms.CheckedListBox chkUsuarios;
        private System.Windows.Forms.Button btnAgregarUsuarios;
        private System.Windows.Forms.TextBox txtNuevoNombreGrupo;
        private System.Windows.Forms.Button btnCambiarNombre;
        private System.Windows.Forms.Label label1;
    }
}