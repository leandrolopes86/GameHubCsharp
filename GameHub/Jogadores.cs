using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHub
{
    internal class Jogadores
    {
        public string Nome { get; set; }
        public string Senha { get; set; }

        public Jogadores(string nome, string senha)
        {
            Nome = nome;
            Senha = senha;            
        }

        public override string ToString()
        {
            return $"Nome {Nome}\nSenha: {Senha}";
        }    
    }
}
