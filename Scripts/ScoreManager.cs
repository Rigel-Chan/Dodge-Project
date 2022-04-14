using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public PlayerMovement player;
    public GameObject restartMenu;
    public Text highscoreText;
    int highscoreTemp;
    void Start()
    {

        highscoreTemp = PlayerPrefs.GetInt("highscore");
    }

    // Update is called once per frame
    void Update()
    {
        if(player.points >= highscoreTemp)
        {
            highscoreTemp = player.points;
        }
        if(restartMenu.activeSelf)
        {
            highscoreText.text = "High Score: " + highscoreTemp;
            PlayerPrefs.SetInt("highscore", highscoreTemp);
        }
    }

}
