namespace MTMChampo.Views;

public partial class HomeH : ContentPage
{
	public HomeH()
	{
		InitializeComponent();
	}
    private async void IniciarSesion_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Inicio());
    }

    private async void Registrarse_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Register());
    }

    Image image = new Image
    {
        Source = ImageSource.FromFile("huevos.png")
    };
}