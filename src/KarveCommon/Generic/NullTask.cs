using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveCommon.Generic
{
    public class NullTask : Task
    {
        public delegate void NullAction();
        public NullTask(Action action) : base(action)
        {
        
        }
    }
}
