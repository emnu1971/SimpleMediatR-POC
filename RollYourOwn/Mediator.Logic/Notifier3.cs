using System.Diagnostics;

namespace Mediator.Logic
{
    public class Notifier3 : INotifier
    {
        public void Notify()
        {
            Debug.WriteLine("Debugging from Notifier 3");
        }

        public bool CanRun()
        {
            //Check something. And return True if it can run. 
            return true;
        }

    }
}
