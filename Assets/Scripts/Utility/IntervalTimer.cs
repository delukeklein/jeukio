namespace DesertStormZombies.Utility
{
    public class IntervalTimer
    {
        public float Interval { get; set; }

        private float elapsed;

        public IntervalTimer(float interval)
        {
            this.Interval = interval;
        }

        public bool Check(float delteTime)
        {
            elapsed = elapsed < Interval ? elapsed + delteTime : 0;
            return elapsed >= Interval;
        }
    }

    public class IntervalTimerContinues
    {
        public float Interval { get; set; }

        private float elapsed;

        public IntervalTimerContinues(float interval)
        {
            this.Interval = interval;
        }

        public void Add(float delteTime)
        {
            elapsed = elapsed + delteTime;
        }

        public bool Check()
        {
            bool done = elapsed >= Interval;

            if(done)
            {
                elapsed = 0;
            }

            return done;
        }
    }
}