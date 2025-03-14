using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int PlayerScore = 0; // Pontuação do player
    public static int PlayerLives = 1; // Vidas do player

    public GUISkin layout;              // Fonte do placar

    public static void Damage() {
        PlayerLives--;
    }

    public static void Score() {
        PlayerScore++;
    }

    // Gerência da pontuação e fluxo do jogo
    void OnGUI () {
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 170, 20, 150, 50), "Score: " + PlayerScore);
        GUI.Label(new Rect(Screen.width / 2 + 20, 20, 150, 50), "Vidas: " + PlayerLives);
            // ball.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
            
        if ((PlayerLives <= 0 || PlayerScore == 10) && SceneManager.GetActiveScene().name == "Level1")
        {
            SceneManager.LoadScene("Final");
        }
    }

    
    // Start is called before the first frame update
    void Start()
    {
        PlayerScore = 0;
        PlayerLives = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
