using Unity.Mathematics;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    [SerializeField] private GameObject slashAnimPrefab;
    [SerializeField] private Transform slashAnimationSpawnPoint;

    private PlayerControls playerControls;
    private Animator myAnimator;
    private PlayerController playerController;
    private ActiveWeapon activeWeapon;

    private GameObject slashAnim;

    private void Awake() {
        // vai procurar em toda hierarquia de parentes
        playerController = GetComponentInParent<PlayerController>();
        activeWeapon = GetComponentInParent<ActiveWeapon>();

        playerControls = new PlayerControls();
        myAnimator = GetComponent<Animator>();
    }

    private void OnEnable() {
        playerControls.Enable();
    }
    
    
    void Start() {
        playerControls.Combat.Attack.started += _ => Attack();
    }

    private void Update() {
        MouseFollowWithOffSet();
    }

    //methods
    private void Attack() {
        myAnimator.SetTrigger("Attack");

        slashAnim = Instantiate(slashAnimPrefab, slashAnimationSpawnPoint.position, quaternion.identity);
        slashAnim.transform.parent = this.transform.parent;
    }

    //animation event
    public void SwingUpFlipAnim() {
        slashAnim.transform.rotation = Quaternion.Euler(-180, 0, 0);
        
        // animaçao vira pro lado
        if (playerController.FacingLeft) {
            slashAnim.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    public void SwingDownFlipAnim() {
        slashAnim.transform.rotation = Quaternion.Euler(0, 0, 0);
        
        // animaçao vira pro lado
        if (playerController.FacingLeft) {
            slashAnim.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    //off set do mouse
    private void MouseFollowWithOffSet() {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(playerController.transform.position);

        float deltaX = mousePos.x - playerScreenPoint.x;
        float deltaY = mousePos.y - playerScreenPoint.y;

        float angle = Mathf.Atan2(deltaY, Mathf.Abs(deltaX)) * Mathf.Rad2Deg;

        // espada vira pro lado
        if (mousePos.x < playerScreenPoint.x) {
            activeWeapon.transform.rotation = Quaternion.Euler(0, -180, angle);
        } else {
            activeWeapon.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

}
