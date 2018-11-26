using System;
using System.Collections.Generic;

namespace Perfil
{
    public class Carta
    {
        public int Id { get; set; }
        public string Resposta { get; set; }
        public string Categoria { get; set; }
        public List<string> Dicas { get; set; }
        public bool[] Usadas { get; set; }

        public override string ToString()
        {
            Console.Clear(); 
            string txt = String.Empty;

            txt += String.Format("Eu sou um(a) {0}\n\n", Categoria);
            for(int i=0; i < Dicas.Count; i++)
            {
                if (Usadas[i])    
                    txt += String.Format("{0,2}. {1}\n", i + 1, Dicas[i]);
                else
                    txt += String.Format("{0,2}. {1}\n", i + 1, "?");
            }

            return txt;
        }

        public bool ProcessarPalpite(string palpite)
        {
            if (Resposta.ToLower() == palpite.ToLower())
            {
                Console.WriteLine("YOU WIN!!");
                return false;
            }
            else if (DicasEsgotadas())
            {
                Console.WriteLine("YOU LOSE!!");
                Console.WriteLine("A resposta era {0}", Resposta);

                return false;
            }
            return true;
        }

        private bool DicasEsgotadas()
        {
            foreach(bool x in Usadas)
            {
                if (x == false)
                {
                    return false;
                }
            }
            return true;
        }

        public void RegistrarDica(int dicaPedida)
        {
            Usadas[dicaPedida - 1] = true;
            Console.WriteLine(Dicas[dicaPedida - 1]);
        }
    }
}