namespace IU
{
    partial class VisualizarPanolForm
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
            this.bttnCancelar = new System.Windows.Forms.Button();
            this.dataGridViewComponentes = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewComponentes)).BeginInit();
            this.SuspendLayout();
            // 
            // bttnCancelar
            // 
            this.bttnCancelar.Location = new System.Drawing.Point(400, 568);
            this.bttnCancelar.Name = "bttnCancelar";
            this.bttnCancelar.Size = new System.Drawing.Size(75, 23);
            this.bttnCancelar.TabIndex = 0;
            this.bttnCancelar.Text = "Cancelar";
            this.bttnCancelar.UseVisualStyleBackColor = true;
            this.bttnCancelar.Click += new System.EventHandler(this.bttnCancelar_Click);
            // 
            // dataGridViewComponentes
            // 
            this.dataGridViewComponentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewComponentes.Location = new System.Drawing.Point(1, 1);
            this.dataGridViewComponentes.Name = "dataGridViewComponentes";
            this.dataGridViewComponentes.Size = new System.Drawing.Size(505, 537);
            this.dataGridViewComponentes.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 568);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Entregar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonEntregar_Click);
            // 
            // VisualizarPanolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 615);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridViewComponentes);
            this.Controls.Add(this.bttnCancelar);
            this.Name = "VisualizarPanolForm";
            this.Text = "Buscar Componentes";
            this.Load += new System.EventHandler(this.VisualizarPanolForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewComponentes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bttnCancelar;
        private System.Windows.Forms.DataGridView dataGridViewComponentes;
        private System.Windows.Forms.Button button1;
    }
}