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
        await DisplayAlert("Esta mal!!!", "Todos los campos son obligatorios.", "OK");
        return;
    }

        var usuario = UserManager.UsuariosRegistrados.FirstOrDefault(u => u.NombreUsuario == username && u.Contrasena == password);

        if (usuario == null)
        {
        await DisplayAlert("Esta mal!!!", "Usuario o contraseña incorrectos.", "OK");
        return;
        }

        await DisplayAlert("Éxito", "Inicio de sesión exitoso.", "OK");
        await Navigation.PushAsync(new CuentasBancariasPage(App.DbService));

            
        }
       
    }
}
