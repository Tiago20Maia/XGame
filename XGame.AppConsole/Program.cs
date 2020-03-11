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
            request.Email = "tiago@gmail.com";
            request.Senha = "123456789";

            var response = service.AutenticarJogador(request);

            Console.WriteLine("Serviço é valido? " + service.IsValid());

            service.Notifications.ToList().ForEach(x =>
            {
                Console.WriteLine(x.Message);
            });

            Console.ReadKey();
        }
    }
}
