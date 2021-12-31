using System;

public class EventSource
{
    private EventHandler<int> Updated;

    public void RaiseUpdates()
    {
        counter++;
        //Updated?.Invoke(this, counter);
        if(Updated != null){

            Console.Write('~');
            Updated(this, counter);

        }

        Console.Write('!');

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