using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace EvaluacionDemo.Views.PopupPage
{
    public partial class AddUserPopup : Rg.Plugins.Popup.Pages.PopupPage
    {
        public AddUserPopup()
        {
            InitializeComponent();
            this.BindingContext = new ViewModels.AddUserPopupViewModel();
        }
    }
}
