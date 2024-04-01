namespace Pjatk.Apbd.Exercise2.Core;

public sealed class LiquidsContainer(
    Centimetre height,
    Kilogram ownWeight,
    int id,
    Kilogram maxLoad
) : Container(height, ownWeight, id, maxLoad), IHazardNotifier
{
    protected override string TypeString => "L";

    private bool hazadrousMaterialsLoaded;
    public bool HazadrousMaterialsLoaded
    {
        get => hazadrousMaterialsLoaded;
        set
        {
            hazadrousMaterialsLoaded = value;
            ValidateHazards();
        }
    }

    public override void Load(Kilogram additionalLoad)
    {
        base.Load(additionalLoad);
        ValidateHazards();
    }

    private void ValidateHazards()
    {
        var loadPercentage = LoadMass.Value / MaxLoad.Value;
        if (HazadrousMaterialsLoaded)
        {
            if (loadPercentage > 0.5m)
            {
                HazardNotification?.Invoke(
                    this,
                    "Kontener cieczy z niebezpiecznym ładunkiem przekroczył 50% pojemności"
                );
            }
        }
        else
        {
            if (loadPercentage > 0.9m)
            {
                HazardNotification?.Invoke(
                    this,
                    "Kontener cieczy z bezpiecznym ładunkiem przekroczył 90% pojemności"
                );
            }
        }
    }

    public event IHazardNotifier.HazardEventHandler? HazardNotification;
}
