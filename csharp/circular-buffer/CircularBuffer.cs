using System;
using System.Collections.Generic;

public class CircularBuffer<T>
{
    private int capacity;

    private Queue<T> q;

    public CircularBuffer(int capacity)
    {
        this.capacity = capacity;
        q = new Queue<T>(capacity);
    }

    public T Read()
    {
        return q.Dequeue();
    }

    public void Write(T value)
    {
        if (q.Count == capacity)
        {
            throw new InvalidOperationException();
        }

        q.Enqueue(value);
    }

    public void Overwrite(T value)
    {
        if (q.Count == capacity)
        {
            q.Dequeue();
        }

        q.Enqueue(value);
    }

    public void Clear()
    {
        q.Clear();
    }
}