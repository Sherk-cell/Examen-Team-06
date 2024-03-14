using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    [SerializeField] private GameObject credits;
    private bool creditStatus;
    
    
    public void SceneToLeaderboard()
    {
        var thisScene = SceneManager.GetActiveScene().ToString();
        //SceneManager.LoadScene();
        Debug.Log("Leaderboard doesn't exists yet...");
        
    }
    public void SceneToUpgrade()
    {
        var thisScene = SceneManager.GetActiveScene().ToString();
       // SceneManager.LoadScene();
        Debug.Log("Uprgade doesn't exists yet...");
    }
    public void RollCredits()
    {
        creditStatus = !creditStatus;
        credits.SetActive(creditStatus);
    }

    public void PlayAd()
    {
        Debug.Log("Ads doesn't exists yet...");
    }


}
