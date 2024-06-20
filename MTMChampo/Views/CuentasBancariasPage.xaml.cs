using MTMChampo.Models;
using MTMChampo;
using System.Diagnostics;
namespace MTMChampo.Views;

public partial class CuentasBancariasPage : ContentPage
{
    private readonly LocalDbService _dbService;
    
    private int _editCuentaBancoId;
	public CuentasBancariasPage(LocalDbService dbService)
	{
		InitializeComponent();
        _dbService = dbService;
        Task.Run(async() => ListView.ItemsSource = await _dbService.GetCustomersAsync());    
    }
    private async void saveButton_Clicked(object sender, EventArgs e)
    {
        decimal saldo;
        if (!decimal.TryParse(saldoEntryField.Text, out saldo))
        {
            await DisplayAlert("Error", "Saldo debe ser un número", "OK");
            return;
        }

        try
        {
            if (_editCuentaBancoId == 0)
            {
                await _dbService.Create(new CuentaBanco
                {
                    NumeroCuenta = cuentaEntryField.Text,
                    NombreTitular = nombreEntryField.Text,
                    Saldo = saldo,
                    TipoCuenta = tipoEntryField.Text
                });
            }
            else
            {
                await _dbService.Update(new CuentaBanco
                {
                    Id = _editCuentaBancoId,
                    NumeroCuenta = cuentaEntryField.Text,
                    NombreTitular = nombreEntryField.Text,
                    Saldo = saldo,
                    TipoCuenta = tipoEntryField.Text
                });

                _editCuentaBancoId = 0;
            }
            cuentaEntryField.Text = string.Empty;
            nombreEntryField.Text = string.Empty;
            saldoEntryField.Text = string.Empty;
            tipoEntryField.Text = string.Empty;

            await Device.InvokeOnMainThreadAsync(async () =>
            {
                ListView.ItemsSource = await _dbService.GetCustomersAsync();
            });
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error al guardar cuenta bancaria: {ex.Message}");
            await DisplayAlert("Error", "Ocurrió un error al guardar la cuenta bancaria", "OK");
        }
    }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
        var cuentaBanco = (CuentaBanco)e.Item;
        var action = await DisplayActionSheet("Actions", "Cancel", null, "Edit", "Delete");

            switch (action)
            {
                case "Edit":
                _editCuentaBancoId = cuentaBanco.Id;
                cuentaEntryField.Text = cuentaBanco.NumeroCuenta;
                nombreEntryField.Text = cuentaBanco.NombreTitular;
                saldoEntryField.Text = cuentaBanco.Saldo.ToString();
                tipoEntryField.Text = cuentaBanco.TipoCuenta;
                    break;

                case "Delete":
                await _dbService.Delete(cuentaBanco);
                ListView.ItemsSource = await _dbService.GetCustomersAsync();
                    break;
            }
        }
    private async void About_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new About()); 
    }

}