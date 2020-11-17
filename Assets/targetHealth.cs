using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetHealth : MonoBehaviour
{
    [SerializeField] float health; 

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health >= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
