using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionScript : MonoBehaviour
{
    public int maxHealth = 1000;
    int currentHealth;
    public float attackInterval = 5f;
    private float nextAttackTime = 0f;
    public Animator animator;
    public GameObject fireballPrefab;
    public Transform firePoint;
    private Transform player;

    public float delaytime;

    public float moveDistance = 5.0f;
    public float moveSpeed = 2.0f;

    private Vector3 startPosition;
    private bool movingUp = true;
    public float yOffset;


    void Start()
    {
    player = GameObject.FindGameObjectWithTag("Player").transform;
    currentHealth = maxHealth;
    startPosition = new Vector3(transform.position.x, transform.position.y + yOffset, transform.position.z);
    Debug.Log(gameObject.name + " Spawned at: " + transform.position.y);
    }

    void Update()
    {
    float newY = transform.position.y;

    if (movingUp)
    {
        newY += moveSpeed * Time.deltaTime;
        if (newY >= startPosition.y + moveDistance)
        {
            newY = startPosition.y + moveDistance; // Prevent overshooting
            movingUp = false;
        }
    }
    else
    {
        newY -= moveSpeed * Time.deltaTime;
        if (newY <= startPosition.y - moveDistance)
        {
            newY = startPosition.y - moveDistance; // Prevent overshooting
            movingUp = true;
        }
    }

    transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }


    public void Damage(int Damage)
    {
        currentHealth -= Damage;
        if (currentHealth <= 0)
        {
            //animation
            Debug.Log("Minion d�de");
            gameObject.SetActive(false);

        }
    }




    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (Time.time >= nextAttackTime)
            {
                animator.SetTrigger("Attack");
                nextAttackTime = Time.time + attackInterval;
                // delay - attack skal matche tidsm�ssigt med sprite no. 5 i animationen?
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
