using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Industrieroboter;

internal class KonsolenMenue
{
    public static void Menue(Industrieroboter  roboter)
    {
        
        bool weiter = true;

        while (weiter)
        {
            Console.WriteLine();
            Console.WriteLine("=== Werkzeugkasten-Verwaltung ===");
            Console.WriteLine("1. Werkzeug hinzufügen");
            Console.WriteLine("2. Werkzeug entfernen");
            Console.WriteLine("3. Werkzeugkasten anzeigen");
            Console.WriteLine("4. Werkzeug benutzen");
            Console.WriteLine("5. Werkzeug warten");
            Console.WriteLine("6. Beenden");
            Console.Write("Ihre Auswahl: ");

            int auswahl = LeseZahl(1, 6);

            switch (auswahl)
            {
                case 1:
                    WerkzeugHinzufuegen(roboter);
                    break;

                case 2:
                    WerkzeugEntfernen(roboter);
                    break;

                case 3:
                    WerkzeugkastenAnzeigen(roboter);
                    break;

                case 4:
                    WerkzeugBenutzen(roboter);
                    break;

                case 5:
                    WerkzeugWarten(roboter);
                    break;

                case 6:
                    weiter = false;
                    Console.WriteLine("Programm beendet.");
                    break;


            }
        }
    }


    static int LeseZahl(int min, int max)
    {
        int zahl;

        while (true)
        {
            if (!int.TryParse(Console.ReadLine(), out zahl))
            {
                Console.Write("Ungültige Eingabe. Bitte eine Zahl eingeben: ");
            }
            else if (zahl < min || zahl > max)
            {
                Console.Write($"Ungültige Eingabe. Bitte eine Zahl zwischen {min} und {max} eingeben: ");
            }
            else
            {
                return zahl;
            }
        }
    }


    static void WerkzeugHinzufuegen(Industrieroboter roboter)
    {
        int maxAuswahl = roboter.MaxAnzahlWerkzeuge - 1;
        Console.Write($"Welchen Platz möchten Sie verwenden (0-{maxAuswahl})? ");
        int platz = LeseZahl(0, maxAuswahl);

        Console.WriteLine();
        Console.WriteLine("=== Werkzeugart auswählen ===");
        Console.WriteLine("1. Bohrer");
        Console.WriteLine("2. Greifer");
        Console.WriteLine("3. Schweisser");
        Console.Write("Ihre Auswahl: ");

        int art = LeseZahl(1, 3);

        Werkzeug neu = null;

        Console.Write("Verschleiß in Prozent: ");
        int verschleiss = LeseZahl(0, 100);

        switch (art)
        {
            case 1:

                Console.Write("Größe des Bohrers: ");
                int groesse = LeseZahl(0, int.MaxValue);

                neu = new Bohrer("Bohrer", verschleiss, groesse);
                break;

            case 2:


                neu = new Greifer("Greifer", verschleiss);
                break;

            case 3:


                neu = new Schweisser("Schweisser", verschleiss);
                break;


        }

        roboter.WerkzeugHinzufuegen(platz, neu);
    }


    static void WerkzeugEntfernen(Industrieroboter roboter)
    {
        int maxAuswahl = roboter.MaxAnzahlWerkzeuge - 1;
        Console.Write("Welches Werkzeug soll entfernt werden? Platz: ");
        int platz = LeseZahl(0, maxAuswahl);

        roboter.WerkzeugEntfernen(platz);
    }


    static void WerkzeugkastenAnzeigen(Industrieroboter roboter)
    {
        Console.WriteLine();
        Console.WriteLine("=== Werkzeugkasten ===");

        for (int i = 0; i < roboter.MaxAnzahlWerkzeuge; i++)
        {
            Werkzeug werkzeug = roboter.WerkzeugAnzeigen(i);

            if (werkzeug == null)
            {
                Console.WriteLine($"Platz {i}: leer");
            }
            else
            {
                Console.Write($"Platz {i}: ");
                werkzeug.Ausgeben();
            }
        }
    }


    static void WerkzeugBenutzen(Industrieroboter roboter)
    {
        int maxAuswahl = roboter.MaxAnzahlWerkzeuge - 1;
        Console.Write("Welches Werkzeug möchten Sie benutzen? Platz: ");
        int platz = LeseZahl(0, maxAuswahl);

        Werkzeug werkzeug = roboter.WerkzeugAnzeigen(platz);

        if (werkzeug == null)
        {
            Console.WriteLine("An diesem Platz befindet sich kein Werkzeug.");
            return;
        }

        Console.Write("Verschleiß erhöhen um: ");
        int erhoehung = LeseZahl(0, 100 - werkzeug.Verschleiss);

        int neuerVerschleiss = werkzeug.Verschleiss + erhoehung;

        werkzeug.Verschleiss = neuerVerschleiss;

        Console.Write("Werkzeug nach der Benutzung: ");
        werkzeug.Ausgeben();
    }


    static void WerkzeugWarten(Industrieroboter roboter)
    {
        int maxAuswahl = roboter.MaxAnzahlWerkzeuge - 1;
        Console.Write("Welches Werkzeug soll gewartet werden? Platz: ");
        int platz = LeseZahl(0, maxAuswahl);

        Werkzeug werkzeug = roboter.WerkzeugAnzeigen(platz);

        if (werkzeug == null)
        {
            Console.WriteLine("An diesem Platz befindet sich kein Werkzeug.");
            return;
        }

        werkzeug.Verschleiss = 0;

        Console.Write("Werkzeug nach der Wartung: ");
        werkzeug.Ausgeben();
    }
}
