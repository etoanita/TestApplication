using System.Globalization;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TestApplication.ViewModel;

namespace TestApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
            public MainWindow()
            {
                InitializeComponent();
                DataContext = new MainViewModel();
        }

        //private void SwitchToFrench(object sender, RoutedEventArgs e)
        //{
        //    SetLanguage("fr-FR");
        //}

        //private void SwitchToEnglish(object sender, RoutedEventArgs e)
        //{
        //    SetLanguage("en-US");
        //}

        private void SetLanguage(string culture)
            {
                var dict = new ResourceDictionary();
                switch (culture)
                {
                    case "fr-FR":
                        dict.Source = new System.Uri("Resources/StringResources.fr-FR.xaml", System.UriKind.Relative);
                        break;
                    case "en-US":
                        dict.Source = new System.Uri("Resources/StringResources.en-US.xaml", System.UriKind.Relative);
                        break;
                    default:
                        dict.Source = new System.Uri("Resources/StringResources.xaml", System.UriKind.Relative);
                        break;
                }

                // Clear the old resource dictionaries and add the new one
                this.Resources.MergedDictionaries.Clear();
                this.Resources.MergedDictionaries.Add(dict);
            }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}