using System.Windows;


namespace Klimatkalkyl
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            LabelFileName.Visibility = Visibility.Hidden;
            LabelFileNameSubject.Visibility = Visibility.Hidden;
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
            }
        }
    }
}
