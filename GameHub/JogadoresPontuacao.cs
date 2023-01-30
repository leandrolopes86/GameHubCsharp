using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHub
{
    internal class JogadoresPontuacao
    {
        public string Nome { get; set; }
        public int Pontuacao { get; set; }

        public JogadoresPontuacao(string nome, int pontuacao)
        {
            Nome = nome;
            Pontuacao = pontuacao;
        }

        public override string ToString()
        {
            return $"Nome {Nome}\nPontos: {Pontuacao}\n";
        }
    }
}
