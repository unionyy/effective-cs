using System;

public class EventSource
{
    private EventHandler<int> Updated;

    public void RaiseUpdates()
    {
        counter++;
        Console.Write('!');
        Updated(this, counter);
    }

    public void AddEvent(EventHandler<int> myEvent)
    {
        Updated += myEvent;
    }

    public void RemoveEvent(EventHandler<int> myEvent)
    {
        Updated -= myEvent;
    }

    private int counter;

}