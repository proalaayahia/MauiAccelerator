using CommunityToolkit.Mvvm.Messaging.Messages;
namespace Appy;
public class MyMessage : ValueChangedMessage<string>
{
    public MyMessage(string value) : base(value)
    {

    }
}