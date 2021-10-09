using Xamarin.Forms;

namespace Chapter2.Pages
{
    public partial class CsharpPaddingPage : ContentPage
    {
        public CsharpPaddingPage()
        {
            var stackLayout = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                // Внутренний отступ для содержимого
                Padding = new Thickness(60),
                Children =
                {
                    new BoxView {Color = Color.SkyBlue, Margin = new Thickness(10) /* внешние отступы */},
                    new BoxView {Color = Color.LightSteelBlue, Margin = new Thickness(10)},
                    new BoxView {Color = Color.MediumTurquoise, Margin = new Thickness(10)},
                    new BoxView {Color = Color.SteelBlue, Margin = new Thickness(10)}
                }
            };

            Content = stackLayout;
        }
    }
}