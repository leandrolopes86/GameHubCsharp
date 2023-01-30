using System;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace GameHub
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcao;
            List<Jogadores> jogadores = new List<Jogadores>();
            if (File.Exists("jogadores.json"))
            {
                string json = File.ReadAllText("jogadores.json");
                jogadores = JsonSerializer.Deserialize<List<Jogadores>>(json);

                List<JogadoresPontuacao> jogadoresPontuacao = new List<JogadoresPontuacao>();
                if (File.Exists("jogadoresPontuacao.json"))
                {
                    json = File.ReadAllText("jogadoresPontuacao.json");
                    jogadoresPontuacao = JsonSerializer.Deserialize<List<JogadoresPontuacao>>(json);
                }
                do
                {
                    Menu.ShowMenu();

                    while (!int.TryParse(Console.ReadLine(), out opcao))
                    {
                        Console.WriteLine("Entrada inválida.");
                        Console.Write("[X] - Digite a opção desejada: ");
                    }

                    //opcao = int.Parse(Console.ReadLine());

                    switch (opcao)
                    {
                        case 1:
                            Console.WriteLine(" CADASTRO ");
                            GerenciaJogadores.AdicionaJogador(jogadores);
                            break;

                        case 2:
                            Console.Clear();
                            Console.WriteLine("RANKING ");
                            //GerenciaJogadores.BuscaJogadores(jogadores);
                            GerenciaJogadores.ExibirRanking(jogadoresPontuacao);
                            Menu.MenuAnterior();
                            Console.Clear();
                            break;

                        case 3:
                            Console.Clear();
                            new JogoDaVelha().Iniciar();
                            //JogoDaVelha jogo = new JogoDaVelha();
                            //jogo.Iniciar();
                            break;
                    }
                } while (opcao != 0);
                Console.WriteLine("Encerrando o jogo...");
            }
        }
    }
}