using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobBullet : MonoBehaviour
{
    public float speed = 1f;

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject); // Destroi a bullet
            GameManager.Damage();
        }
        if (other.CompareTag("Border"))
        {
            Destroy(gameObject); // Destroi a bullet se sair da tela
        }
    }
}
