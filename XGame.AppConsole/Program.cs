using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XGame.Arguments.Jogador;
using XGame.Services;

namespace XGame.AppConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando ...");
            var service = new ServiceJogador();
            Console.WriteLine("Criei instancia do serviço");

            AutenticarJogadorRequest request = new AutenticarJogadorRequest();
            Console.WriteLine("Criei a instancia do meu objeto request");
            request.Email = "tiago";

            var response = service.AutenticarJogador(request);
        }
    }
}
