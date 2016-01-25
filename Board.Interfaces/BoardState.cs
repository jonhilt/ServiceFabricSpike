using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Board.Interfaces
{
    [DataContract]
    public class BoardState
    {       
        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public List<ICardActor> Cards = new List<ICardActor>();
    }

    [DataContract]
    public class CardState
    {
        [DataMember]
        public string Description { get; set; }

        public CardState(string description)
        {
            Description = description;
        }
    }

}