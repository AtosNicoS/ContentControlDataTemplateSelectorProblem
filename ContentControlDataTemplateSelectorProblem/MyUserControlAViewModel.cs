namespace ContentControlDataTemplateSelectorProblem
{
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