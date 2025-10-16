namespace CheshireDiore.PlayingCards
{

    public class CardHolder
    // CardHolder can be a player or a dealer. Anyone who has and uses a deck or hand of cards
    {
        private PlayingCardDeck _heldcards;
        public PlayingCardDeck HeldCards {
            get => _heldcards;
            set => _heldcards = value;
        }

        public PlayingCard[] CardsArray => HeldCards.Cards.ToArray();

        public CardHolder()
        {
            _heldcards = new();
        }

        public void PrintHeldCards()
        {
            // Displays the player's hand of cards
            for (int i = 0; i < CardsArray.Length; i++)
            {
                Console.WriteLine($"    {CardsArray[i]}");
            }
        }

        public void PrintHeldCards(int HowMany)
        {
            // Displays the player's hand of cards
            for (int i = 0; i < CardsArray.Length && i < HowMany; i++)
            {
                Console.WriteLine($"    {CardsArray[i]}");
            }
        }

        // TODO: Handle an empty deck
        public void Draw(PlayingCardDeck deck)
        {
            // Draw a card from the given deck and add it to hand
            HeldCards.AddCard(deck.DrawCard());
        }

        public void Discard(int[] cardIndices, PlayingCardDeck discardPile)
        {
            // Discard the specific cards at cardIndices
            Console.WriteLine("CardHolder.Discard(int[], PlayingCardDeck) not implemented.");
        }

        public void Discard(int howMany, PlayingCardDeck discardPile)
        {
            // Discard the top howMany cards
            Console.WriteLine("CardHolder.Discard(int, PlayingCardDeck) not implemented.");
            for (int i = 0; i < howMany; i++)
            {
                discardPile.AddCard(_heldcards.DrawCard());
            }
        }
    }
}