using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Xunit;
using Yahtzee;

namespace Tests
{
    public class TourDeJeuTests
    {

        public class FauxGenerateurDeDes : IGenerateurDeDes
        {
            public List<int> Generer5Des()
            {
                return Des;
            }

            public List<int> Des { get; set; }
        }


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

        [Fact]
        public void inscrire_un_score_dans_une_case()
        {
            FeuilleDeScore feuilleDeScore = new FeuilleDeScore();
            var fauxGenerateurDeDes = new FauxGenerateurDeDes();
            fauxGenerateurDeDes.Des = new List<int>{1, 2, 3, 4, 5};

            TourDeJeu tourDeJeu = new TourDeJeu(feuilleDeScore, fauxGenerateurDeDes);
            tourDeJeu.LancerDes();
            tourDeJeu.EnregistrerScore(Combinaison.As);

            Assert.Equal(1, feuilleDeScore.RecupererScore(Combinaison.As));
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
