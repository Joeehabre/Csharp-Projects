namespace Blackjack.Models;

public class Hand
{
    private readonly List<Card> _cards = new();

    public IReadOnlyList<Card> Cards => _cards;

    public void Add(Card card) => _cards.Add(card);

    public int Value
    {
        get
        {
            int total = _cards.Sum(c => c.Value);
            int aces  = _cards.Count(c => c.IsAce);
            // Reduce aces from 11 → 1 while busting
            while (total > 21 && aces > 0) { total -= 10; aces--; }
            return total;
        }
    }

    public bool IsBust      => Value > 21;
    public bool IsBlackjack => _cards.Count == 2 && Value == 21;

    public override string ToString() =>
        string.Join("  ", _cards) + $"  (total: {Value})";
}
