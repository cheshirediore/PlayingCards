
namespace CheshireDiore.PlayingCards
{

    public class PlayingCardDeck: Deck
    {

        public PlayingCardDeck()
        {
            _cards = new Stack<Card>(); 
        }

        public new PlayingCardDeck Deal(int cardCount)
        {
            return (PlayingCardDeck)base.Deal(cardCount);
        }

        public void FillDeck()
        {
            // Add the 52 standard playing cards
            for (int suit = 0; suit < 4; suit++)
            {
                for (int rank = 2; rank < 15; rank++)
                {
                    Card card = new(rank, suit);
                    AddCard(card);
                }
            }
        }
    }
}