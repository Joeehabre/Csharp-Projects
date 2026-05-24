namespace Blackjack.Models;

public abstract class Player
{
    public string Name    { get; }
    public Hand   Hand    { get; private set; } = new();
    public int    Balance { get; protected set; }

    protected Player(string name, int balance = 0)
    {
        Name    = name;
        Balance = balance;
    }

    public void ResetHand() => Hand = new Hand();

    public abstract bool WantsHit();
}

public class HumanPlayer : Player
{
    public int CurrentBet { get; private set; }

    public HumanPlayer(string name, int startingBalance) : base(name, startingBalance) { }

    public bool PlaceBet(int amount)
    {
        if (amount <= 0 || amount > Balance) return false;
        CurrentBet = amount;
        Balance   -= amount;
        return true;
    }

    public void WinBet(bool blackjack = false)
    {
        // Blackjack pays 3:2
        Balance += blackjack ? (int)(CurrentBet * 2.5) : CurrentBet * 2;
    }

    public void Push() => Balance += CurrentBet;   // Tie — return bet

    public override bool WantsHit()
    {
        Console.Write("  Hit or Stand? (h/s): ");
        return Console.ReadLine()?.Trim().ToLower() == "h";
    }
}

public class Dealer : Player
{
    public Card? HiddenCard { get; private set; }

    public Dealer() : base("Dealer") { }

    public void SetHiddenCard(Card card)
    {
        HiddenCard = card;
        Hand.Add(card);
    }

    public void RevealHand() => HiddenCard = null;

    // Dealer hits on soft 16 or below, stands on hard 17+
    public override bool WantsHit() => Hand.Value < 17;

    public string MaskedString =>
        HiddenCard is not null
            ? $"[??]  {Hand.Cards.Last()}  (showing: {Hand.Cards.Last().Value})"
            : Hand.ToString();
}
