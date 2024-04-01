namespace Pjatk.Apbd.Exercise2.Core;

public sealed class ColdContainer : Container
{
    internal ColdContainer(
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

    protected override string TypeString => "C";

    private static Celsius MinimumTemperature(ColdCargoType cargoType) =>
        (Celsius)(
            cargoType switch
            {
                ColdCargoType.Bananas => 13.3m,
                ColdCargoType.Chocolate => 18,
                ColdCargoType.Fish => 2,
                ColdCargoType.Meat => -15,
                ColdCargoType.IceCream => -18,
                ColdCargoType.FrozenPizza => -30,
                ColdCargoType.Cheese => 7.2m,
                ColdCargoType.Sausages => 5,
                ColdCargoType.Butter => 20.5m,
                ColdCargoType.Eggs => 19,
                _ => throw new ArgumentOutOfRangeException(nameof(cargoType))
            }
        );
}
