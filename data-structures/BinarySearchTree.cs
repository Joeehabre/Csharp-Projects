namespace DataStructures;

/// <summary>Generic BST with insert, search, and in/pre/post-order traversal.</summary>
public class BinarySearchTree<T> where T : IComparable<T>
{
    private sealed class Node
    {
        public T     Value;
        public Node? Left, Right;
        public Node(T value) => Value = value;
    }

    private Node? _root;
    public int Count { get; private set; }

    public void Insert(T value)
    {
        _root = Insert(_root, value);
        Count++;
    }

    private static Node Insert(Node? node, T value)
    {
        if (node is null) return new Node(value);
        int cmp = value.CompareTo(node.Value);
        if      (cmp < 0) node.Left  = Insert(node.Left,  value);
        else if (cmp > 0) node.Right = Insert(node.Right, value);
        return node;
    }

    public bool Contains(T value) => Contains(_root, value);

    private static bool Contains(Node? node, T value)
    {
        if (node is null) return false;
        int cmp = value.CompareTo(node.Value);
        return cmp == 0 || Contains(cmp < 0 ? node.Left : node.Right, value);
    }

    // ── Traversals ───────────────────────────────────────────────────────────

    public IEnumerable<T> InOrder()
    {
        var stack = new System.Collections.Generic.Stack<Node>();
        var cur   = _root;
        while (cur is not null || stack.Count > 0)
        {
            while (cur is not null) { stack.Push(cur); cur = cur.Left; }
            cur = stack.Pop();
            yield return cur.Value;
            cur = cur.Right;
        }
    }

    public IEnumerable<T> PreOrder()  => PreOrder(_root);
    public IEnumerable<T> PostOrder() => PostOrder(_root);

    private static IEnumerable<T> PreOrder(Node? node)
    {
        if (node is null) yield break;
        yield return node.Value;
        foreach (var v in PreOrder(node.Left))  yield return v;
        foreach (var v in PreOrder(node.Right)) yield return v;
    }

    private static IEnumerable<T> PostOrder(Node? node)
    {
        if (node is null) yield break;
        foreach (var v in PostOrder(node.Left))  yield return v;
        foreach (var v in PostOrder(node.Right)) yield return v;
        yield return node.Value;
    }

    public int Height() => Height(_root);
    private static int Height(Node? node) =>
        node is null ? 0 : 1 + Math.Max(Height(node.Left), Height(node.Right));
}
