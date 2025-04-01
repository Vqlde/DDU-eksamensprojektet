using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{

    public int maxHealth = 100;
    private int Health;
    private bool isAttacking;
    public Animator animator;
    public Transform attackPoint;
    public float attackRange;
    public LayerMask enemyLayers;
    public int attackDamage = 50;
    public GameObject endscreen;
    // Start is called before the first frame update
    void Start()
    {
        Health = maxHealth; 
        isAttacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && isAttacking == false)
        {
            Debug.Log("Attack");
            isAttacking = true;
            animator.SetTrigger("Attack");
            // cooldown on nextattack
            isAttacking = false;
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
            foreach (Collider2D enemy in hitEnemies) {
                if (!enemy.isTrigger)
                {
                    Debug.Log("Ramte" + enemy.name);
                    enemy.GetComponent<MinionScript>().Damage(attackDamage);
                }
                
            }

        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    public void Damage(int damage)
    {
        Health -= damage;
        Debug.Log("Du tog skade " +  damage);
        if (Health <= 0)
        {
            Debug.Log("Spilleren døde");
            endscreen.SetActive(true);
        }
    }
    

}
