using General.ActionSystemComponents;
using Models;

namespace GameActions
{
    public class PlayCardGA : GameAction
    {
        public Card Card { get; set; }

        public PlayCardGA(Card card)
        {
            Card = card;
        }
    }
}