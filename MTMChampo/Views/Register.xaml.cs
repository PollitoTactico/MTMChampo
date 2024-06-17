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
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                await DisplayAlert("Esta mal!!", "Por favor ingrese nombre de usuario y contraseña", "OK");
                return; 
            }
            bool registrado = UserManager.RegistrarUsuario(username, password);

            if (registrado)
            {
                await DisplayAlert("Registro", "Usuario registrado correctamente", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Esta mal!!", "El usuario ya existe", "OK");
            }
        }
        private async void InicioR_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Inicio());
        }
    }
}
