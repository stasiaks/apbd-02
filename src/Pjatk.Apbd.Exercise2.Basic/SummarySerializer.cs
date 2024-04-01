using System.Text;
using Pjatk.Apbd.Exercise2.Core;

namespace Pjatk.Apbd.Exercise2.Basic;

public static class SummarySerializer
{
    public static string Summary(Container container)
    {
        var sb = new StringBuilder();
        sb.Append(container.SerialNumber);
        sb.Append(" - (Wysokość: ");
        sb.Append(container.Height);
        sb.Append(", Głębokość: ");
        sb.Append(container.Depth);
        sb.Append(", Waga kontenera: ");
        sb.Append(container.OwnWeight);
        sb.Append(", Masa ładunku: ");
        sb.Append(container.LoadMass);
        sb.Append(", Maksymalny załadunek: ");
        sb.Append(container.MaxLoad);
        sb.Append(TypeSpecificSummary());
        sb.Append(')');

        return sb.ToString();

        string TypeSpecificSummary() =>
            container switch
            {
                LiquidsContainer liquidsContainer
                    => $", Ładunek niebezpieczny: {(liquidsContainer.HazadrousMaterialsLoaded ? "Tak" : "Nie")}",
                GasContainer gasContainer => $", Ciśnienie: {gasContainer.Pressure}",
                ColdContainer coldContainer
                    => $", Typ ładunku: {coldContainer.CargoType}, Temperatura: {coldContainer.Temperature}",
                _ => string.Empty,
            };
    }

    public static string Summary(CargoShip cargoShip)
    {
        var sb = new StringBuilder();

        sb.Append("Statek - (Maksymalna prędkość: ");
        sb.Append(cargoShip.MaxSpeed);
        sb.Append(", Maksymalnie kontenerów: ");
        sb.Append(cargoShip.MaxContainers);
        sb.Append(", Maksymalny załadunek: ");
        sb.Append(cargoShip.MaxLoad);

        sb.Append(')');

        foreach (var container in cargoShip.Containers)
        {
            sb.AppendLine();
            // indent
            sb.Append("    ");
            sb.Append(Summary(container));
        }

        return sb.ToString();
    }
}
