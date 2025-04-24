using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ReadyManager : MonoBehaviourPunCallbacks
{
    public Button readyButton;
    public TMP_Text player1Status;
    public TMP_Text player2Status;

    private const string READY_KEY = "IsReady";

    void Start()
    {
        readyButton.onClick.AddListener(SetReady);
        UpdatePlayerStatus();
    }

    void SetReady()
    {
        ExitGames.Client.Photon.Hashtable props = new ExitGames.Client.Photon.Hashtable();
        props[READY_KEY] = true;
        PhotonNetwork.LocalPlayer.SetCustomProperties(props);
    }

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        if (changedProps.ContainsKey(READY_KEY))
        {
            UpdatePlayerStatus();

            if (AllPlayersReady())
            {
                Debug.Log(" All players are ready!");
            }
        }
    }

    void UpdatePlayerStatus()
    {
        Player[] players = PhotonNetwork.PlayerList;

        for (int i = 0; i < players.Length; i++)
        {
            bool isReady = players[i].CustomProperties.ContainsKey(READY_KEY) &&
                           (bool)players[i].CustomProperties[READY_KEY];

            string playerName = players[i].NickName;
            string statusText = isReady ? "Ready " : "Not Ready ";

            if (i == 0) player1Status.text = playerName + ": " + statusText;
            if (i == 1) player2Status.text = playerName + ": " + statusText;
        }
    }

    bool AllPlayersReady()
    {
        foreach (Player player in PhotonNetwork.PlayerList)
        {
            if (!player.CustomProperties.ContainsKey(READY_KEY) ||
                !(bool)player.CustomProperties[READY_KEY])
                return false;
        }
        return true;
    }
}
