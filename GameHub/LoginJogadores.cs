using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GameHub
{
    internal class LoginUsuarios
    {

        public static Jogadores Login(List<Jogadores> jogadores)
        {

            string json = File.ReadAllText("jogadores.json");
            jogadores = JsonConvert.DeserializeObject<List<Jogadores>>(json);

            Jogadores j;
            int tentativas = 0;
            do
            {
                if (tentativas == 3)
                {
                    Console.WriteLine("Você excedeu o número máximo de tentativas. Por favor, tente novamente mais tarde.");
                    return null;
                }
                Console.Write("Digite o usuario para fazer login: ");
                string NomeLogin = Console.ReadLine();
                Console.Write("Digite a sua senha: ");
                string senhaLogin = ValidaSenha.getPassword();
                //string senhaLogin = Console.ReadLine();
                Console.WriteLine();
                j = jogadores.Find(x => x.Nome == NomeLogin && x.Senha == senhaLogin);
                if (j == null)
                {
                    Console.WriteLine("Nome ou senha inválidos. Tente novamente.");
                    Console.WriteLine();
                    tentativas++;
                }
            } while (j == null);
            return j;
        }
    }
}
