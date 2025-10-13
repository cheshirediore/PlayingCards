using CheshireDiore.PlayingCards;

// See https://aka.ms/new-console-template for more information

Deck deck = new();
for (int suit = 0; suit < 4; suit++)
{
    for (int rank = 2; rank < 15; rank++)
    {
        Card card = new(rank, suit);
        deck.AddCard(card);
    }
}
Deck hand = deck.Deal(5);
foreach (Card card in hand.Cards)
{
    Console.WriteLine($"DEBUG> Program.cs: {card}");
}