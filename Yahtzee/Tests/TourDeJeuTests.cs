using System.Linq;
using Xunit;
using Yahtzee;

namespace Tests
{
    public class TourDeJeuTests
    {
        //Lance les dés
        [Fact]
        public void les_des_sont_lances_on_peut_recupere_leurs_valeurs()
        {
            TourDeJeu tourDeJeu = new TourDeJeu();
            tourDeJeu.LancerDes();
            var resultat = tourDeJeu.RecupererDes();
            Assert.Equal(5, resultat.Count());
        }

        [Fact]
        public void recuperer_les_des_sans_les_lancer_donne_null()
        {
            TourDeJeu tourDeJeu = new TourDeJeu();
            var resultat = tourDeJeu.RecupererDes();
            Assert.Null(resultat);
        }

        // Inscrire un score dans une case
        // Inscrit le score, on ne peut plus lancer
        // Inscrit le score, le tour est terminé
        // Deux Fois
        // Trois fois
        //Stockage des dés

        // Quatre => ca marche pas
        // 5 dés, pas plus
    }
}
