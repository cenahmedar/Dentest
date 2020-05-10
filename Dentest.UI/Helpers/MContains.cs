using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentest.UI.Helpers
{
   public class MContains
    {
        public static bool Check(string text, string key)
        {
            if (string.IsNullOrEmpty(key))
                return true;
            if (string.IsNullOrEmpty(text))
                return false;


            if (text.ToUpper().Contains(key.ToUpper()))
                return true;

            return false;
        }


    }
}
