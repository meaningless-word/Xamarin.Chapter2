using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Chapter2.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaddingPage : ContentPage
    {
        public PaddingPage()
        {
            InitializeComponent();
            
            if (Device.RuntimePlatform == Device.Android)
                bv1.CornerRadius = 10;
        }
    }
}