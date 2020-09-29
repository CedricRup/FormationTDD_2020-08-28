using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Yahtzee
{
    public class TourDeJeu
    {
        private List<int> tirage;
        private FeuilleDeScore feuilleDeScore;
        private IGenerateurDeDes _generateurDeDes;

        public TourDeJeu()
        {
            feuilleDeScore = new FeuilleDeScore();
            _generateurDeDes = new GenerateurDeDes();
        }

        public TourDeJeu(FeuilleDeScore feuilleDeScore, IGenerateurDeDes generateurDeDes)
        {
            this.feuilleDeScore = feuilleDeScore;
            _generateurDeDes = generateurDeDes;
        }

        public void LancerDes()
        {
            var generateur = _generateurDeDes;
            tirage = generateur.Generer5Des();
        }

        public List<int> RecupererDes()
        {
            return tirage;
        }

        public void EnregistrerScore(Combinaison @as)
        {
            throw new System.NotImplementedException();
        }
    }
}