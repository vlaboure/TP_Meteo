using System;
using System.Collections.Generic;
using System.Text;

namespace TP_Meteo
{
    public class StationMeteo
    {
        /// <summary>
        //              / OBSOLETE version ave delegate
        /// </summary>
        /// <param name="temps"></param>
        //*****************************************
            //délégué utilisé pour manipuler l'évenement temps qui change
            // Ici on déclare le délégué
            //public delegate void FaitIlBeau(Temps temps);
            //public delegate void EstCeEte(Temperature temperature);
            //public event EstCeEte TemperatureChange;
            //public event FaitIlBeau QuandLeTempsChange;
        //*******************************************

        /// <summary>
        //              Utilisée Version avec Action/ 
        /// </summary>
        public Action<Temps> QuandLeTempsChange_Act;
        public Action<Temperature> TemperatureChange_Act;
        // type nullable accés à une variable sans exception NullReferenceException et nlles méthodes disponibles....
        private Temps ? ancienTemps;
        private Temperature? ancienneTemperature;
        private int nbRepetitions;
        private Random random;
        //*********************** Action remplace delegate et event
        
        public StationMeteo(int nbRepet)
        {
            nbRepetitions = nbRepet;
            random = new Random();
            ancienTemps = null;
            ancienneTemperature = null;
        }

        public void Demarrer()
        {
            for(int i = 0; i <= nbRepetitions; i++)
            {
                int valeur = random.Next(0, 100);
                if (valeur < 5)
                    GererTemps(Temps.Soleil);
                else
                {
                    if (valeur < 50)
                        GererTemps(Temps.Nuage);
                    else
                    {
                        if (valeur < 90)
                            GererTemps(Temps.Pluie);
                        else
                            GererTemps(Temps.Orage);
                    }
                }

                //**** pout les températures
                int temp = random.Next(-20, 60);
                if (temp < -20)
                    GererTemperatures(Temperature.Artique);
                else if (temp >= -20 && temp < 10)
                    GererTemperatures(Temperature.Hiver);
                else if (temp >= 10 && temp < 25)
                    GererTemperatures(Temperature.Printemps);
                else if (temp > 40)
                    GererTemperatures(Temperature.canicule);
                        else GererTemperatures(Temperature.ete); 

            }
        }

        private void GererTemperatures(Temperature temperature) 
        {
            if(ancienneTemperature.HasValue && ancienneTemperature.Value != temperature && TemperatureChange_Act != null)             
                TemperatureChange_Act(temperature);
            ancienneTemperature = temperature;
        }

        private void GererTemps(Temps temps)
    //méthode qui teste si le temps a changé modifie la valeur de temps si le temps à changé avec la méthode Demarrer et
    //finalement renseigne ancienTemps avec la nouvelle valeur de temps
        {
            //.HasValue test si ancienTemps est null.
            //s'il est null on n'appelle pas l'événement QuandLeTempsChange
        //******************************* ICI in déclare le délégué en passant par la méthode IlFaitBeau
          //  if (ancienTemps.HasValue && ancienTemps.Value != temps && QuandLeTempsChange != null)

        //*********************************ICI utilisation de Action<T>
            if (ancienTemps.HasValue && ancienTemps.Value != temps && QuandLeTempsChange_Act != null)
                QuandLeTempsChange_Act(temps);
            ancienTemps = temps;
        }
    }
}
