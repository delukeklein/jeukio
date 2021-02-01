﻿using UnityEngine;

using TMPro;
using System.Collections;

namespace DesertStormZombies.Game
{
    public class GameWaves : MonoBehaviour
    {
        [SerializeField] private GameStatistics playerStatistics;

        [SerializeField] private TextMeshProUGUI text;

        [SerializeField] private int minimumKills = 10;

        [SerializeField] private float waveMulitplier = 1.5f;
        [SerializeField] private float textDuration;

        public int AmountOfZombies { get; set; }

        private int wave;

        public int Wave => wave;

        private void Start()
        {
            StartCoroutine(NextWave());
        }

        private void Update()
        {
            if (playerStatistics.Kills > ZombieCap(wave))
            {
                StartCoroutine(NextWave());
            }
        }

        private IEnumerator NextWave()
        {
            wave++;

            text.text = "WAVE " + wave;

            yield return new WaitForSeconds(textDuration);

            text.text = "";
        }

        public int ZombieCap(int wave) => (int) (minimumKills * (wave * waveMulitplier));

        public int RequiredZombies => ZombieCap(wave) - ZombieCap(wave - 1);
    }
}