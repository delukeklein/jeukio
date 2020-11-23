using UnityEngine;

public class PointsHolder : MonoBehaviour
{
    private int points;

    public void Add(uint amount) => points += amount;

    public bool Reduce(uint amount)
    {
        int points = this.points - amount;

        if(points >= 0)
        {
            this.points = points;

            return true;
        }

        return false;
    }
}
