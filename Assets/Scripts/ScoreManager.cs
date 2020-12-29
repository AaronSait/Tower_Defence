using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
    public int lives = 20;
    public int money = 100;

    public Text moneyTxt;
    public Text livesTxt;

    void Start()
    {
        UpdateLives();
        UpdateMoney();    
    }
    public void LoseLife(int l = 1)
    {
        lives -= l;
        UpdateLives();
        if (lives <= 0)
        {
            GameOver();
        }
    }
    void UpdateLives()
    {
        livesTxt.text = "Lives: " + lives;
    }
    public void GameOver()
    {
        Debug.Log("Game Over");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    public void gainMoney(int m)
    {
        money += m;
        UpdateMoney();
    }
    void UpdateMoney()
    {
        moneyTxt.text = "Money: £" + money;
    } 

}
