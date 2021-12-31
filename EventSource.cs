using System;

public class EventSource
{
    private EventHandler<int> Updated;
    private readonly object updatedLock = new object();

    public void RaiseUpdates()
    {
        counter++;
        //Updated?.Invoke(this, counter);
        lock(updatedLock) {
            if(Updated != null){

                Console.Write('~');
                Updated(this, counter);

            }
        }
        

        Console.Write('!');

    }

    public void AddEvent(EventHandler<int> myEvent)
    {
        Updated += myEvent;
    }

    public void RemoveEvent(EventHandler<int> myEvent)
    {
        lock(updatedLock) {
            Updated -= myEvent;
        }
    }

    private int counter;

}