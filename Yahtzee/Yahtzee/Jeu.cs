using Tests;

namespace Yahtzee
{
    public class Jeu
    {
        private IAfficheur afficheur;

        public Jeu(IAfficheur afficheur, IEntree entreeObject)
        {
            this.afficheur = afficheur;
        }

        public void Commencer()
        {
            afficheur.AfficherMessage("appuyez sur entrée pour lancer les dés");
        }
    }
}