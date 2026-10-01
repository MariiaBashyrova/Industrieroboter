namespace Industrieroboter;

internal class Program
{
    static void Main(string[] args)
    {
        Testprogramm();
    }

    static void Testprogramm()
    {
        Industrieroboter roboter = new Industrieroboter();
        Werkzeug bohrer1 = new Bohrer("Bohrer", 0, 10);
        Werkzeug bohrer2 = new Bohrer("Bohrer", 0, 10);
        roboter.WerkzeugHinzufuegen(5, bohrer1);
        roboter.WerkzeugHinzufuegen(5, bohrer2);
        roboter.WerkzeugHinzufuegen(10, bohrer2);
        roboter.WerkzeugHinzufuegen(-1, bohrer2);
        roboter.WerkzeugEntfernen(5);
        roboter.WerkzeugEntfernen(5);
        roboter.WerkzeugEntfernen(10);
        roboter.WerkzeugEntfernen(-1);
    }
}