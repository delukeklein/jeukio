﻿using UnityEngine;

namespace DesertStormZombies.Items
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Desert Storm Zombies/Weapon")]
    public class WeaponData : ScriptableObject
    {
        public int Damage;
        public int MagSize;

        public float ShootDistance;
        public float FireRate;
        public float ReloadSpeed;

        public bool Semi;

        public bool UseMuzzleFlash;

        public bool Knife;

        public AudioClip ShootAudio;
        public AudioClip ReloadAudio;

        public GameObject Model;
    }
}
