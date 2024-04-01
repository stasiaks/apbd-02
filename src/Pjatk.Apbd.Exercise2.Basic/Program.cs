using System.Diagnostics;
using Pjatk.Apbd.Exercise2.Core;

namespace Pjatk.Apbd.Exercise2.Basic;

public static class Program
{
    public static int Main(string[] args)
    {
        // 1. Stworzenie kontenera danego typu
        var liquidContainer = new LiquidsContainer(
            new Centimetre(200),
            new Centimetre(400),
            new Kilogram(100),
            1,
            new Kilogram(2000)
        )
        {
            HazadrousMaterialsLoaded = true
        };
        liquidContainer.HazardNotification += (_, n) => Console.Error.WriteLine(n);

        var gasContainer = new GasContainer(
            new Centimetre(200),
            new Centimetre(400),
            new Kilogram(100),
            1,
            new Kilogram(2000)
        );

        var coldContainer = new ColdContainer(
            new Centimetre(200),
            new Centimetre(400),
            new Kilogram(100),
            1,
            new Kilogram(2000),
            ColdCargoType.Meat,
            new Celsius(20)
        );

        // 2. Załadowanie ładunku do danego kontenera
        liquidContainer.Load(new Kilogram(500));
        Debug.Assert(liquidContainer.LoadMass.Value == 500);

        // 3. Załadowanie kontenera na statek

        var cargoShip1 = new CargoShip(new Knot(5), 10, new Ton(20));
        cargoShip1.Load(liquidContainer);
        Debug.Assert(cargoShip1.Containers.Count == 1);

        // 4. Załadowanie listy kontenerów na statek
        cargoShip1.Load([gasContainer, coldContainer]);
        Debug.Assert(cargoShip1.Containers.Count == 3);

        // 5. Usunięcie kontenera ze statku
        cargoShip1.Unload(gasContainer);
        Debug.Assert(cargoShip1.Containers.Count == 2);

        // 6. Rozładowanie kontenera
        cargoShip1.Unload();
        Debug.Assert(cargoShip1.Containers.Count == 0);

        // 7. Zastąpienie kontenera na statku o danym numerze innym kontenerem
        cargoShip1.Load(gasContainer);
        cargoShip1.Replace(gasContainer.SerialNumber, liquidContainer);

        Debug.Assert(cargoShip1.Containers.Single() == liquidContainer);

        // 8. Możliwość przeniesienia kontenera między dwoma statkami
        var cargoShip2 = new CargoShip(new Knot(2), 11, new Ton(70));

        cargoShip1.MoveTo(liquidContainer.SerialNumber, cargoShip2);
        Debug.Assert(cargoShip1.Containers.Count == 0);
        Debug.Assert(cargoShip2.Containers.Count == 1);

        // 9. Wypisanie informacji o kontenerze

        Console.WriteLine(SummarySerializer.Summary(liquidContainer));
        Console.WriteLine(SummarySerializer.Summary(gasContainer));
        Console.WriteLine(SummarySerializer.Summary(coldContainer));

        // 10. Wypisanie informacji o danym statku i jego ładunku

        cargoShip2.Load(coldContainer);

        Console.WriteLine(SummarySerializer.Summary(cargoShip1));
        Console.WriteLine(SummarySerializer.Summary(cargoShip2));

        return 0;
    }
}
