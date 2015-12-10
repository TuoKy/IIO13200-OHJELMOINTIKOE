using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H3408_T1b
{
    class Logiikka
    {
        private char[] aakkoset = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'x', 'y', 'z', 'ä', 'ö' };
        private int[] esiintymät = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        int sijainti;
        public int[] checkThis(char[] temp)
        {
            foreach (char aa in temp)
            {
                sijainti = -1;
                foreach (char bb in aakkoset)
                {
                    sijainti++;
                    if (aa.Equals(bb))
                    {
                        esiintymät[sijainti] += 1; 
                    }
                }
            }
            return esiintymät;
        }
        

}
}
