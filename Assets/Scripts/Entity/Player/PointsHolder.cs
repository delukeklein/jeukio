using UnityEngine;

namespace DesertStormZombies.Entity.Player
{
    public class PointsHolder : MonoBehaviour
    {
        private int points;

        public int Amount => points;

        public static PointsHolder operator +(PointsHolder pointHolder, int a)
        {
            pointHolder.points += a;
            return pointHolder;
        }

        public static PointsHolder operator -(PointsHolder pointHolder, int a)
        {
            pointHolder.points -= a;
            return pointHolder;
        }
    }
}