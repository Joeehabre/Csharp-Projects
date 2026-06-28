namespace DesignPatterns.Factory;

// ── Abstract Product ──────────────────────────────────────────────────────────

public abstract class Shape
{
    public abstract double Area();
    public abstract double Perimeter();
    public override string ToString() =>
        $"{GetType().Name,-12} | Area: {Area(),8:F2} | Perimeter: {Perimeter(),8:F2}";
}

// ── Concrete Products ─────────────────────────────────────────────────────────

public class Circle : Shape
{
    private readonly double _r;
    public Circle(double radius) => _r = radius;
    public override double Area()      => Math.PI * _r * _r;
    public override double Perimeter() => 2 * Math.PI * _r;
}

public class Rectangle : Shape
{
    private readonly double _w, _h;
    public Rectangle(double width, double height) { _w = width; _h = height; }
    public override double Area()      => _w * _h;
    public override double Perimeter() => 2 * (_w + _h);
}

public class Triangle : Shape
{
    private readonly double _a, _b, _c;
    public Triangle(double a, double b, double c) { _a = a; _b = b; _c = c; }
    public override double Area()
    {
        double s = (_a + _b + _c) / 2;
        return Math.Sqrt(s * (s - _a) * (s - _b) * (s - _c));
    }
    public override double Perimeter() => _a + _b + _c;
}

// ── Factory ───────────────────────────────────────────────────────────────────

public static class ShapeFactory
{
    public static Shape Create(string type, params double[] args) => type.ToLower() switch
    {
        "circle"    => new Circle(args[0]),
        "rectangle" => new Rectangle(args[0], args[1]),
        "triangle"  => new Triangle(args[0], args[1], args[2]),
        _           => throw new ArgumentException($"Unknown shape: {type}")
    };
}
