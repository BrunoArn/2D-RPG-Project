using UnityEngine;

public class Bow : MonoBehaviour, IWeapon
{
    [SerializeField] private WeaponInfo weaponInfo;

    public void Attack() {
            Debug.Log("Bow Atacck");
    }

    public WeaponInfo GetWeaponInfo() {
        return weaponInfo;
    }  
}
