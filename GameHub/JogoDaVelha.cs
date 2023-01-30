using Newtonsoft.Json;
using GameHub;
using System;
using System.Collections.Generic;
namespace GameHub
{
    class JogoDaVelha
    {
        List<Jogadores> jogadores = new List<Jogadores>();
        private bool fim;
        private char[] posicoes;
        private char vezJogador;
        private int qtdePreenchida;
        public string usuarioVez;
        private Jogadores jogador1;
        private Jogadores jogador2;

        public JogoDaVelha()
        {
            fim = false;
            posicoes = new[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            vezJogador = 'X';
            qtdePreenchida = 0;

        }

        public void Iniciar()
        {
            Console.WriteLine("Jogador 1:");
            jogador1 = LoginUsuarios.Login(jogadores);
            
            Console.WriteLine("Jogador 2:");
            jogador2 = LoginUsuarios.Login(jogadores);
            while (jogador1.Nome == jogador2.Nome)
            {
                Console.WriteLine("Os jogadores não podem ser o mesmo usuário, por favor, escolha outro jogador para jogar contra");
                jogador2 = LoginUsuarios.Login(jogadores);
            }
            Console.WriteLine($"Jogador 1 é {jogador1.Nome}");
            Console.WriteLine($"Jogador 2 é {jogador2.Nome}");
            while (!fim)
            {
                CriarTabela();
                LerEscolhaDoJogador();
                CriarTabela();
                VerificarFimDeJogo();
                MudarVez();
            }
        }
        private void MudarVez()
        {

           // vezJogador = vezJogador == 'X' ? 'O' : 'X';
            if (vezJogador == 'X')
                vezJogador = 'O';
            else
                vezJogador = 'X';

            if (vezJogador == 'X' && !fim)
            {
                usuarioVez = jogador1.Nome;
                Console.WriteLine(usuarioVez);
            }
            else
            {
                usuarioVez = jogador2.Nome;
                Console.WriteLine(usuarioVez);
            }
        }

        private void VerificarFimDeJogo()
        {
            if (qtdePreenchida < 5)
                return;

            if (ExisteVitoriaHorizontal() || ExisteVitoriaVertical() || ExisteVitoriaDiagonal())
            {
                fim = true;
                //Console.WriteLine($"Fim de jogo!!! Vitória de {vezJogador} {usuarioVez}. Pontuacao atual = ");
            /*    if (vezJogador == 'X')
                    jogador1.Pontuacao++;
                else
                    jogador2.Pontuacao++;
                Console.WriteLine($"Fim de jogo!!! Vitória de {vezJogador} {usuarioVez}. Pontuação atual: {jogador1.Nome} - {jogador1.Pontos} x {jogador2.Nome} - {jogador2.Pontos}");
              */  return; 
            }

            if (qtdePreenchida is 9)
            {
                fim = true;
                Console.WriteLine("Fim de jogo!!! EMPATE");
            }
        }

        private bool ExisteVitoriaHorizontal()
        {
            bool vitoriaLinha1 = posicoes[0] == posicoes[1] && posicoes[0] == posicoes[2];
            bool vitoriaLinha2 = posicoes[3] == posicoes[4] && posicoes[3] == posicoes[5];
            bool vitoriaLinha3 = posicoes[6] == posicoes[7] && posicoes[6] == posicoes[8];

            return vitoriaLinha1 || vitoriaLinha2 || vitoriaLinha3;
        }

        private bool ExisteVitoriaVertical()
        {
            bool vitoriaLinha1 = posicoes[0] == posicoes[3] && posicoes[0] == posicoes[6];
            bool vitoriaLinha2 = posicoes[1] == posicoes[4] && posicoes[1] == posicoes[7];
            bool vitoriaLinha3 = posicoes[2] == posicoes[5] && posicoes[2] == posicoes[8];

            return vitoriaLinha1 || vitoriaLinha2 || vitoriaLinha3;
        }

        private bool ExisteVitoriaDiagonal()
        {
            bool vitoriaLinha1 = posicoes[2] == posicoes[4] && posicoes[2] == posicoes[6];
            bool vitoriaLinha2 = posicoes[0] == posicoes[4] && posicoes[0] == posicoes[8];

            return vitoriaLinha1 || vitoriaLinha2;
        }

        private void LerEscolhaDoJogador()
        {
            Console.WriteLine($"Agora é a vez de {usuarioVez} ({vezJogador}) , entre uma posição de 1 a 9 que esteja disponível na tabela");

            bool conversao = int.TryParse(Console.ReadLine(), out int posicaoEscolhida);

            while (!conversao || !ValidarEscolhaUsuario(posicaoEscolhida))
            {
                Console.WriteLine("O campo escolhido é inválido, por favor digite um número entre 1 e 9 que esteja disponível na tabela.");
                conversao = int.TryParse(Console.ReadLine(), out posicaoEscolhida);
            }

            PreencherEscolha(posicaoEscolhida);
        }

        private void PreencherEscolha(int posicaoEscolhida)
        {
            int indice = posicaoEscolhida - 1;

            posicoes[indice] = vezJogador;
            qtdePreenchida++;
        }

        private bool ValidarEscolhaUsuario(int posicaoEscolhida)
        {
            int indice = posicaoEscolhida - 1;

            return posicoes[indice] != 'O' && posicoes[indice] != 'X';
        }

        private void CriarTabela()
        {
            Console.Clear();
            Console.WriteLine(ObterTabela());
        }

        private string ObterTabela()
        {
            return $"__{posicoes[0]}__|__{posicoes[1]}__|__{posicoes[2]}__\n" +
                   $"__{posicoes[3]}__|__{posicoes[4]}__|__{posicoes[5]}__\n" +
                   $"  {posicoes[6]}  |  {posicoes[7]}  |  {posicoes[8]}  \n\n";
        }
    }
}