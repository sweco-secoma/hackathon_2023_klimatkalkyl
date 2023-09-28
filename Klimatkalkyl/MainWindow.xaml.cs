using Klimatkalkyl.Entities;
using Klimatkalkyl.Parsers;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;

namespace Klimatkalkyl
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Resource> Resources { get; set; }

        private Resource Betong { get; set;}

        private string IFCFile { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            InitGraphics();
            ReadResources();
            GetBetongResource();
        }

        
        private void InitGraphics()
        {
            LabelFileName.Visibility = Visibility.Hidden;
            LabelFileNameSubject.Visibility = Visibility.Hidden;
        }

        private void ReadResources()
        {
            JsonParser jsonParser = new JsonParser();
            Resources = jsonParser.ParseResourceFile();
        }

        private void GetBetongResource()
        {
            Betong = JsonParser.GetResource(Resources, "betong");
        }

        private void ButtonOpenFile_Click(object sender, RoutedEventArgs e)
        {
            // Configure open file dialog box
            var dialog = new Microsoft.Win32.OpenFileDialog();
            //dialog.FileName = "Document"; // Default file name
            dialog.DefaultExt = ".ifc"; // Default file extension
            dialog.Filter = "IFC Files (.ifc)|*.ifc"; // Filter files by extension

            // Show open file dialog box
            bool? result = dialog.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                LabelFileName.Visibility = Visibility.Visible;
                LabelFileNameSubject.Visibility = Visibility.Visible;
                // Open document
                string filename = dialog.SafeFileName;
                LabelFileName.Content = filename;

                IFCParser iFCParser = new IFCParser();
                IFCFile = iFCParser.ParseIFCFile(dialog.FileName);
            }
        }
    }
}
