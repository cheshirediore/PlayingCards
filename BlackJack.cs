namespace CheshireDiore.PlayingCards
{
    public class BlackJack : IRuleSet, IManager
    {
        private CardHolder[] _cardholders;
        public CardHolder[] CardHolders => _cardholders;
        private Deck _drawpile;
        public Deck DrawPile => _drawpile;
        public CardHolder Dealer => _cardholders[0];
        public CardHolder Player => _cardholders[1];
        public BlackJack()
        {
            // Initialize the deck that will be dealt from and shuffle it
            Console.WriteLine("DEBUG> BlackJack(): Building DrawPile");
            _drawpile = new();
            DrawPile.FillDeck();
            DrawPile.Shuffle();
            // Initialize the card holder array and populate it
            Console.WriteLine("DEBUG> BlackJack(): Building _cardholders");
            _cardholders = new CardHolder[2];
            Console.WriteLine("DEBUG> BlackJack(): Adding Dealere");
            _cardholders[0] = new CardHolder();
            Console.WriteLine("DEBUG> BlackJack(): Adding Player");
            _cardholders[1] = new CardHolder();
        }

        #region IRuleSet
        // Display the rules for the player
        public void DisplayRules()
        {
            Console.Write("BlackJack.DisplayRules() not implemented.");
        }
        #endregion
        #region IManager
        public void NewGame()
        {
            DrawPile.Cards.Clear();
            Player.HeldCards.Cards.Clear();
            Dealer.HeldCards.Cards.Clear();
            // Reset the deck
            DrawPile.FillDeck();
            DrawPile.Shuffle();
            // Deal two cards to player
            Player.Draw(DrawPile);
            Player.Draw(DrawPile);
            // Deal two cards to dealer (one face down)
            Dealer.Draw(DrawPile);
            Dealer.Draw(DrawPile);
        }
        // Trigger all behaviors that happeen per round.
        public bool NextRound()
        {
            Console.WriteLine("====================================");
            Console.WriteLine("Your cards are:");
            Player.PrintHeldCards();
            
            Console.WriteLine("====================================");
            Console.WriteLine("The dealer is showing:");
            Dealer.PrintHeldCards(1);
            
            // Prompt player to hit or stand
            Console.WriteLine("Hit (h) or Stand (s) (q to quit)?");
            string playerResponse = Console.ReadLine();
            if (playerResponse == "q")
            {
                return false;
            } else if (playerResponse == "h")
            {
                // If hit, deal a card
                Player.Draw(DrawPile);
                Console.WriteLine("Your cards are:");
                Player.PrintHeldCards();

                // Tally player's hand and check if they bust
                int playerTotal = 0;
                for (int i = 0; i < Player.CardsArray.Length; i++)
                {
                    Card card = Player.CardsArray[i];
                    Console.WriteLine($"DEBUG> BlackJack.NextRound(): Player card {card.Rank} is worth = {GetCardValue(card.Rank)}");
                    playerTotal += GetCardValue(card.Rank);
                }
                Console.WriteLine($"DEBUG> BlackJack.NextRound(): Player total = {playerTotal}");
                if (playerTotal > 21) // Bust
                {
                    Console.WriteLine("** BUST **");
                    Console.WriteLine("Better Luck Next Time!");
                    return false;
                } else if (playerTotal == 21)
                {
                    Console.WriteLine("** You win! **");
                    return false;
                }
            } else {
                // If the player has chosen to stand, deal cards for dealer while the dealer's sum is less than 17
                Console.WriteLine("Dealer Behavior Not Implemented");

            }
            return true;
        }
        #endregion

        private int GetCardValue(int rank)
        {
            switch (rank)
            {
                // Number cards just use their own value
                case <= 10:
                    return rank;
                // Jack through King are worth 10
                case <= 13:
                    return 10;
                // Ace is worth 1 or 11. TODO: handle the 1 case
                case 14:
                    return 11;
                default:
                    return -1;
            }
        }
    }
}