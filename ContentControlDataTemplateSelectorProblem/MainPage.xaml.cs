using Windows.UI.Xaml.Controls;

namespace ContentControlDataTemplateSelectorProblem
{
    public sealed partial class MainPage : Page
    {
        public MainPageViewModel ViewModel => DataContext as MainPageViewModel;

        public MainPage()
        {
            this.InitializeComponent();
            DataContext = new MainPageViewModel();
        }
    }
}
