using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAGUS.Domain
{
    public class Shield
    {
        public int Ke { get; private set;  }
        public int Ve { get; private set; }
        public int MGT { get; private set; }
        public int Attacks { get; private set; }
        public Dice AttackDice = new Dice(1, 6); 
        public Shield(int ke, int ve, int mgt, int attacks)
        {
            Ke = ke;
            Ve = ve;
            MGT = mgt;
            Attacks = attacks;
        }
    }
}
