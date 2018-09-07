using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heranca
{
    class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Endereco { get; set; }
        public double Salario { get; set; }
        public int NroDependentes { get; set; }

        public int IdSetor { get; set; }

        public override string ToString()
        {
            return String.Format("Nome: {0}\nCPF: {1}\nSalário: {2:0.00}", Nome, Cpf, Salario);
        }

        public Funcionario(string nome, string cpf, double sal)
        {
            Console.WriteLine("Construtor de Funcionario");

            this.Nome = nome;
            this.Cpf = cpf;
            this.Salario = sal;
        }
    }
}
