using Board.Interfaces;
using Microsoft.ServiceFabric.Actors;
using System;
using System.Threading.Tasks;

namespace Board
{
    internal class Card : StatefulActor<CardState>, ICardActor
    {
        protected override Task OnActivateAsync()
        {
            if(this.State == null)
            {
                this.State = new CardState("");
            }
            return base.OnActivateAsync();
        }

        Task<string> ICardActor.GetDescription()
        {
            return Task.FromResult(this.State.Description);
        }

        Task ICardActor.SetDescripton(string description)
        {
            this.State.Description = description;
            return Task.FromResult(this.State.Description);
        }
    }
}
