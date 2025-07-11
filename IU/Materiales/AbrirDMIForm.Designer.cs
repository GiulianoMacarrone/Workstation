namespace IU
{
    partial class AbrirDMIForm
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
            this.buttonCerrar = new System.Windows.Forms.Button();
            this.txtNoStock = new System.Windows.Forms.TextBox();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.txtMEL = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.RichTextBox();
            this.txtNroDMI = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxMatriculaAeronave = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePickerFechaApertura = new System.Windows.Forms.DateTimePicker();
            this.buttonAbrirDMI = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonCerrar
            // 
            this.buttonCerrar.Location = new System.Drawing.Point(330, 398);
            this.buttonCerrar.Name = "buttonCerrar";
            this.buttonCerrar.Size = new System.Drawing.Size(75, 23);
            this.buttonCerrar.TabIndex = 41;
            this.buttonCerrar.Text = "Cancelar";
            this.buttonCerrar.UseVisualStyleBackColor = true;
            this.buttonCerrar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // txtNoStock
            // 
            this.txtNoStock.Location = new System.Drawing.Point(97, 312);
            this.txtNoStock.Name = "txtNoStock";
            this.txtNoStock.Size = new System.Drawing.Size(123, 20);
            this.txtNoStock.TabIndex = 40;
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Location = new System.Drawing.Point(109, 274);
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(296, 20);
            this.txtObservaciones.TabIndex = 39;
            // 
            // txtMEL
            // 
            this.txtMEL.Location = new System.Drawing.Point(96, 233);
            this.txtMEL.Name = "txtMEL";
            this.txtMEL.Size = new System.Drawing.Size(124, 20);
            this.txtMEL.TabIndex = 36;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(97, 171);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(308, 48);
            this.txtDescripcion.TabIndex = 35;
            this.txtDescripcion.Text = "";
            // 
            // txtNroDMI
            // 
            this.txtNroDMI.Location = new System.Drawing.Point(100, 93);
            this.txtNroDMI.Name = "txtNroDMI";
            this.txtNroDMI.Size = new System.Drawing.Size(124, 20);
            this.txtNroDMI.TabIndex = 33;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(27, 315);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 13);
            this.label10.TabIndex = 32;
            this.label10.Text = "No-Stock";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(27, 277);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 13);
            this.label9.TabIndex = 31;
            this.label9.Text = "Observaciones";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 236);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 30;
            this.label8.Text = "Item MEL";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Fecha Apertura";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Descripción";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Numero DMI";
            // 
            // comboBoxMatriculaAeronave
            // 
            this.comboBoxMatriculaAeronave.FormattingEnabled = true;
            this.comboBoxMatriculaAeronave.Location = new System.Drawing.Point(86, 21);
            this.comboBoxMatriculaAeronave.Name = "comboBoxMatriculaAeronave";
            this.comboBoxMatriculaAeronave.Size = new System.Drawing.Size(144, 21);
            this.comboBoxMatriculaAeronave.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Aeronave";
            // 
            // dateTimePickerFechaApertura
            // 
            this.dateTimePickerFechaApertura.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerFechaApertura.Location = new System.Drawing.Point(113, 61);
            this.dateTimePickerFechaApertura.Name = "dateTimePickerFechaApertura";
            this.dateTimePickerFechaApertura.Size = new System.Drawing.Size(111, 20);
            this.dateTimePickerFechaApertura.TabIndex = 42;
            this.dateTimePickerFechaApertura.Value = new System.DateTime(2025, 7, 10, 18, 7, 9, 0);
            // 
            // buttonAbrirDMI
            // 
            this.buttonAbrirDMI.Location = new System.Drawing.Point(30, 398);
            this.buttonAbrirDMI.Name = "buttonAbrirDMI";
            this.buttonAbrirDMI.Size = new System.Drawing.Size(75, 23);
            this.buttonAbrirDMI.TabIndex = 43;
            this.buttonAbrirDMI.Text = "Abrir";
            this.buttonAbrirDMI.UseVisualStyleBackColor = true;
            this.buttonAbrirDMI.Click += new System.EventHandler(this.buttonAbrirDMI_Click);
            // 
            // AbrirDMIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 427);
            this.Controls.Add(this.buttonAbrirDMI);
            this.Controls.Add(this.dateTimePickerFechaApertura);
            this.Controls.Add(this.buttonCerrar);
            this.Controls.Add(this.txtNoStock);
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.txtMEL);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.txtNroDMI);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxMatriculaAeronave);
            this.Controls.Add(this.label1);
            this.Name = "AbrirDMIForm";
            this.Text = "Nuevo Diferido";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCerrar;
        private System.Windows.Forms.TextBox txtNoStock;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.TextBox txtMEL;
        private System.Windows.Forms.RichTextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtNroDMI;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxMatriculaAeronave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePickerFechaApertura;
        private System.Windows.Forms.Button buttonAbrirDMI;
    }
}