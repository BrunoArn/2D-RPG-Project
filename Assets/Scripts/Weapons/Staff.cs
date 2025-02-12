using UnityEngine;

public class Staff : MonoBehaviour, IWeapon
{
    [SerializeField] private WeaponInfo weaponInfo;
    [SerializeField] private GameObject magicLaser;
    [SerializeField] private Transform magicLaserSpawnPoint;

    private Animator animator;

    readonly int ATTACK_HASH = Animator.StringToHash("Attack");
    
    private void Awake() {
        animator = GetComponent<Animator>();
    }

    private void Update() {
        MouseFollowWithOffSet();
    }

    public void Attack() {
        animator.SetTrigger(ATTACK_HASH);
    }

    public void SpawnStaffProjectileAnimEvent(){
        GameObject newLaser = Instantiate(magicLaser, magicLaserSpawnPoint.position, Quaternion.identity);
        newLaser.GetComponent<MagicLaser>().UpdateLaserRange(weaponInfo.weaponRange);
    }

    public WeaponInfo GetWeaponInfo() {
        return weaponInfo;
    }

    private void MouseFollowWithOffSet() {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(PlayerController.Instance.transform.position);

        float deltaX = mousePos.x - playerScreenPoint.x;
        float deltaY = mousePos.y - playerScreenPoint.y;

        // Varia bastante comum offset no player tbm
        //float angle = Mathf.Atan2(deltaY, Mathf.Abs(deltaX)) * Mathf.Rad2Deg;

        //varia menos e fica mais lateralizado
        float angle = Mathf.Atan2(mousePos.y, Mathf.Abs(mousePos.x)) * Mathf.Rad2Deg;

        // espada vira pro lado
        if (mousePos.x < playerScreenPoint.x) {
            ActiveWeapon.Instance.transform.rotation = Quaternion.Euler(0, -180, angle);
        } else {
            ActiveWeapon.Instance.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}
