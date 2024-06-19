using Microsoft.Maui.Controls;
using MTMChampo.Views;
namespace MTMChampo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
