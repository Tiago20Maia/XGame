using System;
using System.Linq;
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

            //AutenticarJogadorRequest request = new AutenticarJogadorRequest();
            //Console.WriteLine("Criei a instancia do meu objeto request");
            //request.Email = "tiago@gmail.com";
            //request.Senha = "123456789";

            var request = new AdicionarJogadorRequest()
            {
                Email = "tiagoferreira209@gmail.com",
                PrimeiroNome = "Tiago",
                UltimoNome = "Brito",
                Senha = "123456"
            };

            var response = service.AdicionarJogador(request);

            Console.WriteLine("Serviço é valido? " + service.IsValid());

            service.Notifications.ToList().ForEach(x =>
            {
                Console.WriteLine(x.Message);
            });

            Console.ReadKey();
        }
    }
}
