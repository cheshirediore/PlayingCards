
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
            // Console.WriteLine($"DEBUG> Deck.cs: Adding card: {card}");
            _cards.Push(card);
            // Console.WriteLine($"DEBUG> Deck.cs: Deck now contains {_cards.Count} cards.");
            // Console.WriteLine($"DEBUG> Deck.cs: Deck stack now has a capacity of {_cards.Capacity}.");
        }
        public Card DrawCard()
        {
            return _cards.Pop();
        }

        public void Shuffle()
        {
            Random random = new();
            // Fisher–Yates shuffle
            // -- To shuffle an array a of n elements (indices 0..n − 1):
            // for i from n − 1 down to 1 do
            //     j ← random integer such that 0 ≤ j ≤ i
            //     exchange a[j] and a[i]
            // Make a copy of the stack's backing array
            Card[] workingCopy = _cards.ToArray();
            // Start the shuffling
            for (int i = workingCopy.Length - 1; i >= 0; i--)
            {
                // Console.WriteLine($"DEBUG> Deck.cs: i = {i}");
                var value1 = workingCopy[i];
                int randomlySelectedIndex = random.Next(i);
                // Console.WriteLine($"DEBUG> Deck.cs: j = {randomlySelectedIndex}");
                var value2 = workingCopy[randomlySelectedIndex];
                // Console.WriteLine($"DEBUG> Deck.cs: Swapping {value1} and {value2}");
                workingCopy[i] = value2;
                workingCopy[randomlySelectedIndex] = value1;
            }
            _cards.Clear();
            foreach (Card card in workingCopy)
            {
                AddCard(card);
            }

        }

        public Deck Deal(int cardCount)
        {
            Deck dealtCards = new();
            for (int i = 0; i < cardCount; i++)
            {
                // _cards.Pop());
                Card card = DrawCard();
                // Console.WriteLine($"DEBUG> Deck.cs: Dealing {card}...");
                dealtCards.AddCard(card);
            }
            // Console.WriteLine($"DEBUG> Deck.cs: Dealt {dealtCards.Count} cards");
            return dealtCards;
        }
    }
}