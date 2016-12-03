using Integracje.UI.ViewModel;

namespace Integracje.UI.View
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : BasePage
    {
        #region Constructors

        public MainPage()
        {
            InitializeComponent();
            DataContext = new MainPageViewModel();
        }

        #endregion Constructors
    }
}