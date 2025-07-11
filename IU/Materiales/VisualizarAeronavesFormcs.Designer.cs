namespace IU
{
    partial class VisualizarAeronavesFormcs
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
            this.dataGridViewDiferidos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxMatriculaAeronave = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtNroDMI = new System.Windows.Forms.TextBox();
            this.txtFechaApertura = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.RichTextBox();
            this.txtMEL = new System.Windows.Forms.TextBox();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.txtFechaCierre = new System.Windows.Forms.TextBox();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.txtNoStock = new System.Windows.Forms.TextBox();
            this.buttonCerrar = new System.Windows.Forms.Button();
            this.buttonCerrarDMI = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDiferidos)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewDiferidos
            // 
            this.dataGridViewDiferidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDiferidos.Location = new System.Drawing.Point(19, 96);
            this.dataGridViewDiferidos.Name = "dataGridViewDiferidos";
            this.dataGridViewDiferidos.Size = new System.Drawing.Size(314, 317);
            this.dataGridViewDiferidos.TabIndex = 0;
            this.dataGridViewDiferidos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDiferidos_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Aeronave";
            // 
            // comboBoxMatriculaAeronave
            // 
            this.comboBoxMatriculaAeronave.FormattingEnabled = true;
            this.comboBoxMatriculaAeronave.Location = new System.Drawing.Point(89, 27);
            this.comboBoxMatriculaAeronave.Name = "comboBoxMatriculaAeronave";
            this.comboBoxMatriculaAeronave.Size = new System.Drawing.Size(144, 21);
            this.comboBoxMatriculaAeronave.TabIndex = 2;
            this.comboBoxMatriculaAeronave.SelectedIndexChanged += new System.EventHandler(this.comboBoxMatriculaAeronave_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Diferidos";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(359, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Numero DMI";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(363, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Descripción";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(359, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Fecha Apertura";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(447, 345);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Fecha de Cierre";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(363, 203);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Estado";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(363, 161);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Item MEL";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(363, 243);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Observaciones";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(363, 281);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 13);
            this.label10.TabIndex = 11;
            this.label10.Text = "No-Stock";
            // 
            // txtNroDMI
            // 
            this.txtNroDMI.Location = new System.Drawing.Point(432, 56);
            this.txtNroDMI.Name = "txtNroDMI";
            this.txtNroDMI.ReadOnly = true;
            this.txtNroDMI.Size = new System.Drawing.Size(124, 20);
            this.txtNroDMI.TabIndex = 12;
            // 
            // txtFechaApertura
            // 
            this.txtFechaApertura.Location = new System.Drawing.Point(445, 24);
            this.txtFechaApertura.Name = "txtFechaApertura";
            this.txtFechaApertura.ReadOnly = true;
            this.txtFechaApertura.Size = new System.Drawing.Size(111, 20);
            this.txtFechaApertura.TabIndex = 13;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(433, 96);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.ReadOnly = true;
            this.txtDescripcion.Size = new System.Drawing.Size(308, 48);
            this.txtDescripcion.TabIndex = 14;
            this.txtDescripcion.Text = "";
            // 
            // txtMEL
            // 
            this.txtMEL.Location = new System.Drawing.Point(432, 158);
            this.txtMEL.Name = "txtMEL";
            this.txtMEL.ReadOnly = true;
            this.txtMEL.Size = new System.Drawing.Size(124, 20);
            this.txtMEL.TabIndex = 15;
            // 
            // txtEstado
            // 
            this.txtEstado.Location = new System.Drawing.Point(432, 200);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.ReadOnly = true;
            this.txtEstado.Size = new System.Drawing.Size(124, 20);
            this.txtEstado.TabIndex = 16;
            // 
            // txtFechaCierre
            // 
            this.txtFechaCierre.Location = new System.Drawing.Point(535, 342);
            this.txtFechaCierre.Name = "txtFechaCierre";
            this.txtFechaCierre.ReadOnly = true;
            this.txtFechaCierre.Size = new System.Drawing.Size(111, 20);
            this.txtFechaCierre.TabIndex = 17;
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Location = new System.Drawing.Point(445, 240);
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.ReadOnly = true;
            this.txtObservaciones.Size = new System.Drawing.Size(296, 20);
            this.txtObservaciones.TabIndex = 18;
            // 
            // txtNoStock
            // 
            this.txtNoStock.Location = new System.Drawing.Point(433, 278);
            this.txtNoStock.Name = "txtNoStock";
            this.txtNoStock.ReadOnly = true;
            this.txtNoStock.Size = new System.Drawing.Size(123, 20);
            this.txtNoStock.TabIndex = 19;
            // 
            // buttonCerrar
            // 
            this.buttonCerrar.Location = new System.Drawing.Point(713, 415);
            this.buttonCerrar.Name = "buttonCerrar";
            this.buttonCerrar.Size = new System.Drawing.Size(75, 23);
            this.buttonCerrar.TabIndex = 20;
            this.buttonCerrar.Text = "Cancelar";
            this.buttonCerrar.UseVisualStyleBackColor = true;
            this.buttonCerrar.Click += new System.EventHandler(this.buttonCerrar_Click);
            // 
            // buttonCerrarDMI
            // 
            this.buttonCerrarDMI.Enabled = false;
            this.buttonCerrarDMI.Location = new System.Drawing.Point(366, 340);
            this.buttonCerrarDMI.Name = "buttonCerrarDMI";
            this.buttonCerrarDMI.Size = new System.Drawing.Size(75, 23);
            this.buttonCerrarDMI.TabIndex = 21;
            this.buttonCerrarDMI.Text = "Cerrar DMI";
            this.buttonCerrarDMI.UseVisualStyleBackColor = true;
            this.buttonCerrarDMI.Visible = false;
            this.buttonCerrarDMI.Click += new System.EventHandler(this.buttonCerrarDMI_Click);
            // 
            // VisualizarAeronavesFormcs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonCerrarDMI);
            this.Controls.Add(this.buttonCerrar);
            this.Controls.Add(this.txtNoStock);
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.txtFechaCierre);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.txtMEL);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.txtFechaApertura);
            this.Controls.Add(this.txtNroDMI);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxMatriculaAeronave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewDiferidos);
            this.Name = "VisualizarAeronavesFormcs";
            this.Text = "Visualizar Aeronaves";
            this.Load += new System.EventHandler(this.VisualizarAeronavesFormcs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDiferidos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewDiferidos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxMatriculaAeronave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtNroDMI;
        private System.Windows.Forms.TextBox txtFechaApertura;
        private System.Windows.Forms.RichTextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtMEL;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.TextBox txtFechaCierre;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.TextBox txtNoStock;
        private System.Windows.Forms.Button buttonCerrar;
        private System.Windows.Forms.Button buttonCerrarDMI;
    }
}