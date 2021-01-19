using DesertStormZombies.Entity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DesertStormZombies.Game
{
    [RequireComponent(typeof(Slider))]
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Health health;

        private Slider slider;

        private void Start()
        {
            slider = GetComponent<Slider>();
        }

        private void Update()
        {
            slider.value = (float) health.CurrentHealth / health.MaxHealth;
        }
    }
}


