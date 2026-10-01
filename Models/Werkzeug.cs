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
