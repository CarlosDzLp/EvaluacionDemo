using System;
using System.Windows.Input;
using BussinesLayer;
using EvaluacionDemo.Helpers;
using EvaluacionDemo.ViewModels.Base;
using Xamarin.Forms;

namespace EvaluacionDemo.ViewModels.Session
{
    public class LoginPageViewModel : BindableBase
    {
        BLLogin login = new BLLogin();
        ISnackBar snack = DependencyService.Get<ISnackBar>();
        #region Properties
        private string _user;
        public string User
        {
            get { return _user; }
            set { SetProperty(ref _user, value); }
        }
        private string _password;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }
        #endregion


        #region Constructor

        public LoginPageViewModel()
        {
            TapRegisterCommand = new Command(TapRegisterCommandExcuted);
            LogInCommand = new Command(LogInCommandExecuted);
        }

        #endregion


        #region Command

        public ICommand TapRegisterCommand { get; set; }
        public ICommand LogInCommand { get; set; }

        #endregion


        #region ExecutedCommand
        private void TapRegisterCommandExcuted()
        {
            try
            {
                App.Current.MainPage.Navigation.PushAsync(new Views.Session.RegisterPage());
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        private async void LogInCommandExecuted()
        {
            try
            {
                if(!string.IsNullOrWhiteSpace(User))
                {
                    if((!string.IsNullOrWhiteSpace(Password)))
                    {
                        if (Validator.ValidateLegth(User))
                        {
                            if (Validator.ValidatePassword(Password))
                            {
                                var response = await login.DoLogin(User, Password);
                                if(response!=null)
                                {
                                    App.Current.MainPage = new NavigationPage(new Views.Principal.HomePage());
                                }
                                else
                                {
                                    await snack.SnackError("usuario no encontrado");
                                }
                            }
                            else
                            {
                                await snack.SnackError("Ingrese una contraseña correcta");
                            }
                        }
                        else
                        {
                            await snack.SnackError("Ingrese un usuario correcto");
                        }
                    }
                    else
                    {
                        await snack.SnackError("Ingrese una contraseña");
                    }
                }
                else
                {
                    await snack.SnackError("Ingrese un usuario");
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        #endregion
    }
}
