using Microsoft.ServiceFabric.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board.Interfaces
{
    public interface ICardActor : IActor
    {
        Task SetDescripton(string description);

        Task<string> GetDescription();
    }
}
