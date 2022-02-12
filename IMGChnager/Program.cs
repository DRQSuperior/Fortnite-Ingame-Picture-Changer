using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMGChnager
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            const string message = "Would you like us to update your pictures?";
            const string caption = "DRQSuperior";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                var path1 = "\\FortniteGame\\Saved\\PersistentDownloadDir\\CMS\\Files\\C28FF1DE0C661DAF01E118A30B3F21B897A7A6E2";
                var path2 = Environment.GetEnvironmentVariable("LocalAppData") + path1;
                string[] files = Directory.GetFiles(@path2);
                foreach (var file in files)
                {
                    File.Delete(file);
                }
                const string message1 = "Fortnite must Launch to load new pictures";
                const string caption1 = "DRQSuperior";
                var result1 = MessageBox.Show(message1, caption1,
                                             MessageBoxButtons.OK,
                                             MessageBoxIcon.Information);

                Process.Start("com.epicgames.launcher://apps/Fortnite?action=launch");
            }
            if (result == DialogResult.No)
            {
                Application.Run(new Main());
            }
        }
    }
}
