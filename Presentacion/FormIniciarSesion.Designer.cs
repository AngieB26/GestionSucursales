namespace Presentacion
{
    partial class FormIniciarSesion
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
            this.txtIngresarContraseña = new System.Windows.Forms.TextBox();
            this.txtIngresarRuc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSalirUsuario = new System.Windows.Forms.Button();
            this.btnIniciarSesionUsuario = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtIngresarContraseña
            // 
            this.txtIngresarContraseña.Location = new System.Drawing.Point(103, 126);
            this.txtIngresarContraseña.Name = "txtIngresarContraseña";
            this.txtIngresarContraseña.Size = new System.Drawing.Size(120, 20);
            this.txtIngresarContraseña.TabIndex = 17;
            // 
            // txtIngresarRuc
            // 
            this.txtIngresarRuc.Location = new System.Drawing.Point(103, 93);
            this.txtIngresarRuc.Name = "txtIngresarRuc";
            this.txtIngresarRuc.Size = new System.Drawing.Size(120, 20);
            this.txtIngresarRuc.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(37, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Contraseña:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(71, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Ruc:";
            // 
            // btnSalirUsuario
            // 
            this.btnSalirUsuario.BackColor = System.Drawing.Color.Yellow;
            this.btnSalirUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalirUsuario.Location = new System.Drawing.Point(54, 225);
            this.btnSalirUsuario.Name = "btnSalirUsuario";
            this.btnSalirUsuario.Size = new System.Drawing.Size(153, 42);
            this.btnSalirUsuario.TabIndex = 13;
            this.btnSalirUsuario.Text = "Salir";
            this.btnSalirUsuario.UseVisualStyleBackColor = false;
            this.btnSalirUsuario.Click += new System.EventHandler(this.btnSalirUsuario_Click);
            // 
            // btnIniciarSesionUsuario
            // 
            this.btnIniciarSesionUsuario.BackColor = System.Drawing.Color.Yellow;
            this.btnIniciarSesionUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciarSesionUsuario.Location = new System.Drawing.Point(54, 174);
            this.btnIniciarSesionUsuario.Name = "btnIniciarSesionUsuario";
            this.btnIniciarSesionUsuario.Size = new System.Drawing.Size(153, 42);
            this.btnIniciarSesionUsuario.TabIndex = 12;
            this.btnIniciarSesionUsuario.Text = "Iniciar Sesión";
            this.btnIniciarSesionUsuario.UseVisualStyleBackColor = false;
            this.btnIniciarSesionUsuario.Click += new System.EventHandler(this.btnIniciarSesionUsuario_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label8.Location = new System.Drawing.Point(15, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(172, 29);
            this.label8.TabIndex = 90;
            this.label8.Text = "Iniciar Sesión";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Presentacion.Properties.Resources._149071;
            this.pictureBox1.Location = new System.Drawing.Point(189, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(43, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 93;
            this.pictureBox1.TabStop = false;
            // 
            // FormIniciarSesion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Red;
            this.ClientSize = new System.Drawing.Size(257, 300);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtIngresarContraseña);
            this.Controls.Add(this.txtIngresarRuc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSalirUsuario);
            this.Controls.Add(this.btnIniciarSesionUsuario);
            this.Name = "FormIniciarSesion";
            this.Text = "FormIniciarSesion";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtIngresarContraseña;
        private System.Windows.Forms.TextBox txtIngresarRuc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSalirUsuario;
        private System.Windows.Forms.Button btnIniciarSesionUsuario;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}