using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;
public class GameManagerScript : MonoBehaviour
{
    public GameObject gameOverUI;
    
    private float waveTimer;
    public float scoreTotal = 0;
    public TextMeshProUGUI scoreText;
    public Shooting shootStat;
    private GameManagerScript weapon;
    
    public PlayerHealth health;

// Odpowiada za death screen i sprawdza czy player żyje: (PlayerHealth)
    void Update()
    {
        
        if (health.playerHP <= 0)
        {
            gameOverUI.SetActive(true);
        }
        
        scoreText.text = scoreTotal.ToString();   
        
    }


    #region  Start
    // Reset punktów do 0 na start
    void Awake()
    {
        shootStat.gameObject.GetComponent<Shooting>();
        health = FindObjectOfType<PlayerHealth>();
        
        scoreTotal = 0;
    }
    #endregion

    // Im więcej punktów, tym szybcie respawnują się enemy:
    
#region WaveProgress

    
    // Odpowiada za fazę gry, odniesienia: Spawner
    public float getWavePhase()
    {
        if (scoreTotal < 5)
        {
            shootStat.setWeaponStat(0.5f, 5f, 1);
            return 4;
        }
        else if (scoreTotal is >= 5 and < 15)
        {
            shootStat.setWeaponStat(0.3f, 15f, 1);
            return 3;
        }
        else if (scoreTotal is >= 16 and < 40)
        {
            shootStat.setWeaponStat(0.3f, 5f, 3);
            return 2;
        }
        else if (scoreTotal is >= 41 and < 80)
        {
            shootStat.setWeaponStat(0.2f, 15f, 3);
            return 1;
        }
        else if (scoreTotal is >= 81 and < 200)
        {
            shootStat.setWeaponStat(0.1f, 30f, 3);
            return 0.75f;
        }
        else if (scoreTotal >= 201)
        {
            shootStat.setWeaponStat(0.01f, 60f, 3);
            return 0.25f;
        }
        else
        {
            Debug.Log("Cos poszlo nie tak");
            return 0;
        }
        
    
    }
    
    #endregion
    
    
    // Odniesienie znajduje się w EnemyStats, dodaje punkty
    public float AddScore(float x)
    {
        scoreTotal += x;
        Debug.Log("Score:" + scoreTotal);
        return x;
    }
    
    
    
}
