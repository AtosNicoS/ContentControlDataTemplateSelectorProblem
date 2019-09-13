namespace ContentControlDataTemplateSelectorProblem
{
    public class ElementA : ElementBase
    {
        public ElementA(string text)
        {
            Text = text;
            MyUserControlAViewModel = new MyUserControlAViewModel(text);
        }

        public string Text
        {
            get => _text;
            private set => Set(ref _text, value);
        }
        private string _text;

        public MyUserControlAViewModel MyUserControlAViewModel
        {
            get => _myUserControlAViewModel;
            private set => Set(ref _myUserControlAViewModel, value);
        }
        private MyUserControlAViewModel _myUserControlAViewModel;
    }
}