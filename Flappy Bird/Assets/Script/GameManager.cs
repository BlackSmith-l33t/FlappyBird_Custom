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
    
    int score = 0;
    int iEndscore = 0;

    private void Awake()
    {
        player.OnDie += GameOver;
        player.OnScore += UpScore;
    }

    public void ReStart()
    {
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1.0F;
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
        Destroy(GetComponent<Player>());
    }

    private void UpScore()
    {       
        score++;
        scoreCount.text = score.ToString();
        iEndscore = score;
    }
}
