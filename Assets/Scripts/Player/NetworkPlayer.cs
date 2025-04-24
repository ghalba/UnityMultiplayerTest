using UnityEngine;
using Photon.Pun;
using TMPro;

public class NetworkPlayer : MonoBehaviourPun
{
    public TextMeshProUGUI nameText;

    void Start()
    {
        if (nameText == null)
        {
            Debug.LogError("nameText is not assigned!", this);
            return;
        }

        if (photonView.IsMine)
        {
            Camera cam = Camera.main;
            if (cam != null)
            {
                FollowCamera followScript = cam.GetComponent<FollowCamera>();
                if (followScript != null)
                {
                    followScript.target = this.transform;
                }
            }

            Debug.Log("My nickname is: " + PhotonNetwork.NickName);

            nameText.text = PhotonNetwork.NickName;
            nameText.color = Color.green;
        }
        else
        {
            Debug.Log("Other player nickname: " + photonView.Owner.NickName);

            nameText.text = photonView.Owner.NickName;
            nameText.color = Color.red;
        }
    }


    void Update()
    {
        // Optional: Always face camera
        nameText.transform.LookAt(Camera.main.transform);
        nameText.transform.Rotate(0, 180, 0);
    }
}
