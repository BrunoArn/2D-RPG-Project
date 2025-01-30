using UnityEngine;

public class Bow : MonoBehaviour, IWeapon
{
    public void Attack() {
            Debug.Log("Bow Atacck");
            ActiveWeapon.Instance.ToggleIsAttacking(false);
        }
}
