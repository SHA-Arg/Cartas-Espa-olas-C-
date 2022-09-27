using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartasEspañolas
{
    public class Carta
    {
        public int numero;
        public Palo palo;

        public Carta(int numero, Palo palo)
        {
            this.numero = numero;
            this.palo = palo;
        }

        public override string ToString()
        {
            return numero + " de " + palo;
        }
    }

}


