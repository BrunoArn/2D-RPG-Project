using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour, IEnemy
{
    [SerializeField] private GameObject bulletPRefab;
    [SerializeField] private float bulletMoveSpeed;
    [SerializeField] private int burstCount;
    [SerializeField] private float timeBetweenBursts;
    [SerializeField] private float restTime = 1f;

    private bool isShooting = false;

    public void Attack() {
        if(!isShooting)
        { 
            StartCoroutine(ShootRoutine()); 
        }
    }

    private IEnumerator ShootRoutine() {
        isShooting = true;

        for (int i = 0; i < burstCount; i++)
        {
            Vector2 targetDirection = PlayerController.Instance.transform.position - transform.position;

            GameObject newBullet = Instantiate(bulletPRefab, transform.position, Quaternion.identity);
            newBullet.transform.right = targetDirection;

            if(newBullet.TryGetComponent(out Projectile projectile)) {
                projectile.UpdateProjectileSpeed(bulletMoveSpeed);
            }   
            yield return new WaitForSeconds(timeBetweenBursts);
        }
        

        yield return new WaitForSeconds(restTime);
        isShooting = false;
    }
}
