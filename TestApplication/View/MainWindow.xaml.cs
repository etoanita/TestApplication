using System.Windows;
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
    }
}