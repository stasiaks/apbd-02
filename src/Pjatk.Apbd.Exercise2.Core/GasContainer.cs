namespace Pjatk.Apbd.Exercise2.Core;

public sealed class GasContainer(
    Centimetre height,
    Centimetre depth,
    Kilogram ownWeight,
    int id,
    Kilogram maxLoad,
    Bar pressure
) : Container(height, depth, ownWeight, id, maxLoad), IHazardNotifier
{
    protected override string TypeString => "G";

    /// <summary>
    ///  Do uzupełniania samodzielnie podczas ładowania.
    ///  Treść zadania nie oczekuje od kontenera przechowywania wystarczającej ilości informacji aby przeliczać na bieżąco.
    /// </summary>
    public Bar Pressure { get; set; } = pressure;

    public override void Empty()
    {
        const decimal partToLeave = 0.05m;
        LoadMass = new Kilogram(LoadMass.Value * partToLeave);
        Pressure = new Bar(Pressure.Value * partToLeave);
    }

    /*
    * Treść zadania nie opisała żadnego zdarzenia które powinno zgłosić tu błąd.
    * Przekroczenie ładowności jest już pokryte przez
        "Jeśli masa ładunku jest większa niż pojemność danego kontenera powinniśmy wyrzucić błąd OverfillException"
    */
    public event IHazardNotifier.HazardEventHandler? HazardNotification;
}
