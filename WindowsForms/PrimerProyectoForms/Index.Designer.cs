namespace PrimerProyectoForms
{
    partial class Index
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblNombreProducto = new System.Windows.Forms.Label();
            this.lbltalle = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.lblcolor = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.btnAgregarNuevoProducto = new System.Windows.Forms.Button();
            this.btnIrAVentas = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.cbxCantidad = new System.Windows.Forms.ComboBox();
            this.btnIrCarrito = new System.Windows.Forms.Button();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.cbxMarcas = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxtipos = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtbuscar = new System.Windows.Forms.TextBox();
            this.pbxImg = new System.Windows.Forms.PictureBox();
            this.lblStockTotal = new System.Windows.Forms.Label();
            this.btnModificar = new System.Windows.Forms.Button();
            this.brnBorrarfiltros = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImg)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecio.Location = new System.Drawing.Point(457, 311);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(81, 18);
            this.lblPrecio.TabIndex = 4;
            this.lblPrecio.Text = "PRECIO: $";
            // 
            // lblNombreProducto
            // 
            this.lblNombreProducto.AutoSize = true;
            this.lblNombreProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreProducto.Location = new System.Drawing.Point(452, 266);
            this.lblNombreProducto.Name = "lblNombreProducto";
            this.lblNombreProducto.Size = new System.Drawing.Size(110, 25);
            this.lblNombreProducto.TabIndex = 5;
            this.lblNombreProducto.Text = "NOMBRE";
            // 
            // lbltalle
            // 
            this.lbltalle.AutoSize = true;
            this.lbltalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltalle.Location = new System.Drawing.Point(458, 383);
            this.lbltalle.Name = "lbltalle";
            this.lbltalle.Size = new System.Drawing.Size(62, 18);
            this.lbltalle.TabIndex = 9;
            this.lbltalle.Text = "TALLES\r\n";
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad.Location = new System.Drawing.Point(458, 348);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(155, 18);
            this.lblCantidad.TabIndex = 10;
            this.lblCantidad.Text = "TOTAL DISPONIBLE: ";
            // 
            // lblcolor
            // 
            this.lblcolor.AutoSize = true;
            this.lblcolor.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcolor.Location = new System.Drawing.Point(627, 383);
            this.lblcolor.Name = "lblcolor";
            this.lblcolor.Size = new System.Drawing.Size(82, 18);
            this.lblcolor.TabIndex = 12;
            this.lblcolor.Text = "COLORES";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(651, 513);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(124, 28);
            this.btnEliminar.TabIndex = 14;
            this.btnEliminar.Text = "ELIMINAR";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(325, 46);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(111, 23);
            this.btnBuscar.TabIndex = 15;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(460, 465);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(282, 29);
            this.button6.TabIndex = 17;
            this.button6.Text = "CARGAR AL CARRITO";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // btnAgregarNuevoProducto
            // 
            this.btnAgregarNuevoProducto.Location = new System.Drawing.Point(7, 520);
            this.btnAgregarNuevoProducto.Name = "btnAgregarNuevoProducto";
            this.btnAgregarNuevoProducto.Size = new System.Drawing.Size(215, 25);
            this.btnAgregarNuevoProducto.TabIndex = 19;
            this.btnAgregarNuevoProducto.Text = "AGREGAR NUEVO PRODUCTO";
            this.btnAgregarNuevoProducto.UseVisualStyleBackColor = true;
            this.btnAgregarNuevoProducto.Click += new System.EventHandler(this.btnAgregarNuevoProducto_Click);
            // 
            // btnIrAVentas
            // 
            this.btnIrAVentas.Location = new System.Drawing.Point(341, 520);
            this.btnIrAVentas.Name = "btnIrAVentas";
            this.btnIrAVentas.Size = new System.Drawing.Size(66, 25);
            this.btnIrAVentas.TabIndex = 21;
            this.btnIrAVentas.Text = "VENTAS";
            this.btnIrAVentas.UseVisualStyleBackColor = true;
            this.btnIrAVentas.Click += new System.EventHandler(this.btnIrAVentas_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(458, 425);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(158, 18);
            this.label19.TabIndex = 23;
            this.label19.Text = "SELECCIONAR CANT";
            // 
            // cbxCantidad
            // 
            this.cbxCantidad.FormattingEnabled = true;
            this.cbxCantidad.Location = new System.Drawing.Point(627, 425);
            this.cbxCantidad.Name = "cbxCantidad";
            this.cbxCantidad.Size = new System.Drawing.Size(82, 21);
            this.cbxCantidad.TabIndex = 22;
            // 
            // btnIrCarrito
            // 
            this.btnIrCarrito.Location = new System.Drawing.Point(228, 520);
            this.btnIrCarrito.Name = "btnIrCarrito";
            this.btnIrCarrito.Size = new System.Drawing.Size(107, 25);
            this.btnIrCarrito.TabIndex = 25;
            this.btnIrCarrito.Text = "VER CARRITO";
            this.btnIrCarrito.UseVisualStyleBackColor = true;
            this.btnIrCarrito.Click += new System.EventHandler(this.btnIrCarrito_Click);
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.AllowUserToDeleteRows = false;
            this.dgvProductos.AllowUserToResizeColumns = false;
            this.dgvProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvProductos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvProductos.Location = new System.Drawing.Point(7, 87);
            this.dgvProductos.MultiSelect = false;
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.Size = new System.Drawing.Size(429, 427);
            this.dgvProductos.TabIndex = 27;
            this.dgvProductos.SelectionChanged += new System.EventHandler(this.dgvProductos_SelectionChanged);
            // 
            // cbxMarcas
            // 
            this.cbxMarcas.FormattingEnabled = true;
            this.cbxMarcas.Location = new System.Drawing.Point(123, 10);
            this.cbxMarcas.Name = "cbxMarcas";
            this.cbxMarcas.Size = new System.Drawing.Size(74, 21);
            this.cbxMarcas.TabIndex = 28;
            this.cbxMarcas.SelectedIndexChanged += new System.EventHandler(this.cbxMarcas_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 16);
            this.label4.TabIndex = 29;
            this.label4.Text = "Filtrar por: Marca";
            // 
            // cbxtipos
            // 
            this.cbxtipos.FormattingEnabled = true;
            this.cbxtipos.Location = new System.Drawing.Point(245, 10);
            this.cbxtipos.Name = "cbxtipos";
            this.cbxtipos.Size = new System.Drawing.Size(60, 21);
            this.cbxtipos.TabIndex = 30;
            this.cbxtipos.SelectedIndexChanged += new System.EventHandler(this.cbxtipos_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(205, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 16);
            this.label5.TabIndex = 31;
            this.label5.Text = "Tipo:";
            // 
            // txtbuscar
            // 
            this.txtbuscar.Location = new System.Drawing.Point(7, 49);
            this.txtbuscar.Name = "txtbuscar";
            this.txtbuscar.Size = new System.Drawing.Size(289, 20);
            this.txtbuscar.TabIndex = 32;
            this.txtbuscar.TextChanged += new System.EventHandler(this.txtbuscar_TextChanged);
            // 
            // pbxImg
            // 
            this.pbxImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbxImg.Location = new System.Drawing.Point(455, 10);
            this.pbxImg.Name = "pbxImg";
            this.pbxImg.Size = new System.Drawing.Size(330, 241);
            this.pbxImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxImg.TabIndex = 34;
            this.pbxImg.TabStop = false;
            // 
            // lblStockTotal
            // 
            this.lblStockTotal.AutoSize = true;
            this.lblStockTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStockTotal.Location = new System.Drawing.Point(595, 348);
            this.lblStockTotal.Name = "lblStockTotal";
            this.lblStockTotal.Size = new System.Drawing.Size(0, 18);
            this.lblStockTotal.TabIndex = 36;
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(461, 513);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(124, 28);
            this.btnModificar.TabIndex = 37;
            this.btnModificar.Text = "MODIFICAR";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // brnBorrarfiltros
            // 
            this.brnBorrarfiltros.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.brnBorrarfiltros.Location = new System.Drawing.Point(341, 7);
            this.brnBorrarfiltros.Name = "brnBorrarfiltros";
            this.brnBorrarfiltros.Size = new System.Drawing.Size(95, 23);
            this.brnBorrarfiltros.TabIndex = 38;
            this.brnBorrarfiltros.Text = "🗑️ FILTROS";
            this.brnBorrarfiltros.UseVisualStyleBackColor = true;
            this.brnBorrarfiltros.Click += new System.EventHandler(this.brnBorrarfiltros_Click);
            // 
            // Index
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 557);
            this.Controls.Add(this.brnBorrarfiltros);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.lblStockTotal);
            this.Controls.Add(this.pbxImg);
            this.Controls.Add(this.txtbuscar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbxtipos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbxMarcas);
            this.Controls.Add(this.dgvProductos);
            this.Controls.Add(this.btnIrCarrito);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.cbxCantidad);
            this.Controls.Add(this.btnIrAVentas);
            this.Controls.Add(this.btnAgregarNuevoProducto);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.lblcolor);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.lbltalle);
            this.Controls.Add(this.lblNombreProducto);
            this.Controls.Add(this.lblPrecio);
            this.Location = new System.Drawing.Point(5, 5);
            this.MaximumSize = new System.Drawing.Size(819, 596);
            this.MinimumSize = new System.Drawing.Size(819, 596);
            this.Name = "Index";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Stock";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label lblNombreProducto;
        private System.Windows.Forms.Label lbltalle;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Label lblcolor;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button btnAgregarNuevoProducto;
        private System.Windows.Forms.Button btnIrAVentas;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cbxCantidad;
        private System.Windows.Forms.Button btnIrCarrito;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.ComboBox cbxMarcas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxtipos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtbuscar;
        private System.Windows.Forms.PictureBox pbxImg;
        private System.Windows.Forms.Label lblStockTotal;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button brnBorrarfiltros;
    }
}

