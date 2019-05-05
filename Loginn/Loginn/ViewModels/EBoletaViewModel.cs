using GalaSoft.MvvmLight.Command;
using Loginn.Views;
using System;
using System.Windows.Input;
using Xamarin.Forms;
using Loginn.Services;
using System.Collections.ObjectModel;
using Loginn.Models;

namespace Loginn.ViewModels
{
    public class EBoletaViewModel : BaseViewModel
    {
        #region Attributes
        private string code;
        private ObservableCollection<Products> eboleta = new ObservableCollection<Products>();
        private int stepper;
        private string valorStepper;
        #endregion

        #region Properties
        public string Code
        {
            get { return this.code; }
            set { SetValue(ref this.code, value); }
        }

        public ObservableCollection<Products> EBoleta
        {
            get { return this.eboleta; }
            set { SetValue(ref this.eboleta, value); }
        }

        public int Stepper
        {
            get { return this.stepper; }
            set { SetValue(ref this.stepper, value); }
        }

        public string ValorStepper
        {
            get { return this.valorStepper; }
            set { SetValue(ref this.valorStepper, value); }
        }
        #endregion

        #region Constructor

        #endregion

        #region Commands
        public ICommand ScanCommand
        {
            get
            {
                return new RelayCommand(Scan);
            }
        }

        private async void Scan()
        {
            var scanner = DependencyService.Get<IQrScanningService>();
            var result = await scanner.ScanAsync();

            if(result != null)
            {
                this.Code = result;
                this.AgregaProductos(Convert.ToString(Code));
                this.Stepper = 1;
            }
        }
        #endregion

        #region Methods
        private ObservableCollection<Products> AgregaProductos(string codigo)
        {
            eboleta.Add(new Products
            {
                Nombre = codigo
            });
           return eboleta;
        }
        #endregion
    }
}
