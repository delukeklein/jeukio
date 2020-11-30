using UnityEngine;

public class PointsHolder : MonoBehaviour
{
    private int points;

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
