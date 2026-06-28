namespace DataStructures;

/// <summary>Circular-buffer generic queue with O(1) enqueue/dequeue.</summary>
public class Queue<T> : IEnumerable<T>
{
    private T[]  _data;
    private int  _head, _tail, _count;

    public Queue(int initialCapacity = 4) => _data = new T[initialCapacity];

    public int  Count   => _count;
    public bool IsEmpty => _count == 0;

    public void Enqueue(T item)
    {
        if (_count == _data.Length) Resize();
        _data[_tail] = item;
        _tail        = (_tail + 1) % _data.Length;
        _count++;
    }

    public T Dequeue()
    {
        if (IsEmpty) throw new InvalidOperationException("Queue is empty.");
        var item = _data[_head];
        _data[_head] = default!;
        _head  = (_head + 1) % _data.Length;
        _count--;
        return item;
    }

    public T Peek()
    {
        if (IsEmpty) throw new InvalidOperationException("Queue is empty.");
        return _data[_head];
    }

    private void Resize()
    {
        var bigger = new T[_data.Length * 2];
        for (int i = 0; i < _count; i++)
            bigger[i] = _data[(_head + i) % _data.Length];
        _data  = bigger;
        _head  = 0;
        _tail  = _count;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < _count; i++)
            yield return _data[(_head + i) % _data.Length];
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() =>
        GetEnumerator();
}
