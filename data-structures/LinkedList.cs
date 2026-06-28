namespace DataStructures;

/// <summary>Doubly-linked generic list with O(1) head/tail insert.</summary>
public class LinkedList<T> : IEnumerable<T>
{
    private sealed class Node
    {
        public T     Value;
        public Node? Prev, Next;
        public Node(T value) => Value = value;
    }

    private Node? _head, _tail;

    public int Count { get; private set; }

    public void AddFirst(T value)
    {
        var node = new Node(value) { Next = _head };
        if (_head is not null) _head.Prev = node;
        _head = node;
        _tail ??= node;
        Count++;
    }

    public void AddLast(T value)
    {
        var node = new Node(value) { Prev = _tail };
        if (_tail is not null) _tail.Next = node;
        _tail = node;
        _head ??= node;
        Count++;
    }

    public T RemoveFirst()
    {
        if (_head is null) throw new InvalidOperationException("List is empty.");
        var value = _head.Value;
        _head = _head.Next;
        if (_head is not null) _head.Prev = null;
        else _tail = null;
        Count--;
        return value;
    }

    public T RemoveLast()
    {
        if (_tail is null) throw new InvalidOperationException("List is empty.");
        var value = _tail.Value;
        _tail = _tail.Prev;
        if (_tail is not null) _tail.Next = null;
        else _head = null;
        Count--;
        return value;
    }

    public bool Contains(T value)
    {
        var cur = _head;
        while (cur is not null)
        {
            if (EqualityComparer<T>.Default.Equals(cur.Value, value)) return true;
            cur = cur.Next;
        }
        return false;
    }

    public IEnumerator<T> GetEnumerator()
    {
        var cur = _head;
        while (cur is not null) { yield return cur.Value; cur = cur.Next; }
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() =>
        GetEnumerator();
}
