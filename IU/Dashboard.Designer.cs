namespace IU
{
    partial class Dashboard
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.dgvDisponibles = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvRealizadas = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.buttonHoy = new System.Windows.Forms.Button();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.buttonCerrar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTotalOTs = new System.Windows.Forms.TextBox();
            this.txtTotalPendientes = new System.Windows.Forms.TextBox();
            this.txtTotalRealizadas = new System.Windows.Forms.TextBox();
            this.txtPromedioTareas = new System.Windows.Forms.TextBox();
            this.printButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.chartHeatMap = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartPromedioCierreTareas = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartCumplimiento = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dgvHistorialEstado = new System.Windows.Forms.DataGridView();
            this.label12 = new System.Windows.Forms.Label();
            this.buttonImprimirHistorialEstadoFlota = new System.Windows.Forms.Button();
            this.buttonActualizarEstadoAeronave = new System.Windows.Forms.Button();
            this.buttonAbrirUbicacionArchivos = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDisponibles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRealizadas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartHeatMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPromedioCierreTareas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCumplimiento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorialEstado)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpDesde
            // 
            this.dtpDesde.CustomFormat = "";
            this.dtpDesde.Location = new System.Drawing.Point(57, 12);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(200, 20);
            this.dtpDesde.TabIndex = 0;
            this.dtpDesde.Value = new System.DateTime(2025, 6, 25, 19, 51, 14, 0);
            // 
            // dgvDisponibles
            // 
            this.dgvDisponibles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDisponibles.Location = new System.Drawing.Point(12, 81);
            this.dgvDisponibles.Name = "dgvDisponibles";
            this.dgvDisponibles.ReadOnly = true;
            this.dgvDisponibles.Size = new System.Drawing.Size(461, 181);
            this.dgvDisponibles.TabIndex = 1;
            this.dgvDisponibles.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDisponibles_CellDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Trabajos disponibles";
            // 
            // dgvRealizadas
            // 
            this.dgvRealizadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRealizadas.Location = new System.Drawing.Point(12, 301);
            this.dgvRealizadas.Name = "dgvRealizadas";
            this.dgvRealizadas.ReadOnly = true;
            this.dgvRealizadas.Size = new System.Drawing.Size(461, 150);
            this.dgvRealizadas.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 285);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Trabajos realizados";
            // 
            // chart
            // 
            chartArea5.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.chart.Legends.Add(legend5);
            this.chart.Location = new System.Drawing.Point(540, 71);
            this.chart.Name = "chart";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            this.chart.Series.Add(series5);
            this.chart.Size = new System.Drawing.Size(630, 366);
            this.chart.TabIndex = 5;
            this.chart.Text = "chart1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(547, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tareas Creadas vs Completadas";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Location = new System.Drawing.Point(325, 12);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(200, 20);
            this.dtpHasta.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Desde";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(284, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Hasta";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(1269, 15);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(93, 20);
            this.lblUsername.TabIndex = 12;
            this.lblUsername.Text = "UserName";
            // 
            // buttonHoy
            // 
            this.buttonHoy.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonHoy.Location = new System.Drawing.Point(631, 12);
            this.buttonHoy.Name = "buttonHoy";
            this.buttonHoy.Size = new System.Drawing.Size(99, 23);
            this.buttonHoy.TabIndex = 13;
            this.buttonHoy.Text = "Hoy";
            this.buttonHoy.UseVisualStyleBackColor = true;
            this.buttonHoy.Click += new System.EventHandler(this.buttonHoy_Click);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFiltrar.Location = new System.Drawing.Point(540, 12);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(99, 23);
            this.btnFiltrar.TabIndex = 17;
            this.btnFiltrar.Text = "Personalizado";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Location = new System.Drawing.Point(819, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 23);
            this.button2.TabIndex = 18;
            this.button2.Text = "7 días";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button7dias_Click);
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Location = new System.Drawing.Point(727, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(99, 23);
            this.button3.TabIndex = 19;
            this.button3.Text = "30 días";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button30dias_Click);
            // 
            // buttonCerrar
            // 
            this.buttonCerrar.Location = new System.Drawing.Point(1735, 913);
            this.buttonCerrar.Name = "buttonCerrar";
            this.buttonCerrar.Size = new System.Drawing.Size(75, 23);
            this.buttonCerrar.TabIndex = 23;
            this.buttonCerrar.Text = "Cerrar";
            this.buttonCerrar.UseVisualStyleBackColor = true;
            this.buttonCerrar.Click += new System.EventHandler(this.buttonCerrar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 492);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Resumen:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 514);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "Total de Órdenes";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 537);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 13);
            this.label9.TabIndex = 26;
            this.label9.Text = "Órdenes Pendientes";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 562);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 13);
            this.label10.TabIndex = 27;
            this.label10.Text = "Órdenes Realizadas";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 585);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(134, 13);
            this.label11.TabIndex = 28;
            this.label11.Text = "Promedio de tareas por OT";
            // 
            // txtTotalOTs
            // 
            this.txtTotalOTs.Location = new System.Drawing.Point(110, 512);
            this.txtTotalOTs.Name = "txtTotalOTs";
            this.txtTotalOTs.Size = new System.Drawing.Size(78, 20);
            this.txtTotalOTs.TabIndex = 29;
            // 
            // txtTotalPendientes
            // 
            this.txtTotalPendientes.Location = new System.Drawing.Point(124, 534);
            this.txtTotalPendientes.Name = "txtTotalPendientes";
            this.txtTotalPendientes.Size = new System.Drawing.Size(63, 20);
            this.txtTotalPendientes.TabIndex = 30;
            // 
            // txtTotalRealizadas
            // 
            this.txtTotalRealizadas.Location = new System.Drawing.Point(123, 559);
            this.txtTotalRealizadas.Name = "txtTotalRealizadas";
            this.txtTotalRealizadas.Size = new System.Drawing.Size(64, 20);
            this.txtTotalRealizadas.TabIndex = 31;
            // 
            // txtPromedioTareas
            // 
            this.txtPromedioTareas.Location = new System.Drawing.Point(155, 582);
            this.txtPromedioTareas.Name = "txtPromedioTareas";
            this.txtPromedioTareas.Size = new System.Drawing.Size(69, 20);
            this.txtPromedioTareas.TabIndex = 32;
            // 
            // printButton
            // 
            this.printButton.Location = new System.Drawing.Point(398, 462);
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(75, 23);
            this.printButton.TabIndex = 33;
            this.printButton.Text = "Imprimir";
            this.printButton.UseVisualStyleBackColor = true;
            this.printButton.Click += new System.EventHandler(this.printButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(547, 455);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 35;
            this.label7.Text = "Cumplimiento";
            // 
            // chartHeatMap
            // 
            chartArea6.Name = "ChartArea1";
            this.chartHeatMap.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.chartHeatMap.Legends.Add(legend6);
            this.chartHeatMap.Location = new System.Drawing.Point(1204, 71);
            this.chartHeatMap.Name = "chartHeatMap";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bubble;
            series6.Legend = "Legend1";
            series6.Name = "Series1";
            series6.YValuesPerPoint = 2;
            this.chartHeatMap.Series.Add(series6);
            this.chartHeatMap.Size = new System.Drawing.Size(580, 366);
            this.chartHeatMap.TabIndex = 36;
            this.chartHeatMap.Text = "chart3";
            // 
            // chartPromedioCierreTareas
            // 
            chartArea7.Name = "ChartArea1";
            this.chartPromedioCierreTareas.ChartAreas.Add(chartArea7);
            legend7.Name = "Legend1";
            this.chartPromedioCierreTareas.Legends.Add(legend7);
            this.chartPromedioCierreTareas.Location = new System.Drawing.Point(983, 471);
            this.chartPromedioCierreTareas.Name = "chartPromedioCierreTareas";
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Range;
            series7.Legend = "Legend1";
            series7.Name = "Series1";
            series7.YValuesPerPoint = 2;
            this.chartPromedioCierreTareas.Series.Add(series7);
            this.chartPromedioCierreTareas.Size = new System.Drawing.Size(801, 413);
            this.chartPromedioCierreTareas.TabIndex = 37;
            this.chartPromedioCierreTareas.Text = "chart4";
            // 
            // chartCumplimiento
            // 
            chartArea8.Name = "ChartArea1";
            this.chartCumplimiento.ChartAreas.Add(chartArea8);
            legend8.Name = "Legend1";
            this.chartCumplimiento.Legends.Add(legend8);
            this.chartCumplimiento.Location = new System.Drawing.Point(540, 471);
            this.chartCumplimiento.Name = "chartCumplimiento";
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series8.Legend = "Legend1";
            series8.Name = "Series1";
            this.chartCumplimiento.Series.Add(series8);
            this.chartCumplimiento.Size = new System.Drawing.Size(265, 152);
            this.chartCumplimiento.TabIndex = 38;
            this.chartCumplimiento.Text = "chart2";
            // 
            // dgvHistorialEstado
            // 
            this.dgvHistorialEstado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorialEstado.Location = new System.Drawing.Point(12, 644);
            this.dgvHistorialEstado.Name = "dgvHistorialEstado";
            this.dgvHistorialEstado.ReadOnly = true;
            this.dgvHistorialEstado.Size = new System.Drawing.Size(906, 240);
            this.dgvHistorialEstado.TabIndex = 39;
            this.dgvHistorialEstado.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHistorialEstado_CellContentClick);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(15, 628);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(146, 13);
            this.label12.TabIndex = 40;
            this.label12.Text = "Historial Estado de Flota";
            // 
            // buttonImprimirHistorialEstadoFlota
            // 
            this.buttonImprimirHistorialEstadoFlota.Location = new System.Drawing.Point(155, 903);
            this.buttonImprimirHistorialEstadoFlota.Name = "buttonImprimirHistorialEstadoFlota";
            this.buttonImprimirHistorialEstadoFlota.Size = new System.Drawing.Size(75, 23);
            this.buttonImprimirHistorialEstadoFlota.TabIndex = 41;
            this.buttonImprimirHistorialEstadoFlota.Text = "Imprimir";
            this.buttonImprimirHistorialEstadoFlota.UseVisualStyleBackColor = true;
            this.buttonImprimirHistorialEstadoFlota.Click += new System.EventHandler(this.buttonImprimirHistorialEstadoFlota_Click);
            // 
            // buttonActualizarEstadoAeronave
            // 
            this.buttonActualizarEstadoAeronave.Location = new System.Drawing.Point(18, 903);
            this.buttonActualizarEstadoAeronave.Name = "buttonActualizarEstadoAeronave";
            this.buttonActualizarEstadoAeronave.Size = new System.Drawing.Size(108, 23);
            this.buttonActualizarEstadoAeronave.TabIndex = 42;
            this.buttonActualizarEstadoAeronave.Text = "Actualizar Estado";
            this.buttonActualizarEstadoAeronave.UseVisualStyleBackColor = true;
            this.buttonActualizarEstadoAeronave.Click += new System.EventHandler(this.buttonActualizarEstadoAeronave_Click);
            // 
            // buttonAbrirUbicacionArchivos
            // 
            this.buttonAbrirUbicacionArchivos.Location = new System.Drawing.Point(346, 541);
            this.buttonAbrirUbicacionArchivos.Name = "buttonAbrirUbicacionArchivos";
            this.buttonAbrirUbicacionArchivos.Size = new System.Drawing.Size(127, 61);
            this.buttonAbrirUbicacionArchivos.TabIndex = 43;
            this.buttonAbrirUbicacionArchivos.Text = "Abrir Ubicación de los Archivos";
            this.buttonAbrirUbicacionArchivos.UseVisualStyleBackColor = true;
            this.buttonAbrirUbicacionArchivos.Click += new System.EventHandler(this.buttonAbrirUbicacionArchivos_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1822, 948);
            this.Controls.Add(this.buttonAbrirUbicacionArchivos);
            this.Controls.Add(this.buttonActualizarEstadoAeronave);
            this.Controls.Add(this.buttonImprimirHistorialEstadoFlota);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.dgvHistorialEstado);
            this.Controls.Add(this.chartCumplimiento);
            this.Controls.Add(this.chartPromedioCierreTareas);
            this.Controls.Add(this.chartHeatMap);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.printButton);
            this.Controls.Add(this.txtPromedioTareas);
            this.Controls.Add(this.txtTotalRealizadas);
            this.Controls.Add(this.txtTotalPendientes);
            this.Controls.Add(this.txtTotalOTs);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.buttonCerrar);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.buttonHoy);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvRealizadas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvDisponibles);
            this.Controls.Add(this.dtpDesde);
            this.Name = "Dashboard";
            this.Tag = "";
            this.Text = "Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Dashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDisponibles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRealizadas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartHeatMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPromedioCierreTareas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCumplimiento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorialEstado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.DataGridView dgvDisponibles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvRealizadas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Button buttonHoy;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button buttonCerrar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtTotalOTs;
        private System.Windows.Forms.TextBox txtTotalPendientes;
        private System.Windows.Forms.TextBox txtTotalRealizadas;
        private System.Windows.Forms.TextBox txtPromedioTareas;
        private System.Windows.Forms.Button printButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartHeatMap;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPromedioCierreTareas;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCumplimiento;
        private System.Windows.Forms.DataGridView dgvHistorialEstado;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button buttonImprimirHistorialEstadoFlota;
        private System.Windows.Forms.Button buttonActualizarEstadoAeronave;
        private System.Windows.Forms.Button buttonAbrirUbicacionArchivos;
    }
}