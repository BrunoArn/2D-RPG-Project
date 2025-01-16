using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    private PlayerControls playerControls;
    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator myAnimator;
    private SpriteRenderer mySpriteRenderer;

    //On awake initialize things
    private void Awake() {
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    //Enables or disables things
    private void OnEnable() {
        playerControls.Enable();
    }
    private void OnDisable() {
        playerControls.Disable();
    }

    //better for input
    private void Update() {
        PlayerInput();
    }

    // better for physics
    private void FixedUpdate() {
        AdjustPlayerFacingDirection();
        Move();
    }

    //my methods
    private void PlayerInput() {
        movement = playerControls.Movement.Move.ReadValue<Vector2>();

        myAnimator.SetFloat("moveX", movement.x);
        myAnimator.SetFloat("moveY", movement.y);
    }
    //used in fixed
    private void Move() {
        rb.MovePosition(rb.position + movement * moveSpeed *Time.fixedDeltaTime);
    }

    private void AdjustPlayerFacingDirection() {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);

        if (mousePos.x < playerScreenPoint.x) {
            mySpriteRenderer.flipX = true;
        } else {
            mySpriteRenderer.flipX = false;
        }
    }

}
