﻿using CommunityToolkit.Mvvm.Messaging;

namespace Appy.ViewModels;

public partial class WebViewViewModel : BaseViewModel,IRecipient<MyMessage>
{
	[ObservableProperty]
	public string source;

	[ObservableProperty]
	public bool isLoading;

	public WebViewViewModel()
	{
		// TODO: Update the default URL
		Source = "https://github.com/sponsors/mrlacey";
		IsLoading = true;
        WeakReferenceMessenger.Default.Register(this);
    }

    [RelayCommand]
	private async void WebViewNavigated(WebNavigatedEventArgs e)
	{
		IsLoading = false;

		if (e.Result != WebNavigationResult.Success)
		{
			// TODO: handle failed navigation in an appropriate way
			await Shell.Current.DisplayAlert("Navigation failed", e.Result.ToString(), "OK");
		}
	}

	[RelayCommand]
	private void NavigateBack(WebView webView)
	{
		if (webView.CanGoBack)
		{
			webView.GoBack();
		}
	}

	[RelayCommand]
	private void NavigateForward(WebView webView)
	{
		if (webView.CanGoForward)
		{
			webView.GoForward();
		}
	}

	[RelayCommand]
	private void RefreshPage(WebView webView)
	{
		webView.Reload();
	}

	[RelayCommand]
	private async void OpenInBrowser()
	{
		await Launcher.OpenAsync(Source);
	}

    public void Receive(MyMessage message)
    {
		Source = message.Value;
        Shell.Current.DisplayAlert("Message received", message.Value, "OK");
    }
}
