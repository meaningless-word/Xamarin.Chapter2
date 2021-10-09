using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Chapter2.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WebPage : ContentPage
	{
		public WebPage()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Обработчик навигации
		/// </summary>
		private void NavigateToPage(object sender, EventArgs e)
		{
			// переход по ссылке с автодополнением при необходимости
			webView.Source = new UrlWebViewSource { Url = urlEntry.Text.Contains("http") ? urlEntry.Text : $"https://{urlEntry.Text}" };
		}
	}
}