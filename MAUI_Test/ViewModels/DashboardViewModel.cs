using System.Collections.ObjectModel;
using MAUI_Test.Models;
using Microsoft.Maui.Graphics;

namespace MAUI_Test.ViewModels
{
    public class SidebarItem
    {
        public string Title { get; set; } = string.Empty;
        public string IconData { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }

    public class DashboardViewModel
    {
        public ObservableCollection<KpiItem> Kpis { get; set; } = new();
        public ObservableCollection<ActivityItem> Activities { get; set; } = new();
        public ObservableCollection<OrderItem> Orders { get; set; } = new();
        public ObservableCollection<SidebarItem> SidebarItems { get; set; } = new();

        // Summary details from top left
        public string Earnings { get; set; } = "$3,468.96";
        public string SalesCount { get; set; } = "82";

        public DashboardViewModel()
        {
            LoadSidebarItems();
            LoadKpis();
            LoadActivities();
            LoadOrders();
        }

        private void LoadSidebarItems()
        {
            // Standard sidebar menu icons in SVG paths
            string pathHome = "M10 20v-6h4v6h5v-8h3L12 3 2 12h3v8z";
            string pathGrid = "M4 4h7v7H4zm0 9h7v7H4zm9-9h7v7h-7zm0 9h7v7h-7z";
            string pathLayers = "M11.99 18.54l-7.37-5.73L3 14.07l9 7 9-7-1.63-1.27zM12 16l7.36-5.73L21 9l-9-7-9 7 1.63 1.27L12 16z";
            string pathBox = "M19 3H5c-1.1 0-2 .9-2 2v14c0 1.1.9 2 2 2h14c1.1 0 2-.9 2-2V5c0-1.1-.9-2-2-2zm-2 10h-4v4h-2v-4H7v-2h4V7h2v4h4v2z";
            string pathEdit = "M3 17.25V21h3.75L17.81 9.94l-3.75-3.75L3 17.25zM20.71 7.04c.39-.39.39-1.02 0-1.41l-2.34-2.34c-.39-.39-1.02-.39-1.41 0l-1.83 1.83 3.75 3.75 1.83-1.83z";
            string pathText = "M14 17H4v2h10v-2zm6-8H4v2h16V9zM4 15h16v-2H4v2zM4 5v2h16V5H4z";
            string pathChart = "M3.5 18.49l6-6.01 4 4L22 6.92l-1.41-1.41-7.09 7.97-4-4L3 15.67z";
            string pathTable = "M10 10.02h5V21h-5zM17 21h5V10.02h-5zm-7-13h12V3H10zm-7 5h5V3H3zm0 8h5v-7H3z";
            string pathPop = "M19 19H5V5h7V3H5c-1.11 0-2 .9-2 2v14c0 1.1.89 2 2 2h14c1.1 0 2-.9 2-2v-7h-2v7zM14 3v2h3.59l-9.83 9.83 1.41 1.41L19 6.41V10h2V3h-7z";
            string pathBell = "M12 22c1.1 0 2-.9 2-2h-4c0 1.1.89 2 2 2zm6-6v-5c0-3.07-1.64-5.64-4.5-6.32V4c0-.83-.67-1.5-1.5-1.5s-1.5.67-1.5 1.5v.68C7.63 5.36 6 7.92 6 11v5l-2 2v1h16v-1l-2-2z";
            string pathImage = "M19 3H5c-1.1 0-2 .9-2 2v14c0 1.1.9 2 2 2h14c1.1 0 2-.9 2-2V5c0-1.1-.9-2-2-2zm-5 14H7l2.5-3.14 1.71 2.06 2.43-3.14L18 17h-4z";
            string pathPlace = "M12 2C8.13 2 5 5.13 5 9c0 5.25 7 13 7 13s7-7.75 7-13c0-3.87-3.13-7-7-7zm0 9.5c-1.38 0-2.5-1.12-2.5-2.5s1.12-2.5 2.5-2.5 2.5 1.12 2.5 2.5-1.12 2.5-2.5 2.5z";
            string pathPerson = "M12 12c2.21 0 4-1.79 4-4s-1.79-4-4-4-4 1.79-4 4 1.79 4 4 4zm0 2c-2.67 0-8 1.34-8 4v2h16v-2c0-2.66-5.33-4-8-4z";
            string pathError = "M12 2C6.48 2 2 6.48 2 12s4.48 10 10 10 10-4.48 10-10S17.52 2 12 2zm1 15h-2v-2h2v2zm0-4h-2V7h2v6z";
            string pathPages = "M3 5v14c0 1.1.89 2 2 2h14c1.1 0 2-.9 2-2V5c0-1.1-.9-2-2-2H5c-1.11 0-2 .9-2 2zm12 4c0 1.66-1.34 3-3 3s-3-1.34-3-3 1.34-3 3-3 3 1.34 3 3z";
            string pathCart = "M7 18c-1.1 0-1.99.9-1.99 2S5.9 22 7 22s2-.9 2-2-.9-2-2-2zM1 1h4l2.68 12.83-1.4 2.54c-.15.27-.28.57-.28.9 0 1.1.9 2 2 2h12v-2H7.42c-.14 0-.25-.11-.25-.25l.02-.06 1.2-2.18h7.45c.75 0 1.41-.41 1.75-1.03l3.58-6.49c.08-.14.12-.31.12-.48 0-.55-.45-1-1-1H5.21l-.94-2H1v2zm16 16c-1.1 0-1.99.9-1.99 2s.89 2 1.99 2 2-.9 2-2-.9-2-2-2z";
            string pathMail = "M20 4H4c-1.1 0-1.99.9-1.99 2L2 18c0 1.1.9 2 2 2h16c1.1 0 2-.9 2-2V6c0-1.1-.9-2-2-2zm0 4l-8 5-8-5V6l8 5 8-5v2z";
            string pathCal = "M19 3h-1V1h-2v2H8V1H6v2H5c-1.11 0-1.99.9-1.99 2L3 19c0 1.1.89 2 2 2h14c1.1 0 2-.9 2-2V5c0-1.1-.9-2-2-2zm0 16H5V8h14v11z";
            string pathList = "M14 10H2v2h12v-2zm0-4H2v2h12V6zM2 16h8v-2H2v2zm19.5-4.5L20 10l-4 4-2-2-1.5 1.5 3.5 3.5 5.5-5.5z";
            string pathDoc = "M19 3h-4.18C14.4 1.84 13.3 1 12 1c-1.3 0-2.4.84-2.82 2H5c-1.1 0-2 .9-2 2v14c0 1.1.9 2 2 2h14c1.1 0 2-.9 2-2V5c0-1.1-.9-2-2-2zm-7 0c.55 0 1 .45 1 1s-.45 1-1 1-1-.45-1-1 .45-1 1-1zm2 14H7v-2h7v2zm3-4H7v-2h10v2zm0-4H7V7h10v2z";

            SidebarItems.Add(new SidebarItem { Title = "Dashboard", IconData = pathHome, IsActive = true });
            SidebarItems.Add(new SidebarItem { Title = "Widgets", IconData = pathGrid });
            SidebarItems.Add(new SidebarItem { Title = "UI Elements", IconData = pathLayers });
            SidebarItems.Add(new SidebarItem { Title = "Advanced UI", IconData = pathBox });
            SidebarItems.Add(new SidebarItem { Title = "Form Elements", IconData = pathEdit });
            SidebarItems.Add(new SidebarItem { Title = "Editors", IconData = pathText });
            SidebarItems.Add(new SidebarItem { Title = "Charts", IconData = pathChart });
            SidebarItems.Add(new SidebarItem { Title = "Tables", IconData = pathTable });
            SidebarItems.Add(new SidebarItem { Title = "Popups", IconData = pathPop });
            SidebarItems.Add(new SidebarItem { Title = "Notifications", IconData = pathBell });
            SidebarItems.Add(new SidebarItem { Title = "Icons", IconData = pathImage });
            SidebarItems.Add(new SidebarItem { Title = "Maps", IconData = pathPlace });
            SidebarItems.Add(new SidebarItem { Title = "User Pages", IconData = pathPerson });
            SidebarItems.Add(new SidebarItem { Title = "Error Pages", IconData = pathError });
            SidebarItems.Add(new SidebarItem { Title = "General Pages", IconData = pathPages });
            SidebarItems.Add(new SidebarItem { Title = "E-Commerce", IconData = pathCart });
            SidebarItems.Add(new SidebarItem { Title = "E-mail", IconData = pathMail });
            SidebarItems.Add(new SidebarItem { Title = "Calendar", IconData = pathCal });
            SidebarItems.Add(new SidebarItem { Title = "Todo List", IconData = pathList });
            SidebarItems.Add(new SidebarItem { Title = "Gallery", IconData = pathImage });
            SidebarItems.Add(new SidebarItem { Title = "Documentation", IconData = pathDoc });
        }

