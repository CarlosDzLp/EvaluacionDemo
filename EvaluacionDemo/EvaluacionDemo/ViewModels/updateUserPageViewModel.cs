using System;
using System.Windows.Input;
using BussinesLayer;
using DataEntities;
using EvaluacionDemo.Helpers;
using EvaluacionDemo.ViewModels.Base;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace EvaluacionDemo.ViewModels
{
    public class updateUserPageViewModel : BindableBase
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
        public string _selectedPicker;
        public string SelectedPicker
        {
            get { return _selectedPicker; }
            set { SetProperty(ref _selectedPicker, value); }
        }
        public bool _isToggled;
        public bool IsToggled
        {
            get { return _isToggled; }
            set { SetProperty(ref _isToggled, value); }
        }
        private UserModel userModel = new UserModel();
        #endregion

        public updateUserPageViewModel(UserModel user)
        {
            userModel = user;
            Email = userModel.Email;
            User = userModel.User;
            Password = userModel.Password;
            SelectedPicker = userModel.Sex;
            IsToggled = userModel.Status;
            UpdateCommand = new Command(UpdateCommandExecuted);
        }

        #region Command
        public ICommand UpdateCommand { get; set; }
        #endregion

        #region ComamndExecuted
        private async void UpdateCommandExecuted()
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(Email) && Validator.ValidateEmail(Email))
                {
                    if (!string.IsNullOrWhiteSpace(User) && Validator.ValidateLegth(User))
                    {
                        if (!string.IsNullOrWhiteSpace(Password) && Validator.ValidatePassword(Password))
                        {

                                if (!string.IsNullOrWhiteSpace(SelectedPicker))
                            {
                                userModel.User = User;
                                userModel.Status = IsToggled;
                                userModel.Sex = SelectedPicker;
                                userModel.Password = Password;
                                userModel.Email = Email;
                                        var result = await login.Update(userModel);
                                        if (result)
                                        {
                                    await snack.SnackSuccess("se actualizo correctamente");
                                    await PopupNavigation.PopAsync();
                                    MessagingCenter.Send<updateUserPageViewModel>(this, "send");
                                }
                                        else
                                        {
                                            await snack.SnackError("Ocurrio un error");
                                        }
                                    
                                }
                                else
                                {
                                    await snack.SnackError("Seleccione un genero");
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
