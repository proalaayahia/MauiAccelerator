﻿namespace Appy.Views;

public partial class WebViewPage : ContentPage
{
	public WebViewPage(WebViewViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
