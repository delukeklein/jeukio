using UnityEngine;

namespace DesertStormZombies.Game
{
    public class GameStatistics : MonoBehaviour
    {
        private int kills;

        public int Kills => kills;

        public void AddKills(int kills) => this.kills += kills;
    }
}