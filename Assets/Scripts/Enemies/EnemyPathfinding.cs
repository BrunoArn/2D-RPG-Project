using UnityEngine;

public class EnemyPathfinding : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;

    private Vector2 moveDirection;
    private Rigidbody2D rb;
    private Knockback knockBack;
    private SpriteRenderer spriteRenderer;

    private void Awake() {
        knockBack = GetComponent<Knockback>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate() {
        if(knockBack.GettingKnockBack) { return; }

        rb.MovePosition(rb.position + moveDirection * moveSpeed *Time.fixedDeltaTime);

        if(moveDirection.x < 0) { spriteRenderer.flipX = true; } 
        else { spriteRenderer.flipX = false; } 
    }

    public void moveTo(Vector2 targetPosition) {
        moveDirection = targetPosition;
    }

    public void StopMoving() {
        moveDirection = Vector3.zero;
    }
}
