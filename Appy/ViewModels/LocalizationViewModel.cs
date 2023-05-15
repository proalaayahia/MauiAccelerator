namespace Appy.ViewModels;

public partial class LocalizationViewModel : BaseViewModel
{
	public string LocalizedText => Appy.Resources.Strings.AppResources.HelloMessage;
}
