namespace CheshireDiore.PlayingCards
{
    public interface IManager
    {
        // Trigger initial setup
        void NewGame();
        // Trigger all behaviors that happeen per round.
        // Returned bool indicates if game should terminate.
        bool NextRound();
    }
}