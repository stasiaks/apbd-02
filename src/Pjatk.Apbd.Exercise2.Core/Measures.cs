namespace Pjatk.Apbd.Exercise2.Core;

// Jednostki SI implementowane jako osobone typy, celem uniknięcia "Primitive Obsession"
// Niestety C# nie wspiera "Units of Measure" https://learn.microsoft.com/en-us/dotnet/fsharp/language-reference/units-of-measure

public record Kilogram(decimal Value)
{
    public static implicit operator Ton(Kilogram kilogram) => new(kilogram.Value / 1000);

    public static explicit operator Kilogram(decimal value) => new(value);
};

public record Ton(decimal Value)
{
    public static implicit operator Kilogram(Ton ton) => new(ton.Value * 1000);

    public static explicit operator Ton(decimal value) => new(value);
};

// Zadanie wymagało wszędzie centymetrów, normalnie implementowałbym metry jako jednostkę SI
public record Centimetre(decimal Value)
{
    public static explicit operator Centimetre(decimal value) => new(value);
};

public record Bar(decimal Value)
{
    public static explicit operator Bar(decimal value) => new(value);
};

public record Celsius(decimal Value)
{
    public static explicit operator Celsius(decimal value) => new(value);
};

public record Knot(decimal Value)
{
    public static explicit operator Knot(decimal value) => new(value);
};
