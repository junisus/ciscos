namespace SisCoS
{
    partial class FrmMantProducto
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvDirectorio = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.clmIdProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMarca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmProcedencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPrecioC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPrecioV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbEdicion = new System.Windows.Forms.GroupBox();
            this.cmbPro = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.cmbMarca = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.txtPV = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtVenta = new DevComponents.DotNetBar.LabelX();
            this.txtCompra = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.txtStock = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.cmbCat = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.cmbMed = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.button1 = new System.Windows.Forms.Button();
            this.txtdescrip = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.txtid = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDirectorio)).BeginInit();
            this.gbEdicion.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.txtDesc);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(749, 45);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            // 
            // txtDesc
            // 
            this.txtDesc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtDesc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtDesc.BackColor = System.Drawing.Color.White;
            this.txtDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDesc.ForeColor = System.Drawing.Color.Black;
            this.txtDesc.Location = new System.Drawing.Point(75, 14);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(499, 20);
            this.txtDesc.TabIndex = 1;
            this.txtDesc.TextChanged += new System.EventHandler(this.txtDesc_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Descripción";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.dgvDirectorio);
            this.groupBox1.Controls.Add(this.gbEdicion);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(12, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(749, 462);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // dgvDirectorio
            // 
            this.dgvDirectorio.AllowUserToAddRows = false;
            this.dgvDirectorio.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDirectorio.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDirectorio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDirectorio.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmIdProducto,
            this.clmDescripcion,
            this.clmMed,
            this.clmCat,
            this.clmMarca,
            this.clmProcedencia,
            this.clmStock,
            this.clmPrecioC,
            this.clmPrecioV});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDirectorio.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDirectorio.EnableHeadersVisualStyles = false;
            this.dgvDirectorio.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvDirectorio.Location = new System.Drawing.Point(6, 21);
            this.dgvDirectorio.Name = "dgvDirectorio";
            this.dgvDirectorio.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDirectorio.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDirectorio.RowHeadersVisible = false;
            this.dgvDirectorio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDirectorio.Size = new System.Drawing.Size(734, 294);
            this.dgvDirectorio.TabIndex = 4;
            this.dgvDirectorio.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDirectorio_CellClick);
            this.dgvDirectorio.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDirectorio_CellDoubleClick);
            // 
            // clmIdProducto
            // 
            this.clmIdProducto.DataPropertyName = "idProducto";
            this.clmIdProducto.HeaderText = "IdProducto";
            this.clmIdProducto.MinimumWidth = 30;
            this.clmIdProducto.Name = "clmIdProducto";
            this.clmIdProducto.ReadOnly = true;
            this.clmIdProducto.Width = 30;
            // 
            // clmDescripcion
            // 
            this.clmDescripcion.DataPropertyName = "descripcion";
            this.clmDescripcion.HeaderText = "Descripción";
            this.clmDescripcion.Name = "clmDescripcion";
            this.clmDescripcion.ReadOnly = true;
            this.clmDescripcion.Width = 200;
            // 
            // clmMed
            // 
            this.clmMed.DataPropertyName = "Medida";
            this.clmMed.HeaderText = "Medida";
            this.clmMed.Name = "clmMed";
            this.clmMed.ReadOnly = true;
            // 
            // clmCat
            // 
            this.clmCat.DataPropertyName = "Categoria";
            this.clmCat.HeaderText = "Categoria";
            this.clmCat.Name = "clmCat";
            this.clmCat.ReadOnly = true;
            // 
            // clmMarca
            // 
            this.clmMarca.DataPropertyName = "Marca";
            this.clmMarca.HeaderText = "Marca";
            this.clmMarca.Name = "clmMarca";
            this.clmMarca.ReadOnly = true;
            // 
            // clmProcedencia
            // 
            this.clmProcedencia.DataPropertyName = "Procedencia";
            this.clmProcedencia.HeaderText = "Procedencia";
            this.clmProcedencia.Name = "clmProcedencia";
            this.clmProcedencia.ReadOnly = true;
            // 
            // clmStock
            // 
            this.clmStock.DataPropertyName = "Stock";
            this.clmStock.HeaderText = "Stock";
            this.clmStock.Name = "clmStock";
            this.clmStock.ReadOnly = true;
            // 
            // clmPrecioC
            // 
            this.clmPrecioC.DataPropertyName = "precioCompra";
            this.clmPrecioC.HeaderText = "Precio Compra";
            this.clmPrecioC.Name = "clmPrecioC";
            this.clmPrecioC.ReadOnly = true;
            // 
            // clmPrecioV
            // 
            this.clmPrecioV.DataPropertyName = "precioVenta";
            this.clmPrecioV.HeaderText = "Precio Venta";
            this.clmPrecioV.Name = "clmPrecioV";
            this.clmPrecioV.ReadOnly = true;
            // 
            // gbEdicion
            // 
            this.gbEdicion.BackColor = System.Drawing.SystemColors.Control;
            this.gbEdicion.Controls.Add(this.cmbPro);
            this.gbEdicion.Controls.Add(this.labelX8);
            this.gbEdicion.Controls.Add(this.cmbMarca);
            this.gbEdicion.Controls.Add(this.labelX7);
            this.gbEdicion.Controls.Add(this.txtPV);
            this.gbEdicion.Controls.Add(this.txtVenta);
            this.gbEdicion.Controls.Add(this.txtCompra);
            this.gbEdicion.Controls.Add(this.labelX6);
            this.gbEdicion.Controls.Add(this.txtStock);
            this.gbEdicion.Controls.Add(this.labelX5);
            this.gbEdicion.Controls.Add(this.cmbCat);
            this.gbEdicion.Controls.Add(this.labelX4);
            this.gbEdicion.Controls.Add(this.cmbMed);
            this.gbEdicion.Controls.Add(this.labelX2);
            this.gbEdicion.Controls.Add(this.button1);
            this.gbEdicion.Controls.Add(this.txtdescrip);
            this.gbEdicion.Controls.Add(this.labelX3);
            this.gbEdicion.Controls.Add(this.txtid);
            this.gbEdicion.Controls.Add(this.labelX1);
            this.gbEdicion.ForeColor = System.Drawing.Color.Black;
            this.gbEdicion.Location = new System.Drawing.Point(15, 331);
            this.gbEdicion.Name = "gbEdicion";
            this.gbEdicion.Size = new System.Drawing.Size(725, 121);
            this.gbEdicion.TabIndex = 6;
            this.gbEdicion.TabStop = false;
            this.gbEdicion.Text = "Edición";
            // 
            // cmbPro
            // 
            this.cmbPro.DisplayMember = "Text";
            this.cmbPro.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbPro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPro.FormattingEnabled = true;
            this.cmbPro.ItemHeight = 14;
            this.cmbPro.Location = new System.Drawing.Point(264, 85);
            this.cmbPro.Name = "cmbPro";
            this.cmbPro.Size = new System.Drawing.Size(158, 20);
            this.cmbPro.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbPro.TabIndex = 22;
            // 
            // labelX8
            // 
            this.labelX8.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.ForeColor = System.Drawing.Color.Black;
            this.labelX8.Location = new System.Drawing.Point(187, 85);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(75, 23);
            this.labelX8.TabIndex = 21;
            this.labelX8.Text = "Procedencia:";
            // 
            // cmbMarca
            // 
            this.cmbMarca.DisplayMember = "Text";
            this.cmbMarca.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMarca.FormattingEnabled = true;
            this.cmbMarca.ItemHeight = 14;
            this.cmbMarca.Location = new System.Drawing.Point(60, 85);
            this.cmbMarca.Name = "cmbMarca";
            this.cmbMarca.Size = new System.Drawing.Size(114, 20);
            this.cmbMarca.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbMarca.TabIndex = 20;
            // 
            // labelX7
            // 
            this.labelX7.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.ForeColor = System.Drawing.Color.Black;
            this.labelX7.Location = new System.Drawing.Point(13, 85);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(75, 23);
            this.labelX7.TabIndex = 19;
            this.labelX7.Text = "Marca:";
            // 
            // txtPV
            // 
            this.txtPV.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.txtPV.Border.Class = "TextBoxBorder";
            this.txtPV.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPV.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtPV.Location = new System.Drawing.Point(520, 94);
            this.txtPV.Name = "txtPV";
            this.txtPV.Size = new System.Drawing.Size(114, 20);
            this.txtPV.TabIndex = 18;
            // 
            // txtVenta
            // 
            this.txtVenta.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.txtVenta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtVenta.ForeColor = System.Drawing.Color.Black;
            this.txtVenta.Location = new System.Drawing.Point(438, 94);
            this.txtVenta.Name = "txtVenta";
            this.txtVenta.Size = new System.Drawing.Size(91, 23);
            this.txtVenta.TabIndex = 17;
            this.txtVenta.Text = "Precio Venta:";
            // 
            // txtCompra
            // 
            this.txtCompra.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.txtCompra.Border.Class = "TextBoxBorder";
            this.txtCompra.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCompra.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtCompra.Location = new System.Drawing.Point(520, 56);
            this.txtCompra.Name = "txtCompra";
            this.txtCompra.Size = new System.Drawing.Size(114, 20);
            this.txtCompra.TabIndex = 16;
            // 
            // labelX6
            // 
            this.labelX6.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.ForeColor = System.Drawing.Color.Black;
            this.labelX6.Location = new System.Drawing.Point(438, 56);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(91, 23);
            this.labelX6.TabIndex = 15;
            this.labelX6.Text = "Precio Compra:";
            // 
            // txtStock
            // 
            this.txtStock.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.txtStock.Border.Class = "TextBoxBorder";
            this.txtStock.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtStock.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtStock.Location = new System.Drawing.Point(325, 56);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(97, 20);
            this.txtStock.TabIndex = 14;
            // 
            // labelX5
            // 
            this.labelX5.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.ForeColor = System.Drawing.Color.Black;
            this.labelX5.Location = new System.Drawing.Point(287, 56);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(75, 23);
            this.labelX5.TabIndex = 13;
            this.labelX5.Text = "Stock";
            // 
            // cmbCat
            // 
            this.cmbCat.DisplayMember = "Text";
            this.cmbCat.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbCat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCat.FormattingEnabled = true;
            this.cmbCat.ItemHeight = 14;
            this.cmbCat.Location = new System.Drawing.Point(476, 19);
            this.cmbCat.Name = "cmbCat";
            this.cmbCat.Size = new System.Drawing.Size(158, 20);
            this.cmbCat.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbCat.TabIndex = 12;
            // 
            // labelX4
            // 
            this.labelX4.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.ForeColor = System.Drawing.Color.Black;
            this.labelX4.Location = new System.Drawing.Point(414, 19);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(75, 23);
            this.labelX4.TabIndex = 11;
            this.labelX4.Text = "Categoria:";
            // 
            // cmbMed
            // 
            this.cmbMed.DisplayMember = "Text";
            this.cmbMed.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbMed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMed.FormattingEnabled = true;
            this.cmbMed.ItemHeight = 14;
            this.cmbMed.Location = new System.Drawing.Point(234, 19);
            this.cmbMed.Name = "cmbMed";
            this.cmbMed.Size = new System.Drawing.Size(158, 20);
            this.cmbMed.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbMed.TabIndex = 10;
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.ForeColor = System.Drawing.Color.Black;
            this.labelX2.Location = new System.Drawing.Point(187, 19);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 9;
            this.labelX2.Text = "Medida:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(650, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(58, 95);
            this.button1.TabIndex = 8;
            this.button1.Text = "Modificar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtdescrip
            // 
            this.txtdescrip.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.txtdescrip.Border.Class = "TextBoxBorder";
            this.txtdescrip.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtdescrip.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtdescrip.Location = new System.Drawing.Point(74, 56);
            this.txtdescrip.Name = "txtdescrip";
            this.txtdescrip.Size = new System.Drawing.Size(199, 20);
            this.txtdescrip.TabIndex = 5;
            // 
            // labelX3
            // 
            this.labelX3.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.ForeColor = System.Drawing.Color.Black;
            this.labelX3.Location = new System.Drawing.Point(11, 56);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(75, 23);
            this.labelX3.TabIndex = 4;
            this.labelX3.Text = "Descripción:";
            // 
            // txtid
            // 
            this.txtid.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.txtid.Border.Class = "TextBoxBorder";
            this.txtid.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtid.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtid.Location = new System.Drawing.Point(74, 21);
            this.txtid.Name = "txtid";
            this.txtid.ReadOnly = true;
            this.txtid.Size = new System.Drawing.Size(100, 20);
            this.txtid.TabIndex = 1;
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.ForeColor = System.Drawing.Color.Black;
            this.labelX1.Location = new System.Drawing.Point(11, 21);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "Id Producto";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(636, 14);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(104, 25);
            this.button2.TabIndex = 2;
            this.button2.Text = "Excel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FrmMantProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 534);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmMantProducto";
            this.Text = "FrmMantProducto";
            this.Load += new System.EventHandler(this.FrmMantProducto_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDirectorio)).EndInit();
            this.gbEdicion.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvDirectorio;
        private System.Windows.Forms.GroupBox gbEdicion;
        private System.Windows.Forms.Button button1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtdescrip;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.TextBoxX txtid;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPV;
        private DevComponents.DotNetBar.LabelX txtVenta;
        private DevComponents.DotNetBar.Controls.TextBoxX txtCompra;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.Controls.TextBoxX txtStock;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbCat;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbMed;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbPro;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbMarca;
        private DevComponents.DotNetBar.LabelX labelX7;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmIdProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMed;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCat;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMarca;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmProcedencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPrecioC;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPrecioV;
        private System.Windows.Forms.Button button2;
    }
}