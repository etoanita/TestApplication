using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Windows;
using System.Windows.Input;
using TestApplication.Model;

namespace TestApplication.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Device> CmbContent { get; set; }
        public ObservableCollection<Pump>? Pumps { get; set; }
        public ObservableCollection<ModelBase> DataGridItems { get; set; } = new ObservableCollection<ModelBase>();
        public MainViewModel()
        {
            LoadComboboxData("../../../DataSource/devices.json");
            SelectedItem = CmbContent.First();
            OnButtonClickCommand = new RelayCommand(async param => await ButtonClickAsync());
            ChangeLanguageCommand = new RelayCommand(param => ChangeLanguage());
            ButtonText = ELanguages.Ru;
        }

        private ELanguages _buttonText;

        public ELanguages ButtonText
        {
            get { return _buttonText; }
            set
            {
                _buttonText = value;
                OnPropertyChanged();
            }
        }

        private void ChangeLanguage()
        {
            if (ButtonText == ELanguages.Ru)
            {
                ResourceDictionary dict = new()
                {
                    Source = new Uri("Resources/StringResources.en.xaml", UriKind.Relative)
                };
                Application.Current.Resources.MergedDictionaries.Clear();
                Application.Current.Resources.MergedDictionaries.Add(dict);
                ButtonText = ELanguages.En;
            }
            else if (ButtonText == ELanguages.En)
            {
                ResourceDictionary dict = new()
                {
                    Source = new Uri("Resources/StringResources.ru.xaml", UriKind.Relative)
                };
                Application.Current.Resources.MergedDictionaries.Clear();
                Application.Current.Resources.MergedDictionaries.Add(dict);
                ButtonText = ELanguages.Ru;
            }
            else
                throw new NotImplementedException();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand OnButtonClickCommand { get; }
        public ICommand ChangeLanguageCommand { get; }

        private Device? _selectedItem;
        private ModelBase? _dataGridSelectedItem;
        public Device SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged();

            }
        }

        public ModelBase DataGridSelectedItem
        {
            get => _dataGridSelectedItem;
            set
            {
                _dataGridSelectedItem = value;
                OnPropertyChanged();

            }
        }

        private void LoadComboboxData(string filePath)
        {
            try
            {
                var jsonString = File.ReadAllText(filePath);
                var products = JsonSerializer.Deserialize<ObservableCollection<Device>>(jsonString);
                if (products != null)
                {
                    CmbContent = products;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
        }

        private async Task DownloadAndFillAsync<T>(string suffix) where T: ModelBase
        {
            string jsonResponse;
            using (HttpClient client = new HttpClient())
            {
                jsonResponse = await client.GetStringAsync(String.Concat("https://2392bb8b-2589-4515-a05d-bff3882c6c75.mock.pstmn.io/", suffix));
            }
            var items = JsonSerializer.Deserialize<ObservableCollection<T>>(jsonResponse);
            DataGridItems.Clear();
            foreach (var item in items)
                DataGridItems.Add(item);
        }

        private async Task ButtonClickAsync()
        {
            try
            {
                switch (_selectedItem.Name)
                {
                    case "pumps":
                        {
                            await DownloadAndFillAsync<Pump>("pumps");
                            break;
                        }
                    case "cylinders":
                        {
                            await DownloadAndFillAsync<Cylinder>("cylinders");
                            break;
                        }
                    case "valves":
                        {
                            await DownloadAndFillAsync<Valve>("valves");
                            break;
                        }
                    default:
                        throw new NotImplementedException();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
