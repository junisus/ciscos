namespace SisCoS
{
    partial class FrmMantCliente
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
            this.button2 = new System.Windows.Forms.Button();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.gbEdicion = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.txtRUC = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtTel = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtemail = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtdir = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtofi = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtnom = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtid = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvDirectorioC = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.clmIdCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmOficina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDireccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTelefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRUC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            this.gbEdicion.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDirectorioC)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.txtCliente);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(641, 65);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "|";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button2.Font = new System.Drawing.Font("Modern No. 20", 15.75F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(531, 15);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 40);
            this.button2.TabIndex = 16;
            this.button2.Text = "Excel";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtCliente
            // 
            this.txtCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtCliente.BackColor = System.Drawing.Color.White;
            this.txtCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCliente.ForeColor = System.Drawing.Color.Black;
            this.txtCliente.Location = new System.Drawing.Point(5, 33);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(509, 26);
            this.txtCliente.TabIndex = 1;
            this.txtCliente.TextChanged += new System.EventHandler(this.txtCliente_TextChanged);
            this.txtCliente.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCliente_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(2, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cliente";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(442, 73);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 44);
            this.button1.TabIndex = 8;
            this.button1.Text = "Modificar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // gbEdicion
            // 
            this.gbEdicion.BackColor = System.Drawing.Color.Transparent;
            this.gbEdicion.Controls.Add(this.label8);
            this.gbEdicion.Controls.Add(this.label7);
            this.gbEdicion.Controls.Add(this.label6);
            this.gbEdicion.Controls.Add(this.label5);
            this.gbEdicion.Controls.Add(this.label4);
            this.gbEdicion.Controls.Add(this.label3);
            this.gbEdicion.Controls.Add(this.label2);
            this.gbEdicion.Controls.Add(this.button3);
            this.gbEdicion.Controls.Add(this.txtRUC);
            this.gbEdicion.Controls.Add(this.txtTel);
            this.gbEdicion.Controls.Add(this.button1);
            this.gbEdicion.Controls.Add(this.txtemail);
            this.gbEdicion.Controls.Add(this.txtdir);
            this.gbEdicion.Controls.Add(this.txtofi);
            this.gbEdicion.Controls.Add(this.txtnom);
            this.gbEdicion.Controls.Add(this.txtid);
            this.gbEdicion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbEdicion.ForeColor = System.Drawing.Color.Black;
            this.gbEdicion.Location = new System.Drawing.Point(12, 328);
            this.gbEdicion.Name = "gbEdicion";
            this.gbEdicion.Size = new System.Drawing.Size(641, 158);
            this.gbEdicion.TabIndex = 6;
            this.gbEdicion.TabStop = false;
            this.gbEdicion.Text = "Edición";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(410, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 16);
            this.label8.TabIndex = 23;
            this.label8.Text = "RUC:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(208, 110);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 16);
            this.label7.TabIndex = 22;
            this.label7.Text = "Telefono:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(190, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 16);
            this.label6.TabIndex = 21;
            this.label6.Text = "Dirección:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(68, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 16);
            this.label5.TabIndex = 20;
            this.label5.Text = "Nombre:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 16);
            this.label4.TabIndex = 19;
            this.label4.Text = "email:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 16);
            this.label3.TabIndex = 18;
            this.label3.Text = "Oficina";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 16);
            this.label2.TabIndex = 17;
            this.label2.Text = "ID";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(539, 71);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(91, 46);
            this.button3.TabIndex = 16;
            this.button3.Text = "Cerrar";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtRUC
            // 
            this.txtRUC.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.txtRUC.Border.Class = "TextBoxBorder";
            this.txtRUC.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtRUC.Enabled = false;
            this.txtRUC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRUC.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtRUC.Location = new System.Drawing.Point(413, 41);
            this.txtRUC.MaxLength = 11;
            this.txtRUC.Name = "txtRUC";
            this.txtRUC.Size = new System.Drawing.Size(217, 22);
            this.txtRUC.TabIndex = 15;
            this.txtRUC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRUC_KeyPress);
            // 
            // txtTel
            // 
            this.txtTel.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.txtTel.Border.Class = "TextBoxBorder";
            this.txtTel.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtTel.Location = new System.Drawing.Point(209, 130);
            this.txtTel.MaxLength = 20;
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(210, 22);
            this.txtTel.TabIndex = 14;
            this.txtTel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTel_KeyDown);
            this.txtTel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTel_KeyPress);
            // 
            // txtemail
            // 
            this.txtemail.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.txtemail.Border.Class = "TextBoxBorder";
            this.txtemail.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtemail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtemail.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtemail.Location = new System.Drawing.Point(10, 129);
            this.txtemail.Name = "txtemail";
            this.txtemail.Size = new System.Drawing.Size(193, 22);
            this.txtemail.TabIndex = 13;
            // 
            // txtdir
            // 
            this.txtdir.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.txtdir.Border.Class = "TextBoxBorder";
            this.txtdir.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtdir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdir.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtdir.Location = new System.Drawing.Point(193, 85);
            this.txtdir.Name = "txtdir";
            this.txtdir.Size = new System.Drawing.Size(228, 22);
            this.txtdir.TabIndex = 7;
            // 
            // txtofi
            // 
            this.txtofi.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.txtofi.Border.Class = "TextBoxBorder";
            this.txtofi.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtofi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtofi.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtofi.Location = new System.Drawing.Point(10, 85);
            this.txtofi.Name = "txtofi";
            this.txtofi.Size = new System.Drawing.Size(173, 22);
            this.txtofi.TabIndex = 5;
            // 
            // txtnom
            // 
            this.txtnom.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.txtnom.Border.Class = "TextBoxBorder";
            this.txtnom.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtnom.Enabled = false;
            this.txtnom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnom.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtnom.Location = new System.Drawing.Point(73, 41);
            this.txtnom.Name = "txtnom";
            this.txtnom.Size = new System.Drawing.Size(330, 22);
            this.txtnom.TabIndex = 3;
            // 
            // txtid
            // 
            this.txtid.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.txtid.Border.Class = "TextBoxBorder";
            this.txtid.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtid.Enabled = false;
            this.txtid.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtid.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtid.Location = new System.Drawing.Point(10, 41);
            this.txtid.Name = "txtid";
            this.txtid.ReadOnly = true;
            this.txtid.Size = new System.Drawing.Size(57, 22);
            this.txtid.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.dgvDirectorioC);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(12, 83);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(641, 239);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "|";
            // 
            // dgvDirectorioC
            // 
            this.dgvDirectorioC.AllowUserToAddRows = false;
            this.dgvDirectorioC.AllowUserToDeleteRows = false;
            this.dgvDirectorioC.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDirectorioC.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDirectorioC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDirectorioC.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmIdCliente,
            this.clmNombre,
            this.clmOficina,
            this.clmDireccion,
            this.clmTelefono,
            this.clmRUC,
            this.clmEmail});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDirectorioC.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDirectorioC.EnableHeadersVisualStyles = false;
            this.dgvDirectorioC.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvDirectorioC.Location = new System.Drawing.Point(6, 10);
            this.dgvDirectorioC.Name = "dgvDirectorioC";
            this.dgvDirectorioC.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDirectorioC.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDirectorioC.RowHeadersVisible = false;
            this.dgvDirectorioC.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDirectorioC.Size = new System.Drawing.Size(624, 220);
            this.dgvDirectorioC.TabIndex = 4;
            this.dgvDirectorioC.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDirectorioC_CellClick);
            this.dgvDirectorioC.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDirectorioC_CellDoubleClick);
            // 
            // clmIdCliente
            // 
            this.clmIdCliente.DataPropertyName = "idCliente";
            this.clmIdCliente.HeaderText = "IdCliente";
            this.clmIdCliente.MinimumWidth = 10;
            this.clmIdCliente.Name = "clmIdCliente";
            this.clmIdCliente.ReadOnly = true;
            this.clmIdCliente.Width = 30;
            // 
            // clmNombre
            // 
            this.clmNombre.DataPropertyName = "Nombres";
            this.clmNombre.HeaderText = "Nombre";
            this.clmNombre.MinimumWidth = 100;
            this.clmNombre.Name = "clmNombre";
            this.clmNombre.ReadOnly = true;
            this.clmNombre.Width = 250;
            // 
            // clmOficina
            // 
            this.clmOficina.DataPropertyName = "oficina";
            this.clmOficina.HeaderText = "Oficina";
            this.clmOficina.MinimumWidth = 50;
            this.clmOficina.Name = "clmOficina";
            this.clmOficina.ReadOnly = true;
            this.clmOficina.Width = 95;
            // 
            // clmDireccion
            // 
            this.clmDireccion.DataPropertyName = "direccion";
            this.clmDireccion.HeaderText = "Dirección";
            this.clmDireccion.MinimumWidth = 50;
            this.clmDireccion.Name = "clmDireccion";
            this.clmDireccion.ReadOnly = true;
            this.clmDireccion.Width = 220;
            // 
            // clmTelefono
            // 
            this.clmTelefono.DataPropertyName = "telefono";
            this.clmTelefono.HeaderText = "Teléfono";
            this.clmTelefono.MinimumWidth = 50;
            this.clmTelefono.Name = "clmTelefono";
            this.clmTelefono.ReadOnly = true;
            this.clmTelefono.Width = 95;
            // 
            // clmRUC
            // 
            this.clmRUC.DataPropertyName = "RUC";
            this.clmRUC.HeaderText = "RUC";
            this.clmRUC.MinimumWidth = 50;
            this.clmRUC.Name = "clmRUC";
            this.clmRUC.ReadOnly = true;
            this.clmRUC.Width = 95;
            // 
            // clmEmail
            // 
            this.clmEmail.DataPropertyName = "email";
            this.clmEmail.HeaderText = "e-mail";
            this.clmEmail.MinimumWidth = 50;
            this.clmEmail.Name = "clmEmail";
            this.clmEmail.ReadOnly = true;
            // 
            // FrmMantCliente
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(661, 496);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbEdicion);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmMantCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mantenimiento Cliente";
            this.Load += new System.EventHandler(this.FrmMantCliente_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbEdicion.ResumeLayout(false);
            this.gbEdicion.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDirectorioC)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbEdicion;
        private DevComponents.DotNetBar.Controls.TextBoxX txtdir;
        private DevComponents.DotNetBar.Controls.TextBoxX txtofi;
        private DevComponents.DotNetBar.Controls.TextBoxX txtnom;
        private DevComponents.DotNetBar.Controls.TextBoxX txtid;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvDirectorioC;
        private DevComponents.DotNetBar.Controls.TextBoxX txtemail;
        private DevComponents.DotNetBar.Controls.TextBoxX txtRUC;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmIdCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmOficina;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDireccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTelefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmRUC;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEmail;
    }
}