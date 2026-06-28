namespace Blackjack.Models;

public class Deck
{
    private readonly Queue<Card> _cards;

    private static readonly string[] Ranks =
        { "2","3","4","5","6","7","8","9","10","J","Q","K","A" };

    public Deck()
    {
        var all = (from suit in Enum.GetValues<Suit>()
                   from rank in Ranks
                   select new Card(rank, suit)).ToList();

        // Fisher-Yates shuffle
        var rng = new Random();
        for (int i = all.Count - 1; i > 0; i--)
        {
            int j = rng.Next(i + 1);
            (all[i], all[j]) = (all[j], all[i]);
        }

        _cards = new Queue<Card>(all);
    }

    public Card Deal()
    {
        if (_cards.Count == 0) throw new InvalidOperationException("Deck is empty.");
        return _cards.Dequeue();
    }

    public int Remaining => _cards.Count;
}
