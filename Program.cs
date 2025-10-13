using CheshireDiore.PlayingCards;

// See https://aka.ms/new-console-template for more information

// Initialize an empty deck
Deck deck = new();
// Add the 52 standard playing cards
for (int suit = 0; suit < 4; suit++)
{
    for (int rank = 2; rank < 15; rank++)
    {
        Card card = new(rank, suit);
        deck.AddCard(card);
    }
}
// Shuffle the deck
// TODO: Implement shuffle
deck.Shuffle();

// Deal a hand of 5 cards from the deck
Deck hand = deck.Deal(5);
// Read each card from hand
foreach (Card card in hand.Cards)
{
    Console.WriteLine($"DEBUG> Program.cs: {card}");
}