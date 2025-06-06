using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLogic : MonoBehaviour
{


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


    public float attackRate = 1f;
    float nextAttackTime = 0f;

    public int maxHealth = 3;
    private int Health;
    private string character;

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
                string character = PlayerPrefs.GetString("SelectedCharacter", "brute");
                if (character == "rogue") {
                    animator.SetTrigger("Attack");
                }
                nextAttackTime = Time.time + 1f / attackRate;
         
                StartCoroutine(StartChar());
            }
        } 
    }

    private IEnumerator StartChar()
    {
        yield return new WaitForSeconds(0.3f);
        Debug.Log("Attack tid");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy is CapsuleCollider2D)
            {
                enemy.GetComponent<MinionScript>().Damage(attackDamage);
                Debug.Log("Du damagede " + enemy + "for " + attackDamage);
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
            Debug.Log("Spilleren d�de");
            endscreen.SetActive(true);
            RogueMovement.isAlive = false;
        }
    }
    

}
