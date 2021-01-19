using UnityEngine;

namespace DesertStormZombies.Game
{
    public class GameWaves : MonoBehaviour
    {
        [SerializeField] private GameStatistics playerStatistics;

        [SerializeField] private int minimumKills = 10;

        [SerializeField] private float waveMulitplier = 1.25f;

        private int wave;

        public int Wave => wave;

        private void Update()
        {
            if (playerStatistics.Kills > minimumKills + wave * waveMulitplier)
            {
                NextWave();
            }
        }

        private void NextWave()
        {
            wave++;
        }
    }
}