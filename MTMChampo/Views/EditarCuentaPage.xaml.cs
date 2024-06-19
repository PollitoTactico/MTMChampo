using MTMChampo.Models;
using Microsoft.Maui.Controls;
using System;

namespace MTMChampo.Views
{
    public partial class EditarCuentaPage : ContentPage
    {
        private CuentaBanco cuenta;

        internal EditarCuentaPage(CuentaBanco cuenta)
        {
            InitializeComponent();
            this.cuenta = cuenta;
            CargarDatosCuenta();
        }

        private void CargarDatosCuenta()
        {
            numeroCuentaEntry.Text = cuenta.NumeroCuenta;
            nombreTitularEntry.Text = cuenta.NombreTitular;
            saldoEntry.Text = cuenta.Saldo.ToString();
            tipoCuentaEntry.Text = cuenta.TipoCuenta;
        }

        private async void GuardarCambios_Clicked(object sender, EventArgs e)
        {
            cuenta.NumeroCuenta = numeroCuentaEntry.Text;
            cuenta.NombreTitular = nombreTitularEntry.Text;
            if (decimal.TryParse(saldoEntry.Text, out decimal saldo))
            {
                cuenta.Saldo = saldo;
            }
            cuenta.TipoCuenta = tipoCuentaEntry.Text;

            await DisplayAlert("Éxito", "Cambios guardados exitosamente.", "OK");

            
            await Navigation.PopAsync();
        }
        private async void EditarCuentaBancaria(CuentaBanco cuenta)
        {
            await Navigation.PushAsync(new EditarCuentaPage(cuenta));
        }
    }
}