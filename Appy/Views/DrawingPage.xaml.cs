﻿using CommunityToolkit.Maui.Views;

namespace Appy.Views;

public partial class DrawingPage : AnimatedPage
{
	public DrawingPage(DrawingViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

	private async void SaveClicked(object sender, EventArgs e)
	{
		var drawingLines = (BindingContext as DrawingViewModel).Lines.ToList();
		var points = drawingLines.SelectMany(x => x.Points).ToList();

		var stream = await DrawingView.GetImageStream(
			drawingLines,
			new Size(points.Max(x => x.X) - points.Min(x => x.X), points.Max(x => x.Y) - points.Min(x => x.Y)),
			Colors.Gray);

		GeneratedImage.Source = ImageSource.FromStream(() => stream);
	}
    private async void Button_Clicked(object sender, EventArgs e)
    {
       await base.AnimatedGoTo(nameof(WebViewPage));
    }
}