using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue items with different priorities, then dequeue
    // Expected Result: "A" (Priority 3), "C" (Priority 2), "B" (Priority 1)
    public void TestPriorityQueue_Dequeue_HighestPriority()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 3);
        pq.Enqueue("B", 1);
        pq.Enqueue("C", 2);

        Assert.AreEqual("A", pq.Dequeue()); // Highest priority item
        Assert.AreEqual("C", pq.Dequeue()); // Next highest
        Assert.AreEqual("B", pq.Dequeue()); // Last item
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with the same priority
    // Expected Result: Items are dequeued in FIFO order.
    public void TestPriorityQueue_Dequeue_SamePriority()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 2);
        pq.Enqueue("B", 2);
        pq.Enqueue("C", 2);

        Assert.AreEqual("A", pq.Dequeue()); // FIFO order
        Assert.AreEqual("B", pq.Dequeue());
        Assert.AreEqual("C", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Try to dequeue from an empty queue
    // Expected Result: Throws InvalidOperationException
    public void TestPriorityQueue_Dequeue_EmptyQueue()
    {
        var pq = new PriorityQueue();

        try
        {
            pq.Dequeue();
            Assert.Fail("Expected exception was not thrown.");
        }
        catch (InvalidOperationException ex)
        {
            Assert.AreEqual("The queue is empty.", ex.Message);
        }
    }

    [TestMethod]
    // Scenario: Enqueue items with equal priority and test the order.
    // Expected Result: Items should be dequeued in the order they were enqueued.
    // Defect: if multiple items have the same highest priority, the current code doesn't guarantee they will be dequeued in the order they were added.
    public void TestPriorityQueue_Dequeue_FIFOForEqualPriority()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("X", 5);
        pq.Enqueue("Y", 5);
        pq.Enqueue("Z", 5);

        Assert.AreEqual("X", pq.Dequeue());
        Assert.AreEqual("Y", pq.Dequeue());
        Assert.AreEqual("Z", pq.Dequeue());
    }
}
