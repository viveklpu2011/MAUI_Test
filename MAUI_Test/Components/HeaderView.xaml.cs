using Microsoft.Maui.Controls;

namespace MAUI_Test.Components
{
    public partial class HeaderView : ContentView
    {
        public static readonly BindableProperty TitleProperty =
            BindableProperty.Create(nameof(Title), typeof(string), typeof(HeaderView), string.Empty);

        public static readonly BindableProperty SubtitleProperty =
            BindableProperty.Create(nameof(Subtitle), typeof(string), typeof(HeaderView), string.Empty);

        public static readonly BindableProperty ShowTabsProperty =
            BindableProperty.Create(nameof(ShowTabs), typeof(bool), typeof(HeaderView), false);

        public static readonly BindableProperty ShowLegendProperty =
            BindableProperty.Create(nameof(ShowLegend), typeof(bool), typeof(HeaderView), false);

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public string Subtitle
        {
            get => (string)GetValue(SubtitleProperty);
            set => SetValue(SubtitleProperty, value);
        }

        public bool ShowTabs
        {
            get => (bool)GetValue(ShowTabsProperty);
            set => SetValue(ShowTabsProperty, value);
        }

        public bool ShowLegend
        {
            get => (bool)GetValue(ShowLegendProperty);
            set => SetValue(ShowLegendProperty, value);
        }

        public HeaderView()
        {
            InitializeComponent();
        }
    }
}
