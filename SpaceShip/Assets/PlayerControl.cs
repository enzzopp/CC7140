using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public KeyCode moveUp = KeyCode.UpArrow;      // Move a raquete para cima
    public KeyCode moveDown = KeyCode.DownArrow;    // Move a raquete para baixo
    public KeyCode shoot = KeyCode.Space;         // Atira

    public float speed = 10.0f;             // Define a velocidade da bola
    public float boundY = 4.0f;            // Define os limites em Y

    public float fireRate = 0.3f; // Tempo entre disparos
    private float nextFire = 0f;

    private Rigidbody2D rb2d;               // Define o corpo rigido 2D que representa a raquete
    public GameObject bulletPrefab;
    public Transform firePoint;

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
    }

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();     // Inicializa a raquete
    }

    // Update is called once per frame
    void Update()
    {
        var vel = rb2d.velocity;                // Acessa a velocidade da raquete
        if (Input.GetKey(moveUp)) {             // Velocidade da Raquete para ir para cima
            vel.y = speed;
        }
        else if (Input.GetKey(moveDown)) {      // Velocidade da Raquete para ir para cima
            vel.y = -speed;                    
        }
        else {
            vel.y = 0;                          // Velociade para manter a raquete parada
        }
        rb2d.velocity = vel;                    // Atualizada a velocidade da raquete

        var pos = transform.position;           // Acessa a Posição da raquete
        if (pos.y > boundY) {                  
            pos.y = boundY;                     // Corrige a posicao da raquete caso ele ultrapasse o limite superior
        }
        else if (pos.y < -boundY) {
            pos.y = -boundY;                    // Corrige a posicao da raquete caso ele ultrapasse o limite superior
        }
        transform.position = pos;               // Atualiza a posição da raquete

        if (Input.GetKey(shoot) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Shoot();
        }
    }
}
