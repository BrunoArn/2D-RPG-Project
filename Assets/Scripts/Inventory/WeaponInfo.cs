using UnityEngine;

[CreateAssetMenu(menuName = "new Weapon")]
public class WeaponInfo : ScriptableObject
{
    public GameObject weaponPrefab;
    public float weaponCooldown;
}
