namespace ContentControlDataTemplateSelectorProblem
{
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

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