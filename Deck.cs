
namespace CheshireDiore.PlayingCards
{

    public class Deck
    {

        public Stack<Card> _cards;

        public Stack<Card> Cards => _cards;

        public int Count => _cards.Count;

        public Deck()
        {
            _cards = new Stack<Card>(); 
        }

        public void AddCard(Card card)
        {
            Console.WriteLine($"DEBUG> Deck.cs: Created card: {card}");
            _cards.Push(card);
            Console.WriteLine($"DEBUG> Deck.cs: Deck now contains {_cards.Count} cards.");
            Console.WriteLine($"DEBUG> Deck.cs: Deck stack now has a capacity of {_cards.Capacity}.");
        }

        public void Shuffle()
        {
        }

        public Deck Deal(int cardCount)
        {
            Deck dealtCards = new();
            for (int i = 0; i < cardCount; i++)
            {
                // _cards.Pop());
                Card card = _cards.Pop();
                Console.WriteLine($"DEBUG> Deck.cs: Dealing {card}...");
                dealtCards.AddCard(card);
            }
            Console.WriteLine($"DEBUG> Deck.cs: Dealt {dealtCards.Count} cards");
            return dealtCards;
        }
    }
}