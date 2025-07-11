namespace IU
{
    partial class CrearRotableForm
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
            this.textBoxSerie = new System.Windows.Forms.TextBox();
            this.textNroParte = new System.Windows.Forms.TextBox();
            this.textBoxDescripcion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonAceptar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelNroSerial = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxSerie
            // 
            this.textBoxSerie.BackColor = System.Drawing.Color.White;
            this.textBoxSerie.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBoxSerie.Location = new System.Drawing.Point(112, 82);
            this.textBoxSerie.Name = "textBoxSerie";
            this.textBoxSerie.Size = new System.Drawing.Size(287, 20);
            this.textBoxSerie.TabIndex = 25;
            // 
            // textNroParte
            // 
            this.textNroParte.BackColor = System.Drawing.Color.White;
            this.textNroParte.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textNroParte.Location = new System.Drawing.Point(112, 51);
            this.textNroParte.Name = "textNroParte";
            this.textNroParte.Size = new System.Drawing.Size(287, 20);
            this.textNroParte.TabIndex = 24;
            // 
            // textBoxDescripcion
            // 
            this.textBoxDescripcion.BackColor = System.Drawing.Color.White;
            this.textBoxDescripcion.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBoxDescripcion.Location = new System.Drawing.Point(112, 20);
            this.textBoxDescripcion.Name = "textBoxDescripcion";
            this.textBoxDescripcion.Size = new System.Drawing.Size(287, 20);
            this.textBoxDescripcion.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(12, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Numero de Parte";
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(204, 149);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelar.TabIndex = 17;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // buttonAceptar
            // 
            this.buttonAceptar.Location = new System.Drawing.Point(112, 149);
            this.buttonAceptar.Name = "buttonAceptar";
            this.buttonAceptar.Size = new System.Drawing.Size(75, 23);
            this.buttonAceptar.TabIndex = 16;
            this.buttonAceptar.Text = "Aceptar";
            this.buttonAceptar.UseVisualStyleBackColor = true;
            this.buttonAceptar.Click += new System.EventHandler(this.buttonAceptar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Descripcion";
            // 
            // labelNroSerial
            // 
            this.labelNroSerial.AutoSize = true;
            this.labelNroSerial.ForeColor = System.Drawing.Color.Black;
            this.labelNroSerial.Location = new System.Drawing.Point(12, 85);
            this.labelNroSerial.Name = "labelNroSerial";
            this.labelNroSerial.Size = new System.Drawing.Size(86, 13);
            this.labelNroSerial.TabIndex = 19;
            this.labelNroSerial.Text = "Numero de Serie";
            // 
            // CrearRotableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 214);
            this.Controls.Add(this.textBoxSerie);
            this.Controls.Add(this.textNroParte);
            this.Controls.Add(this.textBoxDescripcion);
            this.Controls.Add(this.labelNroSerial);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonAceptar);
            this.Controls.Add(this.label1);
            this.Name = "CrearRotableForm";
            this.Text = "CrearRotableForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxSerie;
        private System.Windows.Forms.TextBox textNroParte;
        private System.Windows.Forms.TextBox textBoxDescripcion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonAceptar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelNroSerial;
    }
}