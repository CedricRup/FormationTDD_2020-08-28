using System.Collections.Generic;

namespace Yahtzee
{
    public class TourDeJeu
    {
        private List<int> tirage;
        public void LancerDes()
        {
            tirage = new List<int> { 1,  2,  3,  3,  4  };
        }

        public List<int> RecupererDes()
        {
            return tirage;
        }
    }
}