namespace CheshireDiore.PlayingCards
{
    public class PlayingCard
    {
        private int _rank; // Aces high
        private int _suit; // 0 = Spades, 1 = Clubs, 2 = Hearts, 3 = Diamonds

        public int Rank => _rank;
        public string RankString => _rankToString[_rank];
        public int Suit => _suit;
        public string SuitString => _suitToString[_suit];

        private static Dictionary<int, string> _suitToString = new Dictionary<int, string>{
            {0, "Spades"},
            {1, "Clubs"},
            {2, "Hearts"},
            {3, "Diamonds"}
        };

        private static Dictionary<int, string> _rankToString = new Dictionary<int, string>{
            {2, "2"},
            {3, "3"},
            {4, "4"},
            {5, "5"},
            {6, "6"},
            {7, "7"},
            {8, "8"},
            {9, "9"},
            {10, "10"},
            {11, "Jack"},
            {12, "Queen"},
            {13, "King"},
            {14, "Ace"}
        };

        public PlayingCard(int rank, int suit)
        {
            _rank = rank;
            _suit = suit;
        }

        public override string ToString()
        {
            return $"{_rankToString[_rank]} of {_suitToString[_suit]}";
        }

    }
}