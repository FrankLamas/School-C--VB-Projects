namespace ActividadesComplementarias
{
    partial class frmEvaluacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEvaluacion));
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTaller = new System.Windows.Forms.ComboBox();
            this.dgvInscritos = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnImprimir = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmbPer1 = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbPer2 = new System.Windows.Forms.ComboBox();
            this.cmbImprimir = new System.Windows.Forms.ComboBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInscritos)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnImprimir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccione Taller";
            // 
            // cmbTaller
            // 
            this.cmbTaller.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTaller.FormattingEnabled = true;
            this.cmbTaller.Location = new System.Drawing.Point(135, 36);
            this.cmbTaller.Name = "cmbTaller";
            this.cmbTaller.Size = new System.Drawing.Size(282, 24);
            this.cmbTaller.TabIndex = 5;
            this.cmbTaller.SelectedIndexChanged += new System.EventHandler(this.cmbTaller_SelectedIndexChanged);
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
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11});
            this.dgvInscritos.Location = new System.Drawing.Point(12, 66);
            this.dgvInscritos.Name = "dgvInscritos";
            this.dgvInscritos.RowTemplate.Height = 24;
            this.dgvInscritos.Size = new System.Drawing.Size(1145, 248);
            this.dgvInscritos.TabIndex = 6;
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
            this.Column2.Width = 110;
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
            this.Column4.HeaderText = "Aspecto 1";
            this.Column4.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4"});
            this.Column4.Name = "Column4";
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column4.Width = 88;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column5.HeaderText = "Aspecto 2";
            this.Column5.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4"});
            this.Column5.Name = "Column5";
            this.Column5.Width = 69;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column6.HeaderText = "Aspecto 3";
            this.Column6.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4"});
            this.Column6.Name = "Column6";
            this.Column6.Width = 69;
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column7.HeaderText = "Aspecto 4";
            this.Column7.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4"});
            this.Column7.Name = "Column7";
            this.Column7.Width = 69;
            // 
            // Column8
            // 
            this.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column8.HeaderText = "Aspecto 5";
            this.Column8.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4"});
            this.Column8.Name = "Column8";
            this.Column8.Width = 69;
            // 
            // Column9
            // 
            this.Column9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column9.HeaderText = "Aspecto 6";
            this.Column9.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4"});
            this.Column9.Name = "Column9";
            this.Column9.Width = 69;
            // 
            // Column10
            // 
            this.Column10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column10.HeaderText = "Aspecto 7";
            this.Column10.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4"});
            this.Column10.Name = "Column10";
            this.Column10.Width = 69;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "Observación (Opcional)";
            this.Column11.Name = "Column11";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 335);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(631, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Aspecto 1: Cumple en tiempo y forma con las actividades encomendadas alcanzando l" +
    "os objetivos.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 366);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(414, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Aspecto 2: Trabaja en equipo y se adapta a nuevas situaciones.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 396);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(414, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "Aspecto 3: Muestra liderazgo en las actividades encomendadas.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 429);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(399, 17);
            this.label7.TabIndex = 10;
            this.label7.Text = "Aspecto 4: Organiza su tiempo y trabaja de manera proactiva.";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 459);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(771, 17);
            this.label8.TabIndex = 11;
            this.label8.Text = "Aspecto 5: Interpreta la realidad y se sensibiliza aportando soluciones a la prob" +
    "lemática con la actividad complementaria.";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 488);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(697, 17);
            this.label9.TabIndex = 12;
            this.label9.Text = "Aspecto 6: Realiza sugerencias innovadoras para beneficio o mejoramiento del prog" +
    "rama en el que participa.";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 518);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(664, 17);
            this.label10.TabIndex = 13;
            this.label10.Text = "Aspecto 7: Tiene iniciativa para ayudar en las actividades encomendadas y muestra" +
    " espíritu de servicio.";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(807, 335);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(171, 226);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Niveles de Desempeño";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 165);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(90, 17);
            this.label13.TabIndex = 21;
            this.label13.Text = "4.- Excelente";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 136);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(78, 17);
            this.label12.TabIndex = 20;
            this.label12.Text = "3.- Notable";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 106);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 17);
            this.label11.TabIndex = 19;
            this.label11.Text = "2.- Bueno";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 17);
            this.label3.TabIndex = 18;
            this.label3.Text = "1.- Suficiente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 17);
            this.label2.TabIndex = 17;
            this.label2.Text = "0.- Insuficiente";
            // 
            // btnImprimir
            // 
            this.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimir.Image = global::ActividadesComplementarias.Properties.Resources.disco_flexible;
            this.btnImprimir.Location = new System.Drawing.Point(1050, 514);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(49, 47);
            this.btnImprimir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnImprimir.TabIndex = 15;
            this.btnImprimir.TabStop = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::ActividadesComplementarias.Properties.Resources.espalda;
            this.pictureBox1.Location = new System.Drawing.Point(1105, 514);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(52, 47);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // cmbPer1
            // 
            this.cmbPer1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPer1.FormattingEnabled = true;
            this.cmbPer1.Items.AddRange(new object[] {
            "AGO/DIC",
            "ENE/JUL"});
            this.cmbPer1.Location = new System.Drawing.Point(546, 36);
            this.cmbPer1.Name = "cmbPer1";
            this.cmbPer1.Size = new System.Drawing.Size(160, 24);
            this.cmbPer1.TabIndex = 18;
            this.cmbPer1.SelectedIndexChanged += new System.EventHandler(this.cmbPer1_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(475, 39);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 17);
            this.label14.TabIndex = 17;
            this.label14.Text = "Periodo: ";
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
            "2023"});
            this.cmbPer2.Location = new System.Drawing.Point(712, 36);
            this.cmbPer2.Name = "cmbPer2";
            this.cmbPer2.Size = new System.Drawing.Size(162, 24);
            this.cmbPer2.TabIndex = 19;
            this.cmbPer2.SelectedIndexChanged += new System.EventHandler(this.cmbPer2_SelectedIndexChanged);
            // 
            // cmbImprimir
            // 
            this.cmbImprimir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbImprimir.FormattingEnabled = true;
            this.cmbImprimir.Location = new System.Drawing.Point(994, 471);
            this.cmbImprimir.Name = "cmbImprimir";
            this.cmbImprimir.Size = new System.Drawing.Size(162, 24);
            this.cmbImprimir.TabIndex = 20;
            this.cmbImprimir.SelectedIndexChanged += new System.EventHandler(this.cmbImprimir_SelectedIndexChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Enabled = false;
            this.pictureBox2.Image = global::ActividadesComplementarias.Properties.Resources.imprimir;
            this.pictureBox2.Location = new System.Drawing.Point(995, 514);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(49, 47);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 21;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(992, 434);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(170, 17);
            this.label15.TabIndex = 22;
            this.label15.Text = "seleccione un almno para";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(991, 451);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(102, 17);
            this.label16.TabIndex = 23;
            this.label16.Text = "poder imprimir:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(991, 417);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(129, 17);
            this.label17.TabIndex = 24;
            this.label17.Text = "Presione guardar y";
            // 
            // frmEvaluacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1168, 579);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.cmbImprimir);
            this.Controls.Add(this.cmbPer2);
            this.Controls.Add(this.cmbPer1);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvInscritos);
            this.Controls.Add(this.cmbTaller);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEvaluacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Evaluacion";
            this.Load += new System.EventHandler(this.frmEvaluacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInscritos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnImprimir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTaller;
        private System.Windows.Forms.DataGridView dgvInscritos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox btnImprimir;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column4;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column5;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column6;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column7;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column8;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column9;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.ComboBox cmbPer1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cmbPer2;
        private System.Windows.Forms.ComboBox cmbImprimir;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
    }
}