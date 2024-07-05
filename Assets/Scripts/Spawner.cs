using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private GameObject _bossPrefab;
    [SerializeField] public GameObject gameStatus;
    private int bossSpawned = 0;
    private int bossNext = 250;
    public GameManagerScript status;

    private float _timeUntilSpawn;
    
    //Start odliczania:
    void Awake()
    {
        SetTimeUntilSpawn();
    }
    
    //Odliczanie do spawnu:
    void Update()
    {
        _timeUntilSpawn -= Time.deltaTime;
        
        if (status.scoreTotal > bossNext && bossSpawned <= 10)
        {
            Instantiate(_bossPrefab, transform.position, Quaternion.identity);
            bossNext += 150;
            bossSpawned += 1;
        }

        if (_timeUntilSpawn <= 0)
        {
            
            Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
            SetTimeUntilSpawn();
            
        }
        
    }
    //Resert czasu odliczania w odniesieniem do szybkości respawnu zależnego od punktów: (GameManager)
    private void SetTimeUntilSpawn()
    {
        _timeUntilSpawn = status.getWavePhase();
    }






}
