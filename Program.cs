// Overerving, abstracte methods, virtual/override, sealed en polymorfisme.

// We bewaren verschillende figuren als Figuur. Dat is polymorfisme: elk object
// weet zelf welke Oppervlakte() en Beschrijf() het moet uitvoeren.
Figuur[] figuren =
[
    new Rechthoek(3, 4),
    new Vierkant(5),
    new Cirkel(2),
];

foreach (Figuur figuur in figuren)
{
    Console.WriteLine(figuur.Beschrijf());
}

// Een abstracte base class: je kan ze niet zelf instantiëren.
// Ze legt vast wat elke figuur moet kunnen, zonder alles al in te vullen.
abstract class Figuur
{
    // protected: enkel toegankelijk in deze klasse en in afgeleide klassen.
    protected Figuur(string naam) => Naam = naam;

    public string Naam { get; }

    // Een abstracte method: geen body. Elke afgeleide klasse moet ze invullen.
    public abstract double Oppervlakte();

    // Een virtual method: er is een standaardimplementatie, maar een
    // afgeleide klasse mag ze overschrijven.
    public virtual string Beschrijf() => $"{Naam} met oppervlakte {Oppervlakte():0.##}";
}

class Rechthoek : Figuur
{
    public Rechthoek(double breedte, double hoogte) : base("Rechthoek")
    {
        Breedte = breedte;
        Hoogte = hoogte;
    }

    // Deze constructor laat een afgeleide klasse (Vierkant) een eigen naam
    // doorgeven aan de base class.
    protected Rechthoek(string naam, double breedte, double hoogte) : base(naam)
    {
        Breedte = breedte;
        Hoogte = hoogte;
    }

    protected double Breedte { get; }
    protected double Hoogte { get; }

    // override: we vullen de abstracte method uit Figuur in.
    public override double Oppervlakte() => Breedte * Hoogte;
}

// sealed: van deze klasse kan je niet meer verder overerven.
sealed class Vierkant : Rechthoek
{
    // base(...) roept de (protected) constructor van Rechthoek aan.
    public Vierkant(double zijde) : base("Vierkant", zijde, zijde)
    {
    }

    // We overschrijven de virtual method uit Figuur met een eigen tekst.
    public override string Beschrijf() => $"{Naam} met zijde {Breedte} en oppervlakte {Oppervlakte():0.##}";
}

class Cirkel : Figuur
{
    private readonly double _straal;

    public Cirkel(double straal) : base("Cirkel") => _straal = straal;

    public override double Oppervlakte() => Math.PI * _straal * _straal;
}
