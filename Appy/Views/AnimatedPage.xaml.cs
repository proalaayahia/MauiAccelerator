using Microsoft.Maui;

namespace Appy.Views;

public partial class AnimatedPage : ContentPage
{
    public AnimatedPage()
    {
        InitializeComponent();

        AnimatedContainer.FadeTo(1, 100,easing:Easing.CubicInOut);
        AnimatedContainer.Content = Content;
    }

    public async Task AnimatedGoTo(string pUrl)
    {
        await AnimatedContainer.FadeTo(0, 100, easing: Easing.CubicInOut);
        await Shell.Current.GoToAsync($"//{pUrl}", true);
    }
}