        private void LoadKpis()
        {
            // Crown/Wallet icon path
            string crownPath = "M12 17.27L18.18 21l-1.64-7.03L22 9.24l-7.19-.61L12 2 9.19 8.63 2 9.24l5.46 4.73L5.82 21z";
            // Heart path
            string heartPath = "M12 21.35l-1.45-1.32C5.4 15.36 2 12.28 2 8.5 2 5.42 4.42 3 7.5 3c1.74 0 3.41.81 4.5 2.09C13.09 3.81 14.76 3 16.5 3 19.58 3 22 5.42 22 8.5c0 3.78-3.4 6.86-8.55 11.54L12 21.35z";
            // Gear path
            string gearPath = "M19.14 12.94c.04-.3.06-.61.06-.94 0-.32-.02-.64-.07-.94l2.03-1.58c.18-.14.23-.41.12-.61l-1.92-3.32c-.12-.22-.37-.29-.59-.22l-2.39.96c-.5-.38-1.03-.7-1.62-.94l-.36-2.54c-.04-.24-.24-.41-.48-.41h-3.84c-.24 0-.43.17-.47.41l-.36 2.54c-.59.24-1.13.57-1.62.94l-2.39-.96c-.22-.08-.47 0-.59.22L2.74 8.87c-.12.21-.08.47.12.61l2.03 1.58c-.05.3-.09.63-.09.94s.02.64.07.94l-2.03 1.58c-.18.14-.23.41-.12.61l1.92 3.32c.12.22.37.29.59.22l2.39-.96c.5.38 1.03.7 1.62.94l.36 2.54c.05.24.24.41.48.41h3.84c.24 0 .44-.17.47-.41l.36-2.54c.59-.24 1.13-.56 1.62-.94l2.39.96c.22.08.47 0 .59-.22l1.92-3.32c.12-.22.07-.47-.12-.61l-2.01-1.58zM12 15.6c-1.98 0-3.6-1.62-3.6-3.6s1.62-3.6 3.6-3.6 3.6 1.62 3.6 3.6-1.62 3.6-3.6 3.6z";
            // Bar chart path
            string chartPath = "M16 6l2.29 2.29-4.88 4.88-4-4L2 16.59 3.41 18l6-6 4 4 6.3-6.29L22 12V6z";

            Kpis.Add(new KpiItem { Title = "Wallet Balance", Value = "$4,567.53", IconData = crownPath, IconColor = Color.FromArgb("#EF4444"), IconBgColor = Color.FromArgb("#FEE2E2") });
            Kpis.Add(new KpiItem { Title = "Referral Earning", Value = "$1,689.53", IconData = heartPath, IconColor = Color.FromArgb("#3B82F6"), IconBgColor = Color.FromArgb("#DBEAFE") });
            Kpis.Add(new KpiItem { Title = "Estimate Sales", Value = "$2,851.53", IconData = gearPath, IconColor = Color.FromArgb("#10B981"), IconBgColor = Color.FromArgb("#D1FAE5") });
            Kpis.Add(new KpiItem { Title = "Earning", Value = "$52,567.53", IconData = chartPath, IconColor = Color.FromArgb("#EC4899"), IconBgColor = Color.FromArgb("#FCE7F3") });
        }

