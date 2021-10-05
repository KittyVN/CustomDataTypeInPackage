using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.IO.Compression;


namespace TestApp
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        public void Application_Startup(object sender, StartupEventArgs e)
        {
            MainWindow window = new MainWindow();
            if (e.Args.Length == 1) //make sure an argument is passed
            //if(true)
            {
                FileInfo file = new FileInfo(e.Args[0]);
                //FileInfo file = new FileInfo(@"C:\Users\dschermann\Desktop\test\test.vp");
                if (file.Exists) //make sure it's actually a file
                {
                    using (ZipArchive archive = ZipFile.Open(file.FullName, ZipArchiveMode.Update))
                    {
                        ZipArchiveEntry entry = archive.GetEntry("test.txt");
                        /*using (StreamWriter writer = new StreamWriter(entry.Open()))
                        {
                            writer.BaseStream.Seek(0, SeekOrigin.End);
                            writer.WriteLine("append line to file");
                        }*/
                        using (StreamReader reader = new StreamReader(entry.Open()))
                        {
                            window.txtText1.Text = reader.ReadToEnd();
                        }
                    }


                    using (FileStream zipToOpen = new FileStream(file.FullName, FileMode.Open))
                    {
                        
                        using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update))
                        {
                            ZipArchiveEntry readmeEntry = archive.CreateEntry("Readme.txt");
                            using (StreamWriter writer = new StreamWriter(readmeEntry.Open()))
                            {
                                writer.WriteLine("Information about this package.");
                                writer.WriteLine("========================");
                            }
                        }
                    }
                         window.txtText.Text = "Opened via a file";

                    }
            }
            else
            {
                window.txtText.Text = "NOT opened via a file";
            }
            window.Show();

        }
    }
}
