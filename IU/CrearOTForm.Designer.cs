namespace Presentacion_IU
{
    partial class CrearOTForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxAeronaves = new System.Windows.Forms.ComboBox();
            this.textBoxTituloOT = new System.Windows.Forms.TextBox();
            this.comboBoxMatricula = new System.Windows.Forms.ComboBox();
            this.textBoxNroOT = new System.Windows.Forms.TextBox();
            this.textBoxSerialNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePickerFecha = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridViewTrabajos = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBoxTrabajo = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonGenerarOT = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTrabajos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Título";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Aeronave";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Matrícula";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(367, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "OT N°";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(569, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Fecha";
            // 
            // comboBoxAeronaves
            // 
            this.comboBoxAeronaves.FormattingEnabled = true;
            this.comboBoxAeronaves.Location = new System.Drawing.Point(81, 61);
            this.comboBoxAeronaves.Name = "comboBoxAeronaves";
            this.comboBoxAeronaves.Size = new System.Drawing.Size(121, 21);
            this.comboBoxAeronaves.TabIndex = 6;
            // 
            // textBoxTituloOT
            // 
            this.textBoxTituloOT.Location = new System.Drawing.Point(59, 19);
            this.textBoxTituloOT.Name = "textBoxTituloOT";
            this.textBoxTituloOT.Size = new System.Drawing.Size(285, 20);
            this.textBoxTituloOT.TabIndex = 7;
            // 
            // comboBoxMatricula
            // 
            this.comboBoxMatricula.FormattingEnabled = true;
            this.comboBoxMatricula.Location = new System.Drawing.Point(81, 95);
            this.comboBoxMatricula.Name = "comboBoxMatricula";
            this.comboBoxMatricula.Size = new System.Drawing.Size(121, 21);
            this.comboBoxMatricula.TabIndex = 9;
            // 
            // textBoxNroOT
            // 
            this.textBoxNroOT.Location = new System.Drawing.Point(410, 19);
            this.textBoxNroOT.Name = "textBoxNroOT";
            this.textBoxNroOT.ReadOnly = true;
            this.textBoxNroOT.Size = new System.Drawing.Size(136, 20);
            this.textBoxNroOT.TabIndex = 10;
            // 
            // textBoxSerialNumber
            // 
            this.textBoxSerialNumber.Location = new System.Drawing.Point(247, 95);
            this.textBoxSerialNumber.Name = "textBoxSerialNumber";
            this.textBoxSerialNumber.ReadOnly = true;
            this.textBoxSerialNumber.Size = new System.Drawing.Size(100, 20);
            this.textBoxSerialNumber.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(208, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Serial";
            // 
            // dateTimePickerFecha
            // 
            this.dateTimePickerFecha.Location = new System.Drawing.Point(612, 19);
            this.dateTimePickerFecha.Name = "dateTimePickerFecha";
            this.dateTimePickerFecha.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerFecha.TabIndex = 13;
            this.dateTimePickerFecha.Value = new System.DateTime(2025, 7, 4, 0, 0, 0, 0);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(17, 149);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 24);
            this.label7.TabIndex = 14;
            this.label7.Text = "Trabajo";
            // 
            // dataGridViewTrabajos
            // 
            this.dataGridViewTrabajos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTrabajos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dataGridViewTrabajos.Location = new System.Drawing.Point(418, 98);
            this.dataGridViewTrabajos.Name = "dataGridViewTrabajos";
            this.dataGridViewTrabajos.Size = new System.Drawing.Size(402, 218);
            this.dataGridViewTrabajos.TabIndex = 15;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Título";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Descripción";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Intervalo";
            this.Column3.Name = "Column3";
            // 
            // comboBoxTrabajo
            // 
            this.comboBoxTrabajo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxTrabajo.FormattingEnabled = true;
            this.comboBoxTrabajo.Location = new System.Drawing.Point(26, 186);
            this.comboBoxTrabajo.Name = "comboBoxTrabajo";
            this.comboBoxTrabajo.Size = new System.Drawing.Size(323, 28);
            this.comboBoxTrabajo.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(414, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(144, 24);
            this.label8.TabIndex = 17;
            this.label8.Text = "Lista de trabajos";
            // 
            // buttonGenerarOT
            // 
            this.buttonGenerarOT.Location = new System.Drawing.Point(26, 263);
            this.buttonGenerarOT.Name = "buttonGenerarOT";
            this.buttonGenerarOT.Size = new System.Drawing.Size(92, 36);
            this.buttonGenerarOT.TabIndex = 18;
            this.buttonGenerarOT.Text = "Generar";
            this.buttonGenerarOT.UseVisualStyleBackColor = true;
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(256, 263);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(88, 36);
            this.buttonCancelar.TabIndex = 20;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            // 
            // CrearOTForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 365);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonGenerarOT);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.comboBoxTrabajo);
            this.Controls.Add(this.dataGridViewTrabajos);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dateTimePickerFecha);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxSerialNumber);
            this.Controls.Add(this.textBoxNroOT);
            this.Controls.Add(this.comboBoxMatricula);
            this.Controls.Add(this.textBoxTituloOT);
            this.Controls.Add(this.comboBoxAeronaves);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CrearOTForm";
            this.Text = "CrearOTForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTrabajos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxAeronaves;
        private System.Windows.Forms.TextBox textBoxTituloOT;
        private System.Windows.Forms.ComboBox comboBoxMatricula;
        private System.Windows.Forms.TextBox textBoxNroOT;
        private System.Windows.Forms.TextBox textBoxSerialNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePickerFecha;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dataGridViewTrabajos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.ComboBox comboBoxTrabajo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Button buttonGenerarOT;
        private System.Windows.Forms.Button buttonCancelar;
    }
}