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
}