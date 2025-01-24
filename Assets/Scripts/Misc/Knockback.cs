using System.Collections;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public bool GettingKnockBack { get; private set;}

    [SerializeField] private float knockBackTime = .2f;

    private Rigidbody2D rb;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    public void GetKnockback(Transform damageSource, float knockBackThrust) {
        GettingKnockBack = true;
        Vector2 difference = (transform.position - damageSource.position).normalized * knockBackThrust;
        rb.AddForce(difference, ForceMode2D.Impulse);
        StartCoroutine(KnockRoutine());
    }

    private IEnumerator KnockRoutine () {
        yield return new WaitForSeconds(knockBackTime);
        rb.linearVelocity = Vector2.zero;
        GettingKnockBack = false;
    }
}
