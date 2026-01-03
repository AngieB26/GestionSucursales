namespace Presentacion
{
    partial class FormReportes
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
            this.btnMenosStock = new System.Windows.Forms.Button();
            this.btnSupervisoresPorCodigoSucursal = new System.Windows.Forms.Button();
            this.btnProductosPorSucursal = new System.Windows.Forms.Button();
            this.ProductosPorCategoria = new System.Windows.Forms.Button();
            this.dgProducto = new System.Windows.Forms.DataGridView();
            this.dgSucursal = new System.Windows.Forms.DataGridView();
            this.dgSupervisor = new System.Windows.Forms.DataGridView();
            this.txtCodigoSucursal = new System.Windows.Forms.TextBox();
            this.cbCategoríaProducto = new System.Windows.Forms.ComboBox();
            this.txtNombreSucursal = new System.Windows.Forms.TextBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgProducto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgSucursal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgSupervisor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnMenosStock
            // 
            this.btnMenosStock.BackColor = System.Drawing.Color.Yellow;
            this.btnMenosStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenosStock.Location = new System.Drawing.Point(30, 83);
            this.btnMenosStock.Name = "btnMenosStock";
            this.btnMenosStock.Size = new System.Drawing.Size(128, 51);
            this.btnMenosStock.TabIndex = 0;
            this.btnMenosStock.Text = "Listar Sucursales con menos Stock de Productos";
            this.btnMenosStock.UseVisualStyleBackColor = false;
            this.btnMenosStock.Click += new System.EventHandler(this.btnMenosStock_Click);
            // 
            // btnSupervisoresPorCodigoSucursal
            // 
            this.btnSupervisoresPorCodigoSucursal.BackColor = System.Drawing.Color.Yellow;
            this.btnSupervisoresPorCodigoSucursal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupervisoresPorCodigoSucursal.Location = new System.Drawing.Point(30, 197);
            this.btnSupervisoresPorCodigoSucursal.Name = "btnSupervisoresPorCodigoSucursal";
            this.btnSupervisoresPorCodigoSucursal.Size = new System.Drawing.Size(128, 48);
            this.btnSupervisoresPorCodigoSucursal.TabIndex = 1;
            this.btnSupervisoresPorCodigoSucursal.Text = "Listar Supervisores Por codigo de Sucursal";
            this.btnSupervisoresPorCodigoSucursal.UseVisualStyleBackColor = false;
            this.btnSupervisoresPorCodigoSucursal.Click += new System.EventHandler(this.btnSupervisoresPorCodigoSucursal_Click_1);
            // 
            // btnProductosPorSucursal
            // 
            this.btnProductosPorSucursal.BackColor = System.Drawing.Color.Yellow;
            this.btnProductosPorSucursal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProductosPorSucursal.Location = new System.Drawing.Point(30, 292);
            this.btnProductosPorSucursal.Name = "btnProductosPorSucursal";
            this.btnProductosPorSucursal.Size = new System.Drawing.Size(128, 47);
            this.btnProductosPorSucursal.TabIndex = 2;
            this.btnProductosPorSucursal.Text = "Listar Productos Por Nombre de Sucursal";
            this.btnProductosPorSucursal.UseVisualStyleBackColor = false;
            this.btnProductosPorSucursal.Click += new System.EventHandler(this.btnProductosPorSucursal_Click);
            // 
            // ProductosPorCategoria
            // 
            this.ProductosPorCategoria.BackColor = System.Drawing.Color.Yellow;
            this.ProductosPorCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductosPorCategoria.Location = new System.Drawing.Point(30, 345);
            this.ProductosPorCategoria.Name = "ProductosPorCategoria";
            this.ProductosPorCategoria.Size = new System.Drawing.Size(128, 53);
            this.ProductosPorCategoria.TabIndex = 3;
            this.ProductosPorCategoria.Text = "Listar Productos Por Categoria ";
            this.ProductosPorCategoria.UseVisualStyleBackColor = false;
            this.ProductosPorCategoria.Click += new System.EventHandler(this.ProductosPorCategoria_Click);
            // 
            // dgProducto
            // 
            this.dgProducto.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgProducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProducto.Location = new System.Drawing.Point(290, 292);
            this.dgProducto.Name = "dgProducto";
            this.dgProducto.Size = new System.Drawing.Size(533, 151);
            this.dgProducto.TabIndex = 40;
            // 
            // dgSucursal
            // 
            this.dgSucursal.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgSucursal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSucursal.Location = new System.Drawing.Point(290, 65);
            this.dgSucursal.Name = "dgSucursal";
            this.dgSucursal.Size = new System.Drawing.Size(533, 92);
            this.dgSucursal.TabIndex = 42;
            // 
            // dgSupervisor
            // 
            this.dgSupervisor.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgSupervisor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSupervisor.Location = new System.Drawing.Point(290, 175);
            this.dgSupervisor.Name = "dgSupervisor";
            this.dgSupervisor.Size = new System.Drawing.Size(533, 97);
            this.dgSupervisor.TabIndex = 53;
            // 
            // txtCodigoSucursal
            // 
            this.txtCodigoSucursal.Location = new System.Drawing.Point(164, 212);
            this.txtCodigoSucursal.Name = "txtCodigoSucursal";
            this.txtCodigoSucursal.Size = new System.Drawing.Size(112, 20);
            this.txtCodigoSucursal.TabIndex = 54;
            // 
            // cbCategoríaProducto
            // 
            this.cbCategoríaProducto.FormattingEnabled = true;
            this.cbCategoríaProducto.Items.AddRange(new object[] {
            "Carnes",
            "Aves",
            "Pescados",
            "Lácteos",
            "Frutas y Verduras",
            "Abarrotes",
            "Quesos y Fiambres",
            "Licores",
            "Cervezas",
            "Cuidado Personal",
            "Mundo Bebé",
            "Limpieza"});
            this.cbCategoríaProducto.Location = new System.Drawing.Point(164, 346);
            this.cbCategoríaProducto.Name = "cbCategoríaProducto";
            this.cbCategoríaProducto.Size = new System.Drawing.Size(112, 21);
            this.cbCategoríaProducto.TabIndex = 55;
            // 
            // txtNombreSucursal
            // 
            this.txtNombreSucursal.Location = new System.Drawing.Point(164, 294);
            this.txtNombreSucursal.Name = "txtNombreSucursal";
            this.txtNombreSucursal.Size = new System.Drawing.Size(112, 20);
            this.txtNombreSucursal.TabIndex = 56;
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.Yellow;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Location = new System.Drawing.Point(30, 411);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(128, 32);
            this.btnSalir.TabIndex = 57;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label8.Location = new System.Drawing.Point(340, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(133, 31);
            this.label8.TabIndex = 88;
            this.label8.Text = "Reportes";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Presentacion.Properties.Resources._10215218;
            this.pictureBox1.Location = new System.Drawing.Point(180, 74);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(90, 74);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 89;
            this.pictureBox1.TabStop = false;
            // 
            // FormReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Red;
            this.ClientSize = new System.Drawing.Size(855, 472);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.txtNombreSucursal);
            this.Controls.Add(this.cbCategoríaProducto);
            this.Controls.Add(this.txtCodigoSucursal);
            this.Controls.Add(this.dgSupervisor);
            this.Controls.Add(this.dgSucursal);
            this.Controls.Add(this.dgProducto);
            this.Controls.Add(this.ProductosPorCategoria);
            this.Controls.Add(this.btnProductosPorSucursal);
            this.Controls.Add(this.btnSupervisoresPorCodigoSucursal);
            this.Controls.Add(this.btnMenosStock);
            this.Name = "FormReportes";
            this.Text = "FormReportes";
            ((System.ComponentModel.ISupportInitialize)(this.dgProducto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgSucursal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgSupervisor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMenosStock;
        private System.Windows.Forms.Button btnSupervisoresPorCodigoSucursal;
        private System.Windows.Forms.Button btnProductosPorSucursal;
        private System.Windows.Forms.Button ProductosPorCategoria;
        private System.Windows.Forms.DataGridView dgProducto;
        private System.Windows.Forms.DataGridView dgSucursal;
        private System.Windows.Forms.DataGridView dgSupervisor;
        private System.Windows.Forms.TextBox txtCodigoSucursal;
        private System.Windows.Forms.ComboBox cbCategoríaProducto;
        private System.Windows.Forms.TextBox txtNombreSucursal;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}