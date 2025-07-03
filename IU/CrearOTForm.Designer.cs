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
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxAeronaves = new System.Windows.Forms.ComboBox();
            this.textBoxTituloOT = new System.Windows.Forms.TextBox();
            this.textBoxNroOT = new System.Windows.Forms.TextBox();
            this.textBoxSerialNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePickerFecha = new System.Windows.Forms.DateTimePicker();
            this.lblTrabajo = new System.Windows.Forms.Label();
            this.dgvTrabajos = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonGenerarOT = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.dataGridViewTareas = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrabajos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTareas)).BeginInit();
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
            this.comboBoxAeronaves.SelectedIndexChanged += new System.EventHandler(this.comboBoxAeronaves_SelectedIndexChanged);
            // 
            // textBoxTituloOT
            // 
            this.textBoxTituloOT.Location = new System.Drawing.Point(59, 19);
            this.textBoxTituloOT.Name = "textBoxTituloOT";
            this.textBoxTituloOT.Size = new System.Drawing.Size(285, 20);
            this.textBoxTituloOT.TabIndex = 7;
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
            this.textBoxSerialNumber.Location = new System.Drawing.Point(247, 61);
            this.textBoxSerialNumber.Name = "textBoxSerialNumber";
            this.textBoxSerialNumber.ReadOnly = true;
            this.textBoxSerialNumber.Size = new System.Drawing.Size(100, 20);
            this.textBoxSerialNumber.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(208, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Serial";
            // 
            // dateTimePickerFecha
            // 
            this.dateTimePickerFecha.Enabled = false;
            this.dateTimePickerFecha.Location = new System.Drawing.Point(612, 19);
            this.dateTimePickerFecha.Name = "dateTimePickerFecha";
            this.dateTimePickerFecha.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerFecha.TabIndex = 13;
            this.dateTimePickerFecha.Value = new System.DateTime(2025, 7, 2, 0, 0, 0, 0);
            // 
            // lblTrabajo
            // 
            this.lblTrabajo.AutoSize = true;
            this.lblTrabajo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrabajo.Location = new System.Drawing.Point(12, 344);
            this.lblTrabajo.Name = "lblTrabajo";
            this.lblTrabajo.Size = new System.Drawing.Size(74, 24);
            this.lblTrabajo.TabIndex = 14;
            this.lblTrabajo.Text = "Trabajo";
            // 
            // dgvTrabajos
            // 
            this.dgvTrabajos.AllowUserToAddRows = false;
            this.dgvTrabajos.AllowUserToDeleteRows = false;
            this.dgvTrabajos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTrabajos.Location = new System.Drawing.Point(16, 133);
            this.dgvTrabajos.MultiSelect = false;
            this.dgvTrabajos.Name = "dgvTrabajos";
            this.dgvTrabajos.ReadOnly = true;
            this.dgvTrabajos.Size = new System.Drawing.Size(872, 208);
            this.dgvTrabajos.TabIndex = 15;
            this.dgvTrabajos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTrabajos_CellClick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(17, 106);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(144, 24);
            this.label8.TabIndex = 17;
            this.label8.Text = "Lista de trabajos";
            // 
            // buttonGenerarOT
            // 
            this.buttonGenerarOT.Location = new System.Drawing.Point(12, 633);
            this.buttonGenerarOT.Name = "buttonGenerarOT";
            this.buttonGenerarOT.Size = new System.Drawing.Size(92, 36);
            this.buttonGenerarOT.TabIndex = 18;
            this.buttonGenerarOT.Text = "Generar";
            this.buttonGenerarOT.UseVisualStyleBackColor = true;
            this.buttonGenerarOT.Click += new System.EventHandler(this.buttonGenerarOT_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(800, 633);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(88, 36);
            this.buttonCancelar.TabIndex = 20;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // dataGridViewTareas
            // 
            this.dataGridViewTareas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTareas.Location = new System.Drawing.Point(16, 371);
            this.dataGridViewTareas.Name = "dataGridViewTareas";
            this.dataGridViewTareas.Size = new System.Drawing.Size(872, 256);
            this.dataGridViewTareas.TabIndex = 21;
            // 
            // CrearOTForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 681);
            this.Controls.Add(this.dataGridViewTareas);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonGenerarOT);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dgvTrabajos);
            this.Controls.Add(this.lblTrabajo);
            this.Controls.Add(this.dateTimePickerFecha);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxSerialNumber);
            this.Controls.Add(this.textBoxNroOT);
            this.Controls.Add(this.textBoxTituloOT);
            this.Controls.Add(this.comboBoxAeronaves);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CrearOTForm";
            this.Text = "Crear Orden de Trabajo";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrabajos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTareas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxAeronaves;
        private System.Windows.Forms.TextBox textBoxTituloOT;
        private System.Windows.Forms.TextBox textBoxNroOT;
        private System.Windows.Forms.TextBox textBoxSerialNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePickerFecha;
        private System.Windows.Forms.Label lblTrabajo;
        private System.Windows.Forms.DataGridView dgvTrabajos;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonGenerarOT;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.DataGridView dataGridViewTareas;
    }
}