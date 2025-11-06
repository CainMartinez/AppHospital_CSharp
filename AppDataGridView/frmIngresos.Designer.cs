namespace AppDataGridView
{
    partial class frmIngresos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIngresos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.chkDarAlta = new System.Windows.Forms.CheckBox();
            this.dtpFechaAlta = new System.Windows.Forms.DateTimePicker();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.lblMotivo = new System.Windows.Forms.Label();
            this.dtpFechaIngreso = new System.Windows.Forms.DateTimePicker();
            this.lblIngreso = new System.Windows.Forms.Label();
            this.lblAlta = new System.Windows.Forms.Label();
            this.lblEspecialidad = new System.Windows.Forms.Label();
            this.txtEspecialidad = new System.Windows.Forms.TextBox();
            this.lblHabitacion = new System.Windows.Forms.Label();
            this.txtHabitacion = new System.Windows.Forms.TextBox();
            this.btnEliminarIngreso = new System.Windows.Forms.Button();
            this.btnAgregarIngreso = new System.Windows.Forms.Button();
            this.btnEditarIngreso = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.pacientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbPacientes = new System.Windows.Forms.ToolStripButton();
            this.lblTituloIngresos = new System.Windows.Forms.Label();
            this.dgvIngresos = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngresos)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkDarAlta
            // 
            this.chkDarAlta.AutoSize = true;
            this.chkDarAlta.Location = new System.Drawing.Point(208, 58);
            this.chkDarAlta.Name = "chkDarAlta";
            this.chkDarAlta.Size = new System.Drawing.Size(149, 29);
            this.chkDarAlta.TabIndex = 3;
            this.chkDarAlta.Text = "Dar de alta";
            this.chkDarAlta.UseVisualStyleBackColor = true;
            this.chkDarAlta.CheckedChanged += new System.EventHandler(this.chkDarAlta_CheckedChanged);
            // 
            // dtpFechaAlta
            // 
            this.dtpFechaAlta.Location = new System.Drawing.Point(194, 19);
            this.dtpFechaAlta.Name = "dtpFechaAlta";
            this.dtpFechaAlta.Size = new System.Drawing.Size(414, 31);
            this.dtpFechaAlta.TabIndex = 4;
            // 
            // txtMotivo
            // 
            this.txtMotivo.Location = new System.Drawing.Point(246, 29);
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(400, 31);
            this.txtMotivo.TabIndex = 5;
            // 
            // lblMotivo
            // 
            this.lblMotivo.AutoSize = true;
            this.lblMotivo.Location = new System.Drawing.Point(44, 32);
            this.lblMotivo.Name = "lblMotivo";
            this.lblMotivo.Size = new System.Drawing.Size(76, 25);
            this.lblMotivo.TabIndex = 6;
            this.lblMotivo.Text = "Motivo";
            // 
            // dtpFechaIngreso
            // 
            this.dtpFechaIngreso.Location = new System.Drawing.Point(246, 215);
            this.dtpFechaIngreso.Name = "dtpFechaIngreso";
            this.dtpFechaIngreso.Size = new System.Drawing.Size(400, 31);
            this.dtpFechaIngreso.TabIndex = 7;
            // 
            // lblIngreso
            // 
            this.lblIngreso.AutoSize = true;
            this.lblIngreso.Location = new System.Drawing.Point(44, 215);
            this.lblIngreso.Name = "lblIngreso";
            this.lblIngreso.Size = new System.Drawing.Size(179, 25);
            this.lblIngreso.TabIndex = 8;
            this.lblIngreso.Text = "Fecha de ingreso";
            // 
            // lblAlta
            // 
            this.lblAlta.AutoSize = true;
            this.lblAlta.Location = new System.Drawing.Point(25, 19);
            this.lblAlta.Name = "lblAlta";
            this.lblAlta.Size = new System.Drawing.Size(143, 25);
            this.lblAlta.TabIndex = 9;
            this.lblAlta.Text = "Fecha de alta";
            // 
            // lblEspecialidad
            // 
            this.lblEspecialidad.AutoSize = true;
            this.lblEspecialidad.Location = new System.Drawing.Point(44, 92);
            this.lblEspecialidad.Name = "lblEspecialidad";
            this.lblEspecialidad.Size = new System.Drawing.Size(135, 25);
            this.lblEspecialidad.TabIndex = 11;
            this.lblEspecialidad.Text = "Especialidad";
            // 
            // txtEspecialidad
            // 
            this.txtEspecialidad.Location = new System.Drawing.Point(246, 89);
            this.txtEspecialidad.Name = "txtEspecialidad";
            this.txtEspecialidad.Size = new System.Drawing.Size(400, 31);
            this.txtEspecialidad.TabIndex = 10;
            // 
            // lblHabitacion
            // 
            this.lblHabitacion.AutoSize = true;
            this.lblHabitacion.Location = new System.Drawing.Point(44, 153);
            this.lblHabitacion.Name = "lblHabitacion";
            this.lblHabitacion.Size = new System.Drawing.Size(114, 25);
            this.lblHabitacion.TabIndex = 13;
            this.lblHabitacion.Text = "Habitación";
            // 
            // txtHabitacion
            // 
            this.txtHabitacion.Location = new System.Drawing.Point(246, 150);
            this.txtHabitacion.Name = "txtHabitacion";
            this.txtHabitacion.Size = new System.Drawing.Size(122, 31);
            this.txtHabitacion.TabIndex = 12;
            // 
            // btnEliminarIngreso
            // 
            this.btnEliminarIngreso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEliminarIngreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarIngreso.Location = new System.Drawing.Point(3, 279);
            this.btnEliminarIngreso.Name = "btnEliminarIngreso";
            this.btnEliminarIngreso.Size = new System.Drawing.Size(244, 131);
            this.btnEliminarIngreso.TabIndex = 14;
            this.btnEliminarIngreso.Text = "Eliminar";
            this.btnEliminarIngreso.UseVisualStyleBackColor = true;
            this.btnEliminarIngreso.Click += new System.EventHandler(this.btnEliminarIngreso_Click);
            // 
            // btnAgregarIngreso
            // 
            this.btnAgregarIngreso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAgregarIngreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarIngreso.Location = new System.Drawing.Point(3, 3);
            this.btnAgregarIngreso.Name = "btnAgregarIngreso";
            this.btnAgregarIngreso.Size = new System.Drawing.Size(244, 130);
            this.btnAgregarIngreso.TabIndex = 15;
            this.btnAgregarIngreso.Text = "Añadir";
            this.btnAgregarIngreso.UseVisualStyleBackColor = true;
            this.btnAgregarIngreso.Click += new System.EventHandler(this.btnAgregarIngreso_Click);
            // 
            // btnEditarIngreso
            // 
            this.btnEditarIngreso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEditarIngreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarIngreso.Location = new System.Drawing.Point(3, 139);
            this.btnEditarIngreso.Name = "btnEditarIngreso";
            this.btnEditarIngreso.Size = new System.Drawing.Size(244, 134);
            this.btnEditarIngreso.TabIndex = 16;
            this.btnEditarIngreso.Text = "Modificar";
            this.btnEditarIngreso.UseVisualStyleBackColor = true;
            this.btnEditarIngreso.Click += new System.EventHandler(this.btnEditarIngreso_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pacientesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1438, 40);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // pacientesToolStripMenuItem
            // 
            this.pacientesToolStripMenuItem.Name = "pacientesToolStripMenuItem";
            this.pacientesToolStripMenuItem.Size = new System.Drawing.Size(133, 36);
            this.pacientesToolStripMenuItem.Text = "Pacientes";
            this.pacientesToolStripMenuItem.Click += new System.EventHandler(this.Pacientes_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbPacientes});
            this.toolStrip1.Location = new System.Drawing.Point(0, 40);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1438, 42);
            this.toolStrip1.TabIndex = 18;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbPacientes
            // 
            this.tsbPacientes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPacientes.Image = ((System.Drawing.Image)(resources.GetObject("tsbPacientes.Image")));
            this.tsbPacientes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPacientes.Name = "tsbPacientes";
            this.tsbPacientes.Size = new System.Drawing.Size(46, 36);
            this.tsbPacientes.Text = "Pacientes";
            this.tsbPacientes.Click += new System.EventHandler(this.Pacientes_Click);
            // 
            // lblTituloIngresos
            // 
            this.lblTituloIngresos.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTituloIngresos.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloIngresos.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblTituloIngresos.Location = new System.Drawing.Point(0, 82);
            this.lblTituloIngresos.Name = "lblTituloIngresos";
            this.lblTituloIngresos.Size = new System.Drawing.Size(1438, 174);
            this.lblTituloIngresos.TabIndex = 22;
            this.lblTituloIngresos.Text = "Ingresos";
            this.lblTituloIngresos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvIngresos
            // 
            this.dgvIngresos.AllowUserToAddRows = false;
            this.dgvIngresos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(251)))), ((int)(((byte)(252)))));
            this.dgvIngresos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvIngresos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvIngresos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvIngresos.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvIngresos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvIngresos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(157)))), ((int)(((byte)(164)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvIngresos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvIngresos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvIngresos.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvIngresos.EnableHeadersVisualStyles = false;
            this.dgvIngresos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(236)))), ((int)(((byte)(241)))));
            this.dgvIngresos.Location = new System.Drawing.Point(33, 778);
            this.dgvIngresos.Margin = new System.Windows.Forms.Padding(6);
            this.dgvIngresos.Name = "dgvIngresos";
            this.dgvIngresos.ReadOnly = true;
            this.dgvIngresos.RowHeadersVisible = false;
            this.dgvIngresos.RowHeadersWidth = 82;
            this.dgvIngresos.Size = new System.Drawing.Size(1390, 306);
            this.dgvIngresos.TabIndex = 23;
            this.dgvIngresos.SelectionChanged += new System.EventHandler(this.dgvIngresos_SelectionChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.lblAlta);
            this.panel1.Controls.Add(this.chkDarAlta);
            this.panel1.Controls.Add(this.dtpFechaAlta);
            this.panel1.Location = new System.Drawing.Point(161, 620);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(688, 100);
            this.panel1.TabIndex = 24;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.lblMotivo);
            this.panel2.Controls.Add(this.txtMotivo);
            this.panel2.Controls.Add(this.lblEspecialidad);
            this.panel2.Controls.Add(this.lblHabitacion);
            this.panel2.Controls.Add(this.txtEspecialidad);
            this.panel2.Controls.Add(this.txtHabitacion);
            this.panel2.Controls.Add(this.lblIngreso);
            this.panel2.Controls.Add(this.dtpFechaIngreso);
            this.panel2.Location = new System.Drawing.Point(161, 296);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(688, 294);
            this.panel2.TabIndex = 25;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.btnAgregarIngreso, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnEditarIngreso, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnEliminarIngreso, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1087, 292);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(250, 413);
            this.tableLayoutPanel1.TabIndex = 26;
            // 
            // frmIngresos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1438, 1192);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvIngresos);
            this.Controls.Add(this.lblTituloIngresos);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmIngresos";
            this.Text = "Formulario Ingresos";
            this.Load += new System.EventHandler(this.frmIngresos_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngresos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox chkDarAlta;
        private System.Windows.Forms.DateTimePicker dtpFechaAlta;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.Label lblMotivo;
        private System.Windows.Forms.DateTimePicker dtpFechaIngreso;
        private System.Windows.Forms.Label lblIngreso;
        private System.Windows.Forms.Label lblAlta;
        private System.Windows.Forms.Label lblEspecialidad;
        private System.Windows.Forms.TextBox txtEspecialidad;
        private System.Windows.Forms.Label lblHabitacion;
        private System.Windows.Forms.TextBox txtHabitacion;
        private System.Windows.Forms.Button btnEliminarIngreso;
        private System.Windows.Forms.Button btnAgregarIngreso;
        private System.Windows.Forms.Button btnEditarIngreso;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem pacientesToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbPacientes;
        private System.Windows.Forms.Label lblTituloIngresos;
        private System.Windows.Forms.DataGridView dgvIngresos;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}