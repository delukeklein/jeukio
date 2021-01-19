using DesertStormZombies.Entity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DesertStormZombies.Game
{
    [RequireComponent(typeof(Image))]
    public class HealthVignet : MonoBehaviour
    {
        [SerializeField] private Health health;

        private Image image;

        private void Start()
        {
            image = GetComponent<Image>();
        }

        private void Update()
        {
            image.color = new Color(1, 1, 1, 1f - ((float) health.CurrentHealth / health.MaxHealth));
        }
    }
}


