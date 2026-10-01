namespace Industrieroboter;
public enum SchweisserArt
{
    Punktschweissen,
    Schutzgasschweissen,
    WigSchweissen,
    Laserschweissen
}
public class Schweisser : Werkzeug
{
    public SchweisserArt SchweisserArt { get; set; }
    public Schweisser(string art, int verschleiss, SchweisserArt schweisserArt) : base(art, verschleiss)
    {
        SchweisserArt = schweisserArt;
    }
    public override void Ausgeben()
    {
        Console.WriteLine($"Schweisser {SchweisserArt} (Verschleiss {Verschleiss} %).");
    }
}