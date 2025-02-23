using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float speed = 15.0f;             // Define a velocidade da bola
    public float boundX = 2.358f;            // Define os limites em Y
    private Rigidbody2D rb2d;               // Define o corpo rigido 2D que representa a raquete

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();     // Inicializa a raquete
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 newPosition = Vector2.Lerp(rb2d.position, mousePosition, speed * Time.deltaTime);

        // Limitar a posição dentro dos limites (antes de mover)
        newPosition.x = Mathf.Clamp(newPosition.x, -boundX, boundX);

        if (newPosition.y >= 0)
        {
            newPosition.y = 0;
        }

        // Mover o Rigidbody com a posição corrigida
        rb2d.MovePosition(newPosition);            // Atualiza a posição da raquete

    }
}
