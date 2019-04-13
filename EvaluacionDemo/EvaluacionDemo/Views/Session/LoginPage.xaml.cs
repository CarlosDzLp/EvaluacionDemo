using System;
using System.Collections.Generic;
using EvaluacionDemo.ViewModels.Session;
using Xamarin.Forms;

namespace EvaluacionDemo.Views.Session
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            //NavigationPage.SetHasNavigationBar(this, false);
            this.BindingContext = new LoginPageViewModel();
        }
    }
}
