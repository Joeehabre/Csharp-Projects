using DataStructures;

namespace DataStructures.Tests;

public class LinkedListTests
{
    [Fact]
    public void NewList_IsEmpty()
    {
        var list = new LinkedList<int>();

        Assert.Equal(0, list.Count);
        Assert.Empty(list);
    }

    [Fact]
    public void AddLast_AppendsInOrder()
    {
        var list = new LinkedList<int>();
        list.AddLast(1);
        list.AddLast(2);
        list.AddLast(3);

        Assert.Equal(new[] { 1, 2, 3 }, list.ToArray());
        Assert.Equal(3, list.Count);
    }

    [Fact]
    public void AddFirst_PrependsInOrder()
    {
        var list = new LinkedList<int>();
        list.AddFirst(1);
        list.AddFirst(2);
        list.AddFirst(3);

        Assert.Equal(new[] { 3, 2, 1 }, list.ToArray());
    }

    [Fact]
    public void AddFirstAndAddLast_Combine()
    {
        var list = new LinkedList<int>();
        list.AddLast(2);
        list.AddLast(3);
        list.AddFirst(1);

        Assert.Equal(new[] { 1, 2, 3 }, list.ToArray());
    }

    [Fact]
    public void RemoveFirst_ReturnsAndRemovesHead()
    {
        var list = new LinkedList<string>();
        list.AddLast("a");
        list.AddLast("b");

        Assert.Equal("a", list.RemoveFirst());
        Assert.Equal(new[] { "b" }, list.ToArray());
        Assert.Equal(1, list.Count);
    }

    [Fact]
    public void RemoveLast_ReturnsAndRemovesTail()
    {
        var list = new LinkedList<string>();
        list.AddLast("a");
        list.AddLast("b");

        Assert.Equal("b", list.RemoveLast());
        Assert.Equal(new[] { "a" }, list.ToArray());
    }

    [Fact]
    public void RemoveFirst_OnEmptyList_Throws()
    {
        var list = new LinkedList<int>();

        Assert.Throws<InvalidOperationException>(() => list.RemoveFirst());
    }

    [Fact]
    public void RemoveLast_OnEmptyList_Throws()
    {
        var list = new LinkedList<int>();

        Assert.Throws<InvalidOperationException>(() => list.RemoveLast());
    }

    [Fact]
    public void RemovingOnlyElement_LeavesListEmptyAndReusable()
    {
        var list = new LinkedList<int>();
        list.AddLast(1);
        list.RemoveFirst();

        Assert.Equal(0, list.Count);
        Assert.Empty(list);

        list.AddLast(2);
        Assert.Equal(new[] { 2 }, list.ToArray());
    }

    [Fact]
    public void Contains_FindsPresentValueAndRejectsAbsentOne()
    {
        var list = new LinkedList<int>();
        list.AddLast(1);
        list.AddLast(2);

        Assert.True(list.Contains(2));
        Assert.False(list.Contains(99));
    }

    [Fact]
    public void Contains_WorksForReferenceTypes()
    {
        var list = new LinkedList<string>();
        list.AddLast("hello");

        Assert.True(list.Contains("hello"));
        Assert.False(list.Contains("world"));
    }

    [Fact]
    public void RemovingFromBothEnds_LeavesMiddleIntact()
    {
        var list = new LinkedList<int>();
        for (int i = 1; i <= 5; i++) list.AddLast(i);

        list.RemoveFirst();
        list.RemoveLast();

        Assert.Equal(new[] { 2, 3, 4 }, list.ToArray());
        Assert.Equal(3, list.Count);
    }
}
