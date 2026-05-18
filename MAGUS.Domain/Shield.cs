using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAGUS.Domain
{
    public class Shield 
    {
        public int MGT {  get; private set; }
        public int SFE {  get; private set; }
        public string Material {  get; private set; }

        public Shield(int mgt, int sfe, string material)
        {
            MGT = mgt;
            SFE = sfe;
            Material = material;
        }
    }
}
