using Microsoft.Maui.Controls;
using MTMChampo.Views;
namespace MTMChampo
{
    public partial class App : Application
    {
        public static LocalDbService DbService { get; private set; }
        public App()
        {
            InitializeComponent();
            DbService = new LocalDbService();
            MainPage = new AppShell();
        }

        public void OnLoginSuccessful()
        {
            Shell.Current.GoToAsync("//CuentasBancariasPage");
        }
    }
}
