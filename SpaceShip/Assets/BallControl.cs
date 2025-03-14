using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    public KeyCode launchBall = KeyCode.Space;
    private Rigidbody2D rb2d;
    private bool ballLaunched = false;

    void OnCollisionEnter2D(Collision2D coll){
        if (coll.gameObject.tag == "Brick"){

            if (coll.gameObject.name == "Special Brick"){
                GameManager.Score();
                transform.localScale = new Vector3(1f, 1f, 1f);
            }

            Destroy(coll.gameObject);
            GameManager.Score();
        }
    }

    // Reinicializa a posição e velocidade da bola
    void ResetBall(){
        rb2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    // Reinicializa o jogo
    void RestartGame(){
        ResetBall();
        Invoke("GoBall", 1);
        ballLaunched = false;
    }

    void ResetGame(){
        GameManager.PlayerLives = 3;
        GameManager.PlayerScore = 0;
        RestartGame();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        ResetGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(launchBall) && !ballLaunched) { 
            ballLaunched = true; 
            float rand = Random.Range(0, 2);
            if(rand < 1){
                rb2d.AddForce(new Vector2(15, 15));
            } else {
                rb2d.AddForce(new Vector2(-15, 15));
            }
        }

        if (rb2d.velocity.magnitude > 5)
        {
            rb2d.velocity *= (1 - 0.5f * Time.deltaTime);
        }
        else if (rb2d.velocity.magnitude < 5)
        {
            rb2d.velocity = rb2d.velocity.normalized * 5;
        }

        if (rb2d.velocity.x == 0 && rb2d.velocity.y > 0) {
            rb2d.AddForce(new Vector2(1, 0));
        } else if (rb2d.velocity.x == 0 && rb2d.velocity.y < 0) {
            rb2d.AddForce(new Vector2(1, 0));
        }
    }
}
