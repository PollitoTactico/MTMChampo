using MTMChampo.Models;
using Microsoft.Maui.Controls;
using System;

namespace MTMChampo.Views
{
    [QueryProperty(nameof(CuentaId), nameof(CuentaId))]
    public partial class EditarCuentaPage : ContentPage
    {
        private CuentaBanco cuenta;

        internal EditarCuentaPage()
        {
            InitializeComponent();
            
        }
        public EditarCuentaPage(string cuentaId) : this()
        {
            CuentaId = cuentaId;
        }

        private void CargarDatosCuenta()
        {
            if (cuenta != null)
            {
                numeroCuentaEntry.Text = cuenta.NumeroCuenta;
                nombreTitularEntry.Text = cuenta.NombreTitular;
                saldoEntry.Text = cuenta.Saldo.ToString();
                tipoCuentaEntry.Text = cuenta.TipoCuenta;
            }
        }

        private async void GuardarCambios_Clicked(object sender, EventArgs e)
        {
            if (cuenta != null)
            {
                cuenta.NumeroCuenta = numeroCuentaEntry.Text;
                cuenta.NombreTitular = nombreTitularEntry.Text;
                if (decimal.TryParse(saldoEntry.Text, out decimal saldo))
                {
                    cuenta.Saldo = saldo;
                }
                cuenta.TipoCuenta = tipoCuentaEntry.Text;

                BankManager.ActualizarCuenta(cuenta);
                await BankManager.GuardarCuentasAsync();

                await DisplayAlert("Éxito", "Cambios guardados exitosamente.", "OK");

                MessagingCenter.Send(this, "ActualizarCuentas", cuenta);

                await Navigation.PopAsync();
            }
        }

        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            if (cuenta != null)
            {
                BankManager.Cuentas.Remove(cuenta);
                await BankManager.GuardarCuentasAsync();

                await DisplayAlert("Éxito", "Cuenta eliminada exitosamente.", "OK");

                MessagingCenter.Send(this, "ActualizarCuentas", cuenta);

                await Navigation.PopAsync();
            }
        }

        public string CuentaId
        {
            set
            {
                cuenta = BankManager.Cuentas.FirstOrDefault(c => c.Id.ToString() == value);
                CargarDatosCuenta();
            }
        }
    }
}
