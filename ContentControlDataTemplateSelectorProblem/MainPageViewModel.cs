namespace ContentControlDataTemplateSelectorProblem
{
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    public class MainPageViewModel : BindableBase
    {
        public bool TestBoolean
        {
            get => _testBoolean;
            set => Set(ref _testBoolean, value);
        }
        private bool _testBoolean = false;

        public ElementBase Element
        {
            get => _element;
            set => Set(ref _element, value);
        }
        private ElementBase _element;

        public void SetA1()
        {
            Element = new ElementA("A1");
        }

        public void SetA2()
        {
            Element = new ElementA("A2");
        }

        public void SetB1()
        {
            Element = new ElementB(true);
        }

        public void SetB2()
        {
            Element = new ElementB(false);
        }
    }

    public abstract class ElementBase : BindableBase
    {

    }

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

    public class ElementB : ElementBase
    {
        public ElementB(bool state)
        {
            TestBoolean = state;
        }
        public bool TestBoolean
        {
            get => _testBoolean;
            private set => Set(ref _testBoolean, value);
        }
        private bool _testBoolean;
    }

    public class ElementDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ElementADataTemplate { get; set; }
        public DataTemplate ElementBDataTemplate { get; set; }
        public DataTemplate EmptyDataTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item)
        {
            switch (item)
            {
                case ElementA _:
                    return ElementADataTemplate;
                case ElementB _:
                    return ElementBDataTemplate;
                default:
                    return EmptyDataTemplate;
            }
        }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            return SelectTemplateCore(item);
        }
    }
}