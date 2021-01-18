using DesertStormZombies.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField] Transform shootingPoint;

    private IntervalTimer intervalTimer;

    protected void Start()
    {
        intervalTimer = new IntervalTimer(0);
    }

    public void Reload()
    {

    }
}
