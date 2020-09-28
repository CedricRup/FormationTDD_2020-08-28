using System;
using System.Collections.Generic;
using Xunit;
using Yahtzee;

namespace Tests
{
    public class CalculateurScoreTests
    {

        [Fact]
        public void lance_NullReferenceException_si_le_tirage_est_nul()
        {
            List<int> tirage = null;
            CalculateurDeScore calculateurDeScore = new CalculateurDeScore();
            Assert.Throws<NullReferenceException>(()=> calculateurDeScore.CalculerScore(tirage, Combinaison.Yahtzee));
        }

        [Fact]
        public void calculer_un_yahtzee_pour_5_5_donne_50_points()
        {
            List<int> tirage = new List<int>{5,5,5,5,5};
            CalculateurDeScore calculateurDeScore = new CalculateurDeScore();
            var score = calculateurDeScore.CalculerScore(tirage, Combinaison.Yahtzee);
            Assert.Equal(50,score);
        }


        [Fact]
        public void calculer_un_yahtzee_pour_5_1_donne_50_points()
        {
            List<int> tirage = new List<int>{1,1,1,1,1};
            CalculateurDeScore calculateurDeScore = new CalculateurDeScore();
            var score = calculateurDeScore.CalculerScore(tirage, Combinaison.Yahtzee);
            Assert.Equal(50,score);
        }


        [Fact]
        public void calculer_un_yahtzee_pour_4_5_donne_0_points()
        {
            List<int> tirage = new List<int> { 5, 5, 5, 1, 5 };
            CalculateurDeScore calculateurDeScore = new CalculateurDeScore();
            var score = calculateurDeScore.CalculerScore(tirage, Combinaison.Yahtzee);
            Assert.Equal(0, score);
        }

        [Fact]
        public void calculer_un_carre_pour_5_des_différents_donne_0_points()
        {
            List<int> tirage = new List<int> { 1, 2, 3, 4, 5 };
            CalculateurDeScore calculateurDeScore = new CalculateurDeScore();
            var score = calculateurDeScore.CalculerScore(tirage, Combinaison.Carre);
            Assert.Equal(0, score);
        }


        [Fact]
        public void calculer_un_carre_pour________()
        {
            List<int> tirage = new List<int> { 1, 5, 5, 5, 5 };
            CalculateurDeScore calculateurDeScore = new CalculateurDeScore();
            var score = calculateurDeScore.CalculerScore(tirage, Combinaison.Carre);
            Assert.Equal(21, score);
        }

        [Fact]
        public void calculer_un_carre_pour_5_5_donne_25_points()
        {
            List<int> tirage = new List<int> { 5, 5, 5, 5, 5 };
            CalculateurDeScore calculateurDeScore = new CalculateurDeScore();
            var score = calculateurDeScore.CalculerScore(tirage, Combinaison.Carre);
            Assert.Equal(25, score);
        }
    }
}
