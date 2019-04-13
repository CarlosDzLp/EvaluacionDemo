using System;
using System.Windows.Input;
using BussinesLayer;
using DataEntities;
using EvaluacionDemo.Helpers;
using EvaluacionDemo.ViewModels.Base;
using Xamarin.Forms;

namespace EvaluacionDemo.ViewModels.Session
{
    public class RegisterPageViewModel : BindableBase
    {
        BLLogin login = new BLLogin();
        ISnackBar snack = DependencyService.Get<ISnackBar>();
        #region Properties
        private string _email;
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }
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
        private string _confirmPassword;
        public string ConfirmPassword
        {
            get { return _confirmPassword; }
            set { SetProperty(ref _confirmPassword, value); }
        }
        public string _selectedPicker;
        public string SelectedPicker
        {
            get { return _selectedPicker; }
            set { SetProperty(ref _selectedPicker, value); }
        }
        #endregion

        #region Constructor
        public RegisterPageViewModel()
        {
            try
            {
                RegisterCommand = new Command(RegisterCommandExecuted);
            }
            catch(Exception ex)
            {

            }
        }
        #endregion

        #region Command
        public ICommand RegisterCommand { get; set; }
        #endregion

        #region CommandExecuted
        private async void RegisterCommandExecuted()
        {
            try
            {
                if(!string.IsNullOrWhiteSpace(Email) && Validator.ValidateEmail(Email))
                {
                    if(!string.IsNullOrWhiteSpace(User) && Validator.ValidateLegth(User))
                    {
                        if(!string.IsNullOrWhiteSpace(Password) && Validator.ValidatePassword(Password) && !string.IsNullOrWhiteSpace(ConfirmPassword))
                        {
                            if(Password == ConfirmPassword)
                            {
                                if(!string.IsNullOrWhiteSpace(SelectedPicker))
                                {
                                    var response = await login.ValidateUser(User, Email);
                                    if(response)
                                    {
                                        await snack.SnackError("Hay un usuario registrado con esos datos");
                                    }
                                    else
                                    {
                                        var user = new UserModel();
                                        user.DateCreated = DateTime.Now;
                                        user.Email = Email;
                                        user.Password = Password;
                                        user.Sex = SelectedPicker;
                                        user.Status = true;
                                        user.User = User;
                                        var result = await login.Insert(user);
                                        if(result)
                                        {
                                            App.Current.MainPage = new NavigationPage(new Views.Principal.HomePage());
                                        }
                                        else
                                        {
                                            await snack.SnackError("Ocurrio un error");
                                        }
                                    }
                                }
                                else
                                {
                                    await snack.SnackError("Seleccione un genero");
                                }
                            }
                            else
                            {
                                await snack.SnackError("Las contraseñas no coinciden");
                            }
                        }
                        else
                        {
                            await snack.SnackError("ingrese una contraseña valida");
                        }
                    }
                    else
                    {
                        await snack.SnackError("Ingrese un usuario valido");
                    }
                }
                else
                {
                    await snack.SnackError("Ingrese un email valido");
                }
            }
            catch(Exception ex)
            {

            }
        }
        #endregion
    }
}
