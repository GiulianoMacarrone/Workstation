namespace IU
{
    partial class VisualizarOT
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
            this.dgvOTs = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonVisualizarOT = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOTs)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOTs
            // 
            this.dgvOTs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOTs.Location = new System.Drawing.Point(12, 25);
            this.dgvOTs.Name = "dgvOTs";
            this.dgvOTs.Size = new System.Drawing.Size(776, 413);
            this.dgvOTs.TabIndex = 0;
            this.dgvOTs.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOTs_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Seleccione una Orden de Trabajo";
            // 
            // buttonVisualizarOT
            // 
            this.buttonVisualizarOT.Location = new System.Drawing.Point(15, 441);
            this.buttonVisualizarOT.Name = "buttonVisualizarOT";
            this.buttonVisualizarOT.Size = new System.Drawing.Size(75, 23);
            this.buttonVisualizarOT.TabIndex = 2;
            this.buttonVisualizarOT.Text = "Visualizar";
            this.buttonVisualizarOT.UseVisualStyleBackColor = true;
            this.buttonVisualizarOT.Click += new System.EventHandler(this.buttonVisualizarOT_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(704, 441);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 23);
            this.buttonExit.TabIndex = 3;
            this.buttonExit.Text = "Salir";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // VisualizarOT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 471);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonVisualizarOT);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvOTs);
            this.Name = "VisualizarOT";
            this.Text = "Visualizar Orden de Trabajo";
            ((System.ComponentModel.ISupportInitialize)(this.dgvOTs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOTs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonVisualizarOT;
        private System.Windows.Forms.Button buttonExit;
    }
}