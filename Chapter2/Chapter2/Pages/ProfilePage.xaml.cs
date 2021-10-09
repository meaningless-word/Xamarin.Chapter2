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
	public partial class ProfilePage : ContentPage
	{
		public ProfilePage()
		{
			InitializeComponent();
		}

		private void NotifyUser(object sender, ToggledEventArgs e)
		{
			if (gasSwitch.On && climateSwitch.On && electroSwitch.On)
				DisplayAlert("Внимание!", "Пльзователь получит полный доступ ко всем системам", "OK");
		}
	}
}