        private void LoadActivities()
        {
            // Edit list path
            string pathTask = "M14 2H6c-1.1 0-1.99.9-1.99 2L4 20c0 1.1.89 2 2 2h12c1.1 0 2-.9 2-2V8l-6-6zm2 16H8v-2h8v2zm0-4H8v-2h8v2zm-3-5V3.5L18.5 9H13z";
            
            // Thunderbolt path
            string pathDeal = "M7 2v11h3v9l7-12h-4l4-8z";
            
            // File edit path
            string pathArticle = "M3 17.25V21h3.75L17.81 9.94l-3.75-3.75L3 17.25zM20.71 7.04c.39-.39.39-1.02 0-1.41l-2.34-2.34c-.39-.39-1.02-.39-1.41 0l-1.83 1.83 3.75 3.75 1.83-1.83z";
            
            // Database storage path
            string pathDock = "M12 2C6.48 2 2 6.48 2 12s4.48 10 10 10 10-4.48 10-10S17.52 2 12 2zm-1 17.93c-3.95-.49-7-3.85-7-7.93 0-.62.08-1.21.21-1.79L9 15v1c0 1.1.9 2 2 2v1.93zm6.9-2.54c-.26-.81-1-1.39-1.9-1.39h-1v-3c0-.55-.45-1-1-1H8v-2h2c.55 0 1-.45 1-1V7h2c1.1 0 2-.9 2-2v-.41c2.93 1.19 5 4.06 5 7.41 0 2.08-.8 3.97-2.1 5.39z";
            
            // Chat bubble path
            string pathComment = "M20 2H4c-1.1 0-1.99.9-1.99 2L2 22l4-4h14c1.1 0 2-.9 2-2V4c0-1.1-.9-2-2-2zM6 9h12v2H6V9zm8 5H6v-2h8v2zm4-6H6V6h12v2z";

            Activities.Add(new ActivityItem { Time = "42 Mins Ago", Title = "Task Updated", Description = "Nikolai Updated a Task", IconData = pathTask, IconColor = Color.FromArgb("#3B82F6"), IconBgColor = Color.FromArgb("#DBEAFE") });
            Activities.Add(new ActivityItem { Time = "1 day Ago", Title = "Deal Added", Description = "Panshi Updated a Task", IconData = pathDeal, IconColor = Color.FromArgb("#EF4444"), IconBgColor = Color.FromArgb("#FEE2E2") });
            Activities.Add(new ActivityItem { Time = "42 Mins Ago", Title = "Published Article", Description = "Rasel Published a Article", IconData = pathArticle, IconColor = Color.FromArgb("#3B82F6"), IconBgColor = Color.FromArgb("#DBEAFE") });
            Activities.Add(new ActivityItem { Time = "1 day Ago", Title = "Dock Updated", Description = "Reshmi Updated a Dock", IconData = pathDock, IconColor = Color.FromArgb("#F59E0B"), IconBgColor = Color.FromArgb("#FEF3C7") });
            Activities.Add(new ActivityItem { Time = "1 day Ago", Title = "Replyed Comment", Description = "Jenathon Added a Comment", IconData = pathComment, IconColor = Color.FromArgb("#10B981"), IconBgColor = Color.FromArgb("#D1FAE5"), ShowLine = false });
        }

