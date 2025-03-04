using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public KeyCode moveLeft = KeyCode.A;  
    public KeyCode moveRight = KeyCode.D;
    public KeyCode shoot = KeyCode.Space;

    public float speed = 2.0f;         
    public float boundX = 8.0f;

    public Rigidbody2D rb2d;
    public GameObject bulletPrefab;
    public Transform firePoint;

    public float fireRate = 0.3f; // Tempo entre disparos
    private float nextFire = 0f;

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
    }

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var vel = rb2d.velocity;       
        if (Input.GetKey(moveLeft)) {   
            vel.x = -speed;
        }
        else if (Input.GetKey(moveRight)) {    
            vel.x = speed;                    
        }
        else {
            vel.x = 0;                   
        }
        rb2d.velocity = vel;                 

        var pos = transform.position;         
        if (pos.x > boundX) {                  
            pos.x = boundX;          
        }
        else if (pos.x < -boundX) {
            pos.x = -boundX;                
        }
        transform.position = pos;

        if (Input.GetKey(shoot) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Shoot();
        }
    }
}
