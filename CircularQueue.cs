using System;

public class CircularQueue<T>
{
    private T[] _queue;  // Array to hold elements
    private int _head;   // Index of the front element
    private int _tail;   // Index of the last element
    private int _size;   // Current number of elements
    private int _capacity; // Maximum number of elements the queue can hold

    public CircularQueue(int capacity)
    {
        if (capacity <= 0)
            throw new ArgumentException("Capacity must be greater than zero.");

        _capacity = capacity;
        _queue = new T[capacity];
        _head = 0;
        _tail = -1;
        _size = 0;
    }

    // Returns the number of elements in the queue
    public int Count => _size;

    // Checks if the queue is full
    public bool IsFull => _size == _capacity;

    // Checks if the queue is empty
    public bool IsEmpty => _size == 0;

    // Enqueues an element to the queue
    public void Enqueue(T item)
    {
        if (IsFull)
            throw new InvalidOperationException("Queue is full.");

        _tail = (_tail + 1) % _capacity; // Move tail circularly
        _queue[_tail] = item;
        _size++;
    }

    // Dequeues an element from the front of the queue
    public T Dequeue()
    {
        if (IsEmpty)
            throw new InvalidOperationException("Queue is empty.");

        T item = _queue[_head];
        _queue[_head] = default!; // Clear the slot (optional)
        _head = (_head + 1) % _capacity; // Move head circularly
        _size--;
        return item;
    }

    // Returns the element at the front of the queue without removing it
    public T Peek()
    {
        if (IsEmpty)
            throw new InvalidOperationException("Queue is empty.");

        return _queue[_head];
    }

    // Prints the elements in the queue
    public void Print()
    {
        if (IsEmpty)
        {
            Console.WriteLine("Queue is empty.");
            return;
        }

        Console.Write("Queue: ");
        for (int i = 0; i < _size; i++)
        {
            Console.Write(_queue[(_head + i) % _capacity] + " ");
        }
        Console.WriteLine();
    }
}