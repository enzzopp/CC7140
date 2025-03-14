using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Mob"))
        {
            Destroy(other.gameObject); // Destroi o inimigo
            Destroy(gameObject); // Destroi a bullet
            GameManager.Score();
        }
        else if (other.CompareTag("Border"))
        {
            Destroy(gameObject); // Destroi a bullet se sair da tela
        }
    }
}
