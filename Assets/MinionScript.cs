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


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        currentHealth = maxHealth;
        startPosition = transform.position;
    }

    private void Update()
    {
        if (movingUp)
        {
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;
            if (transform.position.y >= startPosition.y + moveDistance)
            {
                movingUp = false;
            }
        }
        else
        {
            transform.position += Vector3.down * moveSpeed * Time.deltaTime;
            if (transform.position.y <= startPosition.y - moveDistance)
            {
                movingUp = true;
            }
        }
    }


    public void Damage(int Damage)
    {
        currentHealth -= Damage;
        if (currentHealth <= 0)
        {
            //animation
            Debug.Log("Minion døde");
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
                // delay - attack skal matche tidsmæssigt med sprite no. 5 i animationen?
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
