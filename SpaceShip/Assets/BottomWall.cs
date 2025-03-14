using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomWall : MonoBehaviour
{
    public GameObject mobPrefab;
    public float mobRate = 3f;
    private float nextMob = 0f;

    void Spawn()
    {
        float screenX = Camera.main.aspect * Camera.main.orthographicSize;
        float randomY = Random.Range(-4f, 4f);
        
        Vector2 spawnPosition = new Vector2(screenX, randomY);
        
        GameObject mob = Instantiate(mobPrefab, spawnPosition, Quaternion.identity);
        
        mob.AddComponent<MobControl>();
    }

    void Start()
    {
        // nextMob = mobRate; // Inicializa o temporizador para o primeiro spawn
    }

    void Update()
    {
        if (Time.time > nextMob)
        {
            nextMob = Time.time + mobRate;
            Spawn();
        }
    }
}