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

            //AutenticarJogadorRequest autenticarRequest = new AutenticarJogadorRequest();
            //Console.WriteLine("Criei a instancia do meu objeto request");
            //autenticarRequest.Email = "tiago@gmail.com";
            //autenticarRequest.Senha = "123456789";

            //var AdicionarRequest = new AdicionarJogadorRequest()
            //{
            //    Email = "tiagoferreira209@gmail.com",
            //    PrimeiroNome = "Tiago",
            //    UltimoNome = "Brito",
            //    Senha = "123456"
            //};

            //var response = service.AutenticarJogador(autenticarRequest);

            //var response2 = service.AdicionarJogador(AdicionarRequest); 

            var result = service.ListarJogador();

            Console.WriteLine("Serviço é valido? " + service.IsValid());

            service.Notifications.ToList().ForEach(x =>
            {
                Console.WriteLine(x.Message);
            });

            Console.ReadKey();
        }
    }
}
