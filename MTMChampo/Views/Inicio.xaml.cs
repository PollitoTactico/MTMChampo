using MTMChampo.Models;
using System;


namespace MTMChampo.Views
{
    public partial class Inicio : ContentPage
    {
        public Inicio()
        {
            InitializeComponent();
        }
        private async void RegisterL_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Register());
        }

        private async void InicioL_Clicked(object sender, EventArgs e)
        {
            string username = usernameEntry.Text;
            string password = passwordEntry.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                await DisplayAlert("Error", "Todos los campos son obligatorios.", "OK");
                return;
            }

            var user = UserManager.RegisteredUsers.FirstOrDefault(u => u.username == username && u.password == password);

            if (user == null)
            {
                await DisplayAlert("Error", "Usuario o contrase�a incorrectos.", "OK");
                return;
            }

            await DisplayAlert("�xito", "Inicio de sesi�n exitoso.", "OK");
            // Navegar a la siguiente p�gina o acci�n, por ahora solo mostramos mensaje
        }

    }
}
