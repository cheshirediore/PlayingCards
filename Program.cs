using CheshireDiore.PlayingCards;

int TestNumber = 1;

// Test the basic methods of the Deck class
if (TestNumber == 0)
{
    // Initialize an empty deck
    Deck deck = new();
    deck.FillDeck();
    // Shuffle the deck
    deck.Shuffle();

    // Deal a hand of 5 cards from the deck
    Deck hand = deck.Deal(5);
    // Read each card from hand
    foreach (Card card in hand.Cards)
    {
        // Console.WriteLine($"DEBUG> Program.cs: {card}");
    }
}

// Test the basic methods of the BlackJack class
if (TestNumber == 1)
{
    BlackJack blackjack = new();

    Deck drawpile = blackjack.DrawPile;
    CardHolder dealer = blackjack.Dealer;
    CardHolder player = blackjack.Player;

    blackjack.NewGame();
    // Console.WriteLine($"DEBUG> Program.cs: Dealer now has {dealer.HeldCards.Count} cards");
    // Console.WriteLine($"DEBUG> Program.cs: Player now has {player.HeldCards.Count} cards");

    bool keepPlaying = true;

    while (keepPlaying)
    {
        keepPlaying = blackjack.NextRound();
    }
}