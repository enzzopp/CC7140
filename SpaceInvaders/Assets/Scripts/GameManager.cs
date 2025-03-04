using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int PlayerScore = 0; // Pontuação do player
    public static int PlayerLives = 3; // Vidas do player
    public static int enemieCount = 32; // Quantidade de inimigos

    public GUISkin layout;              // Fonte do placar

    public static void Damage() {
        PlayerLives--;
    }

    public static void Score() {
        PlayerScore++;
        enemieCount--;
    }

    // Gerência da pontuação e fluxo do jogo
    void OnGUI () {
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 170, 20, 150, 50), "Score: " + PlayerScore);
        GUI.Label(new Rect(Screen.width / 2 + 20, 20, 150, 50), "Vidas: " + PlayerLives);
            
        if (enemieCount == 0 && SceneManager.GetActiveScene().name == "Level1")
        {
            GUI.Label(new Rect(Screen.width / 2, 200, 2000, 1000), "LEVEL 2");
            // ball.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
            SceneManager.LoadScene("Level2");
            PlayerScore = 0;
            PlayerLives = 3;
            enemieCount = 32;
        }
        if (enemieCount == 0 && SceneManager.GetActiveScene().name == "Level2")
        {
            GUI.Label(new Rect(Screen.width / 2, 200, 2000, 1000), "LEVEL 2");
            // ball.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
            SceneManager.LoadScene("Final");
        }
        if (PlayerLives <= 0)
        {
            SceneManager.LoadScene("Final");
        }
    }

    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
}
