namespace DesignPatterns.Strategy;

// ── Strategy Interface ────────────────────────────────────────────────────────

public interface ISortStrategy<T> where T : IComparable<T>
{
    void Sort(T[] arr);
    string Name { get; }
}

// ── Concrete Strategies ───────────────────────────────────────────────────────

public class BubbleSort<T> : ISortStrategy<T> where T : IComparable<T>
{
    public string Name => "Bubble Sort";
    public void Sort(T[] arr)
    {
        for (int i = 0; i < arr.Length - 1; i++)
            for (int j = 0; j < arr.Length - 1 - i; j++)
                if (arr[j].CompareTo(arr[j + 1]) > 0)
                    (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
    }
}

public class QuickSort<T> : ISortStrategy<T> where T : IComparable<T>
{
    public string Name => "Quick Sort";
    public void Sort(T[] arr) => Qs(arr, 0, arr.Length - 1);

    private static void Qs(T[] arr, int lo, int hi)
    {
        if (lo >= hi) return;
        int p = Partition(arr, lo, hi);
        Qs(arr, lo, p - 1);
        Qs(arr, p + 1, hi);
    }

    private static int Partition(T[] arr, int lo, int hi)
    {
        var pivot = arr[hi]; int i = lo - 1;
        for (int j = lo; j < hi; j++)
            if (arr[j].CompareTo(pivot) <= 0)
                (arr[++i], arr[j]) = (arr[j], arr[i]);
        (arr[i + 1], arr[hi]) = (arr[hi], arr[i + 1]);
        return i + 1;
    }
}

public class MergeSort<T> : ISortStrategy<T> where T : IComparable<T>
{
    public string Name => "Merge Sort";
    public void Sort(T[] arr) => Ms(arr, 0, arr.Length - 1);

    private static void Ms(T[] arr, int lo, int hi)
    {
        if (lo >= hi) return;
        int mid = (lo + hi) / 2;
        Ms(arr, lo, mid); Ms(arr, mid + 1, hi);
        Merge(arr, lo, mid, hi);
    }

    private static void Merge(T[] arr, int lo, int mid, int hi)
    {
        var left  = arr[lo..(mid + 1)];
        var right = arr[(mid + 1)..(hi + 1)];
        int i = 0, j = 0, k = lo;
        while (i < left.Length && j < right.Length)
            arr[k++] = left[i].CompareTo(right[j]) <= 0 ? left[i++] : right[j++];
        while (i < left.Length)  arr[k++] = left[i++];
        while (j < right.Length) arr[k++] = right[j++];
    }
}

// ── Context ───────────────────────────────────────────────────────────────────

public class Sorter<T> where T : IComparable<T>
{
    private ISortStrategy<T> _strategy;

    public Sorter(ISortStrategy<T> strategy) => _strategy = strategy;

    public void SetStrategy(ISortStrategy<T> strategy) => _strategy = strategy;

    public T[] Sort(T[] input)
    {
        var copy = (T[])input.Clone();
        var sw   = System.Diagnostics.Stopwatch.StartNew();
        _strategy.Sort(copy);
        sw.Stop();
        Console.WriteLine($"  {_strategy.Name,-14}: {sw.Elapsed.TotalMicroseconds,6:F1} µs");
        return copy;
    }
}
