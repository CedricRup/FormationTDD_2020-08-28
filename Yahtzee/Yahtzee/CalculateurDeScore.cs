using System.Collections.Generic;
using System.Linq;

namespace Yahtzee
{
    public class CalculateurDeScore
    {
        public int CalculerScore(List<int> tirage, Combinaison combinaison)
        {
            var premierDe = tirage[0];
            if (combinaison == Combinaison.Carre)
            {
                var nombreDeDesIdentiquesAuPremier = tirage.Count(de => de == premierDe);
                return nombreDeDesIdentiquesAuPremier >= 4 ? 25 : 0;
            }
            
            return tirage.Any(de => de != premierDe) ? 0 : 50;
        }
    }
}