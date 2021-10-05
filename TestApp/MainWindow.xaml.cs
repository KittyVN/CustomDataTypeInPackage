using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.IO.Compression;


namespace TestApp
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
       

        private void btnClick(object sender, RoutedEventArgs e)
        {
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)

                saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

                string path = saveFileDialog1.FileName;
                if(path!= "")
                {
                    System.IO.Directory.CreateDirectory(path);
                    string fileName = "test.txt";
                    string pathfile;
                    pathfile = System.IO.Path.Combine(path, fileName);
                    Console.WriteLine("Path to my file: {0}\n", pathfile);

                    BinaryWriter bw = new BinaryWriter(File.Create(pathfile));
                    bw.Write("Created with my APP, otherwise not much to read here");
                    bw.Dispose();


                    ZipFile.CreateFromDirectory(path, path + ".vp");
                    Directory.Delete(path,true);

                }

            }
        }

        

    }
    
}
