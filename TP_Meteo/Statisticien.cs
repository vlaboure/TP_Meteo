using System;
using System.Collections.Generic;
using System.Text;

namespace TP_Meteo
{
    public class Statisticien
    {
        private StationMeteo stationMeteo;
        private int nbChangementTemps, nbChangementTemperature;
        private int nbSoleil, joursEte;

        public Statisticien(StationMeteo station)
        {
            nbChangementTemps = 0;
            nbChangementTemperature =
            nbSoleil = 0;
            joursEte = 0;
            stationMeteo = station;
        }

        public void Demarrer()
        {

            // on ajoute au délégué event une action MeteoChange
            //***************** En utilisant la délcaration delegate
            // stationMeteo.QuandLeTempsChange += MeteoChange;

            //**************En utilisant Action<T>
            stationMeteo.QuandLeTempsChange_Act += MeteoChange;
            stationMeteo.TemperatureChange_Act += TemperatureChange;
            //démarrage boucle génération de temps
            stationMeteo.Demarrer();

            // désabonnement à l'évenement
            //***************** En utilisant la délcaration delegate
            // stationMeteo.QuandLeTempsChange -= MeteoChange;
            //**************En utilisant Action<T>
            stationMeteo.QuandLeTempsChange_Act += MeteoChange;
            stationMeteo.TemperatureChange_Act += TemperatureChange;
        }


        public void AfficherRapport()
        {
            Console.Write("Nombre de fois où le temps a changé : {0}\t ",nbChangementTemps);
            Console.WriteLine("Nombre de fois où la temperature a changé : {0}", nbChangementTemperature);
            Console.Write("Nombre de fois où il a fait soleil : {0}\t\t",nbSoleil);
            Console.WriteLine("Nombre de jours où la temperature était celle de l'été : {0}", joursEte);
            Console.Write("Pourcentage de beau temps : {0}\t\t\t",nbSoleil * 100 / nbChangementTemps + " %");          
            Console.WriteLine("Pourcentage de jours d'été : {0}",joursEte * 100 / nbChangementTemperature + " %");


        }

        //méthode locale exécutée par le délégué quand on lance un événement
        private void MeteoChange(Temps temps)
        {
            if (temps == Temps.Soleil)
                nbSoleil++;
            nbChangementTemps++;
        }

        private void TemperatureChange(Temperature temperature)
        {
            if (temperature == Temperature.ete)
                joursEte++;
            nbChangementTemperature++;
        }
    }
}
