using UnityEngine;

[CreateAssetMenu(menuName = "Weapon Data", fileName = "Weapon Data")]
public class WeaponData : ScriptableObject
{
    public Mesh mesh;

    public uint Damage;

    public uint Recoil;

    public uint FireRate;
}
