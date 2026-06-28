namespace DesignPatterns.Observer;

// ── Interfaces ────────────────────────────────────────────────────────────────

public interface IStockObserver
{
    void OnPriceChanged(string ticker, decimal oldPrice, decimal newPrice);
}

public interface IStockSubject
{
    void Subscribe(IStockObserver observer);
    void Unsubscribe(IStockObserver observer);
    void Notify(string ticker, decimal oldPrice, decimal newPrice);
}

// ── Subject ───────────────────────────────────────────────────────────────────

public class StockMarket : IStockSubject
{
    private readonly List<IStockObserver>      _observers = new();
    private readonly Dictionary<string,decimal> _prices   = new();

    public void Subscribe(IStockObserver o)   => _observers.Add(o);
    public void Unsubscribe(IStockObserver o) => _observers.Remove(o);

    public void Notify(string ticker, decimal oldPrice, decimal newPrice)
    {
        foreach (var o in _observers)
            o.OnPriceChanged(ticker, oldPrice, newPrice);
    }

    public void SetPrice(string ticker, decimal price)
    {
        var old = _prices.GetValueOrDefault(ticker, price);
        _prices[ticker] = price;
        if (old != price) Notify(ticker, old, price);
    }
}

// ── Concrete Observers ────────────────────────────────────────────────────────

public class AlertObserver : IStockObserver
{
    private readonly decimal _threshold;
    public AlertObserver(decimal threshold) => _threshold = threshold;

    public void OnPriceChanged(string ticker, decimal oldPrice, decimal newPrice)
    {
        var change = Math.Abs((newPrice - oldPrice) / oldPrice * 100);
        if (change >= _threshold)
            Console.WriteLine($"  🚨 ALERT  {ticker}: ${oldPrice:F2} → ${newPrice:F2}  ({change:F1}% change)");
    }
}

public class LogObserver : IStockObserver
{
    public void OnPriceChanged(string ticker, decimal oldPrice, decimal newPrice)
    {
        var arrow = newPrice > oldPrice ? "▲" : "▼";
        Console.WriteLine($"  📋 LOG    {ticker}: ${oldPrice:F2} {arrow} ${newPrice:F2}");
    }
}
