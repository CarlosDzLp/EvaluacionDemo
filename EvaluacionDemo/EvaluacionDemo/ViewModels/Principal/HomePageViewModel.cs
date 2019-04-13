using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using BussinesLayer;
using DataEntities;
using EvaluacionDemo.ViewModels.Base;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace EvaluacionDemo.ViewModels.Principal
{
    public class HomePageViewModel : BindableBase
    {
        BLLogin login = new BLLogin();
        #region Properties
        private ObservableCollection<UserModel> list;
        public ObservableCollection<UserModel> ListUser
        {
            get { return list; }
            set { SetProperty(ref list, value); }
        }
        #endregion


        #region Constructor
        public HomePageViewModel()
        {
            ListUser = new ObservableCollection<UserModel>();
            ItemToolBarcommand = new Command(ItemToolBarcommandExecuted);
            SelectedCommand = new Command<UserModel>(SelectedCommandExecuted);
            LoadData();
            MessagingCenter.Subscribe<updateUserPageViewModel>(this, "send", (obj) =>
            {
                LoadData();
            });
            MessagingCenter.Subscribe<AddUserPopupViewModel>(this, "sendApp", (obj) =>
            {
                LoadData();
            });
        }
        #endregion

        #region Command
        public ICommand ItemToolBarcommand { get; set; }
        public ICommand SelectedCommand { get; set; }
        #endregion

        #region Methods
        private async void LoadData()
        {
            try
            {
                ListUser.Clear();
                var result = await login.ListUser();
                foreach(var item in result)
                {
                    ListUser.Add(item);
                }
            }
            catch(Exception ex)
            {

            }
        }

        #endregion

        #region CommandExcuted
        private async void ItemToolBarcommandExecuted()
        {
            try
            {
                await PopupNavigation.PushAsync(new Views.PopupPage.AddUserPopup());
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        private async void SelectedCommandExecuted(UserModel user)
        {
            try
            {
                if(user != null)
                {
                    await PopupNavigation.PushAsync(new Views.PopupPage.UpdateUserPage(user));
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
