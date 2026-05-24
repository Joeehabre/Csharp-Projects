namespace DesignPatterns.Builder;

// ── Product ───────────────────────────────────────────────────────────────────

public class Pizza
{
    public string   Size        { get; init; } = "Medium";
    public string   Crust       { get; init; } = "Thin";
    public string   Sauce       { get; init; } = "Tomato";
    public string   Cheese      { get; init; } = "Mozzarella";
    public string[] Toppings    { get; init; } = Array.Empty<string>();
    public bool     ExtraCheese { get; init; }

    public override string ToString()
    {
        var toppings = Toppings.Length > 0 ? string.Join(", ", Toppings) : "none";
        return $"""
          Size:   {Size}
          Crust:  {Crust}
          Sauce:  {Sauce}
          Cheese: {Cheese}{(ExtraCheese ? " (extra)" : "")}
          Tops:   {toppings}
        """;
    }
}

// ── Builder (Fluent Interface) ────────────────────────────────────────────────

public class PizzaBuilder
{
    private string   _size        = "Medium";
    private string   _crust       = "Thin";
    private string   _sauce       = "Tomato";
    private string   _cheese      = "Mozzarella";
    private bool     _extraCheese = false;
    private readonly List<string> _toppings = new();

    public PizzaBuilder WithSize(string size)       { _size   = size;   return this; }
    public PizzaBuilder WithCrust(string crust)     { _crust  = crust;  return this; }
    public PizzaBuilder WithSauce(string sauce)     { _sauce  = sauce;  return this; }
    public PizzaBuilder WithCheese(string cheese)   { _cheese = cheese; return this; }
    public PizzaBuilder WithExtraCheese()           { _extraCheese = true; return this; }
    public PizzaBuilder AddTopping(string topping)  { _toppings.Add(topping); return this; }

    public Pizza Build() => new()
    {
        Size        = _size,
        Crust       = _crust,
        Sauce       = _sauce,
        Cheese      = _cheese,
        ExtraCheese = _extraCheese,
        Toppings    = _toppings.ToArray()
    };
}
