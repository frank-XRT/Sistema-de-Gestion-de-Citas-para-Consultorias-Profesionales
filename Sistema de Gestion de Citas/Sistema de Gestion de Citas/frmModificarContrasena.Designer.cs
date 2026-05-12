namespace Sistema_de_Gestion_de_Citas
{
    partial class frmModificarContrasena
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblContrasenaActual = new System.Windows.Forms.Label();
            this.txtContrasenaActual = new System.Windows.Forms.TextBox();
            this.lblContrasenaNueva = new System.Windows.Forms.Label();
            this.txtContrasenaNueva = new System.Windows.Forms.TextBox();
            this.lblVerificarContrasena = new System.Windows.Forms.Label();
            this.txtVerificarContrasena = new System.Windows.Forms.TextBox();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(120, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(200, 20);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Modificar contrasena";
            // 
            // lblContrasenaActual
            // 
            this.lblContrasenaActual.AutoSize = true;
            this.lblContrasenaActual.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContrasenaActual.Location = new System.Drawing.Point(30, 70);
            this.lblContrasenaActual.Name = "lblContrasenaActual";
            this.lblContrasenaActual.Size = new System.Drawing.Size(150, 20);
            this.lblContrasenaActual.TabIndex = 1;
            this.lblContrasenaActual.Text = "Contrasena actual";
            // 
            // txtContrasenaActual
            // 
            this.txtContrasenaActual.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContrasenaActual.Location = new System.Drawing.Point(210, 67);
            this.txtContrasenaActual.Name = "txtContrasenaActual";
            this.txtContrasenaActual.Size = new System.Drawing.Size(200, 26);
            this.txtContrasenaActual.TabIndex = 2;
            // 
            // lblContrasenaNueva
            // 
            this.lblContrasenaNueva.AutoSize = true;
            this.lblContrasenaNueva.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContrasenaNueva.Location = new System.Drawing.Point(30, 120);
            this.lblContrasenaNueva.Name = "lblContrasenaNueva";
            this.lblContrasenaNueva.Size = new System.Drawing.Size(150, 20);
            this.lblContrasenaNueva.TabIndex = 3;
            this.lblContrasenaNueva.Text = "Contrasena nueva";
            // 
            // txtContrasenaNueva
            // 
            this.txtContrasenaNueva.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContrasenaNueva.Location = new System.Drawing.Point(210, 117);
            this.txtContrasenaNueva.Name = "txtContrasenaNueva";
            this.txtContrasenaNueva.Size = new System.Drawing.Size(200, 26);
            this.txtContrasenaNueva.TabIndex = 4;
            // 
            // lblVerificarContrasena
            // 
            this.lblVerificarContrasena.AutoSize = true;
            this.lblVerificarContrasena.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVerificarContrasena.Location = new System.Drawing.Point(30, 170);
            this.lblVerificarContrasena.Name = "lblVerificarContrasena";
            this.lblVerificarContrasena.Size = new System.Drawing.Size(170, 20);
            this.lblVerificarContrasena.TabIndex = 5;
            this.lblVerificarContrasena.Text = "Verifique su contrasena";
            // 
            // txtVerificarContrasena
            // 
            this.txtVerificarContrasena.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVerificarContrasena.Location = new System.Drawing.Point(210, 167);
            this.txtVerificarContrasena.Name = "txtVerificarContrasena";
            this.txtVerificarContrasena.Size = new System.Drawing.Size(200, 26);
            this.txtVerificarContrasena.TabIndex = 6;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmar.Location = new System.Drawing.Point(150, 220);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(140, 35);
            this.btnConfirmar.TabIndex = 7;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // frmModificarContrasena
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 280);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.txtVerificarContrasena);
            this.Controls.Add(this.lblVerificarContrasena);
            this.Controls.Add(this.txtContrasenaNueva);
            this.Controls.Add(this.lblContrasenaNueva);
            this.Controls.Add(this.txtContrasenaActual);
            this.Controls.Add(this.lblContrasenaActual);
            this.Controls.Add(this.lblTitulo);
            this.Name = "frmModificarContrasena";
            this.Text = "Modificar contrasena";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblContrasenaActual;
        private System.Windows.Forms.TextBox txtContrasenaActual;
        private System.Windows.Forms.Label lblContrasenaNueva;
        private System.Windows.Forms.TextBox txtContrasenaNueva;
        private System.Windows.Forms.Label lblVerificarContrasena;
        private System.Windows.Forms.TextBox txtVerificarContrasena;
        private System.Windows.Forms.Button btnConfirmar;
    }
}
