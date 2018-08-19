namespace Lowes
{
    partial class frmProducto
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
            this.txtIdProducto = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblIdProducto = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEliminate = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.dgbProductos = new System.Windows.Forms.DataGridView();
            this.lblPrecioVenta = new System.Windows.Forms.Label();
            this.lblPrecioCompra = new System.Windows.Forms.Label();
            this.txtPrecioVenta = new System.Windows.Forms.TextBox();
            this.txtPrecioCompra = new System.Windows.Forms.TextBox();
            this.lblUnidad = new System.Windows.Forms.Label();
            this.txtUnidad = new System.Windows.Forms.TextBox();
            this.lblIdCategoria = new System.Windows.Forms.Label();
            this.lblInventario = new System.Windows.Forms.Label();
            this.txtInventario = new System.Windows.Forms.TextBox();
            this.cbxIdCategoria = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgbProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // txtIdProducto
            // 
            this.txtIdProducto.Location = new System.Drawing.Point(260, 208);
            this.txtIdProducto.Name = "txtIdProducto";
            this.txtIdProducto.Size = new System.Drawing.Size(100, 20);
            this.txtIdProducto.TabIndex = 0;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(260, 247);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // lblIdProducto
            // 
            this.lblIdProducto.AutoSize = true;
            this.lblIdProducto.Location = new System.Drawing.Point(164, 211);
            this.lblIdProducto.Name = "lblIdProducto";
            this.lblIdProducto.Size = new System.Drawing.Size(61, 13);
            this.lblIdProducto.TabIndex = 2;
            this.lblIdProducto.Text = "id Producto";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(164, 250);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(44, 13);
            this.lblNombre.TabIndex = 3;
            this.lblNombre.Text = "Nombre";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(260, 398);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 4;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnEliminate
            // 
            this.btnEliminate.Location = new System.Drawing.Point(341, 398);
            this.btnEliminate.Name = "btnEliminate";
            this.btnEliminate.Size = new System.Drawing.Size(75, 23);
            this.btnEliminate.TabIndex = 5;
            this.btnEliminate.Text = "Eliminate";
            this.btnEliminate.UseVisualStyleBackColor = true;
            this.btnEliminate.Click += new System.EventHandler(this.btnEliminate_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(422, 398);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 6;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // dgbProductos
            // 
            this.dgbProductos.AllowUserToAddRows = false;
            this.dgbProductos.AllowUserToDeleteRows = false;
            this.dgbProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgbProductos.Location = new System.Drawing.Point(12, 12);
            this.dgbProductos.MultiSelect = false;
            this.dgbProductos.Name = "dgbProductos";
            this.dgbProductos.ReadOnly = true;
            this.dgbProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgbProductos.Size = new System.Drawing.Size(777, 169);
            this.dgbProductos.TabIndex = 7;
            this.dgbProductos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgbProductos_CellClick);
            // 
            // lblPrecioVenta
            // 
            this.lblPrecioVenta.AutoSize = true;
            this.lblPrecioVenta.Location = new System.Drawing.Point(164, 326);
            this.lblPrecioVenta.Name = "lblPrecioVenta";
            this.lblPrecioVenta.Size = new System.Drawing.Size(82, 13);
            this.lblPrecioVenta.TabIndex = 11;
            this.lblPrecioVenta.Text = "Precio de venta";
            // 
            // lblPrecioCompra
            // 
            this.lblPrecioCompra.AutoSize = true;
            this.lblPrecioCompra.Location = new System.Drawing.Point(164, 287);
            this.lblPrecioCompra.Name = "lblPrecioCompra";
            this.lblPrecioCompra.Size = new System.Drawing.Size(90, 13);
            this.lblPrecioCompra.TabIndex = 10;
            this.lblPrecioCompra.Text = "Precio de compra";
            // 
            // txtPrecioVenta
            // 
            this.txtPrecioVenta.Location = new System.Drawing.Point(260, 323);
            this.txtPrecioVenta.Name = "txtPrecioVenta";
            this.txtPrecioVenta.Size = new System.Drawing.Size(100, 20);
            this.txtPrecioVenta.TabIndex = 9;
            // 
            // txtPrecioCompra
            // 
            this.txtPrecioCompra.Location = new System.Drawing.Point(260, 284);
            this.txtPrecioCompra.Name = "txtPrecioCompra";
            this.txtPrecioCompra.Size = new System.Drawing.Size(100, 20);
            this.txtPrecioCompra.TabIndex = 8;
            // 
            // lblUnidad
            // 
            this.lblUnidad.AutoSize = true;
            this.lblUnidad.Location = new System.Drawing.Point(394, 287);
            this.lblUnidad.Name = "lblUnidad";
            this.lblUnidad.Size = new System.Drawing.Size(41, 13);
            this.lblUnidad.TabIndex = 18;
            this.lblUnidad.Text = "Unidad";
            // 
            // txtUnidad
            // 
            this.txtUnidad.Location = new System.Drawing.Point(490, 284);
            this.txtUnidad.Name = "txtUnidad";
            this.txtUnidad.Size = new System.Drawing.Size(100, 20);
            this.txtUnidad.TabIndex = 16;
            // 
            // lblIdCategoria
            // 
            this.lblIdCategoria.AutoSize = true;
            this.lblIdCategoria.Location = new System.Drawing.Point(394, 250);
            this.lblIdCategoria.Name = "lblIdCategoria";
            this.lblIdCategoria.Size = new System.Drawing.Size(63, 13);
            this.lblIdCategoria.TabIndex = 15;
            this.lblIdCategoria.Text = "id Categoria";
            // 
            // lblInventario
            // 
            this.lblInventario.AutoSize = true;
            this.lblInventario.Location = new System.Drawing.Point(394, 211);
            this.lblInventario.Name = "lblInventario";
            this.lblInventario.Size = new System.Drawing.Size(54, 13);
            this.lblInventario.TabIndex = 14;
            this.lblInventario.Text = "Inventario";
            // 
            // txtInventario
            // 
            this.txtInventario.Location = new System.Drawing.Point(490, 208);
            this.txtInventario.Name = "txtInventario";
            this.txtInventario.Size = new System.Drawing.Size(100, 20);
            this.txtInventario.TabIndex = 12;
            // 
            // cbxIdCategoria
            // 
            this.cbxIdCategoria.FormattingEnabled = true;
            this.cbxIdCategoria.Location = new System.Drawing.Point(490, 246);
            this.cbxIdCategoria.Name = "cbxIdCategoria";
            this.cbxIdCategoria.Size = new System.Drawing.Size(121, 21);
            this.cbxIdCategoria.TabIndex = 19;
            // 
            // frmProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 444);
            this.Controls.Add(this.cbxIdCategoria);
            this.Controls.Add(this.lblUnidad);
            this.Controls.Add(this.txtUnidad);
            this.Controls.Add(this.lblIdCategoria);
            this.Controls.Add(this.lblInventario);
            this.Controls.Add(this.txtInventario);
            this.Controls.Add(this.lblPrecioVenta);
            this.Controls.Add(this.lblPrecioCompra);
            this.Controls.Add(this.txtPrecioVenta);
            this.Controls.Add(this.txtPrecioCompra);
            this.Controls.Add(this.dgbProductos);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnEliminate);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblIdProducto);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtIdProducto);
            this.Name = "frmProducto";
            this.Text = "Productos";
            this.Load += new System.EventHandler(this.frmProducto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgbProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtIdProducto;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblIdProducto;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEliminate;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.DataGridView dgbProductos;
        private System.Windows.Forms.Label lblPrecioVenta;
        private System.Windows.Forms.Label lblPrecioCompra;
        private System.Windows.Forms.TextBox txtPrecioVenta;
        private System.Windows.Forms.TextBox txtPrecioCompra;
        private System.Windows.Forms.Label lblUnidad;
        private System.Windows.Forms.TextBox txtUnidad;
        private System.Windows.Forms.Label lblIdCategoria;
        private System.Windows.Forms.Label lblInventario;
        private System.Windows.Forms.TextBox txtInventario;
        private System.Windows.Forms.ComboBox cbxIdCategoria;
    }
}