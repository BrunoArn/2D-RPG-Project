using UnityEngine;

public class Staff : MonoBehaviour, IWeapon
{

    public void Attack() {
        Debug.Log("Staff Atacck");
        ActiveWeapon.Instance.ToggleIsAttacking(false);
    }
}
