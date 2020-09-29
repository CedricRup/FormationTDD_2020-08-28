using System;
using System.Collections.Generic;

namespace Yahtzee
{
    public class TourDeJeu
    {
        private List<int> tirage;
        private FeuilleDeScore feuilleDeScore;
        private IGenerateurDeDes generateurDeDes;
        private bool tourTermine;
        private int nombreDeLancers;

        public TourDeJeu(FeuilleDeScore feuilleDeScore, IGenerateurDeDes generateurDeDes)
        {
            this.feuilleDeScore = feuilleDeScore;
            this.generateurDeDes = generateurDeDes;
        }

        public void LancerDes()
        {
            if (tourTermine|| nombreDeLancers >= 3)
            {
                throw new Exception();
            }
            tirage = generateurDeDes.Generer5Des();
            nombreDeLancers++;
        }

        public List<int> RecupererDes()
        {
            return tirage;
        }

        public void EnregistrerScore(Combinaison combinaison)
        {
            feuilleDeScore.StockerScore(tirage, combinaison);
            tourTermine = true;
        }
    }
}