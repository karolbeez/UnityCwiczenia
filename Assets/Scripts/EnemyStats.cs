using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyStats : MonoBehaviour
{
    public float health;
    public GameObject Enemy;
    public GameObject deathEffect;
    private GameManagerScript scorer;

    void DeathEffect()
    {
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
    }
    
    
    //Oto co się dzieje jak odbieramy życie enemy:
    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount; 
        
        
        
        //Zgon enemy:
        if (health <= 0)
        {
            DeathEffect();
            scorer = GameObject.FindObjectOfType<GameManagerScript>();
            scorer.AddScore(1);
            Destroy(Enemy);
        }
    }
}
