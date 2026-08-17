using DataStructures;

namespace DataStructures.Tests;

public class BinarySearchTreeTests
{
    /// <summary>Builds the tree used across several tests:
    ///        5
    ///      /   \
    ///     3     7
    ///    / \   / \
    ///   1   4 6   9
    /// </summary>
    private static BinarySearchTree<int> BuildSampleTree()
    {
        var tree = new BinarySearchTree<int>();
        foreach (var n in new[] { 5, 3, 7, 1, 4, 6, 9 }) tree.Insert(n);
        return tree;
    }

    [Fact]
    public void NewTree_IsEmpty()
    {
        var tree = new BinarySearchTree<int>();

        Assert.Equal(0, tree.Count);
        Assert.Equal(0, tree.Height());
        Assert.Empty(tree.InOrder());
    }

    [Fact]
    public void InOrder_ReturnsValuesSorted()
    {
        var tree = BuildSampleTree();

        Assert.Equal(new[] { 1, 3, 4, 5, 6, 7, 9 }, tree.InOrder());
    }

    [Fact]
    public void PreOrder_VisitsRootBeforeChildren()
    {
        var tree = BuildSampleTree();

        Assert.Equal(new[] { 5, 3, 1, 4, 7, 6, 9 }, tree.PreOrder());
    }

    [Fact]
    public void PostOrder_VisitsChildrenBeforeRoot()
    {
        var tree = BuildSampleTree();

        Assert.Equal(new[] { 1, 4, 3, 6, 9, 7, 5 }, tree.PostOrder());
    }

    [Fact]
    public void Contains_FindsEveryInsertedValue()
    {
        var tree = BuildSampleTree();

        foreach (var n in new[] { 5, 3, 7, 1, 4, 6, 9 })
            Assert.True(tree.Contains(n));
    }

    [Fact]
    public void Contains_RejectsMissingValues()
    {
        var tree = BuildSampleTree();

        Assert.False(tree.Contains(8));
        Assert.False(tree.Contains(0));
    }

    [Fact]
    public void Height_OfBalancedTree_IsLogarithmic()
    {
        var tree = BuildSampleTree();

        Assert.Equal(3, tree.Height());
    }

    [Fact]
    public void Height_OfDegenerateTree_EqualsNodeCount()
    {
        // Inserting sorted input produces a right-leaning chain.
        var tree = new BinarySearchTree<int>();
        foreach (var n in new[] { 1, 2, 3, 4 }) tree.Insert(n);

        Assert.Equal(4, tree.Height());
    }

    [Fact]
    public void SingleNode_HasHeightOne()
    {
        var tree = new BinarySearchTree<int>();
        tree.Insert(42);

        Assert.Equal(1, tree.Height());
        Assert.Equal(new[] { 42 }, tree.InOrder());
    }

    [Fact]
    public void Traversals_WorkForStringKeys()
    {
        var tree = new BinarySearchTree<string>();
        foreach (var s in new[] { "banana", "apple", "cherry" }) tree.Insert(s);

        Assert.Equal(new[] { "apple", "banana", "cherry" }, tree.InOrder());
        Assert.True(tree.Contains("apple"));
        Assert.False(tree.Contains("durian"));
    }

    [Fact]
    public void InOrder_HandlesNegativeValues()
    {
        var tree = new BinarySearchTree<int>();
        foreach (var n in new[] { 0, -5, 5, -10 }) tree.Insert(n);

        Assert.Equal(new[] { -10, -5, 0, 5 }, tree.InOrder());
    }

    [Fact]
    public void DuplicateInsert_DoesNotAppearTwiceInTraversal()
    {
        var tree = new BinarySearchTree<int>();
        tree.Insert(1);
        tree.Insert(1);

        // The tree ignores duplicate keys, so the traversal holds a single node.
        Assert.Equal(new[] { 1 }, tree.InOrder());
    }

    [Fact]
    public void DuplicateInsert_DoesNotInflateCount()
    {
        var tree = new BinarySearchTree<int>();
        tree.Insert(1);
        tree.Insert(1);
        tree.Insert(1);

        // Count must reflect the nodes actually stored, not the number of calls.
        Assert.Equal(1, tree.Count);
    }

    [Fact]
    public void Count_MatchesNumberOfNodesInTraversal()
    {
        var tree = new BinarySearchTree<int>();
        foreach (var n in new[] { 5, 3, 5, 7, 3, 9 }) tree.Insert(n);

        Assert.Equal(tree.InOrder().Count(), tree.Count);
    }
}
