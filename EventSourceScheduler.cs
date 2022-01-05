using System;
using System.Threading.Tasks;
using System.Threading;

public class EventSourceScheduler
{
    private EventHandler<int> Updated;

    private Task task;

    public EventSourceScheduler()
    {
        task = Task.Run(()=>{Thread.Sleep(100);});
    }

    public void RaiseUpdates()
    {
        task.ContinueWith(async delegate
        {
            Console.Write("1");
            await Task.Run(() => {Thread.Sleep(1000);});
            counter++;
            //Updated?.Invoke(this, counter);
            if (Updated != null)
            {

                Console.Write('~');
                Updated(this, counter);

            }

            Console.WriteLine('!');

            return;
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