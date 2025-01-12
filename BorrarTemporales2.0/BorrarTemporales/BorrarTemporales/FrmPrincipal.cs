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
using System.Runtime.InteropServices; // Necesario para FileSystem

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

        // Declaración de SHEmptyRecycleBin
        [DllImport("shell32.dll", CharSet = CharSet.Unicode)]
        private static extern int SHEmptyRecycleBin(IntPtr hwnd, string pszRootPath, RecycleFlags dwFlags);

        [Flags]
        private enum RecycleFlags : uint
        {
            SHERB_NOCONFIRMATION = 0x00000001, // No muestra el cuadro de confirmación
            SHERB_NOPROGRESSUI = 0x00000002,  // No muestra la interfaz de progreso
            SHERB_NOSOUND = 0x00000004        // No reproduce el sonido al vaciar la papelera
        }
        private void HiloBorrar_DoWork(object sender, DoWorkEventArgs e)
        {
            //borro carpeta temporal del usuario
            string carpetaUsuario = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string path = carpetaUsuario+ @"\AppData\Local\Temp";
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
                catch (Exception) { }
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
                catch (Exception){}
                HiloBorrar.ReportProgress(i);
            }


            //borrar archivos de la papelera reciclaje
            try
            {
                int result = SHEmptyRecycleBin(IntPtr.Zero, null, RecycleFlags.SHERB_NOCONFIRMATION);
            }
            catch (Exception ex)
            {
            }

            //borro carpeta temporal de windows
            string carpeta = @"C:\Windows\Temp";

            try
            {
                if (Directory.Exists(carpeta))
                {
                    // Eliminar todos los archivos en la carpeta
                    foreach (string archivo in Directory.GetFiles(carpeta))
                    {
                        try
                        {
                            File.Delete(archivo);
                        }
                        catch (Exception ex)
                        {
                            // Registrar el error y continuar con el siguiente archivo
                            //Console.WriteLine($"No se pudo borrar el archivo: {archivo}. Error: {ex.Message}");
                        }
                    }

                    // Eliminar todas las subcarpetas
                    foreach (string subcarpeta in Directory.GetDirectories(carpeta))
                    {
                        try
                        {
                            Directory.Delete(subcarpeta, true); // Elimina subcarpeta y contenido
                        }
                        catch (Exception ex)
                        {
                            // Registrar el error y continuar con la siguiente subcarpeta
                            Console.WriteLine($"No se pudo borrar la subcarpeta: {subcarpeta}. Error: {ex.Message}");
                        }
                    }

                    //MessageBox.Show("Contenido eliminado (con excepciones, si las hubo).");
                }
                else
                {
                    //MessageBox.Show("La carpeta no existe.");
                }
            }
            catch (Exception ex)
            {
               // MessageBox.Show($"Ocurrió un error general: {ex.Message}");
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
