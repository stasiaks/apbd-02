using Pjatk.Apbd.Exercise2.Core;

namespace Pjatk.Apbd.Exercise2.Basic;

public static class Program
{
    public static int Main(string[] args)
    {
        // 1. Stworzenie kontenera danego typu
        var liquidContainer = new LiquidsContainer(
            new Centimetre(200),
            new Kilogram(100),
            1,
            new Kilogram(2000)
        )
        {
            HazadrousMaterialsLoaded = true
        };
        liquidContainer.HazardNotification += (_, n) => Console.Error.WriteLine(n);
        // 2. Załadowanie ładunku do danego kontenera
        liquidContainer.Load(new Kilogram(1500));
        return 0;
    }
}
