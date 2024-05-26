namespace Academico.Presentacion
{
    partial class Inicio
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
            this.btnEstudiante = new System.Windows.Forms.Button();
            this.btnDocente = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEstudiante
            // 
            this.btnEstudiante.Location = new System.Drawing.Point(93, 49);
            this.btnEstudiante.Name = "btnEstudiante";
            this.btnEstudiante.Size = new System.Drawing.Size(200, 93);
            this.btnEstudiante.TabIndex = 0;
            this.btnEstudiante.Text = "ESTUDIANTES";
            this.btnEstudiante.UseVisualStyleBackColor = true;
            this.btnEstudiante.Click += new System.EventHandler(this.btnEstudiante_Click);
            // 
            // btnDocente
            // 
            this.btnDocente.Location = new System.Drawing.Point(93, 186);
            this.btnDocente.Name = "btnDocente";
            this.btnDocente.Size = new System.Drawing.Size(200, 87);
            this.btnDocente.TabIndex = 1;
            this.btnDocente.Text = "DOCENTES";
            this.btnDocente.UseVisualStyleBackColor = true;
            this.btnDocente.Click += new System.EventHandler(this.btnDocente_Click);
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 323);
            this.Controls.Add(this.btnDocente);
            this.Controls.Add(this.btnEstudiante);
            this.Name = "Inicio";
            this.Text = "Inicio";
            this.Load += new System.EventHandler(this.Inicio_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEstudiante;
        private System.Windows.Forms.Button btnDocente;
    }
}