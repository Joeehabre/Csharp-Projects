using DataStructures;

namespace DataStructures.Tests;

public class StackTests
{
    [Fact]
    public void NewStack_IsEmpty()
    {
        var stack = new Stack<int>();

        Assert.True(stack.IsEmpty);
        Assert.Equal(0, stack.Count);
    }

    [Fact]
    public void Push_IncreasesCount()
    {
        var stack = new Stack<int>();

        stack.Push(1);
        stack.Push(2);

        Assert.Equal(2, stack.Count);
        Assert.False(stack.IsEmpty);
    }

    [Fact]
    public void Pop_ReturnsItemsInLastInFirstOutOrder()
    {
        var stack = new Stack<string>();
        stack.Push("first");
        stack.Push("second");
        stack.Push("third");

        Assert.Equal("third", stack.Pop());
        Assert.Equal("second", stack.Pop());
        Assert.Equal("first", stack.Pop());
        Assert.True(stack.IsEmpty);
    }

    [Fact]
    public void Peek_ReturnsTopWithoutRemovingIt()
    {
        var stack = new Stack<int>();
        stack.Push(10);
        stack.Push(20);

        Assert.Equal(20, stack.Peek());
        Assert.Equal(2, stack.Count);
    }

    [Fact]
    public void Pop_OnEmptyStack_Throws()
    {
        var stack = new Stack<int>();

        Assert.Throws<InvalidOperationException>(() => stack.Pop());
    }

    [Fact]
    public void Peek_OnEmptyStack_Throws()
    {
        var stack = new Stack<int>();

        Assert.Throws<InvalidOperationException>(() => stack.Peek());
    }

    [Fact]
    public void Push_BeyondInitialCapacity_GrowsAndKeepsOrder()
    {
        // Initial capacity is 4, so this forces at least two resizes.
        var stack = new Stack<int>();
        for (int i = 0; i < 50; i++) stack.Push(i);

        Assert.Equal(50, stack.Count);
        for (int i = 49; i >= 0; i--) Assert.Equal(i, stack.Pop());
    }

    [Fact]
    public void Enumeration_YieldsItemsFromTopToBottom()
    {
        var stack = new Stack<int>();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        Assert.Equal(new[] { 3, 2, 1 }, stack.ToArray());
    }

    [Fact]
    public void PushPopInterleaved_KeepsCorrectState()
    {
        var stack = new Stack<int>();
        stack.Push(1);
        stack.Push(2);
        Assert.Equal(2, stack.Pop());

        stack.Push(3);

        Assert.Equal(3, stack.Pop());
        Assert.Equal(1, stack.Pop());
        Assert.True(stack.IsEmpty);
    }

    [Fact]
    public void EmptiedStack_CanBeReused()
    {
        var stack = new Stack<int>();
        stack.Push(1);
        stack.Pop();

        stack.Push(99);

        Assert.Equal(1, stack.Count);
        Assert.Equal(99, stack.Peek());
    }
}
