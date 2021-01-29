using UnityEngine;

using TMPro;

namespace DesertStormZombies.Entity.Player
{
    public class PointsHolder : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI pointsText;

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

        private void Update() => pointsText.text = "Points: " + points;
    }
}