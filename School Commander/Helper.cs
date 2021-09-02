using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Commander
{
    public class Helper
    {
        public static string ConnectionVal(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        public static bool IsEmpty(string checkString)
        {
            if(checkString == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
