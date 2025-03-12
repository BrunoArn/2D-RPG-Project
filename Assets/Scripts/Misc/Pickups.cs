using UnityEngine;

public class Pickups : MonoBehaviour
{

    [SerializeField] private float pickUpDistance = 5f;

    [SerializeField] private float accelerationRate = .2f;
    private float moveSpeed = 0f;
    private Vector3 moveDir;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector3 playerPos = PlayerController.Instance.transform.position;

        if (Vector3.Distance(transform.position, playerPos) < pickUpDistance) {
            moveDir = (playerPos - transform.position).normalized;
            moveSpeed += accelerationRate;
        } else {
            moveDir = Vector3.zero;
            moveSpeed = 0;
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = moveDir * moveSpeed * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("entrou");
        if (collision.gameObject.GetComponent<PlayerController>()) {
            Destroy(gameObject);
        }
    }
}
