using System;
using Xamarin.Forms;

namespace Chapter2.Pages
{
	public partial class RegisterPage : ContentPage
	{
		public RegisterPage()
		{
			InitializeComponent();
			PlatformAdjust();
		}

		/// <summary>
		/// Настраиваем вид для разных платформ
		/// </summary>
		private void PlatformAdjust()
		{
			if (Device.RuntimePlatform == Device.UWP)
			{
				placeHolder.PlaceholderColor = Color.SlateGray;
				loginButton.TextColor = Color.AliceBlue;
				loginButton.Margin = new Thickness(0, 5);
			}
		}
	}
}