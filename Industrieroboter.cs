using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Industrieroboter;

public class Industrieroboter
{
    static readonly int maxAnzWerkzeuge = 10;

    Werkzeug[] werkzeugKasten = new Werkzeug[maxAnzWerkzeuge];

    public bool WerkzeugHinzufuegen(int platz, Werkzeug neu)
    {
        if (platz < 0 || platz >= maxAnzWerkzeuge) {
            Console.WriteLine($"Hinzufügen nicht möglich, da Platz {platz} nicht existiert.");
            return false;
        }
        if (werkzeugKasten[platz] == null)
            {
                werkzeugKasten[platz] = neu;
                Console.Write($"Hinzugefügtes Werkzeug auf Platz {platz}:");
                neu.Ausgeben();
                return true;
            }
        else
            {
                Console.WriteLine($"Hinzufügen nicht möglich, da Platz {platz} belegt ist.");
                //werkzeugKasten[platz].Ausgeben();
                return false;
            }
    }

    public  bool WerkzeugEntfernen(int platz)
    {
        if (platz < 0 || platz >= maxAnzWerkzeuge)
        {
            Console.WriteLine($"Entfernen nicht möglich, da Platz {platz} nicht existiert.");
            return false;
        }
        if (werkzeugKasten[platz] != null)
            {
                
                Console.Write($"Entferntes Werkzeug auf Platz {platz}:");
                werkzeugKasten[platz].Ausgeben();
                werkzeugKasten[platz] = null;
                return true;
            }
        else
            {
                Console.WriteLine($"Entfernen nicht möglich, da Platz {platz} nicht belegt ist.");
                return false;
            }
    }
}
