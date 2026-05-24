using DesignPatterns.Observer;
using DesignPatterns.Factory;
using DesignPatterns.Strategy;
using DesignPatterns.Builder;

Console.WriteLine("╔══════════════════════════════════╗");
Console.WriteLine("║     C# Design Patterns Demo      ║");
Console.WriteLine("╚══════════════════════════════════╝\n");

// ─────────────────────────────────────────────────────────────────────────────
Console.WriteLine("── 1. Observer Pattern (Stock Market) ──");
var market = new StockMarket();
market.Subscribe(new LogObserver());
market.Subscribe(new AlertObserver(threshold: 5m));  // alert on 5%+ moves

market.SetPrice("AAPL", 180.00m);
market.SetPrice("AAPL", 185.50m);   // +3.1% — log only
market.SetPrice("AAPL", 172.00m);   // -7.3% — log + alert
market.SetPrice("MSFT", 320.00m);
market.SetPrice("MSFT", 348.00m);   // +8.8% — log + alert

// ─────────────────────────────────────────────────────────────────────────────
Console.WriteLine("\n── 2. Factory Pattern (Shapes) ──");
var shapes = new[]
{
    ShapeFactory.Create("circle",    5),
    ShapeFactory.Create("rectangle", 4, 6),
    ShapeFactory.Create("triangle",  3, 4, 5),
};
foreach (var shape in shapes) Console.WriteLine("  " + shape);

// ─────────────────────────────────────────────────────────────────────────────
Console.WriteLine("\n── 3. Strategy Pattern (Sorting) ──");
var rng  = new Random(42);
var data = Enumerable.Range(0, 1000).Select(_ => rng.Next(10_000)).ToArray();

var sorter = new Sorter<int>(new BubbleSort<int>());
sorter.Sort(data);

sorter.SetStrategy(new QuickSort<int>());
sorter.Sort(data);

sorter.SetStrategy(new MergeSort<int>());
var sorted = sorter.Sort(data);
Console.WriteLine($"  Verified sorted: {sorted[0]} ≤ {sorted[^1]}");

// ─────────────────────────────────────────────────────────────────────────────
Console.WriteLine("\n── 4. Builder Pattern (Pizza) ──");
var pizza = new PizzaBuilder()
    .WithSize("Large")
    .WithCrust("Thick")
    .WithSauce("BBQ")
    .WithCheese("Cheddar")
    .WithExtraCheese()
    .AddTopping("Chicken")
    .AddTopping("Red Onion")
    .AddTopping("Jalapeños")
    .Build();

Console.WriteLine("  Your pizza:");
Console.WriteLine(pizza);
