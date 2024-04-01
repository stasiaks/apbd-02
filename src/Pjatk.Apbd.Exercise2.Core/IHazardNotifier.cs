namespace Pjatk.Apbd.Exercise2.Core;

public interface IHazardNotifier
{
    public delegate void HazardEventHandler(object sender, string notification);
    public event HazardEventHandler? HazardNotification;
}
