namespace Pjatk.Apbd.Exercise2.Core;

public class CargoShip(Knot maxSpeed, int maxContainers, Ton maxLoad)
{
    private readonly List<Container> _containers = [];

    public IReadOnlyCollection<Container> Containers => _containers.AsReadOnly();

    public Knot MaxSpeed { get; } = maxSpeed;
    public int MaxContainers { get; } = maxContainers;

    // Nie sprawdzam tego w żadnym momencie.
    // Ponieważ kontenery nie są niemutowalne, i tak nie mógłbym zapewnić czy ich masa nie zmieniła się po załadowaniu.
    // Użytkownik sam musi sprawdzić czy masa nie została przekroczona.
    public Ton MaxLoad { get; } = maxLoad;

    public Ton CurrentLoad => (Kilogram)_containers.Sum(x => x.LoadMass.Value + x.OwnWeight.Value);

    public void Load(Container container) => Load([container]);

    public void Load(IList<Container> containers)
    {
        if (_containers.Count + containers.Count > MaxContainers)
        {
            throw new OverfillException();
        }
        _containers.AddRange(containers);
    }

    public void Unload(Container container) => _containers.Remove(container);

    public void Unload(string serialNumber)
    {
        var found = _containers.Find(x => x.SerialNumber == serialNumber);
        if (found is not null)
        {
            _containers.Remove(found);
        }
    }

    public void Unload()
    {
        _containers.Clear();
    }

    public void Replace(string serialNumber, Container newContainer)
    {
        Unload(serialNumber);
        Load(newContainer);
    }

    public void MoveTo(string serialNumber, CargoShip cargoShip)
    {
        if(_containers.Find(x => x.SerialNumber == serialNumber) is {} container)
        {
            _containers.Remove(container);
            cargoShip.Load(container);
        }
    }
}
