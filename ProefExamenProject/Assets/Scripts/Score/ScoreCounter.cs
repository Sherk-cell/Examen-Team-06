using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    public static ScoreCounter instance;

    public TMP_Text scoreText;
    public TMP_Text coinText;
    public int currentScore = 0;
    public int currentCoins = 0;
    public int endScore;
    public ScoreCalc scoreCalc;

    void Awake()
    {
        instance = this;
    }
    
    void Update()
    {
        coinText.text = "Coins: " + currentCoins.ToString();
        scoreText.text = "Points: " + scoreCalc.car.transform.position.z.ToString("0");
    }

    public void IncreaseScore(int s)
    {
        currentScore += s;
        scoreText.text = "Points: " + currentScore.ToString();
    }

    public void IncreaseCoins(int c)
    {
        currentCoins += c;
        coinText.text = "Coins: " + currentCoins.ToString();
    }
}
