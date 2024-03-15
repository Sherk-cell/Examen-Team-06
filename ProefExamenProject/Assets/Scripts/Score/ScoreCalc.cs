using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ScoreCalc : MonoBehaviour
{
    public Transform car;
    public Transform endPos;
    public ScoreCounter scoreCounter;


    public void Die()
    {
        endPos = car;
        CoinsMultiplyScore();
        Debug.Log(scoreCounter.endScore);
    }

    public void CoinsMultiplyScore()
    {
        scoreCounter.endScore = scoreCounter.currentScore * scoreCounter.currentCoins;
    }
    
    void Update()
    {
        if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
            Die();
    }

}
