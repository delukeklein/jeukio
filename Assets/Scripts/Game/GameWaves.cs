using UnityEngine;

namespace DesertStormZombies.Game
{
    public class GameWaves : MonoBehaviour
    {
        [SerializeField] private GameStatistics playerStatistics;

        private int wave;

        public int Wave => wave;

        private void Update()
        {
            if (playerStatistics.Kills > 10 + wave * 1.25f)
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