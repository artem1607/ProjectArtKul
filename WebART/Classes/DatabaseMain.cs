
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebART.Classes
{
    public class DatabaseMain
    {
        public static List<KeyValueBD> dataList;
        public DatabaseMain(IEnumerable<KeyValueBD> keys)
        {
            dataList = keys.ToList();
        }
    }
}