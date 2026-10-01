using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Industrieroboter;

public abstract class Werkzeug
{
    private string _art; 

    protected int _verschleiss;
    protected int Verschleiss { get => _verschleiss;
             set => _verschleiss=(value>100 || value<0)?throw new ArgumentOutOfRangeException():value; }
    public string Art { get => _art; set => _art = value; }

    public Werkzeug(string art, int verschleiss)
    {
        Art = art;
        Verschleiss = verschleiss;
    }

    public abstract void Ausgeben();
}

public class Bohrer : Werkzeug
{
    private int Grosse;
    public Bohrer(string art, int verschleiss, int grosse) : base(art, verschleiss)
    {
        Grosse = grosse;
    }
    public override void Ausgeben()
    {
        Console.WriteLine($"Bohrer mit Groesse {Grosse} (Verschleiss {Verschleiss} %).");
    }
}