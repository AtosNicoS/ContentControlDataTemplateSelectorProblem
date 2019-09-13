using Windows.UI.Xaml.Controls;

namespace ContentControlDataTemplateSelectorProblem
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using Windows.UI.Xaml;
    using JetBrains.Annotations;

    public sealed partial class MyUserControlA : UserControl, INotifyPropertyChanged, INotifyPropertyChanging
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangingEventHandler PropertyChanging;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            switch (propertyName)
            {
                case nameof(ViewModel):
                    // Update Datacontext on ViewModel change
                    DataContext = ViewModel;

                    // Enable this, to make the UI update properly.
                    //Bindings.Update();
                    break;
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OnPropertyChanging([CallerMemberName] string propertyName = null)
        {
            PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(propertyName));
        }

        public MyUserControlA()
        {
            InitializeComponent();
            DataContextChanged += (s, e) => ViewModel = DataContext as MyUserControlAViewModel;
        }

        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(nameof(ViewModel),
            typeof(MyUserControlAViewModel),
            typeof(MyUserControlA), new PropertyMetadata(null));

        public MyUserControlAViewModel ViewModel
        {
            get => (MyUserControlAViewModel)GetValue(ViewModelProperty);
            set => SetDependencyPropertyValue(ViewModelProperty, value);
        }

        private void SetDependencyPropertyValue<T>(DependencyProperty property, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(GetValue(property), value))
            {
                return;
            }
            OnPropertyChanging(propertyName);
            SetValue(property, value);
            OnPropertyChanged(propertyName);
        }
    }
}
