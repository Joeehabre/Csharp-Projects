namespace Blackjack.Models;

public enum Suit { Hearts, Diamonds, Clubs, Spades }

public class Card
{
    public string Rank { get; }
    public Suit   Suit { get; }

    public Card(string rank, Suit suit)
    {
        Rank = rank;
        Suit = suit;
    }

    public int Value => Rank switch
    {
        "J" or "Q" or "K" => 10,
        "A"                => 11,   // Aces handled as 11; hand logic reduces to 1
        _                  => int.Parse(Rank)
    };

    public bool IsAce => Rank == "A";

    private string SuitSymbol => Suit switch
    {
        Suit.Hearts   => "♥",
        Suit.Diamonds => "♦",
        Suit.Clubs    => "♣",
        Suit.Spades   => "♠",
        _             => "?"
    };

    public override string ToString() => $"{Rank}{SuitSymbol}";
}
