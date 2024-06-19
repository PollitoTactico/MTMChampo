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
                await DisplayAlert("Esta mal!!!", "Todos los campos son obligatorios.", "OK");
                return;
            }

            if (UserManager.UsuariosRegistrados.Any(u => u.NombreUsuario == username))
            {
                await DisplayAlert("Esta mal!!!", "El usuario ya está registrado.", "OK");
                return;
            }

            UserManager.UsuariosRegistrados.Add(new UserManager { NombreUsuario = username, Contrasena = password });
            await DisplayAlert("Éxito", "Registro exitoso.", "OK");
            
            await Navigation.PushAsync(new Inicio());
        }

        private async void InicioR_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Inicio());
            
        }

    }
}
