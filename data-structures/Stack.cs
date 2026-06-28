namespace DataStructures;

/// <summary>Array-backed generic stack with O(1) push/pop/peek.</summary>
public class Stack<T> : IEnumerable<T>
{
    private T[]  _data;
    private int  _top = -1;

    public Stack(int initialCapacity = 4) => _data = new T[initialCapacity];

    public int  Count    => _top + 1;
    public bool IsEmpty  => _top < 0;

    public void Push(T item)
    {
        if (_top == _data.Length - 1) Resize();
        _data[++_top] = item;
    }

    public T Pop()
    {
        if (IsEmpty) throw new InvalidOperationException("Stack is empty.");
        return _data[_top--];
    }

    public T Peek()
    {
        if (IsEmpty) throw new InvalidOperationException("Stack is empty.");
        return _data[_top];
    }

    private void Resize()
    {
        var bigger = new T[_data.Length * 2];
        Array.Copy(_data, bigger, _data.Length);
        _data = bigger;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = _top; i >= 0; i--)
            yield return _data[i];
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() =>
        GetEnumerator();
}
