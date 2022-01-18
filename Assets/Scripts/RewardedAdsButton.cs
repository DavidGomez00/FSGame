using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;


[RequireComponent(typeof(Button))]
public class RewardedAdsButton : MonoBehaviour, IUnityAdsListener
{

    public ShopScript shopScript;
    private string gameId = "3764525";
    Button myButton;
    public string myPlacementId = "rewardedVideo";

    void Start()
    {
        myButton = GetComponent<Button>();

        // Set interactivity to be dependent on the Placement’s status:
        myButton.interactable = Advertisement.IsReady(myPlacementId);

        // Map the ShowRewardedVideo function to the button’s click listener:
        if (myButton) myButton.onClick.AddListener(ShowRewardedVideo);

        // Initialize the Ads listener and service:
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, true);
    }

    // Implement a function for showing a rewarded video ad:
    void ShowRewardedVideo()
    {
        Advertisement.Show(myPlacementId);
    }

    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsReady(string placementId)
    {
        // If the ready Placement is rewarded, activate the button: 
        if (placementId == myPlacementId)
        {
            myButton.interactable = true;
        }
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished)
        {
            int currency = PlayerPrefs.GetInt("Currency");
            Debug.Log("Actual Currency: " + currency);
            currency += 25;
            PlayerPrefs.SetInt("Currency", currency);
            Debug.Log("Post Currency: " + currency);
            Debug.Log("Ad shown correctly, currency: " + PlayerPrefs.GetInt("Currency"));
            shopScript.GetCurrency();
        }
        else if (showResult == ShowResult.Skipped)
        {
            // Do not reward the user for skipping the ad.
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.LogWarning("The ad did not finish due to an error.");
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.LogError("Something went wrong while playing ad");
    }

    public void OnUnityAdsDidStart(string placementId)
    {
    }
}
