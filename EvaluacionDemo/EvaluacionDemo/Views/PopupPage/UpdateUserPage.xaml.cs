using System;
using System.Collections.Generic;
using DataEntities;
using Xamarin.Forms;

namespace EvaluacionDemo.Views.PopupPage
{
    public partial class UpdateUserPage : Rg.Plugins.Popup.Pages.PopupPage
    {
        public UpdateUserPage(UserModel user)
        {
            InitializeComponent();
            this.BindingContext = new ViewModels.updateUserPageViewModel(user);
        }
    }
}
