using System.Collections;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : Singleton<PlayerController>
{
    public bool FacingLeft { get { return facingLeft;} }

    [SerializeField] private float moveSpeed = 1f;

    [Header("Dash Settings")]
    [SerializeField] private float dashSpeed = 4f;
    [SerializeField] private float dashTime = .2f;
    [SerializeField] private float dashCD = .25f;
    private float startingMoveSpeed;
    [SerializeField] private TrailRenderer myTrailRenderer;

    [SerializeField] private Transform weaponCollider;
    [SerializeField] private Transform weaponSlash;

    private PlayerControls playerControls;
    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator myAnimator;
    private SpriteRenderer mySpriteRenderer;

    private Knockback knockback;

    private bool facingLeft = false;
    private bool isDashing = false;

    //On awake initialize things, overriding o singleton
    protected override void Awake() {
        //esse é o singleton
        base.Awake();
        //esse é o override
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        knockback = GetComponent<Knockback>();
    }

    private void Start() {
        playerControls.Combat.Dash.performed += _ => Dash(); 
        startingMoveSpeed = moveSpeed;       
    }

    //Enables or disables things
    private void OnEnable() {
        playerControls.Enable();
    }
    private void OnDisable() {
        playerControls?.Disable();
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

    public Transform GetWeaponCollider() {
        return weaponCollider;
    }

    public Transform GetWeaponSlash() {
        return weaponSlash;
    }

    //my methods
    private void PlayerInput() {
        movement = playerControls.Movement.Move.ReadValue<Vector2>();

        myAnimator.SetFloat("moveX", movement.x);
        myAnimator.SetFloat("moveY", movement.y);
    }
    //used in fixed
    private void Move() {
        if (knockback.GettingKnockBack) { return; }
        rb.MovePosition(rb.position + movement * moveSpeed *Time.fixedDeltaTime);
    }

    private void AdjustPlayerFacingDirection() {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);

        if (mousePos.x < playerScreenPoint.x) {
            mySpriteRenderer.flipX = true;
            facingLeft = true;
        } else {
            mySpriteRenderer.flipX = false;
            facingLeft = false;
        }
    }

    private void Dash() {
        if(!isDashing){
        isDashing = true;
        moveSpeed *= dashSpeed;
        myTrailRenderer.emitting = true;
        StartCoroutine(EndDashRoutine());
        }
    }

    private IEnumerator EndDashRoutine() { 
        yield return new WaitForSeconds(dashTime);
        moveSpeed = startingMoveSpeed;
        myTrailRenderer.emitting = false;
        yield return new WaitForSeconds(dashCD);
        isDashing = false;
    }

}
