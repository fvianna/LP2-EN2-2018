using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SobrecargaMetodos
{
    class Cachorro : Animal
    {
        public override string Barulho()
        {
            return "Au au au!";
        }
    }
}
