using System.Collections.Generic;

namespace Yahtzee
{
    public interface IGenerateurDeDes
    {
        List<int> Generer5Des();
    }

    public class GenerateurDeDes : IGenerateurDeDes
    {
        public GenerateurDeDes()
        {
        }

        public List<int> Generer5Des()
        {
            return new List<int>{1,2,3,4,5};
        }
    }
}