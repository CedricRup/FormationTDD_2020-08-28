using System;

namespace Yahtzee
{
    public interface IAfficheur
    {
        void AfficherMessage(string message);
    }

    public class AfficheurConsole : IAfficheur
    {
        public void AfficherMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}