using Moq;
using Xunit;
using Yahtzee;

namespace Tests
{
    public class JeuTests
    {
        Mock<IAfficheur> afficheur;
        Mock<IEntree> entree;
        private Jeu jeu;

        public JeuTests()
        {
            this.afficheur = new Mock<IAfficheur>();
            this.entree = new Mock<IEntree>();
            jeu = new Jeu(afficheur.Object, entree.Object);
        }

        // Affiche "appuyer sur "entree" pour lancer les dés
        // Quand j'appuie sur espace => lance les des, affiche le tirage
        // Relancer ou Inscrire à As
        // Inscrire à l'as => inscrit, recommence
        [Fact]
        public void lancer_le_jeu_et_affichage_message_accueil()
        {
            jeu.Commencer();
            afficheur.Verify(a => a.AfficherMessage("appuyez sur entrée pour lancer les dés"));
        }

        [Fact]
        public void lancer_les_des_quand_appuyer_sur_entree()
        {
            //TODO: Ecrire ce test
        }
    }
}