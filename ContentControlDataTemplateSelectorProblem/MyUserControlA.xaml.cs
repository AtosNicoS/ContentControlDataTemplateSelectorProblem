using Windows.UI.Xaml.Controls;

namespace ContentControlDataTemplateSelectorProblem
{
    public sealed partial class MyUserControlA : UserControl
    {
        public MyUserControlAViewModel ViewModel => DataContext as MyUserControlAViewModel;

        public MyUserControlA()
        {
            this.InitializeComponent();
        }
    }

    public class MyUserControlAViewModel : BindableBase
    {
        public MyUserControlAViewModel(string text)
        {
            Text = text;
        }
        public string Text
        {
            get => _text;
            private set => Set(ref _text, value);
        }
        private string _text;
    }
}
