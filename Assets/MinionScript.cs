using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionScript : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void Damage(int Damage)
    {
        currentHealth -= Damage;
        if (currentHealth <= 0)
        {
            //animation

        }
    }

    void Update()
    {

    }



}
