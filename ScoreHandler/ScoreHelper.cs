using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.ScoreHandler
{
    class ScoreHelper
    {
        public string[] doubleListToStringArray(List<double> list)
        {
            string[] stringArray = new string[list.Count()];
            int i = 0;
            foreach (var item in list)
            {
                stringArray[i] = item.ToString();
                i++;
            }
            return stringArray;
        }

        public List<double> stringArrayToDoubleList(string[] stringArray)
        {
            List<double> floatList = new List<double>();
            foreach (var item in stringArray)
            {
                if (item != "")
                {
                    floatList.Add(double.Parse(item));
                }
            }
            return floatList;
        }
    }
}
