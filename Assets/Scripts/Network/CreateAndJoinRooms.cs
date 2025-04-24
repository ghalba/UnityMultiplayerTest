using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    public TMP_InputField CreateInput;
    public TMP_InputField JoinInput;
    public TMP_InputField NicknameInput;

    public void CreateRoom()
    {
        SetNickname();
        PhotonNetwork.CreateRoom(CreateInput.text);
    }

    public void JoinRoom()
    {
        SetNickname();
        PhotonNetwork.JoinRoom(JoinInput.text);
    }
    public override void OnJoinedRoom()
    {
        Debug.Log("Joined room! Players in room: " + PhotonNetwork.CurrentRoom.PlayerCount);

        
            PhotonNetwork.LoadLevel("Game");
        
    }
    private void SetNickname()
    {
        if (!string.IsNullOrEmpty(NicknameInput.text))
        {
            PhotonNetwork.NickName = NicknameInput.text;
        }
        else
        {
            PhotonNetwork.NickName = "Player" + Random.Range(1000, 9999); // fallback
        }

        Debug.Log("Nickname set to: " + PhotonNetwork.NickName);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
