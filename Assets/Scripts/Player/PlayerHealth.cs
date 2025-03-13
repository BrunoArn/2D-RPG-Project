using System.Collections;
using UnityEngine;

public class PlayerHealth : Singleton<PlayerHealth>
{
    [SerializeField] private int maxHealth = 3;
    [SerializeField] private float knockbackThrustAmount = 10f;
    [SerializeField] private float damageRecoveryTime = 1f;

    private int currentHealth;
    private bool canTakeDamage = true;

    private Knockback knockback;
    private Flash flash;

    protected override void Awake()
    {
        base.Awake();
        knockback = GetComponent<Knockback>();
        flash = GetComponent<Flash>();
    }

    void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnCollisionStay2D(Collision2D other) {
        EnemyAi enemy = other.gameObject.GetComponent<EnemyAi>();

        if (enemy) {
            TakeDamage(1, other.transform);
        }
    }

    public void HealPlayer() {
        currentHealth += 1;
    }

    public void TakeDamage(int damageAmount, Transform hitTransform) {
        if (!canTakeDamage) { return; }

        ScreenShakeManager.Instance.ShakeScreen();
        knockback.GetKnockback(hitTransform, knockbackThrustAmount);
        StartCoroutine(flash.FlashRoutine());
        canTakeDamage = false;
        currentHealth -= damageAmount;
        StartCoroutine(DamageRecoveryRoutine());
    }

    private IEnumerator DamageRecoveryRoutine() {
        yield return new WaitForSeconds(damageRecoveryTime);
        canTakeDamage = true;
    }
}
