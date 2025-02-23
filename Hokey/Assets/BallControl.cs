using UnityEngine;

public class BallControl : MonoBehaviour
{
    private Rigidbody2D rb2d;

    public AudioSource source;

    // inicializa a bola randomicamente para esquerda ou direita
    void GoBall(){                      
        float rand = Random.Range(0, 2);
        if(rand < 1){
            rb2d.AddForce(new Vector2(5, -10));
        } else {
            rb2d.AddForce(new Vector2(-5, -10));
        }
    }

    // Determina o comportamento da bola nas colisões com os Players (raquetes)
    void OnCollisionEnter2D (Collision2D coll) {

        source.Play();

        Vector2 vel;

        if(coll.collider.CompareTag("Player")){
            vel.x = rb2d.linearVelocity.x;
            vel.y = (rb2d.linearVelocity.y / 2) + (coll.collider.attachedRigidbody.linearVelocity.y / 3);
            rb2d.linearVelocity = vel;
        }
        

        if (rb2d.linearVelocity.magnitude < 3f) {
            rb2d.linearVelocity = rb2d.linearVelocity.normalized * 3f;
        }
    }

    // Reinicializa a posição e velocidade da bola
    void ResetBall(){
        rb2d.linearVelocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    // Reinicializa o jogo
    void RestartGame(){
        ResetBall();
        Invoke("GoBall", 1);
    }

    void Start () {
        source = GetComponent<AudioSource>();
        rb2d = GetComponent<Rigidbody2D>(); // Inicializa o objeto bola
        Invoke("GoBall", 2);    // Chama a função GoBall após 2 segundos
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
