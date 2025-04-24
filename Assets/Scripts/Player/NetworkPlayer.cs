using UnityEngine;
using Photon.Pun;
using TMPro;
using System.Collections;

public class NetworkPlayer : MonoBehaviourPun
{
    public TextMeshProUGUI nameText;
    public GameObject[] emojiPrefabs; // array of different emoji prefabs
    private GameObject currentEmoji;
    public Animator animator;

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
        animator = GetComponent<Animator>();


    }


    void Update()
    {
        //  Always face camera
        nameText.transform.LookAt(Camera.main.transform);
        nameText.transform.Rotate(0, 180, 0);
        
        // Show emoji when pressing 1
        if (photonView.IsMine)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
                photonView.RPC("ShowEmoji", RpcTarget.All, 0);
            if (Input.GetKeyDown(KeyCode.Alpha2))
                photonView.RPC("ShowEmoji", RpcTarget.All, 1);
            if (Input.GetKeyDown(KeyCode.Alpha3))
                photonView.RPC("ShowEmoji", RpcTarget.All, 2);
        }
    }

    [PunRPC]
    void ShowEmoji(int index)
    {
        if (animator == null)
        {
            Debug.LogError("Animator not found on player!", this);
        }
        animator.SetTrigger("Emoji");

        if (index < 0 || index >= emojiPrefabs.Length)
            return;

        if (currentEmoji != null)
            Destroy(currentEmoji);

        currentEmoji = Instantiate(emojiPrefabs[index], transform);
        currentEmoji.transform.localPosition = new Vector3(0, 2f, 0);

        StartCoroutine(HideEmojiAfterDelay());

        if (photonView.IsMine)
            ScoreManager.Instance.AddScore(1);
    }


    IEnumerator HideEmojiAfterDelay()
    {
        yield return new WaitForSeconds(2f);
        if (currentEmoji != null)
            Destroy(currentEmoji);
    }
}
