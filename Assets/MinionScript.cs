using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionScript : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;
    public float attackInterval = 5f;
    private float nextAttackTime = 0f;
    public Animator animator;
    public GameObject fireballPrefab;
    public Transform firePoint;
    private Transform player;

    public float delaytime;

    public float moveDistance = 1.25f;
    public float moveSpeed = 1.5f;

    private Vector3 startPosition;
    private bool movingUp = true;
    public float yOffset;

    private SpriteRenderer spriteRenderer;
    public Color normalColor = Color.white;
    public Color dmgColor = Color.red;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        currentHealth = maxHealth;
        startPosition = new Vector3(transform.position.x, transform.position.y + yOffset, transform.position.z);
        Debug.Log(gameObject.name + " Spawned at: " + transform.position.y);
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float newY = transform.position.y;

        if (movingUp)
        {
            newY += moveSpeed * Time.deltaTime;
            if (newY >= startPosition.y + moveDistance)
            {
                newY = startPosition.y + moveDistance; // Stop exactly at the limit
                movingUp = false;
            }
        }
        else
        {
            newY -= moveSpeed * Time.deltaTime;
            if (newY <= startPosition.y - moveDistance)
            {
                newY = startPosition.y - moveDistance; // Stop exactly at the limit
                movingUp = true;
            }
        }

        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }


    public void Damage(int Damage)
    {
        currentHealth -= Damage;
        spriteRenderer.color = dmgColor;
        StartCoroutine(ColorAwait());
        if (currentHealth <= 0)
        {
            //animation
            Debug.Log("Minion døde");
            gameObject.SetActive(false);

        }
    }
    private IEnumerator ColorAwait()
    {
        yield return new WaitForSeconds(0.3f);
        spriteRenderer.color = normalColor;
    }




    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (Time.time >= nextAttackTime)
            {
                animator.SetTrigger("Attack");
                nextAttackTime = Time.time + attackInterval;
                Attack();

            }
        }
    }




    void Attack()
    {

        Vector2 targetPosition = player.position;
        GameObject fireball = Instantiate(fireballPrefab, firePoint.position, Quaternion.identity);

        fireball.GetComponent<Fireball>().SetTarget(targetPosition);
    }



}
