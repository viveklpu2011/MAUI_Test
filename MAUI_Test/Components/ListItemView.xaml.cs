using Microsoft.Maui.Controls;

namespace MAUI_Test.Components
{
    public partial class ListItemView : ContentView
    {
        public static readonly BindableProperty TimeProperty =
            BindableProperty.Create(nameof(Time), typeof(string), typeof(ListItemView), string.Empty);

        public static readonly BindableProperty ItemTitleProperty =
            BindableProperty.Create(nameof(ItemTitle), typeof(string), typeof(ListItemView), string.Empty);

        public static readonly BindableProperty ItemDescriptionProperty =
            BindableProperty.Create(nameof(ItemDescription), typeof(string), typeof(ListItemView), string.Empty);

        public static readonly BindableProperty IconDataProperty =
            BindableProperty.Create(nameof(IconData), typeof(string), typeof(ListItemView), string.Empty);

        public static readonly BindableProperty IconColorProperty =
            BindableProperty.Create(nameof(IconColor), typeof(Color), typeof(ListItemView), Colors.White);

        public static readonly BindableProperty IconBgColorProperty =
            BindableProperty.Create(nameof(IconBgColor), typeof(Color), typeof(ListItemView), Colors.LightGray);

        public static readonly BindableProperty ShowLineProperty =
            BindableProperty.Create(nameof(ShowLine), typeof(bool), typeof(ListItemView), true);

        public string Time
        {
            get => (string)GetValue(TimeProperty);
            set => SetValue(TimeProperty, value);
        }

        public string ItemTitle
        {
            get => (string)GetValue(ItemTitleProperty);
            set => SetValue(ItemTitleProperty, value);
        }

        public string ItemDescription
        {
            get => (string)GetValue(ItemDescriptionProperty);
            set => SetValue(ItemDescriptionProperty, value);
        }

        public string IconData
        {
            get => (string)GetValue(IconDataProperty);
            set => SetValue(IconDataProperty, value);
        }

        public Color IconColor
        {
            get => (Color)GetValue(IconColorProperty);
            set => SetValue(IconColorProperty, value);
        }

        public Color IconBgColor
        {
            get => (Color)GetValue(IconBgColorProperty);
            set => SetValue(IconBgColorProperty, value);
        }

        public bool ShowLine
        {
            get => (bool)GetValue(ShowLineProperty);
            set => SetValue(ShowLineProperty, value);
        }

        public ListItemView()
        {
            InitializeComponent();
        }
    }
}
