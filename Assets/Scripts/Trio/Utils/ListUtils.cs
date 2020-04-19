using System;
using System.Collections.Generic;

namespace Trio.Utils
{
    public static class ListUtils
    {
        private static readonly Random Rnd = new Random();  

        public static void Shuffle<T>(IList<T> list)  
        {  
            var i = list.Count;  
            while (i > 1) {  
                i--;  
                var rndIdx = Rnd.Next(i + 1);  
                var value = list[rndIdx];  
                list[rndIdx] = list[i];  
                list[i] = value;  
            }  
        }
    }
}
