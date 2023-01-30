using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHub
{
    internal class Menu
    {
        public static void MenuAnterior()
        {
            Console.WriteLine();
            Console.Write("Digite qualquer tecla para voltar ao menu anterior... ");
            Console.ReadKey();
        }

        public static void ShowMenu()
        {
            Console.WriteLine("--------------------------");
            Console.WriteLine("GameHub - Menu Inicial");
            Console.WriteLine("--------------------------");
            Console.WriteLine("[1] - Cadastrar um novo Jogador");
            Console.WriteLine("[2] - Ranking");
            Console.WriteLine("[3] - Jogar Jogo da Velha");
            Console.WriteLine("[4] - Jogar Novo Jogo");
            Console.WriteLine("[0] - Sair do menu");
            Console.Write("[X] - Digite a opção desejada: ");
        }
        public static void MenuLogado()
        {
            Console.WriteLine("Opção [6]: ");
            Console.WriteLine("[1] - Depósito");
            Console.WriteLine("[2] - Saque");
            Console.WriteLine("[3] - Transferencia");
            Console.WriteLine("[4] - Para fazer LOGOUT");
            Console.Write("[X] - Digite a opção desejada: ");
        }
    }
}
