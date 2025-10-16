namespace CheshireDiore.PlayingCards
{
    public class BlackJack : IRuleSet, IManager
    {
        private CardHolder[] _cardholders;
        public CardHolder[] CardHolders => _cardholders;
        private PlayingCardDeck _drawpile;
        public PlayingCardDeck DrawPile => _drawpile;
        public CardHolder Dealer => _cardholders[0];
        public CardHolder Player => _cardholders[1];
        public BlackJack()
        {
            // Initialize the deck that will be dealt from and shuffle it
            // // Console.WriteLine("DEBUG> BlackJack(): Building DrawPile");
            _drawpile = new();
            DrawPile.FillDeck();
            DrawPile.Shuffle();
            // Initialize the card holder array and populate it
            // // Console.WriteLine("DEBUG> BlackJack(): Building _cardholders");
            _cardholders = new CardHolder[2];
            // // Console.WriteLine("DEBUG> BlackJack(): Adding Dealere");
            _cardholders[0] = new CardHolder();
            // // Console.WriteLine("DEBUG> BlackJack(): Adding Player");
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
            
            Console.WriteLine("====================================");
            Console.WriteLine("The dealer is showing:");
            Dealer.PrintHeldCards(1);
            Console.WriteLine("====================================");
            
            // Prompt player to hit or stand
            Console.WriteLine("");
            Console.WriteLine("Hit (h) or Stand (s) (q to quit)?");
            string? playerResponse = Console.ReadLine();
            if (playerResponse is null)
            {
                playerResponse = "q";
            }
            if (playerResponse == "q")
            {
                return false;
            } else if (playerResponse == "h")
            {
                return PlayerTurn();
            } else if (playerResponse == "s") {
                return DealerTurn();
            }
            Console.WriteLine("-----------NewRound----------");
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

        private int TallyCards(CardHolder cardHolder)
        {
            int tally = 0;
            for (int i = 0; i < cardHolder.CardsArray.Length; i++)
            {
                PlayingCard card = cardHolder.CardsArray[i];
                tally += GetCardValue(card.Rank);
            }
            // Console.WriteLine($"Tally is {tally}");
            return tally;
        }

        private bool PlayerTurn()
        {
            // If hit, deal a card
            Player.Draw(DrawPile);
            Console.WriteLine("Your cards are:");
            Player.PrintHeldCards();

            // Tally player's hand and check if they bust
            int playerTotal = TallyCards(Player);
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
            return true;
        }

        private bool DealerTurn()
        {
            // First, flip the dealer's hole card and tally their starting total
            Console.WriteLine("====================================");
            Console.WriteLine("The dealer is showing:");
            Dealer.PrintHeldCards();
            Console.WriteLine("====================================");
            int dealerTotal = TallyCards(Dealer);
            while (dealerTotal < 17)
            {

                // If the player has chosen to stand, deal cards for dealer while the dealer's sum is less than 17
                Dealer.Draw(DrawPile);
                Console.WriteLine("The Dealer Draws a PlayingCard:");
                Dealer.PrintHeldCards();

                // Tally dealer's hand and check if they bust
                Console.WriteLine($"DEBUG> BlackJack(): Tallying Dealer score");
                dealerTotal = TallyCards(Dealer);
                
                if (dealerTotal > 21) // Bust
                {
                    Console.WriteLine("** DEALER BUSTS **");
                    Console.WriteLine("You Win!");
                    return false;
                }
                Console.WriteLine("=== Press Enter to Continue ==");
                string? playerResponse = Console.ReadLine();
                if (playerResponse is null || playerResponse == "q")
                {
                    return false;
                }
            }
            // Now that the player has chosen to Stand, and the dealer has finished drawing, compare the totals
            int playerTotal = TallyCards(Player);
            dealerTotal = TallyCards(Dealer);
            Console.WriteLine($"Player's Total {playerTotal}");
            Console.WriteLine($"Dealer's Total {dealerTotal}");
            if (playerTotal > dealerTotal)
            {
                // Player Wins
                Console.WriteLine("You Win!");
            } else if (playerTotal == dealerTotal)
            {
                // Draw
                Console.WriteLine("It's a Draw!");
            } else {
                // Dealer Wins
                Console.WriteLine("Dealer Wins! Better Luck Next Time!");
            }
            return false;
        }
    }
}