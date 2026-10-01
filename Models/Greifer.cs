namespace Industrieroboter;

public enum GreiferArt
{
    Parallelgreifer,
    Vakuumgreifer,
    Magnetgreifer,
    Nadelgreifer
}
public class Greifer : Werkzeug
{
   public GreiferArt GreiferArt { get; set; }
    public Greifer(string art, int verschleiss, GreiferArt greiferArt) : base(art, verschleiss)
    {
        GreiferArt = greiferArt;    
    }
    public override void Ausgeben()
    {
        Console.WriteLine($"Greifer {GreiferArt} (Verschleiss {Verschleiss} %).");
    }
}
