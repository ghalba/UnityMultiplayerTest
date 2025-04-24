using Photon.Pun;
using UnityEngine;
using TMPro;

public class ChatSystem : MonoBehaviourPun
{
    public TMP_InputField messageInput;
    public TMP_Text chatDisplay;

    void Update()
    {
        // Enter to send
        if (PhotonNetwork.InRoom && Input.GetKeyDown(KeyCode.Return))
        {
            if (!string.IsNullOrEmpty(messageInput.text))
            {
                photonView.RPC("SendMessageToAll", RpcTarget.All, PhotonNetwork.NickName, messageInput.text);
                messageInput.text = "";
                messageInput.ActivateInputField(); // refocus
            }
        }
    }

    [PunRPC]
    void SendMessageToAll(string sender, string message)
    {
        chatDisplay.text += $"\n<color=yellow>{sender}:</color> {message}";
    }
}
