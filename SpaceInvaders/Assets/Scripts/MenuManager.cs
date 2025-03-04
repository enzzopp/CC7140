using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GUISkin skin; // GUI Skin para personalizar a interface

    void OnGUI()
    {
        GUI.skin = skin; // Aplica o GUI Skin

        if (SceneManager.GetActiveScene().name == "Menu")
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2, 100, 50), "Jogar"))
            {
                SceneManager.LoadScene("Level1");
            }
        }
        if (SceneManager.GetActiveScene().name == "Final")
        {
            if (GameManager.PlayerLives <= 0)
                GUI.Label(new Rect(Screen.width / 2 - 80, Screen.height / 2 + 100, 2000, 1000), "GAME OVER");
            else
                GUI.Label(new Rect(Screen.width / 2 - 80, Screen.height / 2 + 100, 2000, 1000), "YOU WIN");

            if (GUI.Button(new Rect(Screen.width / 2 - 50, 500, 100, 50), "RESTART"))
            {
                GameManager.PlayerLives = 3;
                GameManager.PlayerScore = 0;
                GameManager.enemieCount = 32;
                SceneManager.LoadScene("Level1");
            }
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
