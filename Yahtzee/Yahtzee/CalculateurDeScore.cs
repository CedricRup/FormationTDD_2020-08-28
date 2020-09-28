using System;
using System.Collections.Generic;
using System.Linq;

namespace Yahtzee
{
    public class CalculateurDeScore
    {
        public int CalculerScore(List<int> tirage, Combinaison combinaison)
        {
            if (tirage is null)
            {
                throw new NullReferenceException();
            }

            return combinaison switch
            {
                Combinaison.Brelan => CalculerResultatPourUnNombreDeDesIdentiques(tirage, 3),
                Combinaison.Carre => CalculerResultatPourUnNombreDeDesIdentiques(tirage, 4),
                Combinaison.Yahtzee => tirage.Any(de => de != tirage[0]) ? 0 : 50,
                Combinaison.As => CalculResultatAsASix(tirage, 1),
                Combinaison.Deux => CalculResultatAsASix(tirage, 2),
                Combinaison.Trois => CalculResultatAsASix(tirage, 3),
                Combinaison.Quatre => CalculResultatAsASix(tirage, 4),
                Combinaison.Cinq => CalculResultatAsASix(tirage, 5),
                Combinaison.Six => CalculResultatAsASix(tirage, 6),
                _ => throw new NotImplementedException()
            };
        }

        private static int CalculResultatAsASix(List<int> tirage, int valeur)
        {
            return tirage.Count(de => de == valeur) * valeur;
        }

        private static int CalculerResultatPourUnNombreDeDesIdentiques(List<int> tirage, int nombreDeDes)
        {
            foreach (var deAConsiderer in tirage)
            {
                if (tirage.Count(de => de == deAConsiderer) >= nombreDeDes)
                {
                    return tirage.Sum();
                }
            }

            return 0;
        }
    }
}