using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public float playerHP;

    public TMP_Text hpText;
    
    
    
    
    
// Setuje hp na start:
    void Start()
    {
        playerHP = 9;
    }

    void Update()
    {
        hpText.SetText(playerHP.ToString());
    }


    // Sprawdza kolizje
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            TakeDamage();
        }
    }
// Odejmuje hp
    public void TakeDamage()
    {
        playerHP -= 1;
        
       
    }
    
    
    
}
