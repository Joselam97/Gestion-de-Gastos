
namespace GestionDeGastos.Views
{
    partial class GrupoForm
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
            this.txtNombreGrupo = new System.Windows.Forms.TextBox();
            this.clbUsuarios = new System.Windows.Forms.CheckedListBox();
            this.btnGuardarGrupo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtNombreGrupo
            // 
            this.txtNombreGrupo.Location = new System.Drawing.Point(56, 75);
            this.txtNombreGrupo.Name = "txtNombreGrupo";
            this.txtNombreGrupo.Size = new System.Drawing.Size(143, 20);
            this.txtNombreGrupo.TabIndex = 0;
            // 
            // clbUsuarios
            // 
            this.clbUsuarios.FormattingEnabled = true;
            this.clbUsuarios.Location = new System.Drawing.Point(65, 143);
            this.clbUsuarios.Name = "clbUsuarios";
            this.clbUsuarios.Size = new System.Drawing.Size(120, 94);
            this.clbUsuarios.TabIndex = 1;
            // 
            // btnGuardarGrupo
            // 
            this.btnGuardarGrupo.Location = new System.Drawing.Point(72, 268);
            this.btnGuardarGrupo.Name = "btnGuardarGrupo";
            this.btnGuardarGrupo.Size = new System.Drawing.Size(100, 23);
            this.btnGuardarGrupo.TabIndex = 0;
            this.btnGuardarGrupo.Text = "Guardar";
            this.btnGuardarGrupo.UseVisualStyleBackColor = true;
            this.btnGuardarGrupo.Click += new System.EventHandler(this.btnGuardarGrupo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(81, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nombre de Grupo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(81, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Lista de Usuarios";
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(84, 362);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(75, 23);
            this.btnVolver.TabIndex = 5;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // GrupoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 406);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGuardarGrupo);
            this.Controls.Add(this.clbUsuarios);
            this.Controls.Add(this.txtNombreGrupo);
            this.Name = "GrupoForm";
            this.Text = "GrupoForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNombreGrupo;
        private System.Windows.Forms.CheckedListBox clbUsuarios;
        private System.Windows.Forms.Button btnGuardarGrupo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;

        private void btnGuardarGrupo_Click_1(object sender, System.EventArgs e)
        {

        }

        private void btnVolver_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}