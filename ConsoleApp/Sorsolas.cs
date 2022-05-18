using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp6lotto2
{
    internal class Sorsolas
    {
        //az osztály változói
        public int het;
        public int szam1;
        public int szam2;
        public int szam3 ;
        public int szam4;
        public int szam5;


        //construktor, ami paramétereket vár és ez alapján értéket az a változóknak
        public Sorsolas(int het, int szam1, int szam2, int szam3, int szam4, int szam5)
        {
            this.het = het;
            this.szam1 = szam1;
            this.szam2 = szam2;
            this.szam3 = szam3;
            this.szam4 = szam4;
            this.szam5 = szam5  ;

        }
    }
}
