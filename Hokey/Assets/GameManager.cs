using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int Player = 0; // Pontuação do player 1
    public static int Robot = 0; // Pontuação do player 2

    public GUISkin layout;              // Fonte do placar
    GameObject theBall;                 // Referência ao objeto bola

    // incrementa a potuação
    public static void Score (string wallID) {
        if (wallID == "BottomWall")
        {
            Robot++;
        } else
        {
            Player++;
        }
    }

    // Gerência da pontuação e fluxo do jogo
    void OnGUI () {
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100), "" + Player);
        GUI.Label(new Rect(Screen.width / 2 + 150 + 12, 20, 100, 100), "" + Robot);

        if (GUI.Button(new Rect(Screen.width / 2 - 60, 35, 120, 53), "RESTART"))
        {
            Player = 0;
            Robot = 0;
            theBall.SendMessage("RestartGame", null, SendMessageOptions.RequireReceiver);
        }
        if (Player == 5)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "YOU WIN");
            theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        } else if (Robot == 5)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "ROBOT WINS");
            theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start () 
    {
        theBall = GameObject.FindGameObjectWithTag("Ball"); // Busca a referência da bola
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
