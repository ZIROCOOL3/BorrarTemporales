namespace BorrarTemporales
{
    partial class FrmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.PgbBorrar = new Telerik.WinControls.UI.RadProgressBar();
            this.HiloBorrar = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.PgbBorrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // PgbBorrar
            // 
            this.PgbBorrar.Location = new System.Drawing.Point(12, 12);
            this.PgbBorrar.Name = "PgbBorrar";
            this.PgbBorrar.Size = new System.Drawing.Size(308, 44);
            this.PgbBorrar.TabIndex = 0;
            // 
            // HiloBorrar
            // 
            this.HiloBorrar.WorkerReportsProgress = true;
            this.HiloBorrar.DoWork += new System.ComponentModel.DoWorkEventHandler(this.HiloBorrar_DoWork);
            this.HiloBorrar.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.HiloBorrar_ProgressChanged);
            this.HiloBorrar.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.HiloBorrar_RunWorkerCompleted);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 68);
            this.Controls.Add(this.PgbBorrar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPrincipal";
            this.Text = "Borrar Temporales";
            this.Load += new System.EventHandler(this.RadForm1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PgbBorrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadProgressBar PgbBorrar;
        private System.ComponentModel.BackgroundWorker HiloBorrar;
    }
}