using Microsoft.Maui.Controls;

namespace MAUI_Test.Components
{
    public partial class CardView : ContentView
    {
        public static readonly BindableProperty CardPaddingProperty =
            BindableProperty.Create(nameof(CardPadding), typeof(Thickness), typeof(CardView), new Thickness(20));

        public static readonly BindableProperty CardBackgroundColorProperty =
            BindableProperty.Create(nameof(CardBackgroundColor), typeof(Color), typeof(CardView), Colors.White);

        public static readonly BindableProperty CardBorderColorProperty =
            BindableProperty.Create(nameof(CardBorderColor), typeof(Color), typeof(CardView), Color.FromArgb("#F1F5F9"));

        public static readonly BindableProperty CardCornerRadiusProperty =
            BindableProperty.Create(nameof(CardCornerRadius), typeof(int), typeof(CardView), 12);

        public Thickness CardPadding
        {
            get => (Thickness)GetValue(CardPaddingProperty);
            set => SetValue(CardPaddingProperty, value);
        }

        public Color CardBackgroundColor
        {
            get => (Color)GetValue(CardBackgroundColorProperty);
            set => SetValue(CardBackgroundColorProperty, value);
        }

        public Color CardBorderColor
        {
            get => (Color)GetValue(CardBorderColorProperty);
            set => SetValue(CardBorderColorProperty, value);
        }

        public int CardCornerRadius
        {
            get => (int)GetValue(CardCornerRadiusProperty);
            set => SetValue(CardCornerRadiusProperty, value);
        }

        public CardView()
        {
            InitializeComponent();
        }
    }
}
