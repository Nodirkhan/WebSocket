using System;
using System.Timers;
using SignalRServer.Models;

namespace SignalRServer.Services
{
    internal static class ProcessService
    {
        private static Action _action;
        private static Process Status = Process.Stop;
        private static Timer _timer = null;

        private static void StateChange(object sender, ElapsedEventArgs e)
        {
            var random = new Random().Next(2);
            Status = (Process)random;
            _action();
        }

        public static void StartAsync(int intervalSecond,Action action)
        {
            _timer = new Timer(intervalSecond);
            _timer.Elapsed += StateChange;

            _action = action;
            _timer.Start();
        }

        public static Process GetState() => Status;
    }
}
