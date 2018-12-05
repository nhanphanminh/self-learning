namespace ConsoleApp1.GangsOfFour.Creatations.Singleton
{
    public class Logger
    {
        private static Logger _logger;
        // Lock synchronization object
        private static object syncLock = new object();

        private Logger()
        {
        }

        // why we need double check?
        // 1. If lock in 1st time to check null then it will reduce performance.
        // 2. after check null and lock the resource, we should check null again to make sure only 1 instance is created
        // (because maybe there are many thread came to this step).
        public Logger GetInstance()
        {
            if (_logger == null)
            {
                lock (syncLock)
                {
                    if (_logger == null)
                    {
                        _logger = new Logger();
                    }
                }
            }

            return _logger;
        }
    }
}
