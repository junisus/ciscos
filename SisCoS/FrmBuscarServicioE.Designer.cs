﻿
namespace SisCoS
{
    partial class FrmBuscarServicioE
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
            this.dgvDirectorio3 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.clmIdProductos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDescripcions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmStocks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDirectorio3)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.txtDesc);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(13, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(458, 58);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            // 
            // txtDesc
            // 
            this.txtDesc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtDesc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtDesc.BackColor = System.Drawing.Color.White;
            this.txtDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDesc.ForeColor = System.Drawing.Color.Black;
            this.txtDesc.Location = new System.Drawing.Point(134, 19);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(314, 20);
            this.txtDesc.TabIndex = 1;
            this.txtDesc.TextChanged += new System.EventHandler(this.txtDesc_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(25, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Descripción";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.dgvDirectorio3);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(13, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(458, 277);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            // 
            // dgvDirectorio3
            // 
            this.dgvDirectorio3.AllowUserToAddRows = false;
            this.dgvDirectorio3.AllowUserToDeleteRows = false;
            this.dgvDirectorio3.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDirectorio3.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDirectorio3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDirectorio3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmIdProductos,
            this.clmDescripcions,
            this.clmStocks});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDirectorio3.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDirectorio3.EnableHeadersVisualStyles = false;
            this.dgvDirectorio3.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvDirectorio3.Location = new System.Drawing.Point(4, 19);
            this.dgvDirectorio3.Name = "dgvDirectorio3";
            this.dgvDirectorio3.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDirectorio3.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDirectorio3.RowHeadersVisible = false;
            this.dgvDirectorio3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDirectorio3.Size = new System.Drawing.Size(444, 244);
            this.dgvDirectorio3.TabIndex = 4;
            this.dgvDirectorio3.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDirectorio3_CellDoubleClick);
            // 
            // clmIdProductos
            // 
            this.clmIdProductos.DataPropertyName = "id";
            this.clmIdProductos.HeaderText = "IdServicio";
            this.clmIdProductos.MinimumWidth = 80;
            this.clmIdProductos.Name = "clmIdProductos";
            this.clmIdProductos.ReadOnly = true;
            this.clmIdProductos.Width = 80;
            // 
            // clmDescripcions
            // 
            this.clmDescripcions.DataPropertyName = "Nombres";
            this.clmDescripcions.HeaderText = "Descripción";
            this.clmDescripcions.Name = "clmDescripcions";
            this.clmDescripcions.ReadOnly = true;
            this.clmDescripcions.Width = 253;
            // 
            // clmStocks
            // 
            this.clmStocks.DataPropertyName = "descripcion";
            this.clmStocks.HeaderText = "Tarifa";
            this.clmStocks.Name = "clmStocks";
            this.clmStocks.ReadOnly = true;
            // 
            // FrmBuscarServicioE
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(483, 362);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmBuscarServicioE";
            this.Text = "FrmBuscarServicioE";
            this.Load += new System.EventHandler(this.FrmBuscarServicioE_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDirectorio3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvDirectorio3;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmIdProductos;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDescripcions;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmStocks;
    }
}