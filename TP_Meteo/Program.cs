using System;

namespace TP_Meteo
{
    class Program
    {
        static void Main(string[] args)
        {
            StationMeteo maStation = new StationMeteo(100);
            Statisticien monStatisticien = new Statisticien(maStation);
            
            for (int i = 1; i < 10; i++)
            {
                monStatisticien.Demarrer();
                monStatisticien.AfficherRapport();
            }
            
        }
    }
}
