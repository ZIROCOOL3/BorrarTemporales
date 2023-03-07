namespace BorrarTemporales
{
    partial class FrmBorrar
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBorrar));
            this.HiloBorrar = new System.ComponentModel.BackgroundWorker();
            this.PgbBorrar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // HiloBorrar
            // 
            this.HiloBorrar.WorkerReportsProgress = true;
            this.HiloBorrar.DoWork += new System.ComponentModel.DoWorkEventHandler(this.HiloBorrar_DoWork);
            this.HiloBorrar.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.HiloBorrar_ProgressChanged);
            this.HiloBorrar.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.HiloBorrar_RunWorkerCompleted);
            // 
            // PgbBorrar
            // 
            this.PgbBorrar.Location = new System.Drawing.Point(12, 21);
            this.PgbBorrar.Name = "PgbBorrar";
            this.PgbBorrar.Size = new System.Drawing.Size(367, 23);
            this.PgbBorrar.TabIndex = 0;
            // 
            // FrmBorrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 67);
            this.Controls.Add(this.PgbBorrar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmBorrar";
            this.Text = "Borrar Temporales";
            this.Load += new System.EventHandler(this.FrmBorrar_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker HiloBorrar;
        private ProgressBar PgbBorrar;
    }
}