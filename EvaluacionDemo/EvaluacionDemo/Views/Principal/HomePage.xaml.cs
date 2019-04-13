using System;
using System.Collections.Generic;
using EvaluacionDemo.ViewModels.Principal;
using Xamarin.Forms;

namespace EvaluacionDemo.Views.Principal
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            this.BindingContext = new HomePageViewModel(); 
        }
    }
}
