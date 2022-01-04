using System;
using System.Threading.Tasks;

public class EventSourceScheduler
{
    private EventHandler<int> Updated;

    private Task task;

    public EventSourceScheduler()
    {
        task = Task.Run(()=>{});
    }

    public void RaiseUpdates()
    {
        task.ContinueWith(delegate
        {
            counter++;
            //Updated?.Invoke(this, counter);
            if (Updated != null)
            {

                Console.Write('~');
                Updated(this, counter);

            }

            Console.WriteLine('!');
        });
    }

    public void AddEvent(EventHandler<int> myEvent)
    {
        task.ContinueWith(delegate
        {
            Updated += myEvent;
        });
    }

    public void RemoveEvent(EventHandler<int> myEvent)
    {
        task.ContinueWith(delegate
        {
            Updated -= myEvent;
        });
    }

    private int counter;

}