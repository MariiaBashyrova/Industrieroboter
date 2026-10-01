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
    public int Verschleiss { get => _verschleiss;
             set => _verschleiss=value>100 || value<0?throw new ArgumentOutOfRangeException(nameof(value),
            $"Verschleiss {value} ist ungültig.") :value; }
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
    private int Groesse;
    public Bohrer(string art, int verschleiss, int groesse) : base(art, verschleiss)
    {
        Groesse = groesse;
    }
    public override void Ausgeben()
    {
        Console.WriteLine($"Bohrer mit Groesse {Groesse} (Verschleiss {Verschleiss} %).");
    }
}

public class Greifer : Werkzeug
{
   public Greifer(string art, int verschleiss) : base(art, verschleiss)
    {
    }
    public override void Ausgeben()
    {
        Console.WriteLine($"Greifer (Verschleiss {Verschleiss} %).");
    }
}

public class Schweisser : Werkzeug
{
    public Schweisser(string art, int verschleiss) : base(art, verschleiss)
    {
    }
    public override void Ausgeben()
    {
        Console.WriteLine($"Schweisser (Verschleiss {Verschleiss} %).");
    }
}