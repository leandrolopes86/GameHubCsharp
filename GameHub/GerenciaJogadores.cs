using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace GameHub
{
    internal class GerenciaJogadores
    {
        public static void AdicionaJogador(List<Jogadores> jogadores)

        {
            Console.WriteLine("Digite o nome do jogador:");
            string nomeUsuario = Console.ReadLine();

            // Carrega os jogadores a partir do arquivo JSON
            if (File.Exists("jogadores.json"))
            {
                string json = File.ReadAllText("jogadores.json");
                jogadores = JsonSerializer.Deserialize<List<Jogadores>>(json);
            }

            if (jogadores.Any(j => j.Nome == nomeUsuario))
            {
                Console.WriteLine("Usuário já cadastrado. Tente novamente.");
            }
            else
            {
                Console.Write("Crie uma senha: ");
                string senha = ValidaSenha.getPassword();
                jogadores.Add(new Jogadores(nomeUsuario, senha));
                Console.WriteLine();
                Console.WriteLine($"Jogador {nomeUsuario} criado com sucesso !!");
                SalvarJogadores(jogadores);
                SalvarJogadoresPontuacao(nomeUsuario);
            }
        }

        public static void SalvarJogadores(List<Jogadores> jogadores)
        {
            string json = JsonSerializer.Serialize(jogadores);
            File.WriteAllText("jogadores.json", json);
            Console.WriteLine("Jogadores salvos com sucesso!");
        }

        public static void SalvarJogadoresPontuacao(string nomeUsuario)
        {
            string json;
            List<JogadoresPontuacao> jogadoresPontuacao = new List<JogadoresPontuacao>();
            if (File.Exists("jogadoresPontuacao.json"))
            {
                json = File.ReadAllText("jogadoresPontuacao.json");
                jogadoresPontuacao = JsonSerializer.Deserialize<List<JogadoresPontuacao>>(json);
            }

            jogadoresPontuacao.Add(new JogadoresPontuacao(nomeUsuario, 0));
            json = JsonSerializer.Serialize(jogadoresPontuacao);
            File.WriteAllText("jogadoresPontuacao.json", json);
            Console.WriteLine("Jogadores Pontuação salvo com sucesso!");
        }

        public static void ExibirRanking(List<JogadoresPontuacao> jogadoresPontuacao)
        {
            if (File.Exists("jogadoresPontuacao.json"))
            {
                string json = File.ReadAllText("jogadoresPontuacao.json");
                jogadoresPontuacao = JsonSerializer.Deserialize<List<JogadoresPontuacao>>(json);
            }
            var ranking = jogadoresPontuacao.OrderByDescending(j => j.Pontuacao).ToList();
            for (int i = 0; i < ranking.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {ranking[i].Nome} - {ranking[i].Pontuacao}");
            }
        }
    }
}
