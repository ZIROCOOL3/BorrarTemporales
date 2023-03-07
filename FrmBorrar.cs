using System.ComponentModel;
using System.Windows.Forms;

namespace BorrarTemporales
{
    public partial class FrmBorrar : Form
    {
        public FrmBorrar()
        {
            InitializeComponent();
        }

        private void HiloBorrar_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            string path = @"C:\Users\JAVIER\AppData\Local\Temp";
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

            PgbBorrar.Maximum= Total;


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

        private void FrmBorrar_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            HiloBorrar.RunWorkerAsync();
        }

        private void HiloBorrar_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            PgbBorrar.Value=e.ProgressPercentage;
        }

        private void HiloBorrar_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
        }
    }
}