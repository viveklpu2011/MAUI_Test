using MAUI_Test.ViewModels;

namespace MAUI_Test
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new DashboardViewModel();
        }
    }
}
