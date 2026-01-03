namespace Presentacion
{
    partial class FormSupervisores
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnEliminarSupervisor = new System.Windows.Forms.Button();
            this.btnModificarSupervisor = new System.Windows.Forms.Button();
            this.btnSalirSupervisor = new System.Windows.Forms.Button();
            this.dtFechaIngresoSupervisor = new System.Windows.Forms.DateTimePicker();
            this.txtCorreoSupervisor = new System.Windows.Forms.TextBox();
            this.btnRegistrarSupervisor = new System.Windows.Forms.Button();
            this.txtTelefonoSupervisor = new System.Windows.Forms.TextBox();
            this.txtNombreSupervisor = new System.Windows.Forms.TextBox();
            this.txtCodigoSupervisor = new System.Windows.Forms.TextBox();
            this.dgSupervisor = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgSupervisor)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEliminarSupervisor
            // 
            this.btnEliminarSupervisor.BackColor = System.Drawing.Color.Yellow;
            this.btnEliminarSupervisor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarSupervisor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnEliminarSupervisor.Location = new System.Drawing.Point(376, 360);
            this.btnEliminarSupervisor.Name = "btnEliminarSupervisor";
            this.btnEliminarSupervisor.Size = new System.Drawing.Size(158, 33);
            this.btnEliminarSupervisor.TabIndex = 61;
            this.btnEliminarSupervisor.Text = "Eliminar Supervisor";
            this.btnEliminarSupervisor.UseVisualStyleBackColor = false;
            this.btnEliminarSupervisor.Click += new System.EventHandler(this.btnEliminarSupervisor_Click);
            // 
            // btnModificarSupervisor
            // 
            this.btnModificarSupervisor.BackColor = System.Drawing.Color.Yellow;
            this.btnModificarSupervisor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarSupervisor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnModificarSupervisor.Location = new System.Drawing.Point(212, 360);
            this.btnModificarSupervisor.Name = "btnModificarSupervisor";
            this.btnModificarSupervisor.Size = new System.Drawing.Size(158, 33);
            this.btnModificarSupervisor.TabIndex = 60;
            this.btnModificarSupervisor.Text = "Modificar Supervisor";
            this.btnModificarSupervisor.UseVisualStyleBackColor = false;
            this.btnModificarSupervisor.Click += new System.EventHandler(this.btnModificarSupervisor_Click);
            // 
            // btnSalirSupervisor
            // 
            this.btnSalirSupervisor.BackColor = System.Drawing.Color.Yellow;
            this.btnSalirSupervisor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalirSupervisor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSalirSupervisor.Location = new System.Drawing.Point(540, 360);
            this.btnSalirSupervisor.Name = "btnSalirSupervisor";
            this.btnSalirSupervisor.Size = new System.Drawing.Size(108, 33);
            this.btnSalirSupervisor.TabIndex = 59;
            this.btnSalirSupervisor.Text = "Salir";
            this.btnSalirSupervisor.UseVisualStyleBackColor = false;
            this.btnSalirSupervisor.Click += new System.EventHandler(this.btnSalirSupervisor_Click);
            // 
            // dtFechaIngresoSupervisor
            // 
            this.dtFechaIngresoSupervisor.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaIngresoSupervisor.Location = new System.Drawing.Point(452, 119);
            this.dtFechaIngresoSupervisor.Name = "dtFechaIngresoSupervisor";
            this.dtFechaIngresoSupervisor.Size = new System.Drawing.Size(200, 20);
            this.dtFechaIngresoSupervisor.TabIndex = 58;
            // 
            // txtCorreoSupervisor
            // 
            this.txtCorreoSupervisor.Location = new System.Drawing.Point(291, 119);
            this.txtCorreoSupervisor.Name = "txtCorreoSupervisor";
            this.txtCorreoSupervisor.Size = new System.Drawing.Size(126, 20);
            this.txtCorreoSupervisor.TabIndex = 57;
            // 
            // btnRegistrarSupervisor
            // 
            this.btnRegistrarSupervisor.BackColor = System.Drawing.Color.Yellow;
            this.btnRegistrarSupervisor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrarSupervisor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnRegistrarSupervisor.Location = new System.Drawing.Point(48, 360);
            this.btnRegistrarSupervisor.Name = "btnRegistrarSupervisor";
            this.btnRegistrarSupervisor.Size = new System.Drawing.Size(158, 33);
            this.btnRegistrarSupervisor.TabIndex = 56;
            this.btnRegistrarSupervisor.Text = "Registrar Supervisor";
            this.btnRegistrarSupervisor.UseVisualStyleBackColor = false;
            this.btnRegistrarSupervisor.Click += new System.EventHandler(this.btnRegistrarSupervisor_Click);
            // 
            // txtTelefonoSupervisor
            // 
            this.txtTelefonoSupervisor.Location = new System.Drawing.Point(291, 88);
            this.txtTelefonoSupervisor.Name = "txtTelefonoSupervisor";
            this.txtTelefonoSupervisor.Size = new System.Drawing.Size(125, 20);
            this.txtTelefonoSupervisor.TabIndex = 55;
            // 
            // txtNombreSupervisor
            // 
            this.txtNombreSupervisor.Location = new System.Drawing.Point(88, 119);
            this.txtNombreSupervisor.Name = "txtNombreSupervisor";
            this.txtNombreSupervisor.Size = new System.Drawing.Size(125, 20);
            this.txtNombreSupervisor.TabIndex = 54;
            // 
            // txtCodigoSupervisor
            // 
            this.txtCodigoSupervisor.Location = new System.Drawing.Point(88, 88);
            this.txtCodigoSupervisor.Name = "txtCodigoSupervisor";
            this.txtCodigoSupervisor.Size = new System.Drawing.Size(125, 20);
            this.txtCodigoSupervisor.TabIndex = 53;
            // 
            // dgSupervisor
            // 
            this.dgSupervisor.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgSupervisor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgSupervisor.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgSupervisor.Location = new System.Drawing.Point(34, 164);
            this.dgSupervisor.Name = "dgSupervisor";
            this.dgSupervisor.Size = new System.Drawing.Size(636, 173);
            this.dgSupervisor.TabIndex = 52;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(449, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 51;
            this.label5.Text = "Fecha de ingreso:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(249, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 50;
            this.label4.Text = "Correo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(236, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 49;
            this.label3.Text = "Teléfono:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(39, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 48;
            this.label2.Text = "Nombre:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(42, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 47;
            this.label1.Text = "Código:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label8.Location = new System.Drawing.Point(273, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(185, 31);
            this.label8.TabIndex = 87;
            this.label8.Text = "Supervisores";
            // 
            // FormSupervisores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Red;
            this.ClientSize = new System.Drawing.Size(707, 424);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnEliminarSupervisor);
            this.Controls.Add(this.btnModificarSupervisor);
            this.Controls.Add(this.btnSalirSupervisor);
            this.Controls.Add(this.dtFechaIngresoSupervisor);
            this.Controls.Add(this.txtCorreoSupervisor);
            this.Controls.Add(this.btnRegistrarSupervisor);
            this.Controls.Add(this.txtTelefonoSupervisor);
            this.Controls.Add(this.txtNombreSupervisor);
            this.Controls.Add(this.txtCodigoSupervisor);
            this.Controls.Add(this.dgSupervisor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Name = "FormSupervisores";
            this.Text = "FormSupervisores";
            ((System.ComponentModel.ISupportInitialize)(this.dgSupervisor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEliminarSupervisor;
        private System.Windows.Forms.Button btnModificarSupervisor;
        private System.Windows.Forms.Button btnSalirSupervisor;
        private System.Windows.Forms.DateTimePicker dtFechaIngresoSupervisor;
        private System.Windows.Forms.TextBox txtCorreoSupervisor;
        private System.Windows.Forms.Button btnRegistrarSupervisor;
        private System.Windows.Forms.TextBox txtTelefonoSupervisor;
        private System.Windows.Forms.TextBox txtNombreSupervisor;
        private System.Windows.Forms.TextBox txtCodigoSupervisor;
        private System.Windows.Forms.DataGridView dgSupervisor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
    }
}