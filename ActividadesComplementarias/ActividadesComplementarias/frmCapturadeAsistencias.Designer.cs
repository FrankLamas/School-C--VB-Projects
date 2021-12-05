namespace ActividadesComplementarias
{
    partial class frmCapturadeAsistencias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCapturadeAsistencias));
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTaller = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvInscritos = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.cmbPer1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbPer2 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInscritos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Selecciona Taller:";
            // 
            // cmbTaller
            // 
            this.cmbTaller.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTaller.FormattingEnabled = true;
            this.cmbTaller.Location = new System.Drawing.Point(134, 27);
            this.cmbTaller.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbTaller.Name = "cmbTaller";
            this.cmbTaller.Size = new System.Drawing.Size(140, 24);
            this.cmbTaller.TabIndex = 1;
            this.cmbTaller.SelectedIndexChanged += new System.EventHandler(this.cmbTaller_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::ActividadesComplementarias.Properties.Resources.espalda;
            this.pictureBox1.Location = new System.Drawing.Point(583, 286);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(45, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = global::ActividadesComplementarias.Properties.Resources.comprobado;
            this.pictureBox2.Location = new System.Drawing.Point(533, 286);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(45, 40);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(142, 63);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(200, 22);
            this.dtpFecha.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Seleccione Fecha:";
            // 
            // dgvInscritos
            // 
            this.dgvInscritos.AllowUserToAddRows = false;
            this.dgvInscritos.AllowUserToDeleteRows = false;
            this.dgvInscritos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInscritos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dgvInscritos.Location = new System.Drawing.Point(12, 91);
            this.dgvInscritos.Name = "dgvInscritos";
            this.dgvInscritos.RowTemplate.Height = 24;
            this.dgvInscritos.Size = new System.Drawing.Size(617, 190);
            this.dgvInscritos.TabIndex = 7;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column1.HeaderText = "idInscripción";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 111;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column2.HeaderText = "No de Control";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 120;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column3.HeaderText = "Nombre";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 83;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column4.HeaderText = "Asistencias";
            this.Column4.Items.AddRange(new object[] {
            "Presente",
            "Ausente",
            "Justificado"});
            this.Column4.Name = "Column4";
            this.Column4.Width = 85;
            // 
            // cmbPer1
            // 
            this.cmbPer1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPer1.FormattingEnabled = true;
            this.cmbPer1.Items.AddRange(new object[] {
            "AGO/DIC",
            "ENE/JUL"});
            this.cmbPer1.Location = new System.Drawing.Point(343, 27);
            this.cmbPer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbPer1.Name = "cmbPer1";
            this.cmbPer1.Size = new System.Drawing.Size(140, 24);
            this.cmbPer1.TabIndex = 9;
            this.cmbPer1.SelectedIndexChanged += new System.EventHandler(this.cmbPer1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(280, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Periodo";
            // 
            // cmbPer2
            // 
            this.cmbPer2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPer2.FormattingEnabled = true;
            this.cmbPer2.Items.AddRange(new object[] {
            "2018",
            "2019",
            "2020",
            "2021",
            "2022",
            "2023",
            "2024",
            "2025"});
            this.cmbPer2.Location = new System.Drawing.Point(489, 27);
            this.cmbPer2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbPer2.Name = "cmbPer2";
            this.cmbPer2.Size = new System.Drawing.Size(140, 24);
            this.cmbPer2.TabIndex = 10;
            this.cmbPer2.SelectedIndexChanged += new System.EventHandler(this.cmbPer2_SelectedIndexChanged);
            // 
            // frmCapturadeAsistencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 334);
            this.Controls.Add(this.cmbPer2);
            this.Controls.Add(this.cmbPer1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvInscritos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cmbTaller);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmCapturadeAsistencias";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Captura de Asistencias";
            this.Load += new System.EventHandler(this.frmCapturadeAsistencias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInscritos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTaller;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvInscritos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column4;
        private System.Windows.Forms.ComboBox cmbPer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbPer2;
    }
}