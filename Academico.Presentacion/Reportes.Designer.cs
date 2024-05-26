namespace Academico.Presentacion
{
    partial class Reportes
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
            this.components = new System.ComponentModel.Container();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.estudiantes = new Academico.Presentacion.Estudiantes();
            this.estudiantesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.estudiantesBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.spEstudiantesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.estudiantes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.estudiantesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.estudiantesBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spEstudiantesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Academico.Presentacion.EstudianteInforme2.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(31, 38);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(722, 246);
            this.reportViewer1.TabIndex = 0;
            // 
            // estudiantes
            // 
            this.estudiantes.DataSetName = "Estudiantes";
            this.estudiantes.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // estudiantesBindingSource
            // 
            this.estudiantesBindingSource.DataSource = this.estudiantes;
            this.estudiantesBindingSource.Position = 0;
            // 
            // estudiantesBindingSource1
            // 
            this.estudiantesBindingSource1.DataSource = this.estudiantes;
            this.estudiantesBindingSource1.Position = 0;
            // 
            // spEstudiantesBindingSource
            // 
            this.spEstudiantesBindingSource.DataMember = "spEstudiantes";
            this.spEstudiantesBindingSource.DataSource = this.estudiantes;
            // 
            // Reportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Reportes";
            this.Text = "Reportes";
            this.Load += new System.EventHandler(this.Reportes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.estudiantes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.estudiantesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.estudiantesBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spEstudiantesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource estudiantesBindingSource;
        private Estudiantes estudiantes;
        private System.Windows.Forms.BindingSource estudiantesBindingSource1;
        private System.Windows.Forms.BindingSource spEstudiantesBindingSource;
    }
}