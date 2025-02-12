using System.Collections;
using UnityEngine;

public class MagicLaser : MonoBehaviour
{
    [SerializeField] private float laserGrowTime = 2f;

    private bool isGrowing = true;
    private float laserRange;
    private SpriteRenderer spriteRenderer;
    private CapsuleCollider2D capsuleCollider2D;
   

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); 
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }

    void Start()
    {
        LaserFaceMouse();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Indestructable>() && !collision.isTrigger) {
            isGrowing = false;
        }
    }

    public void UpdateLaserRange(float laserRange) {
        this.laserRange = laserRange;
        StartCoroutine(IncreaseLengthRoutine());
    }

    private IEnumerator IncreaseLengthRoutine() {
        float timePassed = 0f;
        
        while(spriteRenderer.size.x < laserRange && isGrowing) {
            timePassed += Time.deltaTime;
            float linearTime = timePassed / laserGrowTime;

            //sprite
            spriteRenderer.size = new Vector2(Mathf.Lerp(1f, laserRange, linearTime), 1f);
            //collider
            capsuleCollider2D.size = new Vector2(Mathf.Lerp(1f, laserRange, linearTime), capsuleCollider2D.size.y);
            capsuleCollider2D.offset = new Vector2((Mathf.Lerp(1f, laserRange, linearTime)) / 2, capsuleCollider2D.offset.y);

            yield return null;
        }

        StartCoroutine(GetComponent<SpriteFade>().SlowFadeRoutine());
    }

    private void LaserFaceMouse() { 
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = transform.position - mousePosition;
        transform.right = -direction;
    }
}
