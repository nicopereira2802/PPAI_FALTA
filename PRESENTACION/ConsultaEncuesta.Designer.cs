namespace PRESENTACION
{
    partial class ConsultaEncuesta
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
            this.dateTimeInicio = new System.Windows.Forms.DateTimePicker();
            this.dateTimeFin = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.dataGridLlamadas = new System.Windows.Forms.DataGridView();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnCsv = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLlamadas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimeInicio
            // 
            this.dateTimeInicio.Location = new System.Drawing.Point(52, 108);
            this.dateTimeInicio.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dateTimeInicio.MaxDate = new System.DateTime(2023, 11, 28, 0, 0, 0, 0);
            this.dateTimeInicio.MinDate = new System.DateTime(2023, 1, 1, 0, 0, 0, 0);
            this.dateTimeInicio.Name = "dateTimeInicio";
            this.dateTimeInicio.Size = new System.Drawing.Size(212, 20);
            this.dateTimeInicio.TabIndex = 0;
            this.dateTimeInicio.Value = new System.DateTime(2023, 1, 1, 0, 0, 0, 0);
            // 
            // dateTimeFin
            // 
            this.dateTimeFin.Location = new System.Drawing.Point(52, 180);
            this.dateTimeFin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dateTimeFin.MaxDate = new System.DateTime(2023, 11, 28, 0, 0, 0, 0);
            this.dateTimeFin.MinDate = new System.DateTime(2023, 1, 1, 0, 0, 0, 0);
            this.dateTimeFin.Name = "dateTimeFin";
            this.dateTimeFin.Size = new System.Drawing.Size(212, 20);
            this.dateTimeFin.TabIndex = 1;
            this.dateTimeFin.Value = new System.DateTime(2023, 11, 28, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(49, 146);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Fecha Fin Periodo";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(49, 73);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fecha Inicio Periodo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(75, 29);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fechas del Periodo";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(104, 223);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(95, 49);
            this.btnBuscar.TabIndex = 5;
            this.btnBuscar.Text = "Buscar Llamadas por periodo";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(546, 340);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(95, 49);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // dataGridLlamadas
            // 
            this.dataGridLlamadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridLlamadas.Location = new System.Drawing.Point(289, 10);
            this.dataGridLlamadas.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridLlamadas.Name = "dataGridLlamadas";
            this.dataGridLlamadas.RowHeadersWidth = 51;
            this.dataGridLlamadas.RowTemplate.Height = 24;
            this.dataGridLlamadas.Size = new System.Drawing.Size(468, 143);
            this.dataGridLlamadas.TabIndex = 7;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(289, 159);
            this.listBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(468, 160);
            this.listBox1.TabIndex = 8;
            // 
            // btnCsv
            // 
            this.btnCsv.Location = new System.Drawing.Point(354, 340);
            this.btnCsv.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCsv.Name = "btnCsv";
            this.btnCsv.Size = new System.Drawing.Size(95, 49);
            this.btnCsv.TabIndex = 9;
            this.btnCsv.Text = "GenerarCsv";
            this.btnCsv.UseVisualStyleBackColor = true;
            this.btnCsv.Click += new System.EventHandler(this.btnCsv_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 439);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // ConsultaEncuesta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 445);
            this.Controls.Add(this.btnCsv);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.dataGridLlamadas);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimeFin);
            this.Controls.Add(this.dateTimeInicio);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ConsultaEncuesta";
            this.Text = "ConsultaEncuesta";
            this.Load += new System.EventHandler(this.ConsultaEncuesta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLlamadas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimeInicio;
        private System.Windows.Forms.DateTimePicker dateTimeFin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridView dataGridLlamadas;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnCsv;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}