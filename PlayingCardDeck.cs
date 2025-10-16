
namespace CheshireDiore.PlayingCards
{

    public class PlayingCardDeck
    {

        public Stack<PlayingCard> _cards;

        public Stack<PlayingCard> Cards => _cards;

        public int Count => _cards.Count;

        public PlayingCardDeck()
        {
            _cards = new Stack<PlayingCard>(); 
        }

        public void AddCard(PlayingCard card)
        {
            _cards.Push(card);
        }
        public PlayingCard DrawCard()
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
            PlayingCard[] workingCopy = _cards.ToArray();
            // Start the shuffling
            for (int i = workingCopy.Length - 1; i >= 0; i--)
            {
                // Get the first value as the value at the current index
                var value1 = workingCopy[i];
                // Get the second value as some index smaller than (or equal to) the current index
                int randomlySelectedIndex = random.Next(i);
                var value2 = workingCopy[randomlySelectedIndex];
                // Swap the values in the two selected indices
                workingCopy[i] = value2;
                workingCopy[randomlySelectedIndex] = value1;
            }
            _cards.Clear();
            foreach (PlayingCard card in workingCopy)
            {
                AddCard(card);
            }

        }

        public PlayingCardDeck Deal(int cardCount)
        {
            PlayingCardDeck dealtCards = new();
            for (int i = 0; i < cardCount; i++)
            {
                PlayingCard card = DrawCard();
                dealtCards.AddCard(card);
            }
            return dealtCards;
        }

        public void FillDeck()
        {
            // Add the 52 standard playing cards
            for (int suit = 0; suit < 4; suit++)
            {
                for (int rank = 2; rank < 15; rank++)
                {
                    PlayingCard card = new(rank, suit);
                    AddCard(card);
                }
            }
        }
    }
}