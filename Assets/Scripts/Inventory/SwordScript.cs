using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class SwordScript : MonoBehaviour, IWeapon
{
    [SerializeField] private GameObject slashAnimPrefab;
    [SerializeField] private float SwordAttackCD = .5f;
   
    private Transform slashAnimationSpawnPoint;
    private Transform weaponCollider;
    private Animator myAnimator;
    private GameObject slashAnim;

    private void Awake() {
        // vai procurar em toda hierarquia de parentes
        myAnimator = GetComponent<Animator>();
    }

    private void Start() {
        weaponCollider = PlayerController.Instance.GetWeaponCollider();
        slashAnimationSpawnPoint = PlayerController.Instance.GetWeaponSlash();
    }

    private void Update() {
        MouseFollowWithOffSet();
    }

    //methods
    public void Attack() {
            //isAttacking = true;
        myAnimator.SetTrigger("Attack");
        weaponCollider.gameObject.SetActive(true);

        slashAnim = Instantiate(slashAnimPrefab, slashAnimationSpawnPoint.position, quaternion.identity);
        slashAnim.transform.parent = this.transform.parent;
        StartCoroutine(AttackCDRoutine());
    }

    private IEnumerator AttackCDRoutine() {
        yield return new WaitForSeconds(SwordAttackCD);
        ActiveWeapon.Instance.ToggleIsAttacking(false);
    }

    //animation event
    public void DoneAttackingAnimEvent() {
        weaponCollider.gameObject.SetActive(false);
    }

    public void SwingUpFlipAnim() {
        slashAnim.transform.rotation = Quaternion.Euler(-180, 0, 0);
        
        // animaçao vira pro lado
        if (PlayerController.Instance.FacingLeft) {
            slashAnim.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    public void SwingDownFlipAnim() {
        slashAnim.transform.rotation = Quaternion.Euler(0, 0, 0);
        
        // animaçao vira pro lado
        if (PlayerController.Instance.FacingLeft) {
            slashAnim.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    //off set do mouse
    private void MouseFollowWithOffSet() {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(PlayerController.Instance.transform.position);

        float deltaX = mousePos.x - playerScreenPoint.x;
        float deltaY = mousePos.y - playerScreenPoint.y;

        // Varia bastante comum offset no player tbm
        //float angle = Mathf.Atan2(deltaY, Mathf.Abs(deltaX)) * Mathf.Rad2Deg;

        //varia menos e fica mais lateralizado
        float angle = Mathf.Atan2(mousePos.y, Mathf.Abs(mousePos.x)) * Mathf.Rad2Deg;

        // espada vira pro lado
        if (mousePos.x < playerScreenPoint.x) {
            ActiveWeapon.Instance.transform.rotation = Quaternion.Euler(0, -180, angle);
            weaponCollider.transform.rotation= Quaternion.Euler(0,-180, 0);
        } else {
            ActiveWeapon.Instance.transform.rotation = Quaternion.Euler(0, 0, angle);
            weaponCollider.transform.rotation= Quaternion.Euler(0, 0, 0);
        }
    }

}
