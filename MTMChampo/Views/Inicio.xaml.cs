using System;
using System.Threading.Tasks;
using MTMChampo.Models;
using MTMChampo.Views;


namespace MTMChampo.Views
{
    public partial class Inicio : ContentPage
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private async void InicioL_Clicked(object sender, EventArgs e)
        {
            string username = usernameEntry.Text;
            string password = passwordEntry.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                await DisplayAlert("Esta mal!!", "Por favor ingrese nombre de usuario y contraseņa", "OK");
                return;
            }

           
            bool registrado = UserManager.RegistrarUsuario(username, password);

            if (registrado)
            {
                await DisplayAlert("Registro", "Usuario registrado correctamente", "OK");
                await Navigation.PushAsync(new Inicio());
            }
            else
            {
                await DisplayAlert("Esta mal!!", "El usuario ya existe", "OK");
            }

        }

        private async void RegisterL_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Register());
        }
    }
}
