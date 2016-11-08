using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Integracje.UI.View
{
    public class BasePage : Page
    {
        public Frame Frame { get { return (Application.Current.MainWindow as MainWindow).GetFrame(); } }

    }
}
