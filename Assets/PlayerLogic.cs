using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLogic : MonoBehaviour
{

    public int maxHealth = 3;
    private int Health;
    private bool isAttacking;
    public Animator animator;
    public Transform attackPoint;
    public float attackRange;
    public LayerMask enemyLayers;
    public int attackDamage = 50;
    public GameObject endscreen;
    private RogueMovement RogueMovement;
    public Image HealthBar;
    public Sprite[] healthSprites;
    private GameObject healthBarObject;


    public float attackRate = 1.5f;
    float nextAttackTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Health = maxHealth; 
        isAttacking = false;
        endscreen = GameObject.Find("DeathCanvas");
        endscreen.SetActive(false);
        healthBarObject = GameObject.Find("Health");
        HealthBar = healthBarObject.GetComponent<Image>();
        RogueMovement = GetComponent<RogueMovement>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                animator.SetTrigger("Attack");
                nextAttackTime = Time.time + attackRate;
                Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
                foreach (Collider2D enemy in hitEnemies)
                {
                    if (enemy is CapsuleCollider2D)
                    {
                        Debug.Log("Ramte" + enemy.name);
                        enemy.GetComponent<MinionScript>().Damage(attackDamage);
                    }

                }

            }

        }
        
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.layer);
        if (other.gameObject.layer == 7)
        {
            Debug.Log(other.gameObject.layer + other.name);
            SceneManager.LoadScene(2);
        }
    }

    public void Damage(int damage)
    {
        Health -= damage;
        Debug.Log("Du tog skade " +  damage + Health);
        HealthBar.sprite = healthSprites[Health];
        if (Health <= 0)
        {
            Debug.Log("Spilleren døde");
            endscreen.SetActive(true);
            RogueMovement.isAlive = false;
        }
    }
    

}
