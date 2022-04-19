using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public static class Global
{
    public static int bestScore;
}
public class GameManager : MonoBehaviour
{
    public Player player;
    public Text scoreCount;
    public Text endScore;
    public Text bestCore;        
    public GameObject gameOverUI;
    public GameObject gameReadyUI;
    
    int score = 0;
    int iEndscore = 0;
    bool bDead = false;

    private void Awake()
    {
        player.OnDie += GameOver;
        player.OnScore += UpScore;        
    }

    private void Start()
    {
        Time.timeScale = 0.0F;
        player.GetComponent<Animator>().enabled = false;        
    }

    private void Update()
    {
        GameStart();
    }
    public void ReStart()
    {
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1.0F;
    }

    private void GameStart()
    {
        if (player.bStart && player)
        {
            Time.timeScale = 1.0F;
            player.GetComponent<Animator>().enabled = true;
            gameReadyUI.SetActive(false);
        }
    }

    private void GameOver()
    {
        if (iEndscore > Global.bestScore)
        {
           Global.bestScore = iEndscore;
        }

        endScore.text = iEndscore.ToString();
        bestCore.text = Global.bestScore.ToString();
        gameOverUI.SetActive(true);

        Time.timeScale = 0.7F;

        GetComponent<PiepeSpawner>().enabled = false;
        bDead = true;
    }

    private void UpScore()
    {       
        if (bDead)
        {
            return;
        }
        score++;
        scoreCount.text = score.ToString();
        iEndscore = score;
    }
}
