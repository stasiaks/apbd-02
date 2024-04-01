namespace Pjatk.Apbd.Exercise2.Core;

public abstract class Container
{
    public Container(
        Centimetre height,
        Centimetre depth,
        Kilogram ownWeight,
        int id,
        Kilogram maxLoad
    )
    {
        if (maxLoad.Value < 0)
        {
            throw new ArgumentException("Max load cannot be negative", nameof(maxLoad));
        }
        LoadMass = (Kilogram)0;
        Height = height;
        Depth = depth;
        OwnWeight = ownWeight;
        MaxLoad = maxLoad;

        // Kontenery nie będą pilnować swojej unikalności numeracji samodzielnie, to nie ich odpowiedzialność.
        // Musi to robić klasa odpowiedzialna za ich tworzenie.
        SerialNumber = $"KON-{TypeString}-{id}";
    }

    protected abstract string TypeString { get; }

    public string SerialNumber { get; }

    public Kilogram LoadMass { get; protected set; }
    public Centimetre Height { get; }
    public Centimetre Depth { get; }
    public Kilogram OwnWeight { get; }
    public Kilogram MaxLoad { get; }

    public virtual void Empty() => LoadMass = new Kilogram(0);

    public virtual void Load(Kilogram additionalLoad)
    {
        var newLoad = additionalLoad.Value + LoadMass.Value;

        if (newLoad > MaxLoad.Value)
        {
            throw new OverfillException();
        }
        LoadMass = (Kilogram)newLoad;
    }
}
