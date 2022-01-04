using System;

public class EventSource
{
    private EventHandler<int> Updated;
    private readonly object updatedLock = new object();

    public void RaiseUpdates()
    {
        //Updated?.Invoke(this, counter);
        lock (updatedLock)
        {
            counter++;
            if (Updated != null)
            {

                Console.Write('~');
                Updated(this, counter);

            }
            Console.WriteLine('!');
        }

    }

    public void AddEvent(EventHandler<int> myEvent)
    {
        lock (updatedLock)
        {
            Updated += myEvent;
        }
    }

    public void RemoveEvent(EventHandler<int> myEvent)
    {
        lock (updatedLock)
        {
            Updated -= myEvent;
        }
    }

    private int counter;

}
