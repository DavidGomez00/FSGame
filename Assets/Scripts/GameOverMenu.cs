using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class GameOverMenu : MonoBehaviour
{
    
    string gameId = "3764525";
    bool testMode = true;
        
    void Start()
    {
        Advertisement.Initialize(gameId, testMode);
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(1);
    }


    public void BackToMainMenu()
    {
        
        if (Advertisement.IsReady())
        {
            Debug.Log("Anuncio!");
            Advertisement.Show();
        }

        if (!Advertisement.isShowing)
        {
            SceneManager.LoadScene(0);
        }
    }


}
