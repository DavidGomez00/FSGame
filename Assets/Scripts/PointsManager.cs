using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PointsManager : MonoBehaviour
{

    private int points;

    private int newCurrency;
    private int coinsPerTen;

    public TextMeshProUGUI score;
    public TextMeshProUGUI currencyTXT;

    public TextMeshProUGUI HighScore;

    private void Start()
    {
        points = 0;
        coinsPerTen = 1;

        int highScore = PlayerPrefs.GetInt("HighScore");

        if (highScore <= 0)
        {
            PlayerPrefs.SetInt("HighScore", 0);
        }
    }

    public void addPoint()
    {
        points++;
        score.text = "Score: " + points;

        if ((points) % 10 == 0)
        {
            newCurrency += coinsPerTen;
            coinsPerTen++;
            Debug.Log(newCurrency);
            currencyTXT.text = "Currency:" + newCurrency;
        }
    }

    public void saveHighScore()
    {
        if (PlayerPrefs.GetInt("HighScore") < points)
        {
            PlayerPrefs.SetInt("HighScore", points);
        }

        HighScore.text = "HighScore: " + PlayerPrefs.GetInt("HighScore");
    }

    public void saveCurrency()
    {
        int currency = PlayerPrefs.GetInt("Currency");
        currency += newCurrency;

        PlayerPrefs.SetInt("Currency", currency);
    }

    public int getHighScore()
    {
        return PlayerPrefs.GetInt("HighScore");
    }
}
