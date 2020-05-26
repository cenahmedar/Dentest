using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentest.UI.Helpers
{
    public class SimpleModel
    {
        public SimpleModel()
        {
        }

        public SimpleModel(int iD, string nAME)
        {
            ID = iD;
            NAME = nAME;
        }

        public int ID { get; set; }
        public string NAME { get; set; }
    }
}
