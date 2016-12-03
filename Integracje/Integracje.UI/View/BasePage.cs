using System.Windows;
using System.Windows.Controls;

namespace Integracje.UI.View
{
    public class BasePage : Page
    {
        public Frame Frame { get { return (Application.Current.MainWindow as MainWindow).GetFrame(); } }
    }
}