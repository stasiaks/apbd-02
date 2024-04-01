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
            ColdCargoType.Bananas => new Celsius(13.3m),
            ColdCargoType.Chocolate => new Celsius(18),
            ColdCargoType.Fish => new Celsius(2),
            ColdCargoType.Meat => new Celsius(-15),
            ColdCargoType.IceCream => new Celsius(-18),
            ColdCargoType.FrozenPizza => new Celsius(-30),
            ColdCargoType.Cheese => new Celsius(7.2m),
            ColdCargoType.Sausages => new Celsius(5),
            ColdCargoType.Butter => new Celsius(20.5m),
            ColdCargoType.Eggs => new Celsius(19),
            _ => throw new ArgumentOutOfRangeException(nameof(cargoType))
        };
}
