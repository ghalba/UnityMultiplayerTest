using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();

    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Connected to lobby");
        SceneManager.LoadScene("Lobby");
    }
}
