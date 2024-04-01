namespace Pjatk.Apbd.Exercise2.Core;

public abstract class Container
{
    public Container(Centimetre height, Kilogram ownWeight, int id, Kilogram maxLoad)
    {
        if (maxLoad.Value < 0)
        {
            throw new ArgumentException("Max load cannot be negative", nameof(maxLoad));
        }
        LoadMass = new Kilogram(0);
        Height = height;
        OwnWeight = ownWeight;
        MaxLoad = maxLoad;
        SerialNumber = $"KON-{TypeString}-{id}";
    }

    protected abstract string TypeString { get; }

    public string SerialNumber { get; }

    public Kilogram LoadMass { get; private set; }
    public Centimetre Height { get; }
    public Kilogram OwnWeight { get; }
    public Kilogram MaxLoad { get; }

    public virtual void Empty() => LoadMass = new Kilogram(0);

    public virtual void Load(Kilogram additionalLoad)
    {
        var newLoad = new Kilogram(additionalLoad.Value + LoadMass.Value);

        if (newLoad.Value > MaxLoad.Value)
        {
            throw new OverfillException();
        }
        LoadMass = newLoad;
    }
}
