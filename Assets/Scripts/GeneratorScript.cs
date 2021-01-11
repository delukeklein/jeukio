using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorScript : MonoBehaviour
{
    [Header("GO")]

    GameObject Generator1;
    GameObject Generator2;

    [Header("Boollean")]

    bool Generator1State = false;
    bool Generator2State = false;

    //[Header("ECT")]



    void Start()
    {
        
    }

    void Update()
    {
        if(Generator1 && Generator1State && Generator2 && Generator2State == true)
        {
            //hier moeten de machines aan en de ui aan en de andere ui uit met (requires power) 
        }
    }
}
