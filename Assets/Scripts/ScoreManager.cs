using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviourPunCallbacks
{
    public static ScoreManager Instance;

    public GameObject leaderboardPanel;
    public GameObject leaderboardEntryPrefab;
    public Transform leaderboardContent;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    // Call this to add score to the local player
    public void AddScore(int amount)
    {
        int currentScore = 0;

        if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("Score"))
            currentScore = (int)PhotonNetwork.LocalPlayer.CustomProperties["Score"];

        currentScore += amount;

        ExitGames.Client.Photon.Hashtable scoreProp = new ExitGames.Client.Photon.Hashtable();
        scoreProp["Score"] = currentScore;

        PhotonNetwork.LocalPlayer.SetCustomProperties(scoreProp);
    }

    // This automatically gets called when any player updates a CustomProperty (like "Score")
    public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        if (changedProps.ContainsKey("Score"))
        {
            int updatedScore = (int)changedProps["Score"];
            Debug.Log($"{targetPlayer.NickName}'s score is now {updatedScore}");

            UpdateLeaderboard();
        }
    }

    void UpdateLeaderboard()
    {
        // Clear existing entries
        foreach (Transform child in leaderboardContent)
        {
            Destroy(child.gameObject);
        }

        // Add a new entry for each player
        foreach (Player player in PhotonNetwork.PlayerList)
        {
            object score;
            if (player.CustomProperties.TryGetValue("Score", out score))
            {
                GameObject entry = Instantiate(leaderboardEntryPrefab, leaderboardContent);
                TextMeshProUGUI[] texts = entry.GetComponentsInChildren<TextMeshProUGUI>();

                if (texts.Length >= 2)
                {
                    texts[0].text = player.NickName;
                    texts[1].text = score.ToString();
                }
            }
        }
    }

}
