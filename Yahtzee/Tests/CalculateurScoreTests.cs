using System;
using System.Collections.Generic;
using Xunit;
using Yahtzee;

namespace Tests {
    public class CalculateurScoreTests {

        [Fact]
        public void lance_NullReferenceException_si_le_tirage_est_nul () {
            List<int> tirage = null;
            CalculateurDeScore calculateurDeScore = new CalculateurDeScore ();
            Assert.Throws<NullReferenceException> (() => calculateurDeScore.CalculerScore (tirage, Combinaison.Yahtzee));
        }

        [Fact]
        public void lance_NotImplementedException_quand_combinaison_inconnue () {
            List<int> tirage = new List<int> { 4, 4, 4, 5, 6 };
            CalculateurDeScore calculateurDeScore = new CalculateurDeScore ();
            Assert.Throws<NotImplementedException> (() => calculateurDeScore.CalculerScore (tirage, Combinaison.Full));
        }

        [Fact]
        public void calculer_un_yahtzee_pour_5_5_donne_50_points () {
            List<int> tirage = new List<int> { 5, 5, 5, 5, 5 };
            CalculateurDeScore calculateurDeScore = new CalculateurDeScore ();
            var score = calculateurDeScore.CalculerScore (tirage, Combinaison.Yahtzee);
            Assert.Equal (50, score);
        }

        [Fact]
        public void calculer_un_yahtzee_pour_5_1_donne_50_points () {
            List<int> tirage = new List<int> { 1, 1, 1, 1, 1 };
            CalculateurDeScore calculateurDeScore = new CalculateurDeScore ();
            var score = calculateurDeScore.CalculerScore (tirage, Combinaison.Yahtzee);
            Assert.Equal (50, score);
        }

        [Fact]
        public void calculer_un_yahtzee_pour_4_5_donne_0_points () {
            List<int> tirage = new List<int> { 5, 5, 5, 1, 5 };
            CalculateurDeScore calculateurDeScore = new CalculateurDeScore ();
            var score = calculateurDeScore.CalculerScore (tirage, Combinaison.Yahtzee);
            Assert.Equal (0, score);
        }

        [Fact]
        public void calculer_un_carre_pour_5_des_différents_donne_0_points () {
            List<int> tirage = new List<int> { 1, 2, 3, 4, 5 };
            CalculateurDeScore calculateurDeScore = new CalculateurDeScore ();
            var score = calculateurDeScore.CalculerScore (tirage, Combinaison.Carre);
            Assert.Equal (0, score);
        }

        [Fact]
        public void calculer_un_carre_pour_premier_des_different () {
            List<int> tirage = new List<int> { 1, 5, 5, 5, 5 };
            CalculateurDeScore calculateurDeScore = new CalculateurDeScore ();
            var score = calculateurDeScore.CalculerScore (tirage, Combinaison.Carre);
            Assert.Equal (21, score);
        }

        [Fact]
        public void calculer_un_carre_pour_second_des_different () {
            List<int> tirage = new List<int> { 5, 1, 5, 5, 5 };
            CalculateurDeScore calculateurDeScore = new CalculateurDeScore ();
            var score = calculateurDeScore.CalculerScore (tirage, Combinaison.Carre);
            Assert.Equal (21, score);
        }

        [Fact]
        public void calculer_un_carre_pour_5_5_donne_25_points () {
            List<int> tirage = new List<int> { 5, 5, 5, 5, 5 };
            CalculateurDeScore calculateurDeScore = new CalculateurDeScore ();
            var score = calculateurDeScore.CalculerScore (tirage, Combinaison.Carre);
            Assert.Equal (25, score);
        }

        [Fact]
        public void calculer_un_brelan_pour_trois_premiers_des_identiques () {
            List<int> tirage = new List<int> { 3, 3, 3, 4, 6 };
            CalculateurDeScore calculateurDeScore = new CalculateurDeScore ();
            var score = calculateurDeScore.CalculerScore (tirage, Combinaison.Brelan);
            Assert.Equal (19, score);
        }

        [Fact]
        public void calculer_un_brelan_pour_trois_premiers_des_identiques_bis () {
            List<int> tirage = new List<int> { 4, 4, 4, 5, 6 };
            CalculateurDeScore calculateurDeScore = new CalculateurDeScore ();
            var score = calculateurDeScore.CalculerScore (tirage, Combinaison.Brelan);
            Assert.Equal (23, score);
        }

        [Fact]
        public void calculer_lAs () {
            List<int> tirage = new List<int> { 1, 4, 1, 5, 1 };
            CalculateurDeScore calculateurDeScore = new CalculateurDeScore ();
            var score = calculateurDeScore.CalculerScore (tirage, Combinaison.As);
            Assert.Equal (3, score);
        }

        [Fact]
        public void calculer_le_Deux () {
            List<int> tirage = new List<int> { 2, 2, 4, 5, 2 };
            CalculateurDeScore calculateurDeScore = new CalculateurDeScore ();
            var score = calculateurDeScore.CalculerScore (tirage, Combinaison.Deux);
            Assert.Equal (6, score);
        }

        [Fact]
        public void calculer_le_Trois()
        {
            List<int> tirage = new List<int> { 3, 6, 3, 3, 2 };
            CalculateurDeScore calculateurDeScore = new CalculateurDeScore();
            var score = calculateurDeScore.CalculerScore(tirage, Combinaison.Trois);
            Assert.Equal(9, score);
        }

        [Fact]
        public void calculer_le_Quatre()
        {
            List<int> tirage = new List<int> { 4, 6, 3, 4, 2 };
            CalculateurDeScore calculateurDeScore = new CalculateurDeScore();
            var score = calculateurDeScore.CalculerScore(tirage, Combinaison.Quatre);
            Assert.Equal(8, score);
        }

        [Fact]
        public void calculer_le_Cinq()
        {
            List<int> tirage = new List<int> { 5, 5, 3, 3, 5 };
            CalculateurDeScore calculateurDeScore = new CalculateurDeScore();
            var score = calculateurDeScore.CalculerScore(tirage, Combinaison.Cinq);
            Assert.Equal(15, score);
        }

        [Fact]
        public void calculer_le_Six()
        {
            List<int> tirage = new List<int> { 3, 6, 6, 3, 6 };
            CalculateurDeScore calculateurDeScore = new CalculateurDeScore();
            var score = calculateurDeScore.CalculerScore(tirage, Combinaison.Six);
            Assert.Equal(18, score);
        }
    }
}