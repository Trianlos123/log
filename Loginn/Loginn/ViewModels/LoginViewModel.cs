using GalaSoft.MvvmLight.Command;
using Loginn.Views;
using System.Windows.Input;
using Xamarin.Forms;

namespace Loginn.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        #region Attributes
        private string password;
        private string user;
        private bool isRunning;
        private bool isEnabled;
        #endregion

        #region Properties
        public string User
        {
            get { return this.user; }
            set { SetValue(ref this.user, value); }
        }

        public string Password
        {
            get { return this.password; }
            set { SetValue(ref this.password, value); }
        }

        public bool IsRunning
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }

        public bool IsRemember
        {
            get;
            set;
        }

        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }

        #endregion

        #region Commands
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }

        private async void Login()
        {
            if (string.IsNullOrEmpty(User))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Ingresar Usuario", "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(Password))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Ingresar Contraseña", "Aceptar");
                return;
            }

            this.IsRunning = true;
            this.IsEnabled = false;

            if(this.User != "micropos" || this.Password != "micropos")
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert("Error", "Usuario o Contraseña Incorrecto", "Aceptar");
                this.Password = string.Empty;
                return;
            }

            this.IsRunning = false;
            this.IsEnabled = true;

            this.User = string.Empty;
            this.Password = string.Empty;

            MainViewModel.GetInstance().EBoleta = new EBoletaViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new EBoletaPage());

        }
        #endregion

        #region Constructors
        public LoginViewModel()
        {
            this.IsRemember = true;
            this.IsEnabled = true;
        }
        #endregion
    }
}
