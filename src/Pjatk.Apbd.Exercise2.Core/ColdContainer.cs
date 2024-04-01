namespace Pjatk.Apbd.Exercise2.Core;

public sealed class ColdContainer : Container
{
    public ColdContainer(
        Centimetre height,
        Centimetre depth,
        Kilogram ownWeight,
        int id,
        Kilogram maxLoad,
        ColdCargoType cargoType,
        Celsius temperature
    )
        : base(height, depth, ownWeight, id, maxLoad)
    {
        CargoType = cargoType;
        Temperature = temperature;
        if (MinimumTemperature(cargoType).Value > temperature.Value)
        {
            throw new ArgumentOutOfRangeException(nameof(temperature));
        }
    }

    public ColdCargoType CargoType { get; }
    public Celsius Temperature { get; }

    protected override string TypeString => "G";

    private static Celsius MinimumTemperature(ColdCargoType cargoType) =>
        cargoType switch
        {
            _ => throw new ArgumentOutOfRangeException(nameof(cargoType))
        };
}
