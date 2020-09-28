using System.Collections.Generic;
using Tests;

namespace Yahtzee
{
    public class FeuilleDeScore
    {
        private Dictionary<Combinaison, int> scores = new Dictionary<Combinaison, int>();

        public int? RecupererScore(Combinaison caseVoulue)
        {
            return scores.TryGetValue(caseVoulue, out var score) ? (int?)score : null;
        }

        public void StockerScore(List<int> tirage, Combinaison caseVoulue)
        {
            
            if (!scores.ContainsKey(caseVoulue))
            {
                var calculateur = new CalculateurDeScore();
                scores.Add(caseVoulue, calculateur.CalculerScore(tirage, caseVoulue));
            }
            else
            {
                throw new CaseDejaRemplieException();
            }
        }
    }
}