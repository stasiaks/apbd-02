namespace Pjatk.Apbd.Exercise2.Core;

public sealed class GasContainer : Container, IHazardNotifier
{
    protected override string TypeString => "G";

    /// <summary>
    ///  Do uzupełniania samodzielnie podczas ładowania.
    ///  Treść zadania nie oczekuje od kontenera przechowywania wystarczającej ilości informacji aby przeliczać na bieżąco.
    /// </summary>
    public Bar Pressure { get; set; } = new Bar(0);

    internal GasContainer(
        Centimetre height,
        Centimetre depth,
        Kilogram ownWeight,
        int id,
        Kilogram maxLoad
    )
        : base(height, depth, ownWeight, id, maxLoad) { }

    public override void Empty()
    {
        const decimal partToLeave = 0.05m;
        LoadMass = (Kilogram)(LoadMass.Value * partToLeave);
        Pressure = (Bar)(Pressure.Value * partToLeave);
    }

    /*
    * Treść zadania nie opisała żadnego zdarzenia które powinno zgłosić tu błąd.
    * Przekroczenie ładowności jest już pokryte przez
        "Jeśli masa ładunku jest większa niż pojemność danego kontenera powinniśmy wyrzucić błąd OverfillException"
    */
#pragma warning disable CS0067 // The event 'GasContainer.HazardNotification' is never used
    public event IHazardNotifier.HazardEventHandler? HazardNotification;
#pragma warning restore
}
