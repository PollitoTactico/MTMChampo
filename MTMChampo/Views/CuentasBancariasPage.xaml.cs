using MTMChampo.Models;

namespace MTMChampo.Views;

public partial class CuentasBancariasPage : ContentPage
{
	public CuentasBancariasPage()
	{
		InitializeComponent();
        CargarCuentas();

        MessagingCenter.Subscribe<EditarCuentaPage>(this, "ActualizarCuentas", (sender) =>
        {
            CargarCuentas();
        });
    }
    private async void CargarCuentas()
    {
        List<CuentaBanco> cuentas = await BankManager.CargarCuentasAsync();
        cuentasCollectionView.ItemsSource = cuentas;
    }
    private async void Editar_Clicked(object sender, EventArgs e)
    {
        var cuenta = (sender as Button)?.CommandParameter as CuentaBanco;
        if (cuenta != null)
        {
            
            await Navigation.PushAsync(new EditarCuentaPage(cuenta));
        }
    }

    private async void Eliminar_Clicked(object sender, EventArgs e)
    {
        var cuenta = (sender as Button)?.CommandParameter as CuentaBanco;
        if (cuenta != null)
        {
            bool confirmar = await DisplayAlert("Confirmación", $"¿Estás seguro de eliminar la cuenta {cuenta.NumeroCuenta}?", "Sí", "No");
            if (confirmar)
            {
                BankManager.Cuentas.Remove(cuenta);
                await BankManager.GuardarCuentasAsync();
                await DisplayAlert("Éxito", "Cuenta eliminada exitosamente.", "OK");
                CargarCuentas(); 
            }
        }
    }
}