using UnityEngine;

public class PointsHolder : MonoBehaviour
{
    private int points;

    public void Add(uint amount) => points += (int) amount;

    public bool Reduce(uint amount)
    {
        int points = this.points - (int) amount;

        if(points >= 0)
        {
            this.points = points;

            return true;
        }

        return false;
    }
}
