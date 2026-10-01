namespace Industrieroboter;

public enum BohrerArt
{
    Spiralbohrer,
    Stufenbohrer,
    Kernbohrer,
    Gewindebohrer
}
public class Bohrer : Werkzeug
{
    public BohrerArt BohrerArt { get; set; }
    private int Groesse;
    public Bohrer(string art, int verschleiss, int groesse, BohrerArt bohrerArt) : base(art, verschleiss)
    {
        Groesse = groesse;
        BohrerArt = bohrerArt;
    }
    public override void Ausgeben()
    {
        Console.WriteLine($"Bohrer {BohrerArt} mit Groesse {Groesse} (Verschleiss {Verschleiss} %).");
    }
}
