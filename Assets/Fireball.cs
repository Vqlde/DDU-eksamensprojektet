using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 5f;
    public float lifetime = 3f;
    public int damage = 10;

    private Vector2 targetPosition;
    private Vector2 moveDirection;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    public void SetTarget(Vector2 target)
    {
        targetPosition = target;
        moveDirection = (targetPosition - (Vector2)transform.position).normalized;
        float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    void Update()
    {
        transform.position += (Vector3)moveDirection * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Skade til player");
            Destroy(gameObject);
        }
    }
}
