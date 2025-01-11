using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace BorrarTemporales
{
    public partial class FrmPrincipal : Telerik.WinControls.UI.RadForm
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void radProgressBar1_Click(object sender, EventArgs e)
        {
                    }

        private void HiloBorrar_DoWork(object sender, DoWorkEventArgs e)
        {
            string path = @"C:\Users\JAVI\AppData\Local\Temp";
            int Total = 0;
            int i = 0;
            DirectoryInfo directory = new DirectoryInfo(path);

            //cuento cuantos archivos tiene
            foreach (FileInfo file in directory.GetFiles())
            {
                Total++;
            }
            foreach (DirectoryInfo dir in directory.GetDirectories())
            {
                Total++;
            }

            PgbBorrar.Maximum = Total;


            //borro archivos
            foreach (FileInfo file in directory.GetFiles())
            {
                i++;
                try
                {
                    file.Delete();
                }
                catch (Exception)
                {


                }

                HiloBorrar.ReportProgress(i);

            }
            //borro carpetas
            foreach (DirectoryInfo dir in directory.GetDirectories())
            {
                i++;
                try
                {
                    dir.Delete(true);
                }
                catch (Exception)
                {


                }
                HiloBorrar.ReportProgress(i);

            }
        }

        private void RadForm1_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            HiloBorrar.RunWorkerAsync();
        }

        private void HiloBorrar_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            PgbBorrar.Value1 = e.ProgressPercentage;
        }

        private void HiloBorrar_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
        }
    }
}
