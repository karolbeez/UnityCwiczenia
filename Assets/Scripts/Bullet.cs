using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;
    public float damage = 1;

    private void OnCollisionEnter2D(Collision2D other)
    {
        // Efekt po kolizji
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        
        
        // Zadaje tutaj dmg
        
        if(other.gameObject.TryGetComponent<EnemyStats>(out EnemyStats enemyComponent))
        {
           enemyComponent.TakeDamage(damage);
        }
        
        // Obiekt się niszczy
        Destroy(gameObject);
        
    }
}
