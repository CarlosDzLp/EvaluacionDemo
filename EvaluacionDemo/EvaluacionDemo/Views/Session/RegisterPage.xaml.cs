using System;
using System.Collections.Generic;
using EvaluacionDemo.ViewModels.Session;
using Xamarin.Forms;

namespace EvaluacionDemo.Views.Session
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
            //NavigationPage.SetHasNavigationBar(this, false);
            this.BindingContext = new RegisterPageViewModel();
        }
    }
}
