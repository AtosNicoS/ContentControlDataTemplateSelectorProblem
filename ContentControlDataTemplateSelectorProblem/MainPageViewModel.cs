namespace ContentControlDataTemplateSelectorProblem
{
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
}