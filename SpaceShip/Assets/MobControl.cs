using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobControl : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float speed = 3f;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 10f);
    }

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject); // Destroi o inimigo
            GameManager.Damage();
        }
    }
}
