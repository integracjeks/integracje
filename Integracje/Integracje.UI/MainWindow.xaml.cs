using Integracje.UI.View;
using System.Windows;
using System.Windows.Controls;

namespace Integracje.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Application.Current.MainWindow = this;
            var frame = (App.Current.MainWindow as MainWindow).GetFrame();
            frame.Navigate(new MainPage());
        }

        public Frame GetFrame()
        {
            return _mainFrame;
        }
    }
}