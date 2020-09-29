using System;

namespace Yahtzee
{
    class Program
    {
        static void Main(string[] args)
        {
            Jeu jeu = new Jeu(new AfficheurConsole(),null);
            jeu.Commencer();
        }
    }
}
