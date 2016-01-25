using Board.Interfaces;
using Microsoft.ServiceFabric.Actors;
using System;
using System.Threading;

namespace OrderClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var actorId = ActorId.NewId();
            string applicationName = "fabric:/DDDSF";

            var board = ActorProxy.Create<IBoard>(actorId, applicationName);

            Console.WriteLine("actor reference" + board.GetActorReference().ActorId);

            board.SetBoardTitle("Jon's Board");
            board.AddCard("Put out the bin");

            Thread.Sleep(500);

            var cards = board.ListCards().Result;
            var title = board.GetSettings().Result.Title;

            foreach (var card in cards)
            {
                Thread.Sleep(500);
                var description = card.GetDescription().Result;
                Console.WriteLine(description);
            }

            Console.WriteLine(title);
            Console.ReadLine();
        }
    }
}
