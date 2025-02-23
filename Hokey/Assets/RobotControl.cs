using UnityEngine;

public class RobotControl : MonoBehaviour
{
    public float speed = 0.5f;             // Define a velocidade da ball
    public float boundX = 2.358f;            // Define os limites em Y
    private Rigidbody2D rb2d;               // Define o corpo rigido 2D que representa a raquete
    GameObject ball;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();     // Inicializa a raquete
        ball = GameObject.FindGameObjectWithTag("Ball"); // Busca a referência da ball
    }

    // Update is called once per frame
    void Update()
    {

        if (ball == null) return; // Se não houver bola, não faz nada

        // Obtém a posição da bola apenas no eixo X (ignorando o Y)
        Vector2 ballPosition = ball.transform.position;

        // Cria a nova posição do robô, mantendo o Y fixo em 0
        Vector2 newPosition = Vector2.Lerp(rb2d.position, new Vector2(ballPosition.x, 0), speed * Time.deltaTime);

        // Limitar a posição dentro dos limites
        newPosition.x = Mathf.Clamp(newPosition.x, -boundX, boundX);

        // Mantém o robô apenas na parte inferior do campo (Y sempre 0)
        newPosition.y = 1.5f;

        // Move o robô com a posição corrigida
        rb2d.MovePosition(newPosition);

    }
}
