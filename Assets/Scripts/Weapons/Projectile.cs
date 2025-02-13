using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 22f;
    [SerializeField] private GameObject particleOnHitPrefabVFX;
    [SerializeField] private bool isEnemyProjectile = false;
    [SerializeField] private float projectileRange = 10f;
    
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
        PlayerHealth player = other.gameObject.GetComponent<PlayerHealth>();

        if (!other.isTrigger && (enemyHealth || indestructable || player)) {
            if (player && isEnemyProjectile) {
                player.TakeDamage(1, transform);
            }

            Instantiate(particleOnHitPrefabVFX, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    public void UpdateProjectileRange(float projectileRange) {
        this.projectileRange = projectileRange;
    }

    private void DetecFireDistance() {
        if (Vector3.Distance(transform.position , startPosition) > projectileRange) {
            Destroy(gameObject);
        }
    }

    private void MoveProjectile() {
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
    }
}
