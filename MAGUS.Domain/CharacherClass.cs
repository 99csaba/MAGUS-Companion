using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAGUS.Domain
{
    public abstract class CharacherClass
    {
        public abstract int RequiredXp(int level);
        public abstract int GetLevelHM();

        public string ClassName {  get; set; }

        protected CharacherClass(string classname)
        {
            ClassName = classname;
        }

        // <Képzettség>list
    }

    public class Warrior : CharacherClass
    {
        public Warrior() : base("Warrior")
        {
                
        }
        public override int GetLevelHM()
        {
            throw new NotImplementedException();
        }

        public override int RequiredXp(int level)
        {
            throw new NotImplementedException();
        }
    }

}
