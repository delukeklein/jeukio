namespace DesertStormZombies.Utility
{
    public class IntervalTimer
    {
        private readonly float interval;

        private float elapsed;

        public IntervalTimer(float interval)
        {
            this.interval = interval;
        }

        public bool Check(float delteTime)
        {
            elapsed = elapsed < interval ? elapsed + delteTime : 0;
            return elapsed >= interval;
        }
    }
}