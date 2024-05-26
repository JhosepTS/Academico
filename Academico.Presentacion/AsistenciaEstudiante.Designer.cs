namespace Academico.Presentacion
{
    partial class AsistenciaEstudiante
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
            this.txtNumDocumento = new System.Windows.Forms.TextBox();
            this.txtNombres = new System.Windows.Forms.TextBox();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.txtHoraEntrada = new System.Windows.Forms.TextBox();
            this.txtHoraSalida = new System.Windows.Forms.TextBox();
            this.btnRegistrarEntrada = new System.Windows.Forms.Button();
            this.btnRegistrarSalida = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvAsistencias = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsistencias)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNumDocumento
            // 
            this.txtNumDocumento.Location = new System.Drawing.Point(216, 66);
            this.txtNumDocumento.Name = "txtNumDocumento";
            this.txtNumDocumento.Size = new System.Drawing.Size(100, 20);
            this.txtNumDocumento.TabIndex = 0;
            this.txtNumDocumento.TextChanged += new System.EventHandler(this.txtNumDocumento_TextChanged);
            // 
            // txtNombres
            // 
            this.txtNombres.Location = new System.Drawing.Point(216, 123);
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.Size = new System.Drawing.Size(100, 20);
            this.txtNombres.TabIndex = 1;
            // 
            // txtFecha
            // 
            this.txtFecha.Location = new System.Drawing.Point(216, 188);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(100, 20);
            this.txtFecha.TabIndex = 3;
            // 
            // txtHoraEntrada
            // 
            this.txtHoraEntrada.Location = new System.Drawing.Point(460, 96);
            this.txtHoraEntrada.Name = "txtHoraEntrada";
            this.txtHoraEntrada.Size = new System.Drawing.Size(125, 20);
            this.txtHoraEntrada.TabIndex = 4;
            // 
            // txtHoraSalida
            // 
            this.txtHoraSalida.Location = new System.Drawing.Point(460, 188);
            this.txtHoraSalida.Name = "txtHoraSalida";
            this.txtHoraSalida.Size = new System.Drawing.Size(125, 20);
            this.txtHoraSalida.TabIndex = 5;
            // 
            // btnRegistrarEntrada
            // 
            this.btnRegistrarEntrada.Location = new System.Drawing.Point(460, 56);
            this.btnRegistrarEntrada.Name = "btnRegistrarEntrada";
            this.btnRegistrarEntrada.Size = new System.Drawing.Size(125, 23);
            this.btnRegistrarEntrada.TabIndex = 6;
            this.btnRegistrarEntrada.Text = "RegistrarEntrada";
            this.btnRegistrarEntrada.UseVisualStyleBackColor = true;
            this.btnRegistrarEntrada.Click += new System.EventHandler(this.btnRegistrarEntrada_Click);
            // 
            // btnRegistrarSalida
            // 
            this.btnRegistrarSalida.Location = new System.Drawing.Point(460, 142);
            this.btnRegistrarSalida.Name = "btnRegistrarSalida";
            this.btnRegistrarSalida.Size = new System.Drawing.Size(125, 23);
            this.btnRegistrarSalida.TabIndex = 7;
            this.btnRegistrarSalida.Text = "Registrar Salida";
            this.btnRegistrarSalida.UseVisualStyleBackColor = true;
            this.btnRegistrarSalida.Click += new System.EventHandler(this.btnRegistrarSalida_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Num_Documento";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(86, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Nombres";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(86, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Fecha";
            // 
            // dgvAsistencias
            // 
            this.dgvAsistencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAsistencias.Location = new System.Drawing.Point(89, 265);
            this.dgvAsistencias.Name = "dgvAsistencias";
            this.dgvAsistencias.Size = new System.Drawing.Size(609, 150);
            this.dgvAsistencias.TabIndex = 13;
            // 
            // AsistenciaEstudiante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvAsistencias);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRegistrarSalida);
            this.Controls.Add(this.btnRegistrarEntrada);
            this.Controls.Add(this.txtHoraSalida);
            this.Controls.Add(this.txtHoraEntrada);
            this.Controls.Add(this.txtFecha);
            this.Controls.Add(this.txtNombres);
            this.Controls.Add(this.txtNumDocumento);
            this.Name = "AsistenciaEstudiante";
            this.Text = "AsistenciaEstudiante";
            this.Load += new System.EventHandler(this.AsistenciaEstudiante_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsistencias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNumDocumento;
        private System.Windows.Forms.TextBox txtNombres;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.TextBox txtHoraEntrada;
        private System.Windows.Forms.TextBox txtHoraSalida;
        private System.Windows.Forms.Button btnRegistrarEntrada;
        private System.Windows.Forms.Button btnRegistrarSalida;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvAsistencias;
    }
}