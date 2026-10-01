
namespace Industrieroboter;

internal class Program
{
    static void Main(string[] args)
    {
        //Testprogramm();
        TestsStarten();
        Industrieroboter roboter = new Industrieroboter();
        KonsolenMenue.Menue(roboter);
    }

    static void Testprogramm() //Alte Testmethode, die nicht mehr benötigt wird, da die Tests in der Methode TestsStarten() durchgeführt werden.
    {
        Industrieroboter roboter = new Industrieroboter();
        Werkzeug bohrer1 = new Bohrer("Bohrer", 0, 10, BohrerArt.Spiralbohrer);
        Werkzeug bohrer2 = new Bohrer("Bohrer", 0, 10, BohrerArt.Kernbohrer);
        roboter.WerkzeugHinzufuegen(5, bohrer1);
        roboter.WerkzeugHinzufuegen(5, bohrer2);
        roboter.WerkzeugHinzufuegen(10, bohrer2);
        roboter.WerkzeugHinzufuegen(-1, bohrer2);
        roboter.WerkzeugEntfernen(5);
        roboter.WerkzeugEntfernen(5);
        roboter.WerkzeugEntfernen(10);
        roboter.WerkzeugEntfernen(-1);
    }

    static void TestsStarten()
    {
        TestPlatzPruefen();
        TestPlatzPruefenUngueltig();

        TestWerkzeugHinzufuegen();
        TestWerkzeugHinzufuegenBelegt();

        TestWerkzeugEntfernen();
        TestWerkzeugEntfernenLeer();
    }

    static void TestPlatzPruefen()
    {
        Industrieroboter roboter = new Industrieroboter();

        bool ergebnis = roboter.PlatzPruefen(5);

        if (ergebnis == true)
            Console.ForegroundColor = ConsoleColor.Green;
        else
            Console.ForegroundColor = ConsoleColor.Red;

        Console.WriteLine($"PlatzPruefen(5) ->  erwartet: true, erhalten: {ergebnis}");
        Console.ResetColor();
    }

    static void TestPlatzPruefenUngueltig()
    {
        Industrieroboter roboter = new Industrieroboter();

        bool exceptionAufgetreten = false;

        try
        {
            roboter.PlatzPruefen(89);
        }
        catch (ArgumentOutOfRangeException)
        {
            exceptionAufgetreten = true;
        }

        if (exceptionAufgetreten)
            Console.ForegroundColor = ConsoleColor.Green;
        else
            Console.ForegroundColor = ConsoleColor.Red;

        Console.WriteLine($"PlatzPruefen(89) ->  erwartet: ArgumentOutOfRangeException, erhalten: {exceptionAufgetreten}");
        Console.ResetColor();
    }

    static void TestWerkzeugHinzufuegen()
    {
        Industrieroboter roboter = new Industrieroboter();
        Bohrer bohrer = new Bohrer("Bohrer", 20, 10, BohrerArt.Spiralbohrer);

        bool ergebnis = roboter.WerkzeugHinzufuegen(2, bohrer);

        if (ergebnis == true)
            Console.ForegroundColor = ConsoleColor.Green;
        else
            Console.ForegroundColor = ConsoleColor.Red;

        Console.WriteLine($"WerkzeugHinzufuegen(2) ->  erwartet: true, erhalten: {ergebnis}");
        Console.ResetColor();
    }

    static void TestWerkzeugHinzufuegenBelegt()
    {
        Industrieroboter roboter = new Industrieroboter();
        Bohrer bohrer = new Bohrer("Bohrer", 20, 10, BohrerArt.Stufenbohrer);

        roboter.WerkzeugHinzufuegen(2, bohrer);

        Greifer greifer = new Greifer("Greifer", 30, GreiferArt.Vakuumgreifer);

        bool ergebnis = roboter.WerkzeugHinzufuegen(2, greifer);

        if (ergebnis == false)
            Console.ForegroundColor = ConsoleColor.Green;
        else
            Console.ForegroundColor = ConsoleColor.Red;

        Console.WriteLine($"WerkzeugHinzufuegen(2) bei belegtem Platz ->  erwartet: false, erhalten: {ergebnis}");
        Console.ResetColor();
    }
    static void TestWerkzeugEntfernen()
    {
        Industrieroboter roboter = new Industrieroboter();
        Bohrer bohrer = new Bohrer("Bohrer", 20, 10, BohrerArt.Stufenbohrer);

        roboter.WerkzeugHinzufuegen(2, bohrer);

        bool ergebnis = roboter.WerkzeugEntfernen(2);

        if (ergebnis == true)
            Console.ForegroundColor = ConsoleColor.Green;
        else
            Console.ForegroundColor = ConsoleColor.Red;

        Console.WriteLine($"WerkzeugEntfernen(2) ->  erwartet: true, erhalten: {ergebnis}");
        Console.ResetColor();
    }
    static void TestWerkzeugEntfernenLeer()
    {
        var roboter = new Industrieroboter();

        bool ergebnis = roboter.WerkzeugEntfernen(2);

        if (ergebnis == false)
            Console.ForegroundColor = ConsoleColor.Green;
        else
            Console.ForegroundColor = ConsoleColor.Red;

        Console.WriteLine($"WerkzeugEntfernen(2) bei leerem Platz -> erwartet: false, erhalten: {ergebnis}");
        Console.ResetColor();
    }

}
