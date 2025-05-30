using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;


namespace Smart_Home_App
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            _activeButton = btnHome;
        }

        private Button _activeButton;

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            var clickedButton = sender as Button;

            if (_activeButton != null)
                _activeButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#437921"));

            clickedButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffffff"));
            _activeButton = clickedButton;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        bool IsMaximized = false;

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (IsMaximized)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1080;
                    this.Height = 720;

                    IsMaximized = false;    
                }
                else
                {
                    this.WindowState = WindowState.Maximized;

                    IsMaximized = true;
                }
            }
        }
    }
}