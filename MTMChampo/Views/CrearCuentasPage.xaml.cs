using MTMChampo.Models;

namespace MTMChampo.Views;

public partial class CrearCuentasPage : ContentPage
{
	public CrearCuentasPage()
	{
		InitializeComponent();
	}
    private async void CrearCuenta_Clicked(object sender, EventArgs e)
    {
        string numeroCuenta = numeroCuentaEntry.Text;
        string nombreTitular = nombreTitularEntry.Text;
        decimal saldo;
        string tipoCuenta = tipoCuentaEntry.Text;

        if (string.IsNullOrEmpty(numeroCuenta) || string.IsNullOrEmpty(nombreTitular) || !decimal.TryParse(saldoEntry.Text, out saldo) || string.IsNullOrEmpty(tipoCuenta))
        {
            await DisplayAlert("Esta mal!!!", "Todos los campos son obligatorios y el saldo debe ser un número válido.", "OK");
            return;
        }

        if (BankManager.ExisteNumeroCuenta(numeroCuenta))
        {
            await DisplayAlert("Esta mal!!!", "El número de cuenta ya está registrado.", "OK");
            return;
        }

        BankManager.Cuentas.Add(new CuentaBanco { NumeroCuenta = numeroCuenta, NombreTitular = nombreTitular, Saldo = saldo, TipoCuenta = tipoCuenta });
        await BankManager.GuardarCuentasAsync();
        await DisplayAlert("Éxito", "Cuenta bancaria creada exitosamente.", "OK");
        ClearEntries();
    }

    private void ClearEntries()
    {
        numeroCuentaEntry.Text = string.Empty;
        nombreTitularEntry.Text = string.Empty;
        saldoEntry.Text = string.Empty;
        tipoCuentaEntry.Text = string.Empty;
    }

    private async void VerCuentas_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CuentasBancariasPage());
    }
}