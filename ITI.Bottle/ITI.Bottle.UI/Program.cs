using System;

namespace ITI.Bottle.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Flask flask1 = new Flask(1500);
            Flask flask2 = new Flask();
            ShowFlask(flask2);

            flask2.Fill(600);
            ShowFlask(flask2);
            flask2.Fill(1000);
            ShowFlask(flask2);

            flask2.Empty(200);
            ShowFlask(flask2);
            flask2.Empty(400);
            ShowFlask(flask2);
            flask2.Empty(1000);
            ShowFlask(flask2);

            flask2.Fulfill();
            ShowFlask(flask2);
            flask2.Empty();
            ShowFlask(flask2);
        }

        static void ShowFlask(Flask flask)
        {
            Console.WriteLine("Max capacity: {0}, current volume: {1}.", flask.GetMaxCapacity(), flask.GetCurrentVolume());
        }
    }
}
