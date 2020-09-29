using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using Xunit;
using Yahtzee;

namespace Tests {
    public class TourDeJeuTests {
        private FeuilleDeScore feuilleDeScore;
        private TourDeJeu tourDeJeu;
        private Mock<IGenerateurDeDes> fauxGenerateurDeDes;

        public TourDeJeuTests () {
            feuilleDeScore = new FeuilleDeScore ();
            fauxGenerateurDeDes = new Mock<IGenerateurDeDes>();
            ConfigurerLancer(1, 2, 3, 4, 5);
            tourDeJeu = new TourDeJeu(feuilleDeScore, fauxGenerateurDeDes.Object);
        }

        private void ConfigurerLancer(params int[] lancer)
        {
            fauxGenerateurDeDes.Setup(x => x.Generer5Des()).Returns(lancer.ToList());
        }

        [Fact]
        public void les_des_sont_lances_on_peut_recupere_leurs_valeurs () {
            tourDeJeu.LancerDes ();
            var resultat = tourDeJeu.RecupererDes ();
            Assert.Equal (5, resultat.Count ());
        }

        [Fact]
        public void recuperer_les_des_sans_les_lancer_donne_null () {
            var resultat = tourDeJeu.RecupererDes ();
            Assert.Null (resultat);
        }

        [Fact]
        public void inscrire_un_score_dans_une_case () {
            ConfigurerLancer( 1, 2, 3, 4, 5 );
            tourDeJeu.LancerDes ();

            tourDeJeu.EnregistrerScore (Combinaison.As);

            Assert.Equal (1, feuilleDeScore.RecupererScore (Combinaison.As));
        }

        [Fact]
        public void inscrire_un_score_et_relance_impossible () {
            tourDeJeu.LancerDes ();
            tourDeJeu.EnregistrerScore (Combinaison.As);
            
            Assert.Throws<Exception>(() => tourDeJeu.LancerDes());
        }

        [Fact]
        public void peut_relancer_les_des()
        {
            ConfigurerLancer(1, 2, 3, 4, 5);
            tourDeJeu.LancerDes();
            ConfigurerLancer(6, 6, 6, 6, 6);
            tourDeJeu.LancerDes();

            Assert.Equal(new List<int>{6, 6, 6, 6, 6}, tourDeJeu.RecupererDes());
        }

        [Fact]
        public void on_ne_peut_relancer_4_fois_les_des()
        {
            tourDeJeu.LancerDes();
            tourDeJeu.LancerDes();
            tourDeJeu.LancerDes();

            Assert.Throws<Exception>(() => tourDeJeu.LancerDes());
        }


        // Inscrit le score, on ne peut plus lancer
        // Inscrit le score, le tour est terminé
        // Deux Fois
        // Trois fois
        //Stockage des dés

        // Quatre => ca marche pas
        // 5 dés, pas plus
    }
}