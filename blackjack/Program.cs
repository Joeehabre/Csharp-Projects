using Blackjack.Models;

Console.WriteLine("╔══════════════════════════════╗");
Console.WriteLine("║        C# Blackjack          ║");
Console.WriteLine("╚══════════════════════════════╝");
Console.Write("\nEnter your name: ");
var name = Console.ReadLine() ?? "Player";

var player = new HumanPlayer(name, startingBalance: 500);
var dealer = new Dealer();

while (player.Balance > 0)
{
    Console.WriteLine($"\n── New Round  |  Balance: ${player.Balance} ──");
    var deck = new Deck();

    // ── Betting ──────────────────────────────────────────────────────────────
    int bet;
    while (true)
    {
        Console.Write($"Place your bet (1–{player.Balance}): $");
        if (int.TryParse(Console.ReadLine(), out bet) && player.PlaceBet(bet)) break;
        Console.WriteLine("  Invalid bet.");
    }

    // ── Deal ─────────────────────────────────────────────────────────────────
    player.ResetHand();
    dealer.ResetHand();

    player.Hand.Add(deck.Deal());
    dealer.SetHiddenCard(deck.Deal());
    player.Hand.Add(deck.Deal());
    dealer.Hand.Add(deck.Deal());

    Console.WriteLine($"\n  Dealer: {dealer.MaskedString}");
    Console.WriteLine($"  You:    {player.Hand}");

    // ── Check for immediate blackjack ─────────────────────────────────────────
    if (player.Hand.IsBlackjack)
    {
        dealer.RevealHand();
        Console.WriteLine($"\n  Dealer reveals: {dealer.Hand}");
        if (dealer.Hand.IsBlackjack)
        {
            player.Push();
            Console.WriteLine("  Both Blackjack — Push! Bet returned.");
        }
        else
        {
            player.WinBet(blackjack: true);
            Console.WriteLine($"  Blackjack! You win ${(int)(bet * 1.5)}!");
        }
        if (!PlayAgain()) break;
        continue;
    }

    // ── Player turn ──────────────────────────────────────────────────────────
    while (!player.Hand.IsBust && player.WantsHit())
    {
        player.Hand.Add(deck.Deal());
        Console.WriteLine($"  You:    {player.Hand}");
    }

    if (player.Hand.IsBust)
    {
        Console.WriteLine($"\n  Bust! You lose ${bet}.");
        if (!PlayAgain()) break;
        continue;
    }

    // ── Dealer turn ──────────────────────────────────────────────────────────
    dealer.RevealHand();
    Console.WriteLine($"\n  Dealer reveals: {dealer.Hand}");

    while (dealer.WantsHit())
    {
        dealer.Hand.Add(deck.Deal());
        Console.WriteLine($"  Dealer: {dealer.Hand}");
    }

    // ── Result ───────────────────────────────────────────────────────────────
    int pv = player.Hand.Value, dv = dealer.Hand.Value;

    if (dealer.Hand.IsBust || pv > dv)
    {
        player.WinBet();
        Console.WriteLine($"\n  You win ${bet}!  (You: {pv}  Dealer: {dv})");
    }
    else if (pv == dv)
    {
        player.Push();
        Console.WriteLine($"\n  Push — tie!  (Both: {pv})  Bet returned.");
    }
    else
    {
        Console.WriteLine($"\n  Dealer wins.  (You: {pv}  Dealer: {dv})  You lose ${bet}.");
    }

    if (player.Balance == 0)
    {
        Console.WriteLine("\n  You're out of money. Game over!");
        break;
    }

    if (!PlayAgain()) break;
}

Console.WriteLine($"\nThanks for playing, {name}! Final balance: ${player.Balance}");

static bool PlayAgain()
{
    Console.Write("\nPlay again? (y/n): ");
    return Console.ReadLine()?.Trim().ToLower() == "y";
}
