using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSavesManager : MonoBehaviour
{
    public ShopScript shop;
    private void Start()
    {
        if (!PlayerPrefs.HasKey("Currency") || !PlayerPrefs.HasKey("HighScore"))
        {
            SaveSystem.LoadPlayerData();
        }
    }


    private void OnApplicationQuit()
    {
        Debug.Log("Saving Data");
        SaveSystem.SavePlayerData(PlayerPrefs.GetInt("HighScore"), PlayerPrefs.GetInt("Currency"), shop.idsAdquired);
    }

    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
        {
            Debug.Log("Saving Data");
            SaveSystem.SavePlayerData(PlayerPrefs.GetInt("HighScore"), PlayerPrefs.GetInt("Currency"), shop.idsAdquired);
        }
    }
}
