using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 22f;
    [SerializeField] private GameObject particleOnHitPrefabVFX;

    private WeaponInfo weaponInfo;
    private Vector3 startPosition;
    
    private void Start() {
        startPosition = transform.position;
    }

    private void Update() {
        MoveProjectile();
        DetecFireDistance();
    }


    private void OnTriggerEnter2D(Collider2D other) {
        EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
        Indestructable indestructable = other.gameObject.GetComponent<Indestructable>();

        if (!other.isTrigger && (enemyHealth || indestructable)) {
            Instantiate(particleOnHitPrefabVFX, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    public void UpdateWeaponInfo(WeaponInfo weaponInfo) {
        this.weaponInfo = weaponInfo;
    }

    private void DetecFireDistance() {
        if (Vector3.Distance(transform.position , startPosition) > weaponInfo.weaponRange) {
            Destroy(gameObject);
        }
    }

    private void MoveProjectile() {
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
    }
}
