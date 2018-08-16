using System;
using System.Collections.Generic;
using System.Text;

namespace Encapsulamento_Properties
{
    class Pessoa
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }

        // Esta é uma property de na verdade finge ser um atributo "puro", mas é derivada de outras.
        // Properties também podem ser usadas para melhorar as informações disponíveis dos objetos sem gerar 
        // informação repetida.
        public string NomeCompleto 
        {
            get
            {
                return Nome + " " + Sobrenome;
                //Do jeito "chique":
                //return String.Format("{0} {1}", Nome, Sobrenome)
            }
            set
            {
                string[] pedacos = value.Split(' ');
                if (pedacos.Length == 2)
                {
                    Nome = pedacos[0];
                    Sobrenome = pedacos[1];
                }
                else
                    throw new Exception("Nome completo deve estar no formato 'Nome Sobrenome'.");
            }
        }
    }
}
