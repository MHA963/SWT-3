using System;
using System.Threading;
using Microwave.Classes.Interfaces;

namespace Microwave.Classes.Boundary
{
    public class Timer : ITimer
    {
        public int TimeRemaining { get; set; }

        public event EventHandler Expired;
        public event EventHandler TimerTick;

        private System.Timers.Timer timer;

        public Timer()
        {
            timer = new System.Timers.Timer();
            // Bind OnTimerEvent with an object of this, and set up the event
            timer.Elapsed += OnTimerEvent;
            timer.Interval = 1000; // 1 second intervals
            timer.AutoReset = true;  // Repeatable timer
        }


        public void Start(int time)
        {
            TimeRemaining = time;
            timer.Enabled = true;
        }

        public void Stop()
        {
            timer.Enabled = false;
        }

        private void Expire() // the beep will cause exception if tested in pipeline/non windows system.
        {
            timer.Enabled = false;
            Expired?.Invoke(this,System.EventArgs.Empty);
            Console.Beep(2500, 750);
            Thread.Sleep(1000);
            Console.Beep(2500, 750);
            Thread.Sleep(1000);
            Console.Beep(2500, 750);

        }

        private void OnTimerEvent(object sender, System.Timers.ElapsedEventArgs args)
        {
            // One tick has passed
            // Do what I should
            TimeRemaining -= 1;
            TimerTick?.Invoke(this, EventArgs.Empty);

            if (TimeRemaining <= 0)
            {
                Expire();
            }
        }

    }
}
