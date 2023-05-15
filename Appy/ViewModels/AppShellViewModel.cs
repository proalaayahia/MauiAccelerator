﻿namespace Appy.ViewModels;

public partial class AppShellViewModel : BaseViewModel
{

    [CommunityToolkit.Mvvm.Input.RelayCommand]
    async void SignOut()
    {
        if (Preferences.ContainsKey(nameof(App.UserDetails)))
        {
            Preferences.Clear();
            Preferences.Remove(nameof(App.UserDetails));
        }
        await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");

    }
}