using DataStructures;

namespace DataStructures.Tests;

public class QueueTests
{
    [Fact]
    public void NewQueue_IsEmpty()
    {
        var queue = new Queue<int>();

        Assert.True(queue.IsEmpty);
        Assert.Equal(0, queue.Count);
    }

    [Fact]
    public void Dequeue_ReturnsItemsInFirstInFirstOutOrder()
    {
        var queue = new Queue<string>();
        queue.Enqueue("a");
        queue.Enqueue("b");
        queue.Enqueue("c");

        Assert.Equal("a", queue.Dequeue());
        Assert.Equal("b", queue.Dequeue());
        Assert.Equal("c", queue.Dequeue());
        Assert.True(queue.IsEmpty);
    }

    [Fact]
    public void Peek_ReturnsFrontWithoutRemovingIt()
    {
        var queue = new Queue<int>();
        queue.Enqueue(7);
        queue.Enqueue(8);

        Assert.Equal(7, queue.Peek());
        Assert.Equal(2, queue.Count);
    }

    [Fact]
    public void Dequeue_OnEmptyQueue_Throws()
    {
        var queue = new Queue<int>();

        Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
    }

    [Fact]
    public void Peek_OnEmptyQueue_Throws()
    {
        var queue = new Queue<int>();

        Assert.Throws<InvalidOperationException>(() => queue.Peek());
    }

    [Fact]
    public void Enqueue_BeyondInitialCapacity_GrowsAndKeepsOrder()
    {
        var queue = new Queue<int>();
        for (int i = 0; i < 50; i++) queue.Enqueue(i);

        Assert.Equal(50, queue.Count);
        for (int i = 0; i < 50; i++) Assert.Equal(i, queue.Dequeue());
    }

    [Fact]
    public void WrapAround_AfterDequeues_PreservesOrder()
    {
        // Exercises the circular buffer: fill, drain part way, refill so the
        // tail wraps past the end of the backing array.
        var queue = new Queue<int>();
        for (int i = 0; i < 4; i++) queue.Enqueue(i);
        queue.Dequeue();
        queue.Dequeue();

        queue.Enqueue(100);
        queue.Enqueue(200);

        Assert.Equal(new[] { 2, 3, 100, 200 }, queue.ToArray());
    }

    [Fact]
    public void Resize_WhileWrapped_KeepsCorrectOrder()
    {
        var queue = new Queue<int>();
        for (int i = 0; i < 4; i++) queue.Enqueue(i);
        queue.Dequeue();
        queue.Dequeue();
        // Buffer is now wrapped; adding more forces a resize of a wrapped buffer.
        for (int i = 10; i < 20; i++) queue.Enqueue(i);

        Assert.Equal(2, queue.Dequeue());
        Assert.Equal(3, queue.Dequeue());
        for (int i = 10; i < 20; i++) Assert.Equal(i, queue.Dequeue());
        Assert.True(queue.IsEmpty);
    }

    [Fact]
    public void Enumeration_YieldsItemsFromFrontToBack()
    {
        var queue = new Queue<int>();
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);

        Assert.Equal(new[] { 1, 2, 3 }, queue.ToArray());
    }

    [Fact]
    public void EmptiedQueue_CanBeReused()
    {
        var queue = new Queue<int>();
        queue.Enqueue(1);
        queue.Dequeue();

        queue.Enqueue(42);

        Assert.Equal(1, queue.Count);
        Assert.Equal(42, queue.Peek());
    }
}
