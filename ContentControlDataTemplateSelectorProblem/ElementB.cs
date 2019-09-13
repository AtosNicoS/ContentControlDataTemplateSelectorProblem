namespace ContentControlDataTemplateSelectorProblem
{
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
}