using UnityEngine;

public class EnemyPathfinding : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;

    private Vector2 moveDirection;
    private Rigidbody2D rb;
    private Knockback knockBack;

    private void Awake() {
        knockBack = GetComponent<Knockback>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        if(knockBack.GettingKnockBack) { return; }

        rb.MovePosition(rb.position + moveDirection * moveSpeed *Time.fixedDeltaTime);
    }

    public void moveTo(Vector2 targetPosition) {
        moveDirection = targetPosition;
    }
}
