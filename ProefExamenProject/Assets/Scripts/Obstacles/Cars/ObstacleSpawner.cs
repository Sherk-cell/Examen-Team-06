using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnPoints;
    [SerializeField] private float spawnCooldown = 5;
    [SerializeField] private GameObject[] obstacle;
    private float cooldownTimer = 0;

    private void Update()
    {
        if(cooldownTimer <= 0)
        {
            SpawnCar();
        }
        cooldownTimer -= Time.deltaTime;
    }

    private void SpawnCar()
    {
        int random = Random.Range(0, spawnPoints.Length);
        Vector3 spawnPos = spawnPoints[random].transform.position;
        int randomOb = Random.Range(0, obstacle.Length);
        Instantiate(obstacle[randomOb], spawnPos, transform.rotation);
        cooldownTimer = spawnCooldown;
    }
}
