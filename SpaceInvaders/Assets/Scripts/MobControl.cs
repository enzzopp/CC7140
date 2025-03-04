using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MobControl : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float timer = 0.0f;
    private float waitTime = 1.0f;
    private float speed = 2.0f;
    private int moveCount = 0; // Contador de movimentos laterais
    private float tetaVel = 1.1f; // Fator de aumento de velocidade
    private float dropDistance = 0.5f; // Distância de descida
    private float boundX = 8.0f;

    public GameObject bulletPrefab;
    public Transform firePoint;

    public float fireRate = 1f; // Tempo entre disparos
    private float nextFire = 0f;

    void Shoot()
    {
        int i = Random.Range(0, transform.childCount);
        firePoint = transform.GetChild(i);
        Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
    }

    void ChangeState()  
    {
        moveCount++;
        Vector2 vel = rb2d.velocity;
        vel.x *= -1; // Inverte a direção do movimento lateral
        rb2d.velocity = vel;

        if (moveCount >= 4) // A cada 4 trocas de direção, desce e aumenta a velocidade
        {
            moveCount = 0;
            transform.position = new Vector2(transform.position.x, transform.position.y - dropDistance);
            speed *= tetaVel; // Aumenta a velocidade
            rb2d.velocity = new Vector2(Mathf.Sign(vel.x) * speed, 0); // Aplica a nova velocidade
        }
    }

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        if (SceneManager.GetActiveScene().name == "Final"){
            speed = 3.5f;
        }
        rb2d.velocity = new Vector2(speed, 0);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= waitTime)
        {
            ChangeState();
            timer = 0.0f;
        }

        // Verifica se atingiu a borda e troca de direção
        if (transform.position.x >= boundX || transform.position.x <= -boundX)
        {
            ChangeState();
        }

        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Shoot();
        }
    }
}
