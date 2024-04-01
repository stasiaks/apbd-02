namespace Pjatk.Apbd.Exercise2.Core;

// Jednostki SI implementowane jako osobone typy, celem uniknięcia "Primitive Obsession"
// Niestety C# nie wspiera "Units of Measure" https://learn.microsoft.com/en-us/dotnet/fsharp/language-reference/units-of-measure

public record Kilogram(decimal Value);

// Zadanie wymagało wszędzie centymetrów, normalnie implementowałbym metry jako jednostkę SI
public record Centimetre(decimal Value);

public record Bar(decimal Value);

public record Celsius(decimal Value);
