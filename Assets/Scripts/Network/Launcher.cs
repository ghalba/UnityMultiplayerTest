using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class Launcher : MonoBehaviourPunCallbacks
{
    public string gameVersion = "1.0";
    public byte maxPlayers = 2;

    private void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true; // Sync scene for all players
        
            if (string.IsNullOrEmpty(PhotonNetwork.NickName))
            {
                PhotonNetwork.NickName = "Player_" + Random.Range(1000, 9999);
            }

        
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.GameVersion = gameVersion;
        Debug.Log("Connecting to Photon...");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master, joining room...");
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("No room found. Creating a new one.");
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = maxPlayers });
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined room! Players in room: " + PhotonNetwork.CurrentRoom.PlayerCount);

        if (PhotonNetwork.CurrentRoom.PlayerCount == maxPlayers)
        {
            PhotonNetwork.LoadLevel("Game");
        }
    }

}
