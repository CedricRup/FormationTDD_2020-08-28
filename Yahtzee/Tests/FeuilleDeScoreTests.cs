using System.Collections.Generic;
using Xunit;
using Yahtzee;

namespace Tests {
    public class FeuilleDeScoreTests {
        [Fact]
        public void Recuperer_un_score_combinaison_de_1_et_la_stocker () {
            List<int> tirage = new List<int> { 1, 1, 5, 1, 2 };
            var caseVoulue = Combinaison.As;
            FeuilleDeScore feuilleDeScore = new FeuilleDeScore ();
            feuilleDeScore.StockerScore (tirage, caseVoulue);
            Assert.Equal (3, feuilleDeScore.RecupererScore (caseVoulue));

        }

        [Fact]
        public void Recuperer_un_score_combinaison_de_2_et_la_stocker () {
            List<int> tirage = new List<int> { 1, 2, 5, 2, 2 };
            var caseVoulue = Combinaison.Deux;
            FeuilleDeScore feuilleDeScore = new FeuilleDeScore ();
            feuilleDeScore.StockerScore (tirage, caseVoulue);
            Assert.Equal (6, feuilleDeScore.RecupererScore (caseVoulue));

        }

        [Fact]
        public void Stocker_un_score_dans_une_case_déjà_occupée () {
            List<int> tirage = new List<int> { 1, 2, 5, 2, 2 };
            var caseVoulue = Combinaison.Deux;
            FeuilleDeScore feuilleDeScore = new FeuilleDeScore ();
            feuilleDeScore.StockerScore (tirage, caseVoulue);
            Assert.Throws<CaseDejaRemplieException> (() => feuilleDeScore.StockerScore (tirage, caseVoulue));

        }

        [Fact]
        public void Stocker_2_scores_dans_2_cases_differentes () {
            List<int> tirage1 = new List<int> { 1, 2, 5, 2, 2 };
            List<int> tirage2 = new List<int> { 1, 3, 5, 2, 2 };
            var caseVoulue1 = Combinaison.Deux;
            var caseVoulue2 = Combinaison.Cinq;
            FeuilleDeScore feuilleDeScore = new FeuilleDeScore ();
            feuilleDeScore.StockerScore (tirage1, caseVoulue1);
            feuilleDeScore.StockerScore (tirage2, caseVoulue2);
            Assert.Equal (6, feuilleDeScore.RecupererScore (caseVoulue1));
            Assert.Equal (5, feuilleDeScore.RecupererScore (caseVoulue2));
        }


        [Fact]
        public void Recuper_Un_Score_Case_Vide()
        {
            var caseVoulue = Combinaison.Deux;
            FeuilleDeScore feuilleDeScore = new FeuilleDeScore();
            Assert.Null(feuilleDeScore.RecupererScore(caseVoulue));
        }
        // Stocker un score dans autre combinaison, on recupere
        // Stocker un score dans une case déjà occupée => pas possible
        // eviter score négatif ou supérieur à max
        // Plus de case ?
        // Regles bonus

    }
}