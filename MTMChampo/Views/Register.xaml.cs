using Microsoft.Maui.Controls;
using MTMChampo.Models;


namespace MTMChampo.Views
{
    public partial class Register : ContentPage
    {
        public Register()
        {
            InitializeComponent();
        }
        private async void RegisterR_Clicked(object sender, EventArgs e)
        {
            string username = usernameEntry.Text;
            string password = passwordEntry.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                await DisplayAlert("Error", "Todos los campos son obligatorios.", "OK");
                return;
            }

            if (UserManager.RegisteredUsers.Any(u => u.username == username))
            {
                await DisplayAlert("Error", "El usuario ya está registrado.", "OK");
                return;
            }

            UserManager.RegisteredUsers.Add(new UserManager { username = username, password = password });
            await DisplayAlert("Éxito", "Registro exitoso.", "OK");
            await Navigation.PushAsync(new Inicio());
        }

        private async void InicioR_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Inicio());
        }

    }
}
