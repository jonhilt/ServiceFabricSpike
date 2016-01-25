using System.Collections.Generic;
using System.Threading.Tasks;
using Board.Interfaces;
using Microsoft.ServiceFabric.Actors;

namespace Board
{
    internal class Board : StatefulActor<BoardState>, IBoard
    {
        protected override Task OnActivateAsync()
        {
            if (this.State == null)
            {
                this.State = new BoardState();
            }

            ActorEventSource.Current.ActorMessage(this, "State initialized to {0}", this.State);
            return Task.FromResult(true);
        }
        
        Task<List<ICardActor>> IBoard.ListCards()
        {           
            return Task.FromResult(this.State.Cards);
        }

        Task IBoard.AddCard(string description)
        {
            var card = ActorProxy.Create<ICardActor>(ActorId.NewId());
            card.SetDescripton(description);
            this.State.Cards.Add(card);
            return Task.FromResult(card);
        }

        Task<BoardState> IBoard.GetSettings()
        {
            return Task.FromResult(this.State);
        }


        Task IBoard.SetBoardTitle(string title)
        {
            this.State.Title = title;
            return Task.FromResult(this);
        }
    }
}
