using System.Threading.Tasks;
using Microsoft.ServiceFabric.Actors;
using System.Collections.Generic;

namespace Board.Interfaces
{
    public interface IBoard : IActor
    {
        Task<BoardState> GetSettings();
        
        Task SetBoardTitle(string title);

        Task AddCard(string description);

        Task<List<ICardActor>> ListCards();
    }
}
