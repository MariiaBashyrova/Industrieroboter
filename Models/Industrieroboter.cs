using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Industrieroboter;

public class Industrieroboter
{
    private static readonly int maxAnzWerkzeuge = 10;
    // private const int MAX_ANZ_WERKZEUGE = 10;  

    private Werkzeug[] werkzeugKasten; //Aggregation: Industrieroboter hat Werkzeuge

    public Industrieroboter()
    {
        werkzeugKasten = new Werkzeug[maxAnzWerkzeuge];
    }

    public bool WerkzeugHinzufuegen(int platz, Werkzeug neu)
    {
        if (PlatzPruefen(platz))
        {
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
        else
        {
            return false;
        }
    }

    public bool PlatzPruefen(int platz)
    {
        if (platz < 0 || platz >= maxAnzWerkzeuge)
        {
            //Console.WriteLine($"Hinzufügen nicht möglich, da Platz {platz} nicht existiert.");
            //return false;

            throw new ArgumentOutOfRangeException(
            nameof(platz),
            $"Platz {platz} existiert nicht.");
        }
        return true;
    }

    public bool WerkzeugEntfernen(int platz)
    {
        if (PlatzPruefen(platz))
        {
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
        else
        {
            return false;
        }
    }

    public Werkzeug WerkzeugAnzeigen(int platz)
    {
        if (!PlatzPruefen(platz))
            return null;

        return werkzeugKasten[platz];
    }

    public Werkzeug this[int platz]
    {
        get => WerkzeugAnzeigen(platz); // Indexer roboter[platz] gibt das Werkzeug an dem angegebenen Platz zurück
    }

    public int AnzahlWerkzeuge
    {
        get
        {
            int anzahl = 0;

            for (int i = 0; i < maxAnzWerkzeuge; i++)
            {
                if (werkzeugKasten[i] != null)
                    anzahl++;
            }

            return anzahl;
        }
    }

    public int MaxAnzahlWerkzeuge
    {
        get { return maxAnzWerkzeuge; }
    }
}