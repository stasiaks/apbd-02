namespace Pjatk.Apbd.Exercise2.Core;

public static class ContainerFactory
{
    private static int currentLiquidId = 1;
    private static int currentGasId = 1;
    private static int currentColdId = 1;

    public static LiquidsContainer CreateLiquidsContainer(
        Centimetre height,
        Centimetre depth,
        Kilogram ownWeight,
        Kilogram maxLoad
    ) => new(height, depth, ownWeight, currentLiquidId++, maxLoad);

    public static GasContainer CreateGasContainer(
        Centimetre height,
        Centimetre depth,
        Kilogram ownWeight,
        Kilogram maxLoad
    ) => new(height, depth, ownWeight, currentGasId++, maxLoad);

    public static ColdContainer CreateColdContainer(
        Centimetre height,
        Centimetre depth,
        Kilogram ownWeight,
        Kilogram maxLoad,
        ColdCargoType cargoType,
        Celsius temperature
    ) => new(height, depth, ownWeight, currentColdId++, maxLoad, cargoType, temperature);
}