        private void LoadOrders()
        {
            Orders.Add(new OrderItem { Invoice = "12386", Customer = "Charly Dues", From = "Brazil", Price = "$299", Status = "Process", StatusColor = Color.FromArgb("#EF4444"), StatusBg = Color.FromArgb("#FEE2E2") });
            Orders.Add(new OrderItem { Invoice = "12386", Customer = "Marko", From = "Italy", Price = "$2642", Status = "Open", StatusColor = Color.FromArgb("#10B981"), StatusBg = Color.FromArgb("#D1FAE5") });
            Orders.Add(new OrderItem { Invoice = "12386", Customer = "Deniyel Onak", From = "Russia", Price = "$981", Status = "On Hold", StatusColor = Color.FromArgb("#3B82F6"), StatusBg = Color.FromArgb("#DBEAFE") });
            Orders.Add(new OrderItem { Invoice = "12386", Customer = "Belgiri Bastana", From = "Korea", Price = "$369", Status = "Process", StatusColor = Color.FromArgb("#EF4444"), StatusBg = Color.FromArgb("#FEE2E2") });
            Orders.Add(new OrderItem { Invoice = "12386", Customer = "Sarti Onuska", From = "Japan", Price = "$1240", Status = "Open", StatusColor = Color.FromArgb("#10B981"), StatusBg = Color.FromArgb("#D1FAE5") });
        }
    }
}
