using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contrutores
{
    class Carro
    {
        public string Modelo { get; set; } // Property automática. Encapsulamento padrão para um atributo, sem proteção real.

        private string placa; // Atributo privado necessário quando precisamos proteger o atributo.
        public string Placa   // Property explícita, serve de  "porta de acesso" ao atributo privado de mesmo nome (minúsculo)
        {
            get { return placa; }  // Chamado toda vez que queremos usar o valor de "Placa" (Ex: Console.ReadLine(carro.Placa);)
            set {                  // Chamado toda vez que há uma atribuição de valor a "Placa" (Ex: carro.Placa = "AAA-1234"; )
                string novaPlaca = value.ToUpper();
                if (verificarPlaca(novaPlaca))
                    placa = value;
                else
                    throw new Exception("Placa inválida");
            }
        }

        public Carro() { }

        public Carro(string modelo, string placa)
        {
            this.Modelo = modelo;
            this.Placa = placa;
        }

        private bool verificarPlaca(string placa)
        {
            char sep = '-';
            //Toda placa deve ter tamanho 8 e um hífen como separador.
            if (placa.Length != 8 || placa[3] != sep)
                return false;
 
            // Separa as duas partes de uma placa de carro.
            string[] partes = placa.Split(sep);
            string letras = partes[0];
            string nros = partes[1];

            // Testa os tamanhos das duas partes.
            // Desnecessário. Pelas condições testadas acima, já garante os tamanhos.
            if (letras.Length != 3) return false;
            if (nros.Length != 4) return false;

            // Nesse ponto, já sei que tenho parte letras com tamanho 3 
            // e a parte nros com tamanho 4.
 
            // Verifica se a primeira parte é só de letras
            // Exemplo com for clássico
            for (int i = 0; i < letras.Length; i++)
            {
                char l = letras[i];
                if (!Char.IsLetter(l)) return false;
            }

            // Verifica se a segunda parte é só de números
            // Exemplo com foreach análogo
            foreach(char d in nros)
            {
                if (!Char.IsDigit(d)) return false;
            }

            // Se eu passar por todo o método sem retornar false, minha placa é 
            // válida e posso retornar true sem outras verificações.
            return true;
        }

    }
}
