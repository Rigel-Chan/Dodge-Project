using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInterface : MonoBehaviour
{
    
    public Text healthbar;
    public Text level;
    public Text points;
    public Text dashTimerUI;
    public float dashTimer = 0f;
    public EnemySpawn levelTracker;
    public PlayerMovement player;
    public GameObject replayMenu;
    public GameObject pauseMenu;
    public Text highscore;

    void Start()
    {
        pauseMenu.SetActive(false);
        dashTimerUI.text = "Ready";
    }
    void Update()
    {
        points.text = player.points.ToString();
        GameObject[] playerAlive = GameObject.FindGameObjectsWithTag("Player");
        if (playerAlive.Length == 0)
        {
            replayMenu.SetActive(true);
            highscore.text = "Score: " + player.points.ToString();
        }
        healthbar.text = player.health.ToString("F1")+"%";
        level.text = "Level "+levelTracker.level.ToString();
        if (Input.GetKeyDown("escape"))
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
        if (dashTimer <= 0)
        {
            dashTimer = 0;
            dashTimerUI.text = "Ready";
        }
        if (Input.GetKeyDown(KeyCode.Space) && player.dashed == false)
        {
            dashTimer = 2.9f;
        }
    }

    public void FixedUpdate()
    {
        if (player.dashed && dashTimer >= 0)
        {
            dashTimer -= Time.deltaTime;
            dashTimerUI.text = dashTimer.ToString("F1");
        }

    }

}
